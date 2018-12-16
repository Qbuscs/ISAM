using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ISAM
{
	class Row
	{
		public int key;
		public double a;
		public double b;
		public double c;
		public int overflow;
		public static int rowSize = sizeof(int) * 2 + sizeof(double) * 3;

		public Row(int _key, double _a, double _b, double _c, int _overflow)
		{
			key = _key;
			a = _a;
			b = _b;
			c = _c;
			overflow = _overflow;
		}
		public Row(Row _row)
		{
			key = _row.key;
			a = _row.a;
			b = _row.b;
			c = _row.c;
			overflow = _row.overflow;
		}

		public void WriteBinary(BinaryWriter aBinWriter)
		{
			byte[] lbTmp = BitConverter.GetBytes(key);
			byte[] lbRow = lbTmp.Concat(BitConverter.GetBytes(a)).ToArray();
			lbRow = lbRow.Concat(BitConverter.GetBytes(b)).ToArray();
			lbRow = lbRow.Concat(BitConverter.GetBytes(c)).ToArray();
			lbRow = lbRow.Concat(BitConverter.GetBytes(overflow)).ToArray();

			aBinWriter.Write(lbRow);
		}

		static public Row ReadBinary(BinaryReader aBinReader)
		{
			Row lRow = new Row(0, 0, 0, 0, 0);
			byte[] lbRow = aBinReader.ReadBytes(rowSize);
			lRow.key = BitConverter.ToInt32(lbRow, 0);
			lRow.a = BitConverter.ToDouble(lbRow, sizeof(int));
			lRow.b = BitConverter.ToDouble(lbRow, sizeof(int) + sizeof(double));
			lRow.c = BitConverter.ToDouble(lbRow, sizeof(int) + sizeof(double) * 2);
			lRow.overflow = BitConverter.ToInt32(lbRow, sizeof(int) + sizeof(double) * 3);
			return lRow;
		}
	}
}
