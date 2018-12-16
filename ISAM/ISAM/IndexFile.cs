using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ISAM
{
	class IndexFile
	{
		private String msFilePath;
		private int miRowCount;
		private int miBufferRowSize;
		private int miPreambuleSize = sizeof(int);
		public int DiscAccesses { get; set; }
		private int miPage = -1;

		private struct IndexRow {
			public int key;
			public IndexRow (int akey)
			{
				key = akey;
			}
			public static int rowSize = sizeof(int);
		};

		private IndexRow[] mBuffer;

		public IndexFile(String asFilePath, int aiBufferSize)
		{
			msFilePath = asFilePath;
			miBufferRowSize = aiBufferSize;
			mBuffer = new IndexRow[miBufferRowSize];
			for(int i = 0; i < miBufferRowSize; i++)
			{
				mBuffer[i] = new IndexRow(0);
			}

			if (!File.Exists(msFilePath))           //If no file, create one and write preambule
			{
				using (FileStream lFileStream = File.Open(msFilePath, FileMode.Create, FileAccess.Write))
				{
					using (BinaryWriter lBinWriter = new BinaryWriter(lFileStream))
					{
						lBinWriter.Write((int)0);       //Row count
						DiscAccesses++;
					}
				}
			}
			else ReadRowCount();

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

		private void ReadRowCount()
		{
			using (FileStream lFileStream = File.Open(msFilePath, FileMode.Open, FileAccess.Read))
			{
				using (BinaryReader lBinReader = new BinaryReader(lFileStream))
				{
					miRowCount = lBinReader.ReadInt32();
					DiscAccesses++;
				}
			}
		}

		private void ReadBuffer(BinaryReader aBinReader)
		{
			byte[] lbBuffer = aBinReader.ReadBytes(miBufferRowSize * IndexRow.rowSize);
			DiscAccesses++;
			mBuffer = new IndexRow[lbBuffer.Length / IndexRow.rowSize];
			for(int i = 0; i < mBuffer.Length; i++)
			{
				mBuffer[i] = new IndexRow(0);
			}
			for(int i = 0; i < mBuffer.Length; i++)
			{
				mBuffer[i].key = BitConverter.ToInt32(lbBuffer, i * sizeof(int));
			}
		}

		public int GetPage(int aiKey)
		{
			int liPage = 1;
			int liRowsLeft = miRowCount;
			bool lbDone = false;
			using(FileStream lFileStream = File.Open(msFilePath, FileMode.Open, FileAccess.Read))
			{
				using(BinaryReader lBinReader = new BinaryReader(lFileStream))
				{
					lFileStream.Position += miPreambuleSize;         //Skip preambule
					ReadBuffer(lBinReader);
					while(mBuffer.Length > 0 && !lbDone)
					{
						for(int i=0; i<mBuffer.Length; i++)
						{
							if(mBuffer[i].key <= aiKey)
							{
								liPage++;
							}
							else
							{
								lbDone = true;
								break;
							}
						}
						if (!lbDone)
						{
							ReadBuffer(lBinReader);
						}
					}
				}
			}

			return liPage;
		}

		public int[] GetBuffer(int aiPage)
		{
			using(FileStream lFileStream = File.Open(msFilePath, FileMode.Open, FileAccess.Read))
			{
				using(BinaryReader lBinReader = new BinaryReader(lFileStream))
				{
					lFileStream.Position += (aiPage - 1) * IndexRow.rowSize * miBufferRowSize;
					lFileStream.Position += miPreambuleSize;
					ReadBuffer(lBinReader);
				}
			}
			int[] liIndexes = new int[mBuffer.Length];
			for(int i=0; i<mBuffer.Length; i++)
			{
				liIndexes[i] = mBuffer[i].key;
			}
			return liIndexes;
		}

		public void AddRow(int aiKey)
		{
			using (FileStream lFileStream = File.Open(msFilePath, FileMode.Open, FileAccess.Write))
			{
				using (BinaryWriter lBinWriter = new BinaryWriter(lFileStream))
				{
					miRowCount++;
					lBinWriter.Write(miRowCount);
					lFileStream.Position = miPreambuleSize + (miRowCount - 1) * IndexRow.rowSize;
					lBinWriter.Write(aiKey);
					DiscAccesses += 2;
				}
			}
		}
	}
}
