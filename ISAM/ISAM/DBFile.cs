using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ISAM
{
	class DBFile
	{

		private int miRowCount;
		private int miPreambuleSize = sizeof(int);
		private int miLoadedPage;
		private String msFilePath;
		private int miBufferRowSize;
		private IndexFile mIndexFile;
		private OverflowFile mOverflowFile;
		private double mdAlpha;
		private Row[] mBuffer;
		private int miDiscAccesses { get; set; }

		public static int NORECORD = 0;
		public static int NULLPOINTER = -1;
		public static int GUARDRECORD = -2;
		public static int DELETED = -3;
		public static int LAST_DELETED = -4;

		public DBFile(String asFilePath, int aiBufferRowSize, double adAlpha)
		{
			msFilePath = asFilePath;
			miBufferRowSize = aiBufferRowSize;
			miLoadedPage = -1;
			mdAlpha = adAlpha;
			miDiscAccesses = 0;
			mIndexFile = new IndexFile(asFilePath + ".idx", miBufferRowSize);
			mOverflowFile = new OverflowFile(asFilePath + ".ovfl", miBufferRowSize);
			mBuffer = new Row[miBufferRowSize];
			for (int i = 0; i < miBufferRowSize; i++)
			{
				mBuffer[i] = new Row(NORECORD, 0, 0, 0, NULLPOINTER);
			}
			if (!File.Exists(asFilePath))
			{
				using(FileStream lFileStream = File.Create(asFilePath))
				{
					using(BinaryWriter lBinWriter = new BinaryWriter(lFileStream))
					{
						miRowCount = 0;
						lBinWriter.Write(miRowCount);
						miDiscAccesses++;
					}
				}
				InsertRow(new Row(GUARDRECORD, 0, 0, 0, NULLPOINTER), 1);
			}
			else
			{
				using (FileStream lFileStream = File.Open(asFilePath, FileMode.Open, FileAccess.Read))
				{
					using (BinaryReader lBinReader = new BinaryReader(lFileStream))
					{
						miRowCount = lBinReader.ReadInt32();
						miDiscAccesses++;
					}
				}
			}			
		}

		public int GetAccesses()
		{
			return miDiscAccesses + mOverflowFile.DiscAccesses + mIndexFile.DiscAccesses;
		}

		public void ResetAccesses()
		{
			miDiscAccesses = mOverflowFile.DiscAccesses = mIndexFile.DiscAccesses = 0;
		}

		public void SetAccesses(int aiAccesses)
		{
			miDiscAccesses = aiAccesses;
			mOverflowFile.DiscAccesses = mIndexFile.DiscAccesses = 0;
		}

		public int GetRowCount()
		{
			return miRowCount - 1;		//minus guard
		}

		public int GetIndexCount()
		{
			return mIndexFile.GetRowCount();
		}

		public int GetOverflowCount()
		{
			return mOverflowFile.GetRowCount();
		}

		public void SetFilePath(string asPath)
		{
			msFilePath = asPath;
			mIndexFile.SetFilePath(asPath + ".idx");
			mOverflowFile.SetFilePath(asPath + ".ovfl");
		}

		public string[] GetFilePath()
		{
			string[] lsPaths = new string[3];
			lsPaths[0] = msFilePath;
			lsPaths[1] = mIndexFile.GetFilePath();
			lsPaths[2] = mOverflowFile.GetFilePath();
			return lsPaths;
		}

		public void CreateIndex(int aiKey)
		{
			mIndexFile.AddRow(aiKey);
		}

		private void SaveBuffer(BinaryWriter aBinWriter)
		{
			byte[] lbBuffer = new byte[miBufferRowSize * Row.rowSize];
			byte[] lbTmp;
			int liStep1 = sizeof(int);
			int liStep2 = sizeof(int) + sizeof(double);
			int liStep3 = sizeof(int) + sizeof(double) * 2;
			int liStep4 = sizeof(int) + sizeof(double) * 3;
			for (int i = 0; i < miBufferRowSize; i++)
			{
				lbTmp = BitConverter.GetBytes(mBuffer[i].key);
				for(int j = 0; j < lbTmp.Length; j++)
				{
					lbBuffer[Row.rowSize * i + 0 + j] = lbTmp[j];
				}

				lbTmp = BitConverter.GetBytes(mBuffer[i].a);
				for(int j = 0; j < lbTmp.Length; j++)
				{
					lbBuffer[Row.rowSize * i + liStep1 + j] = lbTmp[j];
				}

				lbTmp = BitConverter.GetBytes(mBuffer[i].b);
				for (int j = 0; j < lbTmp.Length; j++)
				{
					lbBuffer[Row.rowSize * i + liStep2 + j] = lbTmp[j];
				}

				lbTmp = BitConverter.GetBytes(mBuffer[i].c);
				for (int j = 0; j < lbTmp.Length; j++)
				{
					lbBuffer[Row.rowSize * i + liStep3 + j] = lbTmp[j];
				}

				lbTmp = BitConverter.GetBytes(mBuffer[i].overflow);
				for (int j = 0; j < lbTmp.Length; j++)
				{
					lbBuffer[Row.rowSize * i + liStep4 + j] = lbTmp[j];
				}
			}
			aBinWriter.Write(lbBuffer);
			miDiscAccesses++;
		}


		private void ReadBuffer(BinaryReader aBinReader)
		{
			byte[] lbBuffer = aBinReader.ReadBytes(miBufferRowSize * Row.rowSize);
			miDiscAccesses++;
			byte[] lbTmp = new byte[Row.rowSize];
			int liStep1 = sizeof(int);
			int liStep2 = sizeof(int) + sizeof(double);
			int liStep3 = sizeof(int) + sizeof(double) * 2;
			int liStep4 = sizeof(int) + sizeof(double) * 3;
			int liStep5 = sizeof(int) * 2 + sizeof(double) * 3;
			mBuffer = new Row[miBufferRowSize];
			for(int i = 0; i < miBufferRowSize; i++)
			{
				mBuffer[i] = new Row(NORECORD, 0, 0, 0, NULLPOINTER);
			}
			for (int i = 0; i < lbBuffer.Length; i += Row.rowSize)			//load buffer
			{
				for(int j = 0; j < liStep1; j++)				//key
				{
					lbTmp[j] = lbBuffer[i + j];
				}
				mBuffer[i / Row.rowSize].key = BitConverter.ToInt32(lbTmp, 0);

				for (int j = liStep1; j < liStep2; j++)			//a
				{
					lbTmp[j] = lbBuffer[i + j];
				}
				mBuffer[i / Row.rowSize].a = BitConverter.ToDouble(lbTmp, 4);

				for (int j = liStep2; j < liStep3; j++)			//b
				{
					lbTmp[j] = lbBuffer[i + j];
				}
				mBuffer[i / Row.rowSize].b = BitConverter.ToDouble(lbTmp, 12);

				for (int j = liStep3; j < liStep4; j++)			//c
				{
					lbTmp[j] = lbBuffer[i + j];
				}
				mBuffer[i / Row.rowSize].c = BitConverter.ToDouble(lbTmp, 20);

				for (int j = liStep4; j < liStep5; j++)			//overflow
				{
					lbTmp[j] = lbBuffer[i + j];
				}
				mBuffer[i / Row.rowSize].overflow = BitConverter.ToInt32(lbTmp, 28);
			}
		}

		public int GetPage(int aiKey)           //USUNAC!
		{
			return mIndexFile.GetPage(aiKey);
		}

		private DBFile InsertRow(Row aRow, int aiPage)
		{
			bool lbInsertedToOverflow = false;
			GetBuffer(aiPage);
			for (int i = 0; i < miBufferRowSize; i++)                                   //find place to insert record
			{
				if (mBuffer[i].key == NORECORD)
				{
					mBuffer[i] = aRow;
					break;
				}
				if(mBuffer[i].key == aRow.key)
				{
					return null;			//row witch such key already exists
				}
				if (mBuffer[i].key < aRow.key)
				{
					if (i == miBufferRowSize - 1)   //last row in page
					{
						//insert to overflow
						lbInsertedToOverflow = true;
						int liNewOverflow = mOverflowFile.AddRowAtPosition(aRow, mBuffer[i].overflow);
						if(mBuffer[i].overflow == NULLPOINTER)
							mBuffer[i].overflow = liNewOverflow;
						break;
					}
					if (mBuffer[i + 1].key == NORECORD)
					{
						mBuffer[i + 1] = aRow;
						break;
					}
					if (mBuffer[i + 1].key > aRow.key)
					{
						//insert to overflow
						lbInsertedToOverflow = true;
						int liNewOverflow = mOverflowFile.AddRowAtPosition(aRow, mBuffer[i].overflow);
						if (mBuffer[i].overflow == NULLPOINTER)
							mBuffer[i].overflow = liNewOverflow;
						break;
					}
				}
			}
			using (FileStream lFileStream = File.Open(msFilePath, FileMode.Open, FileAccess.ReadWrite))
			{
				using (BinaryWriter lBinWriter = new BinaryWriter(lFileStream))
				{
					lFileStream.Position = (aiPage-1) * miBufferRowSize * Row.rowSize;
					lFileStream.Position += miPreambuleSize;
					SaveBuffer(lBinWriter);
					if (!lbInsertedToOverflow)
					{
						miRowCount++;
						lFileStream.Position = 0;
						lBinWriter.Write(miRowCount);
						miDiscAccesses++;
					}
				}
			}
			if (mOverflowFile.GetRowCount() * 10 > miRowCount * 40)		//30%
				return Reorganise();
			return null;
		}

		public DBFile AddRow(int aiKey, double _a, double _b, double _c)
		{
			Row lRow = new Row(aiKey, _a, _b, _c, NULLPOINTER);
			int liPageToInsert = mIndexFile.GetPage(aiKey);
			return InsertRow(lRow, liPageToInsert);
		}

		public Row[] GetBuffer(int aiPage)
		{
			if (aiPage == miLoadedPage)
				return mBuffer;
			int liOffset = (aiPage - 1) * miBufferRowSize * Row.rowSize;
			liOffset += miPreambuleSize;
			using(FileStream lFileStream = File.Open(msFilePath, FileMode.Open, FileAccess.Read))
			{	
				using(BinaryReader lBinReader = new BinaryReader(lFileStream))
				{
					lFileStream.Position = liOffset;
					ReadBuffer(lBinReader);
				}
			}
			miLoadedPage = aiPage;
			return mBuffer;
		}

		public Row[] GetOverflowBuffer(int aiPage)
		{
			return mOverflowFile.GetPage(aiPage);
		}

		public int[] GetIndexBuffer(int aiPage)
		{
			return mIndexFile.GetBuffer(aiPage);
		}

		public Row GetRecord(int aiKey)
		{
			return GetRecordOrDelete(aiKey, false);
		}

		public void DeleteRecord(int aiKey)
		{
			GetRecordOrDelete(aiKey, true);
		}

		private int NextNondeletedKeyInBuffer(int aiCurrentKeyIndex)
		{
			if (aiCurrentKeyIndex == mBuffer.Length - 1) //this is a last index in buffer
				return DELETED;
			for(int i=aiCurrentKeyIndex + 1; i<mBuffer.Length; i++)
			{
				if (mBuffer[i].key != DELETED)
					return mBuffer[i].key;
			}
			return DELETED;
		}

		private Row GetRecordOrDelete(int aiKey, bool abWithDelete)
		{
			int liPage = GetPage(aiKey);
			GetBuffer(liPage);
			if(mBuffer[0].key == NORECORD || mBuffer[0].key > aiKey || aiKey == NORECORD)
				return new Row(NORECORD, 0, 0, 0, NULLPOINTER);
			for (int i=0; i<mBuffer.Length; i++)
			{
				if(mBuffer[i].key == aiKey)
				{
					if (abWithDelete)
					{
						mBuffer[i].key = DELETED;
						using(FileStream lFileStream = File.Open(msFilePath, FileMode.Open, FileAccess.Write))
						{
							using(BinaryWriter lBinWriter = new BinaryWriter(lFileStream))
							{
								lFileStream.Position = miPreambuleSize + (liPage - 1) * Row.rowSize * miBufferRowSize;
								SaveBuffer(lBinWriter);
							}
						}
					}
					return new Row(mBuffer[i]);
				}
				if(i == mBuffer.Length - 1)
				{
					if (mBuffer[i].overflow == NULLPOINTER)
						return new Row(NORECORD, 0, 0, 0, NULLPOINTER);
					return mOverflowFile.GetRecord(aiKey, mBuffer[i].overflow, abWithDelete);
				}
				if((mBuffer[i].key == DELETED || mBuffer[i+1].key == DELETED) && mBuffer[i].overflow != NULLPOINTER)
				{
					int liNextKey = NextNondeletedKeyInBuffer(i);
					if(liNextKey > aiKey || liNextKey == DELETED)
					{
						Row lRow = mOverflowFile.GetRecord(aiKey, mBuffer[i].overflow, abWithDelete);
						if (lRow.key != NORECORD)
							return lRow;
					}

				}
				if(mBuffer[i+1].key > aiKey)
				{
					if(mBuffer[i].overflow != NULLPOINTER)
						return mOverflowFile.GetRecord(aiKey, mBuffer[i].overflow, abWithDelete);
					else
						return new Row(NORECORD, 0, 0, 0, NULLPOINTER);
				}
			}
			return new Row(NORECORD, 0, 0, 0, NULLPOINTER);
		}

		public Row GetFirstRecord()
		{
			GetBuffer(1);
			if (mBuffer[0].overflow == NULLPOINTER)
				return mBuffer[1];
			else
				return mOverflowFile.GetRecord(mBuffer[0].overflow);
		}

		public Row FetchNext(Row aRow /*predecessor*/)
		{
			Row lRowNext;
			if (aRow.key == NORECORD)		//no such previous record
				return new Row(NORECORD, 0, 0, 0, NULLPOINTER);
			if (aRow.overflow != NULLPOINTER)       //record exists and points somewhere
			{   
				lRowNext = mOverflowFile.GetRecord(aRow.overflow);
				if (lRowNext.key != DELETED)		//its not deleted
					return lRowNext;
				if (lRowNext.overflow != NULLPOINTER)       //its not last in chain
				{   
					lRowNext = FetchNext(lRowNext);
					if (lRowNext.key != LAST_DELETED)
						return lRowNext;
				}
			}
			if (aRow.key == DELETED)
				return new Row(LAST_DELETED, 0, 0, 0, NULLPOINTER);
			//record exists but points nowhere
			GetBuffer(GetPage(aRow.key));
			for(int i=0; i<mBuffer.Length; i++)
			{
				if(mBuffer[i].key == DELETED && mBuffer[i].overflow != NULLPOINTER && 
					(NextNondeletedKeyInBuffer(i) > aRow.key || NextNondeletedKeyInBuffer(i) == DELETED))
				{
					lRowNext = mOverflowFile.GetRecord(mBuffer[i].overflow);
					if (lRowNext.key > aRow.key)
						return lRowNext;
					if (lRowNext.key == DELETED && lRowNext.overflow != NULLPOINTER)
					{
						Row lRow = FetchNext(lRowNext);
						if (lRow.key > aRow.key)
							return lRow;
					}
				}
				if (mBuffer[i].key > aRow.key)      //larger record is on the same page
					return new Row(mBuffer[i]);
				if (mBuffer[i].key == NORECORD)     //we reached an empty record, so this is the larges record on this page
					break;
			}
			//This is the largest record in its page, so we return first record of next page
			//(if it's empty, then we get a biggest record of all)
			GetBuffer(GetPage(aRow.key) + 1);
			return new Row(mBuffer[0]);
		}

		public Row FetchNext(int aiKey /*key of predecessor*/)
		{
			Row lRow = GetRecord(aiKey);
			return FetchNext(lRow);
		}

		public DBFile Reorganise()
		{
			DBFile lNewDBFile = new DBFile(msFilePath + ".re", miBufferRowSize, mdAlpha);
			lNewDBFile.SetAccesses(GetAccesses());
			int liRecordCounter = 1;
			int liPage = 1;
			Row lRow = GetFirstRecord();
			Row[] lRowBuffer = new Row[miBufferRowSize];
			for(int i=0; i<miBufferRowSize; i++)
			{
				lRowBuffer[i] = new Row(NORECORD, 0, 0, 0, NULLPOINTER);
			}
			lRowBuffer[0].key = GUARDRECORD;
			while(lRow.key != NORECORD)
			{
				lRowBuffer[liRecordCounter] = new Row(lRow);
				lRowBuffer[liRecordCounter].overflow = NULLPOINTER;
				//lNewDBFile.AddRow(lRow.key, lRow.a, lRow.b, lRow.c);
				lRow = FetchNext(lRow.key);
				liRecordCounter++;
				if((double)(liRecordCounter) / (double)miBufferRowSize >= mdAlpha)		//do we need to make a new index?
				{
					if(lRow.key != NORECORD)
						lNewDBFile.CreateIndex(lRow.key);
					lNewDBFile.SaveBufferAtPage(lRowBuffer, liPage);
					liPage++;
					liRecordCounter = 0;
					for (int i = 0; i < miBufferRowSize; i++)
					{
						lRowBuffer[i] = new Row(NORECORD, 0, 0, 0, NULLPOINTER);
					}
				}
			}
			lNewDBFile.SaveBufferAtPage(lRowBuffer, liPage);
			return lNewDBFile;
		}

		public void SaveBufferAtPage(Row[] aRowBuffer, int aiPage)
		{
			mBuffer = aRowBuffer;
			using(FileStream lFileStream = File.Open(msFilePath, FileMode.Open, FileAccess.Write))
			{
				using(BinaryWriter lBinWriter = new BinaryWriter(lFileStream))
				{
					lFileStream.Position = (aiPage - 1) * miBufferRowSize * Row.rowSize + miPreambuleSize;
					SaveBuffer(lBinWriter);
				}
			}
			miLoadedPage = aiPage;
		}

		public DBFile Update(int aiKey, int aiNewKey, double _a, double _b, double _c, out bool abError)
		{
			abError = false;
			if(aiNewKey == aiKey)		//We don't change key
			{
				DeleteRecord(aiKey);
				return AddRow(aiNewKey, _a, _b, _c);
			}
			else   //We change also the key
			{
				if (GetRecord(aiNewKey).key != NORECORD)        //record with such key already exists
				{
					abError = true;
					return null;
				}
				DeleteRecord(aiKey);
				return AddRow(aiNewKey, _a, _b, _c);
			}
		}
	}
}
