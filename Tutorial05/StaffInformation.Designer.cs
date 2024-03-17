namespace Tutorial03
{
    partial class StaffInformation
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            txtStaffNo = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtStaffName = new TextBox();
            label4 = new Label();
            label5 = new Label();
            txtAge = new TextBox();
            label6 = new Label();
            txtNrcNo = new TextBox();
            label7 = new Label();
            txtPhoneNo1 = new TextBox();
            label8 = new Label();
            cbStaffType = new ComboBox();
            label9 = new Label();
            txtPhoneNo2 = new TextBox();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            rtxtAddress = new RichTextBox();
            pbStaffPhoto = new PictureBox();
            dJoinDate = new DateTimePicker();
            label14 = new Label();
            label15 = new Label();
            rdOther = new RadioButton();
            rdMale = new RadioButton();
            rdfemale = new RadioButton();
            dBirthDate = new DateTimePicker();
            btnAdd = new Button();
            btnClear = new Button();
            btnDelete = new Button();
            btnChooseFile = new Button();
            errorProviderCommon = new ErrorProvider(components);
            dgvStaffInformation = new DataGridView();
            txtPagination = new TextBox();
            btnStart = new Button();
            btnEnd = new Button();
            btnPrevious = new Button();
            btnNext = new Button();
            ((System.ComponentModel.ISupportInitialize)pbStaffPhoto).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProviderCommon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvStaffInformation).BeginInit();
            SuspendLayout();
            // 
            // txtStaffNo
            // 
            txtStaffNo.Enabled = false;
            txtStaffNo.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtStaffNo.Location = new Point(203, 67);
            txtStaffNo.Name = "txtStaffNo";
            txtStaffNo.ReadOnly = true;
            txtStaffNo.Size = new Size(196, 26);
            txtStaffNo.TabIndex = 0;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Georgia", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(344, 8);
            label1.Name = "label1";
            label1.Size = new Size(231, 25);
            label1.TabIndex = 1;
            label1.Text = "Staff Information Form";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(109, 75);
            label2.Name = "label2";
            label2.Size = new Size(69, 18);
            label2.TabIndex = 2;
            label2.Text = "Staff No.";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(109, 124);
            label3.Name = "label3";
            label3.Size = new Size(87, 18);
            label3.TabIndex = 4;
            label3.Text = "Staff Name";
            // 
            // txtStaffName
            // 
            txtStaffName.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtStaffName.Location = new Point(203, 116);
            txtStaffName.Name = "txtStaffName";
            txtStaffName.Size = new Size(196, 26);
            txtStaffName.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(109, 177);
            label4.Name = "label4";
            label4.Size = new Size(80, 18);
            label4.TabIndex = 6;
            label4.Text = "Join From";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(109, 224);
            label5.Name = "label5";
            label5.Size = new Size(98, 18);
            label5.TabIndex = 8;
            label5.Text = "Date of Birth";
            // 
            // txtAge
            // 
            txtAge.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtAge.Location = new Point(202, 263);
            txtAge.Name = "txtAge";
            txtAge.ReadOnly = true;
            txtAge.Size = new Size(196, 26);
            txtAge.TabIndex = 7;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(109, 263);
            label6.Name = "label6";
            label6.Size = new Size(35, 18);
            label6.TabIndex = 10;
            label6.Text = "Age";
            // 
            // txtNrcNo
            // 
            txtNrcNo.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNrcNo.Location = new Point(202, 356);
            txtNrcNo.Name = "txtNrcNo";
            txtNrcNo.Size = new Size(196, 26);
            txtNrcNo.TabIndex = 9;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(109, 310);
            label7.Name = "label7";
            label7.Size = new Size(82, 18);
            label7.TabIndex = 12;
            label7.Text = "Staff Type";
            // 
            // txtPhoneNo1
            // 
            txtPhoneNo1.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPhoneNo1.Location = new Point(544, 112);
            txtPhoneNo1.Name = "txtPhoneNo1";
            txtPhoneNo1.Size = new Size(196, 26);
            txtPhoneNo1.TabIndex = 11;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(109, 356);
            label8.Name = "label8";
            label8.Size = new Size(65, 18);
            label8.TabIndex = 13;
            label8.Text = "NRC No";
            // 
            // cbStaffType
            // 
            cbStaffType.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbStaffType.FormattingEnabled = true;
            cbStaffType.Items.AddRange(new object[] { "Full Time", "Part Time" });
            cbStaffType.Location = new Point(203, 307);
            cbStaffType.Name = "cbStaffType";
            cbStaffType.Size = new Size(195, 26);
            cbStaffType.TabIndex = 14;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(451, 120);
            label9.Name = "label9";
            label9.Size = new Size(76, 18);
            label9.TabIndex = 16;
            label9.Text = "Phone No";
            // 
            // txtPhoneNo2
            // 
            txtPhoneNo2.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPhoneNo2.Location = new Point(544, 170);
            txtPhoneNo2.Name = "txtPhoneNo2";
            txtPhoneNo2.Size = new Size(196, 26);
            txtPhoneNo2.TabIndex = 15;
            // 
            // label10
            // 
            label10.Location = new Point(0, 0);
            label10.Name = "label10";
            label10.Size = new Size(88, 21);
            label10.TabIndex = 27;
            // 
            // label11
            // 
            label11.Location = new Point(0, 0);
            label11.Name = "label11";
            label11.Size = new Size(88, 21);
            label11.TabIndex = 26;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.Location = new Point(451, 224);
            label12.Name = "label12";
            label12.Size = new Size(53, 18);
            label12.TabIndex = 22;
            label12.Text = "Image";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label13.Location = new Point(446, 307);
            label13.Name = "label13";
            label13.Size = new Size(66, 18);
            label13.TabIndex = 24;
            label13.Text = "Address";
            // 
            // rtxtAddress
            // 
            rtxtAddress.Location = new Point(544, 310);
            rtxtAddress.Name = "rtxtAddress";
            rtxtAddress.Size = new Size(244, 86);
            rtxtAddress.TabIndex = 25;
            rtxtAddress.Text = "";
            // 
            // pbStaffPhoto
            // 
            pbStaffPhoto.BorderStyle = BorderStyle.FixedSingle;
            pbStaffPhoto.Location = new Point(544, 222);
            pbStaffPhoto.Name = "pbStaffPhoto";
            pbStaffPhoto.Size = new Size(70, 73);
            pbStaffPhoto.SizeMode = PictureBoxSizeMode.StretchImage;
            pbStaffPhoto.TabIndex = 28;
            pbStaffPhoto.TabStop = false;
            // 
            // dJoinDate
            // 
            dJoinDate.Location = new Point(202, 177);
            dJoinDate.MinDate = new DateTime(1920, 1, 1, 0, 0, 0, 0);
            dJoinDate.Name = "dJoinDate";
            dJoinDate.Size = new Size(196, 25);
            dJoinDate.TabIndex = 29;
            dJoinDate.ValueChanged += dJoinDate_ValueChanged;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label14.Location = new Point(451, 173);
            label14.Name = "label14";
            label14.Size = new Size(76, 18);
            label14.TabIndex = 30;
            label14.Text = "Phone No";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label15.Location = new Point(451, 71);
            label15.Name = "label15";
            label15.Size = new Size(61, 18);
            label15.TabIndex = 31;
            label15.Text = "Gender";
            // 
            // rdOther
            // 
            rdOther.AutoSize = true;
            rdOther.Location = new Point(544, 72);
            rdOther.Name = "rdOther";
            rdOther.Size = new Size(59, 21);
            rdOther.TabIndex = 32;
            rdOther.TabStop = true;
            rdOther.Text = "Other";
            rdOther.UseVisualStyleBackColor = true;
            // 
            // rdMale
            // 
            rdMale.AutoSize = true;
            rdMale.Location = new Point(634, 72);
            rdMale.Name = "rdMale";
            rdMale.Size = new Size(55, 21);
            rdMale.TabIndex = 33;
            rdMale.TabStop = true;
            rdMale.Text = "Male";
            rdMale.UseVisualStyleBackColor = true;
            // 
            // rdfemale
            // 
            rdfemale.AutoSize = true;
            rdfemale.Location = new Point(726, 72);
            rdfemale.Name = "rdfemale";
            rdfemale.Size = new Size(67, 21);
            rdfemale.TabIndex = 34;
            rdfemale.TabStop = true;
            rdfemale.Text = "Female";
            rdfemale.UseVisualStyleBackColor = true;
            // 
            // dBirthDate
            // 
            dBirthDate.Location = new Point(203, 224);
            dBirthDate.MinDate = new DateTime(1920, 1, 1, 0, 0, 0, 0);
            dBirthDate.Name = "dBirthDate";
            dBirthDate.Size = new Size(196, 25);
            dBirthDate.TabIndex = 35;
            dBirthDate.ValueChanged += dBirthDate_ValueChanged;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(263, 417);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(105, 30);
            btnAdd.TabIndex = 36;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(400, 417);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(105, 30);
            btnClear.TabIndex = 37;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(536, 417);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(105, 30);
            btnDelete.TabIndex = 38;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnChooseFile
            // 
            btnChooseFile.Location = new Point(634, 222);
            btnChooseFile.Name = "btnChooseFile";
            btnChooseFile.Size = new Size(154, 30);
            btnChooseFile.TabIndex = 40;
            btnChooseFile.Text = "Choose File";
            btnChooseFile.UseVisualStyleBackColor = true;
            btnChooseFile.Click += clickChooseFile;
            // 
            // errorProviderCommon
            // 
            errorProviderCommon.ContainerControl = this;
            // 
            // dgvStaffInformation
            // 
            dgvStaffInformation.AllowUserToAddRows = false;
            dgvStaffInformation.AllowUserToDeleteRows = false;
            dgvStaffInformation.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvStaffInformation.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvStaffInformation.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvStaffInformation.BackgroundColor = Color.White;
            dgvStaffInformation.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStaffInformation.GridColor = Color.MediumSpringGreen;
            dgvStaffInformation.Location = new Point(0, 472);
            dgvStaffInformation.MultiSelect = false;
            dgvStaffInformation.Name = "dgvStaffInformation";
            dgvStaffInformation.ReadOnly = true;
            dgvStaffInformation.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStaffInformation.Size = new Size(878, 218);
            dgvStaffInformation.TabIndex = 42;
            dgvStaffInformation.CellClick += cellClick_editInfo;
            // 
            // txtPagination
            // 
            txtPagination.Font = new Font("Georgia", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPagination.Location = new Point(404, 704);
            txtPagination.Name = "txtPagination";
            txtPagination.ReadOnly = true;
            txtPagination.Size = new Size(105, 29);
            txtPagination.TabIndex = 43;
            txtPagination.TextAlign = HorizontalAlignment.Center;
            // 
            // btnStart
            // 
            btnStart.Location = new Point(344, 704);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(43, 30);
            btnStart.TabIndex = 44;
            btnStart.Text = "<";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // btnEnd
            // 
            btnEnd.Location = new Point(527, 704);
            btnEnd.Name = "btnEnd";
            btnEnd.Size = new Size(48, 30);
            btnEnd.TabIndex = 45;
            btnEnd.Text = ">";
            btnEnd.UseVisualStyleBackColor = true;
            btnEnd.Click += btnEnd_Click;
            // 
            // btnPrevious
            // 
            btnPrevious.Location = new Point(280, 704);
            btnPrevious.Name = "btnPrevious";
            btnPrevious.Size = new Size(48, 30);
            btnPrevious.TabIndex = 46;
            btnPrevious.Text = "<<";
            btnPrevious.UseVisualStyleBackColor = true;
            btnPrevious.Click += btnPrevious_Click;
            // 
            // btnNext
            // 
            btnNext.Location = new Point(592, 704);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(45, 30);
            btnNext.TabIndex = 47;
            btnNext.Text = ">>";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // StaffInformation
            // 
            AccessibleRole = AccessibleRole.None;
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(878, 749);
            Controls.Add(btnNext);
            Controls.Add(btnPrevious);
            Controls.Add(btnEnd);
            Controls.Add(btnStart);
            Controls.Add(txtPagination);
            Controls.Add(dgvStaffInformation);
            Controls.Add(btnChooseFile);
            Controls.Add(btnDelete);
            Controls.Add(btnClear);
            Controls.Add(btnAdd);
            Controls.Add(dBirthDate);
            Controls.Add(rdfemale);
            Controls.Add(rdMale);
            Controls.Add(rdOther);
            Controls.Add(label15);
            Controls.Add(label14);
            Controls.Add(dJoinDate);
            Controls.Add(pbStaffPhoto);
            Controls.Add(rtxtAddress);
            Controls.Add(label13);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(txtPhoneNo2);
            Controls.Add(cbStaffType);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(txtPhoneNo1);
            Controls.Add(label6);
            Controls.Add(txtNrcNo);
            Controls.Add(label5);
            Controls.Add(txtAge);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtStaffName);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtStaffNo);
            Name = "StaffInformation";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Staff Information";
            Load += first_load;
            Click += StaffForm_click;
            ((System.ComponentModel.ISupportInitialize)pbStaffPhoto).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProviderCommon).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvStaffInformation).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtStaffNo;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtStaffName;
        private Label label4;
        private Label label5;
        private TextBox txtAge;
        private Label label6;
        private TextBox txtNrcNo;
        private Label label7;
        private TextBox txtPhoneNo1;
        private Label label8;
        private ComboBox cbStaffType;
        private Label label9;
        private TextBox txtPhoneNo2;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private RichTextBox rtxtAddress;
        private PictureBox pbStaffPhoto;
        private DateTimePicker dJoinDate;
        private Label label14;
        private Label label15;
        private RadioButton rdOther;
        private RadioButton rdMale;
        private RadioButton rdfemale;
        private DateTimePicker dBirthDate;
        private Button btnAdd;
        private Button btnClear;
        private Button btnDelete;
        private Button btnChooseFile;
        private ErrorProvider errorProviderCommon;
        private DataGridView dgvStaffInformation;
        private Button btnNext;
        private Button btnPrevious;
        private Button btnEnd;
        private Button btnStart;
        private TextBox txtPagination;
    }
}
