using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace ISAM
{
	public partial class Form1 : Form
	{
		private DBFile mDBFile;
		private double mdAlpha = 0.6;
		private int miBufferRowSize = 100;
		private int miFilePage = 1;
		private int miIndexPage = 1;
		private int miOverflowPage = 1;
		Random mRnd;

		public Form1()
		{
			InitializeComponent();
			textBoxRandom.Text = "1";
			mRnd = new Random(); 
		}

		private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == 8);
		}

		private void MakeFile()
		{
			String lsFilePath = createDBFile("Data");
			mDBFile = new DBFile(lsFilePath, miBufferRowSize, mdAlpha);
			labelFile.Text = lsFilePath;
			ReloadView();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			MakeFile();
		}

		private void ReloadView(bool abReset = true)
		{
			if(abReset)
				miFilePage = miOverflowPage = miIndexPage = 1;
			labelAccesses.Text = "Accesses: " + mDBFile.GetAccesses().ToString();
			ReloadMainDataGridView();
			ReloadIndexDataGridView();
			ReloadOverflowDataGridView();
			mDBFile.SetAccesses(mDBFile.GetAccesses() - 3);		//we remove accesses used to reload view
		}

		/*Create new DB file with name passed in argument + 'i', where i is inceremented if such file already exists.
		Returns path to created file*/
		private string createDBFile(string asFileName)
		{
			string lStrCurrDir = Directory.GetCurrentDirectory();
			string lStrFileName = asFileName;
			int lIntFileNumber = 1;
			lStrCurrDir = Path.GetFullPath(Path.Combine(lStrCurrDir, @"..\..\"));
			while (File.Exists(lStrCurrDir + lStrFileName + lIntFileNumber.ToString() + ".jwd"))
			{
				lIntFileNumber++;
			}
			string lStrFilePath = lStrCurrDir + lStrFileName + lIntFileNumber.ToString() + ".jwd";
			return lStrFilePath;
		}

		private void ReloadOverflowDataGridView()
		{
			int liRow;
			dataGridViewOverflow.Rows.Clear();
			Row[] lRows = mDBFile.GetOverflowBuffer(miOverflowPage);
			//foreach row
			for (int i = 0; i < lRows.Length; i++)
			{
				if (lRows[i].key != DBFile.GUARDRECORD && lRows[i].key != DBFile.NORECORD)
				{
					dataGridViewOverflow.Rows.Add();
					liRow = dataGridViewOverflow.Rows.Count - 1;
					dataGridViewOverflow.Rows[liRow].Cells[0].Value = lRows[i].key;
					dataGridViewOverflow.Rows[liRow].Cells[1].Value = lRows[i].a;
					dataGridViewOverflow.Rows[liRow].Cells[2].Value = lRows[i].b;
					dataGridViewOverflow.Rows[liRow].Cells[3].Value = lRows[i].c;
					dataGridViewOverflow.Rows[liRow].Cells[4].Value = lRows[i].overflow;
				}
			}
			
			if (miOverflowPage == 1)
				buttonPrevOverflowPage.Enabled = false;           //we can't go before 1st page
			else
				buttonPrevOverflowPage.Enabled = true;
			if (miOverflowPage > mDBFile.GetOverflowCount() / miBufferRowSize)
				buttonNextOverflowPage.Enabled = false;
			else
				buttonNextOverflowPage.Enabled = true;
			labelOverflowPage.Text = "Page: " + miOverflowPage.ToString();
			
		}

		private void ReloadMainDataGridView()
		{
			int liRow;
			dataGridViewMain.Rows.Clear();
			Row[] lRows = mDBFile.GetBuffer(miFilePage);
			//foreach row
			for (int i = 0; i < lRows.Length; i++)
			{
				if (lRows[i].key != DBFile.GUARDRECORD && lRows[i].key != DBFile.NORECORD)
				{
					dataGridViewMain.Rows.Add();
					liRow = dataGridViewMain.Rows.Count - 1;
					dataGridViewMain.Rows[liRow].Cells[0].Value = lRows[i].key;
					dataGridViewMain.Rows[liRow].Cells[1].Value = lRows[i].a;
					dataGridViewMain.Rows[liRow].Cells[2].Value = lRows[i].b;
					dataGridViewMain.Rows[liRow].Cells[3].Value = lRows[i].c;
					dataGridViewMain.Rows[liRow].Cells[4].Value = lRows[i].overflow;
				}
			}
			
			if (miFilePage == 1)
				buttonPrevFilePage.Enabled = false;           //we can't go before 1st page
			else
				buttonPrevFilePage.Enabled = true;
			if (miFilePage == mDBFile.GetIndexCount() + 1)		//end of file reached
				buttonNextFilePage.Enabled = false;
			else
				buttonNextFilePage.Enabled = true;
			labelFilePage.Text = "Page: " + miFilePage.ToString();
			
		}

		private void ReloadIndexDataGridView()
		{
			int liRow;
			dataGridViewIndex.Rows.Clear();
			int[] lRows = mDBFile.GetIndexBuffer(miIndexPage);
			//foreach row
			for (int i = 0; i < lRows.Length; i++)
			{
				if (lRows[i] != DBFile.NORECORD)
				{
					dataGridViewIndex.Rows.Add();
					liRow = dataGridViewIndex.Rows.Count - 1;
					dataGridViewIndex.Rows[liRow].Cells[0].Value = lRows[i];
				}
			}
			
			if (miIndexPage == 1)
				buttonPrevIndexPage.Enabled = false;           //we can't go before 1st page
			else
				buttonPrevIndexPage.Enabled = true;
			if (miIndexPage >= mDBFile.GetIndexCount() / miBufferRowSize)
				buttonNextIndexPage.Enabled = false;
			else
				buttonNextIndexPage.Enabled = true;
			labelIndexPage.Text = "Page: " + miIndexPage.ToString();
			
		}

		private void textBoxKey_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == 8);
		}

		private void textBoxNewKey_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == 8);
		}

		private void textBoxA_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == '.' || e.KeyChar == '-');
		}

		private void textBoxB_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == '.' || e.KeyChar == '-');
		}

		private void textBoxC_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == '.' || e.KeyChar == '-');
		}

		private void textBoxNewA_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == '.' || e.KeyChar == '-');
		}

		private void textBoxNewB_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == '.' || e.KeyChar == '-');
		}

		private void textBoxNewC_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == '.' || e.KeyChar == '-');
		}

		private void textBoxRandom_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == 8);
		}

		private void buttonAddRow_Click(object sender, EventArgs e)
		{
			if (labelFile.Text == "No file selected")
			{
				MessageBox.Show("Select a file first!", "Error",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			DBFile lDBNew;
			int liKey;
			double ldA, ldB, ldC;
			Int32.TryParse(textBoxKey.Text, out liKey);
			Double.TryParse(textBoxA.Text, out ldA);
			Double.TryParse(textBoxB.Text, out ldB);
			Double.TryParse(textBoxC.Text, out ldC);
			textBoxOffset.Text = "";
			lDBNew = mDBFile.AddRow(liKey, ldA, ldB, ldC);
			if(lDBNew != null)
			{
				SwapDBFile(lDBNew);
				ReloadView(true);
			}
			else
				ReloadView(false);
		}

		private void buttonFindRecord_Click(object sender, EventArgs e)
		{
			if (labelFile.Text == "No file selected")
			{
				MessageBox.Show("Select a file first!", "Error",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			int liKey;
			Int32.TryParse(textBoxKey.Text, out liKey);
			Row lRow = mDBFile.GetRecord(liKey);
			textBoxKey.Text = lRow.key.ToString();
			textBoxA.Text = lRow.a.ToString();
			textBoxB.Text = lRow.b.ToString();
			textBoxC.Text = lRow.c.ToString();
			textBoxOffset.Text = lRow.overflow.ToString();
			labelAccesses.Text = "Accesses: " + mDBFile.GetAccesses().ToString();
		}

		private void buttonFetchNext_Click(object sender, EventArgs e)
		{
			if (labelFile.Text == "No file selected")
			{
				MessageBox.Show("Select a file first!", "Error",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			int liKey;
			Int32.TryParse(textBoxKey.Text, out liKey);
			Row lRow = mDBFile.FetchNext(liKey);
			textBoxKey.Text = lRow.key.ToString();
			textBoxA.Text = lRow.a.ToString();
			textBoxB.Text = lRow.b.ToString();
			textBoxC.Text = lRow.c.ToString();
			textBoxOffset.Text = lRow.overflow.ToString();
			labelAccesses.Text = "Accesses: " + mDBFile.GetAccesses().ToString();
		}

		private void buttonLoadTxt_Click(object sender, EventArgs e)
		{
			string lStrCurrDir = Directory.GetCurrentDirectory();
			lStrCurrDir = Path.GetFullPath(Path.Combine(lStrCurrDir, @"..\.."));
			OpenFileDialog lFileDial = new OpenFileDialog();
			lFileDial.InitialDirectory = lStrCurrDir;
			lFileDial.Filter = "txt files|*.txt";
			DBFile lDBFileNew = null;
			if (lFileDial.ShowDialog() == DialogResult.OK)
			{
				MakeFile();
				using(StreamReader lTxtReader = new StreamReader(lFileDial.FileName))
				{
					string lsTxtFile = lTxtReader.ReadToEnd();
					int liIndex = 0;
					while (liIndex < lsTxtFile.Length - 1) {
						while (lsTxtFile[liIndex] == ' ' || lsTxtFile[liIndex] == '\t' || lsTxtFile[liIndex] == '\n' 
							|| lsTxtFile[liIndex] == '\r')
						{
							liIndex++;
							if (liIndex > lsTxtFile.Length - 1)
								break;
						}
						if (liIndex > lsTxtFile.Length - 1)
							break;
						char lcOption = lsTxtFile[liIndex];
						liIndex++;
						int liValue = 0;
						while (char.IsDigit(lsTxtFile[liIndex]))
						{
							liValue *= 10;
							liValue += lsTxtFile[liIndex] - '0';
							liIndex++;
							if (liIndex > lsTxtFile.Length - 1)
								break;
						}
						switch (lcOption)
						{
							case 'i':
								lDBFileNew = mDBFile.AddRow(liValue, liValue, liValue, liValue);
								if(lDBFileNew != null)
								{
									SwapDBFile(lDBFileNew);
									lDBFileNew = null;
								}
								break;
							case 'd':
								mDBFile.DeleteRecord(liValue);
								break;
							case 'u':
								int liNewKey = 0;
								int liNewValue = 0;
								liIndex++;
								while (char.IsDigit(lsTxtFile[liIndex]))
								{
									liNewKey *= 10;
									liNewKey += lsTxtFile[liIndex] - '0';
									liIndex++;
									if (liIndex > lsTxtFile.Length - 1)
										break;
								}
								liIndex++;
								while (char.IsDigit(lsTxtFile[liIndex]))
								{
									liNewValue *= 10;
									liNewValue += lsTxtFile[liIndex] - '0';
									liIndex++;
									if (liIndex > lsTxtFile.Length - 1)
										break;
								}
								bool lbError = false;
								lDBFileNew = mDBFile.Update(liValue, liNewKey, (double)liNewValue, (double)liNewValue, (double)liNewValue, out lbError);
								if (lDBFileNew != null)
								{
									SwapDBFile(lDBFileNew);
									lDBFileNew = null;
								}
								break;
							default:
								break;
						}
					}
				}
				ReloadView();
			}
		}

		private void buttonFirstRecord_Click(object sender, EventArgs e)
		{
			if (labelFile.Text == "No file selected")
			{
				MessageBox.Show("Select a file first!", "Error",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			Row lRow = mDBFile.GetFirstRecord();
			textBoxKey.Text = lRow.key.ToString();
			textBoxA.Text = lRow.a.ToString();
			textBoxB.Text = lRow.b.ToString();
			textBoxC.Text = lRow.c.ToString();
			textBoxOffset.Text = lRow.overflow.ToString();
			labelAccesses.Text = "Accesses: " + mDBFile.GetAccesses().ToString();
		}

		private void buttonPrevIndexPage_Click(object sender, EventArgs e)
		{
			//Debug.Print(mDBFile.GetRowCount().ToString() + "\n");
			//Debug.Print(mDBFile.GetIndexCount().ToString() + "\n");
			//Debug.Print(mDBFile.GetOverflowCount().ToString() + "\n");
			miIndexPage--;
			ReloadIndexDataGridView();
		}

		private void buttonNextIndexPage_Click(object sender, EventArgs e)
		{
			miIndexPage++;
			ReloadIndexDataGridView();
		}

		private void buttonPrevFilePage_Click(object sender, EventArgs e)
		{
			miFilePage--;
			ReloadMainDataGridView();
		}

		private void buttonNextFilePage_Click(object sender, EventArgs e)
		{
			miFilePage++;
			ReloadMainDataGridView();
		}

		private void buttonPrevOverflowPage_Click(object sender, EventArgs e)
		{
			miOverflowPage--;
			ReloadOverflowDataGridView();
		}

		private void buttonNextOverflowPage_Click(object sender, EventArgs e)
		{
			miOverflowPage++;
			ReloadOverflowDataGridView();
		}

		private void buttonReorganise_Click(object sender, EventArgs e)
		{
			if (labelFile.Text == "No file selected")
			{
				MessageBox.Show("Select a file first!", "Error",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			DBFile lNewDBFile = mDBFile.Reorganise();
			SwapDBFile(lNewDBFile);

			ReloadView();
		}

		private void SwapDBFile(DBFile aDBFileNew)
		{
			string[] lsOldNames = mDBFile.GetFilePath();
			string[] lsNewNames = aDBFileNew.GetFilePath();
			mDBFile = aDBFileNew;
			for (int i = 0; i < 3; i++)
			{
				File.Delete(lsOldNames[i]);
				File.Move(lsNewNames[i], lsOldNames[i]);
			}
			mDBFile.SetFilePath(lsOldNames[0]);
		}

		private void buttonLoadJWD_Click(object sender, EventArgs e)
		{
			string lStrCurrDir = Directory.GetCurrentDirectory();
			string lsFilePath;
			lStrCurrDir = Path.GetFullPath(Path.Combine(lStrCurrDir, @"..\.."));
			OpenFileDialog lFileDial = new OpenFileDialog();
			lFileDial.InitialDirectory = lStrCurrDir;
			lFileDial.Filter = "jwd files|*.jwd";
			if (lFileDial.ShowDialog() == DialogResult.OK)
			{
				lsFilePath = lFileDial.FileName;
				labelFile.Text = lsFilePath;
				mDBFile = new DBFile(lsFilePath, miBufferRowSize, mdAlpha);
				ReloadView();
			}
		}

		private void buttonDelete_Click(object sender, EventArgs e)
		{
			if (labelFile.Text == "No file selected")
			{
				MessageBox.Show("Select a file first!", "Error",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			int liKey;
			Int32.TryParse(textBoxKey.Text, out liKey);
			mDBFile.DeleteRecord(liKey);
			ReloadView();
		}

		private void buttonUpdate_Click(object sender, EventArgs e)
		{
			if (labelFile.Text == "No file selected")
			{
				MessageBox.Show("Select a file first!", "Error",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			int liKey, liOldKey;
			double ldA, ldB, ldC;
			bool lbError;
			Int32.TryParse(textBoxNewKey.Text, out liKey);
			Double.TryParse(textBoxNewA.Text, out ldA);
			Double.TryParse(textBoxNewB.Text, out ldB);
			Double.TryParse(textBoxNewC.Text, out ldC);
			Int32.TryParse(textBoxKey.Text, out liOldKey);
			DBFile lDBNew = mDBFile.Update(liOldKey, liKey, ldA, ldB, ldC, out lbError);
			if (lbError)
			{
				MessageBox.Show("Record with such key already exists!", "Error",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else
			{
				if(lDBNew != null)
				{
					SwapDBFile(lDBNew);
				}
				ReloadView(false);
			}
		}

		private void buttonRandom_Click(object sender, EventArgs e)
		{
			//C# Random is trash, so I decided not to use it, and didn't bother to
			//implement it myself, so I scrapped the idea entirely :v
			//button and textfield are simply set to inactive and invisible
			int liN;
			if (!(Int32.TryParse(textBoxRandom.Text, out liN)))
			{
				MessageBox.Show("Couldn't read the number of records to generate.", "Error",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if (labelFile.Text == "No file selected")
			{
				MessageBox.Show("Select a file first!", "Error",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			
			DBFile lDBNew;
			int liRnd = 1;
			int liMax = Int32.MaxValue / 2;
			for (int i = 0; i < liN; i++)
			{
				while(mDBFile.GetRecord(liRnd).key != DBFile.NORECORD)
					liRnd = mRnd.Next(1, liMax);
				lDBNew = mDBFile.AddRow(liRnd, 0.0, 0.0, 0.0);
				if (lDBNew != null)
				{
					SwapDBFile(lDBNew);
					lDBNew = null;
				}
			}
			ReloadView();
		}

		private void buttonReset_Click(object sender, EventArgs e)
		{
			mDBFile.ResetAccesses();
			labelAccesses.Text = "Accesses: 0";
		}
	}
}
