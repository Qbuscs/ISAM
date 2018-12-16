namespace ISAM
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.button2 = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.textBoxKey = new System.Windows.Forms.TextBox();
			this.textBoxA = new System.Windows.Forms.TextBox();
			this.textBoxB = new System.Windows.Forms.TextBox();
			this.textBoxC = new System.Windows.Forms.TextBox();
			this.buttonAddRow = new System.Windows.Forms.Button();
			this.dataGridViewMain = new System.Windows.Forms.DataGridView();
			this.Key = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.a = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.b = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.c = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Overflow = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.buttonFindRecord = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.textBoxOffset = new System.Windows.Forms.TextBox();
			this.buttonFetchNext = new System.Windows.Forms.Button();
			this.buttonLoadTxt = new System.Windows.Forms.Button();
			this.dataGridViewOverflow = new System.Windows.Forms.DataGridView();
			this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewIndex = new System.Windows.Forms.DataGridView();
			this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.buttonFirstRecord = new System.Windows.Forms.Button();
			this.buttonPrevFilePage = new System.Windows.Forms.Button();
			this.buttonNextFilePage = new System.Windows.Forms.Button();
			this.labelFilePage = new System.Windows.Forms.Label();
			this.labelOverflowPage = new System.Windows.Forms.Label();
			this.buttonNextOverflowPage = new System.Windows.Forms.Button();
			this.buttonPrevOverflowPage = new System.Windows.Forms.Button();
			this.labelIndexPage = new System.Windows.Forms.Label();
			this.buttonNextIndexPage = new System.Windows.Forms.Button();
			this.buttonPrevIndexPage = new System.Windows.Forms.Button();
			this.buttonReorganise = new System.Windows.Forms.Button();
			this.buttonLoadJWD = new System.Windows.Forms.Button();
			this.labelFile = new System.Windows.Forms.Label();
			this.buttonDelete = new System.Windows.Forms.Button();
			this.buttonUpdate = new System.Windows.Forms.Button();
			this.textBoxNewC = new System.Windows.Forms.TextBox();
			this.textBoxNewB = new System.Windows.Forms.TextBox();
			this.textBoxNewA = new System.Windows.Forms.TextBox();
			this.textBoxNewKey = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.buttonRandom = new System.Windows.Forms.Button();
			this.textBoxRandom = new System.Windows.Forms.TextBox();
			this.labelAccesses = new System.Windows.Forms.Label();
			this.buttonReset = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewMain)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewOverflow)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewIndex)).BeginInit();
			this.SuspendLayout();
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(12, 817);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(184, 23);
			this.button2.TabIndex = 3;
			this.button2.Text = "Create File";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(44, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(25, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "Key";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(44, 45);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(13, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "a";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(44, 74);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(13, 13);
			this.label4.TabIndex = 7;
			this.label4.Text = "b";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(44, 103);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(13, 13);
			this.label5.TabIndex = 8;
			this.label5.Text = "c";
			// 
			// textBoxKey
			// 
			this.textBoxKey.Location = new System.Drawing.Point(85, 13);
			this.textBoxKey.Name = "textBoxKey";
			this.textBoxKey.Size = new System.Drawing.Size(100, 20);
			this.textBoxKey.TabIndex = 9;
			this.textBoxKey.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxKey_KeyPress);
			// 
			// textBoxA
			// 
			this.textBoxA.Location = new System.Drawing.Point(85, 42);
			this.textBoxA.Name = "textBoxA";
			this.textBoxA.Size = new System.Drawing.Size(100, 20);
			this.textBoxA.TabIndex = 10;
			this.textBoxA.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxA_KeyPress);
			// 
			// textBoxB
			// 
			this.textBoxB.Location = new System.Drawing.Point(85, 71);
			this.textBoxB.Name = "textBoxB";
			this.textBoxB.Size = new System.Drawing.Size(100, 20);
			this.textBoxB.TabIndex = 11;
			this.textBoxB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxB_KeyPress);
			// 
			// textBoxC
			// 
			this.textBoxC.Location = new System.Drawing.Point(85, 100);
			this.textBoxC.Name = "textBoxC";
			this.textBoxC.Size = new System.Drawing.Size(100, 20);
			this.textBoxC.TabIndex = 12;
			this.textBoxC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxC_KeyPress);
			// 
			// buttonAddRow
			// 
			this.buttonAddRow.Location = new System.Drawing.Point(47, 143);
			this.buttonAddRow.Name = "buttonAddRow";
			this.buttonAddRow.Size = new System.Drawing.Size(138, 23);
			this.buttonAddRow.TabIndex = 13;
			this.buttonAddRow.Text = "Add Row";
			this.buttonAddRow.UseVisualStyleBackColor = true;
			this.buttonAddRow.Click += new System.EventHandler(this.buttonAddRow_Click);
			// 
			// dataGridViewMain
			// 
			this.dataGridViewMain.AllowUserToAddRows = false;
			this.dataGridViewMain.AllowUserToDeleteRows = false;
			this.dataGridViewMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Key,
            this.a,
            this.b,
            this.c,
            this.Overflow});
			this.dataGridViewMain.Location = new System.Drawing.Point(261, 183);
			this.dataGridViewMain.Name = "dataGridViewMain";
			this.dataGridViewMain.ReadOnly = true;
			this.dataGridViewMain.Size = new System.Drawing.Size(469, 568);
			this.dataGridViewMain.TabIndex = 14;
			// 
			// Key
			// 
			this.Key.HeaderText = "Key";
			this.Key.Name = "Key";
			this.Key.ReadOnly = true;
			this.Key.Width = 50;
			// 
			// a
			// 
			this.a.HeaderText = "a";
			this.a.Name = "a";
			this.a.ReadOnly = true;
			// 
			// b
			// 
			this.b.HeaderText = "b";
			this.b.Name = "b";
			this.b.ReadOnly = true;
			// 
			// c
			// 
			this.c.HeaderText = "c";
			this.c.Name = "c";
			this.c.ReadOnly = true;
			// 
			// Overflow
			// 
			this.Overflow.HeaderText = "Overflow";
			this.Overflow.Name = "Overflow";
			this.Overflow.ReadOnly = true;
			this.Overflow.Width = 75;
			// 
			// buttonFindRecord
			// 
			this.buttonFindRecord.Location = new System.Drawing.Point(223, 143);
			this.buttonFindRecord.Name = "buttonFindRecord";
			this.buttonFindRecord.Size = new System.Drawing.Size(137, 23);
			this.buttonFindRecord.TabIndex = 15;
			this.buttonFindRecord.Text = "Find record";
			this.buttonFindRecord.UseVisualStyleBackColor = true;
			this.buttonFindRecord.Click += new System.EventHandler(this.buttonFindRecord_Click);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(204, 13);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(33, 13);
			this.label6.TabIndex = 16;
			this.label6.Text = "offset";
			// 
			// textBoxOffset
			// 
			this.textBoxOffset.Location = new System.Drawing.Point(244, 13);
			this.textBoxOffset.Name = "textBoxOffset";
			this.textBoxOffset.ReadOnly = true;
			this.textBoxOffset.Size = new System.Drawing.Size(100, 20);
			this.textBoxOffset.TabIndex = 17;
			// 
			// buttonFetchNext
			// 
			this.buttonFetchNext.Location = new System.Drawing.Point(569, 143);
			this.buttonFetchNext.Name = "buttonFetchNext";
			this.buttonFetchNext.Size = new System.Drawing.Size(135, 23);
			this.buttonFetchNext.TabIndex = 18;
			this.buttonFetchNext.Text = "Fetch next";
			this.buttonFetchNext.UseVisualStyleBackColor = true;
			this.buttonFetchNext.Click += new System.EventHandler(this.buttonFetchNext_Click);
			// 
			// buttonLoadTxt
			// 
			this.buttonLoadTxt.Location = new System.Drawing.Point(221, 817);
			this.buttonLoadTxt.Name = "buttonLoadTxt";
			this.buttonLoadTxt.Size = new System.Drawing.Size(144, 23);
			this.buttonLoadTxt.TabIndex = 19;
			this.buttonLoadTxt.Text = "Load from text file";
			this.buttonLoadTxt.UseVisualStyleBackColor = true;
			this.buttonLoadTxt.Click += new System.EventHandler(this.buttonLoadTxt_Click);
			// 
			// dataGridViewOverflow
			// 
			this.dataGridViewOverflow.AllowUserToAddRows = false;
			this.dataGridViewOverflow.AllowUserToDeleteRows = false;
			this.dataGridViewOverflow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewOverflow.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
			this.dataGridViewOverflow.Location = new System.Drawing.Point(799, 183);
			this.dataGridViewOverflow.Name = "dataGridViewOverflow";
			this.dataGridViewOverflow.ReadOnly = true;
			this.dataGridViewOverflow.Size = new System.Drawing.Size(469, 568);
			this.dataGridViewOverflow.TabIndex = 20;
			// 
			// dataGridViewTextBoxColumn1
			// 
			this.dataGridViewTextBoxColumn1.HeaderText = "Key";
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn1.ReadOnly = true;
			this.dataGridViewTextBoxColumn1.Width = 50;
			// 
			// dataGridViewTextBoxColumn2
			// 
			this.dataGridViewTextBoxColumn2.HeaderText = "a";
			this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn2.ReadOnly = true;
			// 
			// dataGridViewTextBoxColumn3
			// 
			this.dataGridViewTextBoxColumn3.HeaderText = "b";
			this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
			this.dataGridViewTextBoxColumn3.ReadOnly = true;
			// 
			// dataGridViewTextBoxColumn4
			// 
			this.dataGridViewTextBoxColumn4.HeaderText = "c";
			this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
			this.dataGridViewTextBoxColumn4.ReadOnly = true;
			// 
			// dataGridViewTextBoxColumn5
			// 
			this.dataGridViewTextBoxColumn5.HeaderText = "Overflow";
			this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
			this.dataGridViewTextBoxColumn5.ReadOnly = true;
			this.dataGridViewTextBoxColumn5.Width = 75;
			// 
			// dataGridViewIndex
			// 
			this.dataGridViewIndex.AllowUserToAddRows = false;
			this.dataGridViewIndex.AllowUserToDeleteRows = false;
			this.dataGridViewIndex.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewIndex.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn6});
			this.dataGridViewIndex.Location = new System.Drawing.Point(47, 183);
			this.dataGridViewIndex.Name = "dataGridViewIndex";
			this.dataGridViewIndex.ReadOnly = true;
			this.dataGridViewIndex.Size = new System.Drawing.Size(119, 568);
			this.dataGridViewIndex.TabIndex = 21;
			// 
			// dataGridViewTextBoxColumn6
			// 
			this.dataGridViewTextBoxColumn6.HeaderText = "Key";
			this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
			this.dataGridViewTextBoxColumn6.ReadOnly = true;
			this.dataGridViewTextBoxColumn6.Width = 75;
			// 
			// buttonFirstRecord
			// 
			this.buttonFirstRecord.Location = new System.Drawing.Point(401, 143);
			this.buttonFirstRecord.Name = "buttonFirstRecord";
			this.buttonFirstRecord.Size = new System.Drawing.Size(135, 23);
			this.buttonFirstRecord.TabIndex = 22;
			this.buttonFirstRecord.Text = "First Record";
			this.buttonFirstRecord.UseVisualStyleBackColor = true;
			this.buttonFirstRecord.Click += new System.EventHandler(this.buttonFirstRecord_Click);
			// 
			// buttonPrevFilePage
			// 
			this.buttonPrevFilePage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.buttonPrevFilePage.Location = new System.Drawing.Point(401, 784);
			this.buttonPrevFilePage.Name = "buttonPrevFilePage";
			this.buttonPrevFilePage.Size = new System.Drawing.Size(33, 23);
			this.buttonPrevFilePage.TabIndex = 23;
			this.buttonPrevFilePage.Text = "<";
			this.buttonPrevFilePage.UseVisualStyleBackColor = true;
			this.buttonPrevFilePage.Click += new System.EventHandler(this.buttonPrevFilePage_Click);
			// 
			// buttonNextFilePage
			// 
			this.buttonNextFilePage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.buttonNextFilePage.Location = new System.Drawing.Point(548, 784);
			this.buttonNextFilePage.Name = "buttonNextFilePage";
			this.buttonNextFilePage.Size = new System.Drawing.Size(33, 23);
			this.buttonNextFilePage.TabIndex = 24;
			this.buttonNextFilePage.Text = ">";
			this.buttonNextFilePage.UseVisualStyleBackColor = true;
			this.buttonNextFilePage.Click += new System.EventHandler(this.buttonNextFilePage_Click);
			// 
			// labelFilePage
			// 
			this.labelFilePage.AutoSize = true;
			this.labelFilePage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labelFilePage.Location = new System.Drawing.Point(455, 785);
			this.labelFilePage.Name = "labelFilePage";
			this.labelFilePage.Size = new System.Drawing.Size(63, 20);
			this.labelFilePage.TabIndex = 25;
			this.labelFilePage.Text = "Page: 0";
			// 
			// labelOverflowPage
			// 
			this.labelOverflowPage.AutoSize = true;
			this.labelOverflowPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labelOverflowPage.Location = new System.Drawing.Point(1026, 787);
			this.labelOverflowPage.Name = "labelOverflowPage";
			this.labelOverflowPage.Size = new System.Drawing.Size(63, 20);
			this.labelOverflowPage.TabIndex = 28;
			this.labelOverflowPage.Text = "Page: 0";
			// 
			// buttonNextOverflowPage
			// 
			this.buttonNextOverflowPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.buttonNextOverflowPage.Location = new System.Drawing.Point(1119, 786);
			this.buttonNextOverflowPage.Name = "buttonNextOverflowPage";
			this.buttonNextOverflowPage.Size = new System.Drawing.Size(33, 23);
			this.buttonNextOverflowPage.TabIndex = 27;
			this.buttonNextOverflowPage.Text = ">";
			this.buttonNextOverflowPage.UseVisualStyleBackColor = true;
			this.buttonNextOverflowPage.Click += new System.EventHandler(this.buttonNextOverflowPage_Click);
			// 
			// buttonPrevOverflowPage
			// 
			this.buttonPrevOverflowPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.buttonPrevOverflowPage.Location = new System.Drawing.Point(972, 786);
			this.buttonPrevOverflowPage.Name = "buttonPrevOverflowPage";
			this.buttonPrevOverflowPage.Size = new System.Drawing.Size(33, 23);
			this.buttonPrevOverflowPage.TabIndex = 26;
			this.buttonPrevOverflowPage.Text = "<";
			this.buttonPrevOverflowPage.UseVisualStyleBackColor = true;
			this.buttonPrevOverflowPage.Click += new System.EventHandler(this.buttonPrevOverflowPage_Click);
			// 
			// labelIndexPage
			// 
			this.labelIndexPage.AutoSize = true;
			this.labelIndexPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labelIndexPage.Location = new System.Drawing.Point(76, 787);
			this.labelIndexPage.Name = "labelIndexPage";
			this.labelIndexPage.Size = new System.Drawing.Size(63, 20);
			this.labelIndexPage.TabIndex = 31;
			this.labelIndexPage.Text = "Page: 0";
			// 
			// buttonNextIndexPage
			// 
			this.buttonNextIndexPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.buttonNextIndexPage.Location = new System.Drawing.Point(169, 786);
			this.buttonNextIndexPage.Name = "buttonNextIndexPage";
			this.buttonNextIndexPage.Size = new System.Drawing.Size(33, 23);
			this.buttonNextIndexPage.TabIndex = 30;
			this.buttonNextIndexPage.Text = ">";
			this.buttonNextIndexPage.UseVisualStyleBackColor = true;
			this.buttonNextIndexPage.Click += new System.EventHandler(this.buttonNextIndexPage_Click);
			// 
			// buttonPrevIndexPage
			// 
			this.buttonPrevIndexPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.buttonPrevIndexPage.Location = new System.Drawing.Point(22, 786);
			this.buttonPrevIndexPage.Name = "buttonPrevIndexPage";
			this.buttonPrevIndexPage.Size = new System.Drawing.Size(33, 23);
			this.buttonPrevIndexPage.TabIndex = 29;
			this.buttonPrevIndexPage.Text = "<";
			this.buttonPrevIndexPage.UseVisualStyleBackColor = true;
			this.buttonPrevIndexPage.Click += new System.EventHandler(this.buttonPrevIndexPage_Click);
			// 
			// buttonReorganise
			// 
			this.buttonReorganise.Location = new System.Drawing.Point(1039, 143);
			this.buttonReorganise.Name = "buttonReorganise";
			this.buttonReorganise.Size = new System.Drawing.Size(113, 23);
			this.buttonReorganise.TabIndex = 32;
			this.buttonReorganise.Text = "Reorganise";
			this.buttonReorganise.UseVisualStyleBackColor = true;
			this.buttonReorganise.Click += new System.EventHandler(this.buttonReorganise_Click);
			// 
			// buttonLoadJWD
			// 
			this.buttonLoadJWD.Location = new System.Drawing.Point(387, 817);
			this.buttonLoadJWD.Name = "buttonLoadJWD";
			this.buttonLoadJWD.Size = new System.Drawing.Size(194, 23);
			this.buttonLoadJWD.TabIndex = 33;
			this.buttonLoadJWD.Text = "Load .jwd file";
			this.buttonLoadJWD.UseVisualStyleBackColor = true;
			this.buttonLoadJWD.Click += new System.EventHandler(this.buttonLoadJWD_Click);
			// 
			// labelFile
			// 
			this.labelFile.AutoSize = true;
			this.labelFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labelFile.Location = new System.Drawing.Point(587, 820);
			this.labelFile.Name = "labelFile";
			this.labelFile.Size = new System.Drawing.Size(117, 20);
			this.labelFile.TabIndex = 34;
			this.labelFile.Text = "No file selected";
			// 
			// buttonDelete
			// 
			this.buttonDelete.Location = new System.Drawing.Point(734, 143);
			this.buttonDelete.Name = "buttonDelete";
			this.buttonDelete.Size = new System.Drawing.Size(119, 23);
			this.buttonDelete.TabIndex = 35;
			this.buttonDelete.Text = "Delete";
			this.buttonDelete.UseVisualStyleBackColor = true;
			this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
			// 
			// buttonUpdate
			// 
			this.buttonUpdate.Location = new System.Drawing.Point(893, 143);
			this.buttonUpdate.Name = "buttonUpdate";
			this.buttonUpdate.Size = new System.Drawing.Size(112, 23);
			this.buttonUpdate.TabIndex = 36;
			this.buttonUpdate.Text = "Update";
			this.buttonUpdate.UseVisualStyleBackColor = true;
			this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
			// 
			// textBoxNewC
			// 
			this.textBoxNewC.Location = new System.Drawing.Point(905, 103);
			this.textBoxNewC.Name = "textBoxNewC";
			this.textBoxNewC.Size = new System.Drawing.Size(100, 20);
			this.textBoxNewC.TabIndex = 44;
			this.textBoxNewC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxNewC_KeyPress);
			// 
			// textBoxNewB
			// 
			this.textBoxNewB.Location = new System.Drawing.Point(905, 74);
			this.textBoxNewB.Name = "textBoxNewB";
			this.textBoxNewB.Size = new System.Drawing.Size(100, 20);
			this.textBoxNewB.TabIndex = 43;
			this.textBoxNewB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxNewB_KeyPress);
			// 
			// textBoxNewA
			// 
			this.textBoxNewA.Location = new System.Drawing.Point(905, 45);
			this.textBoxNewA.Name = "textBoxNewA";
			this.textBoxNewA.Size = new System.Drawing.Size(100, 20);
			this.textBoxNewA.TabIndex = 42;
			this.textBoxNewA.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxNewA_KeyPress);
			// 
			// textBoxNewKey
			// 
			this.textBoxNewKey.Location = new System.Drawing.Point(905, 16);
			this.textBoxNewKey.Name = "textBoxNewKey";
			this.textBoxNewKey.Size = new System.Drawing.Size(100, 20);
			this.textBoxNewKey.TabIndex = 41;
			this.textBoxNewKey.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxNewKey_KeyPress);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(850, 106);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(38, 13);
			this.label1.TabIndex = 40;
			this.label1.Text = "New c";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(850, 77);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(38, 13);
			this.label7.TabIndex = 39;
			this.label7.Text = "New b";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(850, 48);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(38, 13);
			this.label8.TabIndex = 38;
			this.label8.Text = "New a";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(850, 20);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(49, 13);
			this.label9.TabIndex = 37;
			this.label9.Text = "New key";
			// 
			// buttonRandom
			// 
			this.buttonRandom.Enabled = false;
			this.buttonRandom.Location = new System.Drawing.Point(1171, 143);
			this.buttonRandom.Name = "buttonRandom";
			this.buttonRandom.Size = new System.Drawing.Size(97, 23);
			this.buttonRandom.TabIndex = 45;
			this.buttonRandom.Text = "Generate random";
			this.buttonRandom.UseVisualStyleBackColor = true;
			this.buttonRandom.Visible = false;
			this.buttonRandom.Click += new System.EventHandler(this.buttonRandom_Click);
			// 
			// textBoxRandom
			// 
			this.textBoxRandom.Enabled = false;
			this.textBoxRandom.Location = new System.Drawing.Point(1171, 117);
			this.textBoxRandom.Name = "textBoxRandom";
			this.textBoxRandom.Size = new System.Drawing.Size(97, 20);
			this.textBoxRandom.TabIndex = 46;
			this.textBoxRandom.Visible = false;
			this.textBoxRandom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxRandom_KeyPress);
			// 
			// labelAccesses
			// 
			this.labelAccesses.AutoSize = true;
			this.labelAccesses.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labelAccesses.Location = new System.Drawing.Point(1035, 16);
			this.labelAccesses.Name = "labelAccesses";
			this.labelAccesses.Size = new System.Drawing.Size(95, 20);
			this.labelAccesses.TabIndex = 47;
			this.labelAccesses.Text = "Accesses: 0";
			// 
			// buttonReset
			// 
			this.buttonReset.Location = new System.Drawing.Point(1039, 41);
			this.buttonReset.Name = "buttonReset";
			this.buttonReset.Size = new System.Drawing.Size(91, 23);
			this.buttonReset.TabIndex = 48;
			this.buttonReset.Text = "Reset";
			this.buttonReset.UseVisualStyleBackColor = true;
			this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.ClientSize = new System.Drawing.Size(1280, 852);
			this.Controls.Add(this.buttonReset);
			this.Controls.Add(this.labelAccesses);
			this.Controls.Add(this.textBoxRandom);
			this.Controls.Add(this.buttonRandom);
			this.Controls.Add(this.textBoxNewC);
			this.Controls.Add(this.textBoxNewB);
			this.Controls.Add(this.textBoxNewA);
			this.Controls.Add(this.textBoxNewKey);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.buttonUpdate);
			this.Controls.Add(this.buttonDelete);
			this.Controls.Add(this.labelFile);
			this.Controls.Add(this.buttonLoadJWD);
			this.Controls.Add(this.buttonReorganise);
			this.Controls.Add(this.labelIndexPage);
			this.Controls.Add(this.buttonNextIndexPage);
			this.Controls.Add(this.buttonPrevIndexPage);
			this.Controls.Add(this.labelOverflowPage);
			this.Controls.Add(this.buttonNextOverflowPage);
			this.Controls.Add(this.buttonPrevOverflowPage);
			this.Controls.Add(this.labelFilePage);
			this.Controls.Add(this.buttonNextFilePage);
			this.Controls.Add(this.buttonPrevFilePage);
			this.Controls.Add(this.buttonFirstRecord);
			this.Controls.Add(this.dataGridViewIndex);
			this.Controls.Add(this.dataGridViewOverflow);
			this.Controls.Add(this.buttonLoadTxt);
			this.Controls.Add(this.buttonFetchNext);
			this.Controls.Add(this.textBoxOffset);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.buttonFindRecord);
			this.Controls.Add(this.dataGridViewMain);
			this.Controls.Add(this.buttonAddRow);
			this.Controls.Add(this.textBoxC);
			this.Controls.Add(this.textBoxB);
			this.Controls.Add(this.textBoxA);
			this.Controls.Add(this.textBoxKey);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.button2);
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewMain)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewOverflow)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewIndex)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textBoxKey;
		private System.Windows.Forms.TextBox textBoxA;
		private System.Windows.Forms.TextBox textBoxB;
		private System.Windows.Forms.TextBox textBoxC;
		private System.Windows.Forms.Button buttonAddRow;
		private System.Windows.Forms.DataGridView dataGridViewMain;
		private System.Windows.Forms.Button buttonFindRecord;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox textBoxOffset;
		private System.Windows.Forms.Button buttonFetchNext;
		private System.Windows.Forms.Button buttonLoadTxt;
		private System.Windows.Forms.DataGridViewTextBoxColumn Key;
		private System.Windows.Forms.DataGridViewTextBoxColumn a;
		private System.Windows.Forms.DataGridViewTextBoxColumn b;
		private System.Windows.Forms.DataGridViewTextBoxColumn c;
		private System.Windows.Forms.DataGridViewTextBoxColumn Overflow;
		private System.Windows.Forms.DataGridView dataGridViewOverflow;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
		private System.Windows.Forms.DataGridView dataGridViewIndex;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
		private System.Windows.Forms.Button buttonFirstRecord;
		private System.Windows.Forms.Button buttonPrevFilePage;
		private System.Windows.Forms.Button buttonNextFilePage;
		private System.Windows.Forms.Label labelFilePage;
		private System.Windows.Forms.Label labelOverflowPage;
		private System.Windows.Forms.Button buttonNextOverflowPage;
		private System.Windows.Forms.Button buttonPrevOverflowPage;
		private System.Windows.Forms.Label labelIndexPage;
		private System.Windows.Forms.Button buttonNextIndexPage;
		private System.Windows.Forms.Button buttonPrevIndexPage;
		private System.Windows.Forms.Button buttonReorganise;
		private System.Windows.Forms.Button buttonLoadJWD;
		private System.Windows.Forms.Label labelFile;
		private System.Windows.Forms.Button buttonDelete;
		private System.Windows.Forms.Button buttonUpdate;
		private System.Windows.Forms.TextBox textBoxNewC;
		private System.Windows.Forms.TextBox textBoxNewB;
		private System.Windows.Forms.TextBox textBoxNewA;
		private System.Windows.Forms.TextBox textBoxNewKey;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Button buttonRandom;
		private System.Windows.Forms.TextBox textBoxRandom;
		private System.Windows.Forms.Label labelAccesses;
		private System.Windows.Forms.Button buttonReset;
	}
}

