using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ISAM
{
	class OverflowFile
	{

		private int miRowCount;
		private String msFilePath;
		private int miBufferRowSize;
		private Row[] mBuffer;
		private int miPreambuleSize = sizeof(int);
		public int DiscAccesses { get; set; }

		public OverflowFile(String asFilePath, int aiBufferRowSize)
		{
			msFilePath = asFilePath;
			miBufferRowSize = aiBufferRowSize;
			if (!File.Exists(msFilePath))           //If no file, create one
			{
				using (FileStream lFileStream = File.Open(msFilePath, FileMode.Create, FileAccess.Write))
				{
					using(BinaryWriter lBinWriter = new BinaryWriter(lFileStream))
					{
						lBinWriter.Write((int)0);           //preambule
						miRowCount = 0;
						DiscAccesses++;
						
					}
				}
			}
			else
			{
				using (FileStream lFileStream = File.Open(msFilePath, FileMode.Open, FileAccess.Read))
				{
					using(BinaryReader lBinReader = new BinaryReader(lFileStream))
					{
						miRowCount = lBinReader.ReadInt32();        //Read preambule
						DiscAccesses++;
					}
				}
			}
		}

		public int GetRowCount()
		{
			return miRowCount;
		}

		public void SetFilePath(string asPath)
		{
			msFilePath = asPath;
		}

		public string GetFilePath()
		{
			return msFilePath;
		}

		public Row[] GetPage(int aiPage)
		{
			byte[] lbPage;
			using(FileStream lFileStream = File.Open(msFilePath, FileMode.Open, FileAccess.Read))
			{
				lFileStream.Position = (aiPage - 1) * Row.rowSize * miBufferRowSize;
				lFileStream.Position += miPreambuleSize;
				using (BinaryReader lBinReader = new BinaryReader(lFileStream))
				{
					lbPage = lBinReader.ReadBytes(Row.rowSize * miBufferRowSize);
					DiscAccesses++;
				}
			}
			Row[] lRows = new Row[lbPage.Length / Row.rowSize];
			for(int i=0; i<lbPage.Length; i+=Row.rowSize)
			{
				lRows[i / Row.rowSize] = new Row(DBFile.NORECORD, 0, 0, 0, DBFile.NULLPOINTER);
				lRows[i / Row.rowSize].key = BitConverter.ToInt32(lbPage, i);
				lRows[i / Row.rowSize].a = BitConverter.ToDouble(lbPage, i + sizeof(int));
				lRows[i / Row.rowSize].b = BitConverter.ToDouble(lbPage, i + sizeof(int) + sizeof(double));
				lRows[i / Row.rowSize].c = BitConverter.ToDouble(lbPage, i + sizeof(int) + sizeof(double) * 2);
				lRows[i / Row.rowSize].overflow = BitConverter.ToInt32(lbPage, i + sizeof(int) + sizeof(double) * 3);
			}
			return lRows;
		}

		public int AddRowAtPosition(Row aRow, int aiPosition)
		{
			int liLocalKey;
			int liLocalOffset = 0;
			int liLocalOffsetToUpdate = DBFile.NULLPOINTER;
			bool lbDone = false;
			bool lbGoFindYourselfAPlace = (aiPosition == DBFile.NULLPOINTER) ? true : false;
			Row lTmpRow;
			double ldTmpA, ldTmpB, ldTmpC;
			using(FileStream lFileStream = File.Open(msFilePath, FileMode.Open, FileAccess.ReadWrite))
			{
				using (BinaryReader lBinReader = new BinaryReader(lFileStream))     //let's look for free spot
				{
					if (aiPosition != DBFile.NULLPOINTER)
					{
						lFileStream.Position = aiPosition;
					}
					else
					{
						lFileStream.Position = miPreambuleSize;		//skip preambule
					}
					try
					{
						while (!lbDone)
						{
							liLocalKey = lBinReader.ReadInt32();
							DiscAccesses++;
							if (liLocalKey == aRow.key)
								return 0;
							if (liLocalKey == DBFile.NORECORD)
							{
								lFileStream.Position -= sizeof(int);        //we can write here
								lbDone = true;
							}
							else           //Someone is standing there
							{
								if (lbGoFindYourselfAPlace)
								{
									lFileStream.Position += sizeof(int) + sizeof(double) * 3;       //We skip the dude (got his key thou)
								}
								else       //He's my dude
								{
									ldTmpA = lBinReader.ReadDouble();       //A			      //We exchange buisness cards
									ldTmpB = lBinReader.ReadDouble();       //B
									ldTmpC = lBinReader.ReadDouble();       //C
									liLocalOffset = lBinReader.ReadInt32();     //overflow
									if (liLocalOffset == DBFile.NULLPOINTER)		//Are you my last dude?
									{
										liLocalOffsetToUpdate = (int)lFileStream.Position - sizeof(int);		//You will remember me ;)
										lbGoFindYourselfAPlace = true;              //I'm to find myself a place on my own
									}
									
									if (liLocalKey > aRow.key)              //should we swap?
									{
										lTmpRow = new Row(aRow);
										aRow.key = liLocalKey;			//I put on your clothes
										aRow.a = ldTmpA;
										aRow.b = ldTmpB;
										aRow.c = ldTmpC;
										using (BinaryWriter lBinWriter = new BinaryWriter(lFileStream, Encoding.Default, true))
										{
											lFileStream.Position -= sizeof(int) * 2 + sizeof(double) * 3;
											lBinWriter.Write(lTmpRow.key);              //You put on my clothes		//BLOKOWO?
											lBinWriter.Write(lTmpRow.a);
											lBinWriter.Write(lTmpRow.b);
											lBinWriter.Write(lTmpRow.c);
											DiscAccesses++;
											lFileStream.Position += sizeof(int);
										}
									}
									if(!lbGoFindYourselfAPlace)
										lFileStream.Position = liLocalOffset;
								}
							}
						}
					}
					catch (EndOfStreamException ex)
					{
						//free spot at the end of file, now in lFileStream.Position
					}

					using (BinaryWriter lBinWriter = new BinaryWriter(lFileStream))     //FileStream is at right position right now
					{
						liLocalOffset = (int)lFileStream.Position;
						aRow.WriteBinary(lBinWriter);
						DiscAccesses++;
						if (liLocalOffsetToUpdate != DBFile.NULLPOINTER)		//did we jump from other record?
						{
							lFileStream.Position = liLocalOffsetToUpdate;       //lets update previous row pointer
							lBinWriter.Write(liLocalOffset);
						}
						lFileStream.Position = 0;               //increment row count
						miRowCount++;
						lBinWriter.Write(miRowCount);
					}
				}
			}
			return liLocalOffset;
		}

		public Row GetRecord(int aiOffset)
		{
			if (aiOffset > miRowCount * Row.rowSize + miPreambuleSize || aiOffset < miPreambuleSize || (aiOffset - miPreambuleSize) % Row.rowSize != 0)
				return new Row(DBFile.NORECORD, -1, -1, -1, DBFile.NULLPOINTER);
			using(FileStream lFileStream = File.Open(msFilePath, FileMode.Open, FileAccess.Read))
			{
				using(BinaryReader lBinReader = new BinaryReader(lFileStream))
				{
					lFileStream.Position = aiOffset;
					DiscAccesses++;
					return Row.ReadBinary(lBinReader);
				}
			}
		}

		public Row GetRecord(int aiKey, int aiOverflow, bool abWithDelete)
		{
			bool lbDone = false;
			Row lRow = new Row(DBFile.NORECORD, 0, 0, 0, DBFile.NULLPOINTER);
			using(FileStream lFileStream = File.Open(msFilePath, FileMode.Open, FileAccess.ReadWrite))
			{
				using (BinaryReader lBinReader = new BinaryReader(lFileStream))
				{
					lFileStream.Position = aiOverflow;
					while (!lbDone)
					{
						//liKey = lBinReader.ReadInt32();
						lRow = Row.ReadBinary(lBinReader);
						DiscAccesses++;
						if (lRow.key == aiKey)
						{
							//ldA = lBinReader.ReadDouble();
							//ldB = lBinReader.ReadDouble();
							//ldC = lBinReader.ReadDouble();
							//liOffset = lBinReader.ReadInt32();
							lbDone = true;
							if (abWithDelete)
							{
								using(BinaryWriter lBinWriter = new BinaryWriter(lFileStream))
								{
									lFileStream.Position -= Row.rowSize;
									lBinWriter.Write((int)DBFile.DELETED);
									DiscAccesses++;
								}
							}
						}
						else
						{
							if (lRow.overflow == DBFile.NULLPOINTER)
								lbDone = true;
							else
								lFileStream.Position = lRow.overflow;
						}
					}
				}
			}
			if (lRow.key != aiKey)
				lRow.key = DBFile.NORECORD;
			return lRow;
		}

	}
}
