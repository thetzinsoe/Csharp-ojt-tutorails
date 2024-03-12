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
            lvStaffInfo = new ListView();
            lvStaffNo = new ColumnHeader();
            lvImage = new ColumnHeader();
            lvStaffName = new ColumnHeader();
            lvJoinForm = new ColumnHeader();
            lvStaffType = new ColumnHeader();
            lvNrcNo = new ColumnHeader();
            lvGender = new ColumnHeader();
            lvAge = new ColumnHeader();
            lvPhoneNo = new ColumnHeader();
            lvPhoneNo2 = new ColumnHeader();
            lvAddress = new ColumnHeader();
            btnChooseFile = new Button();
            errorProviderCommon = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)pbStaffPhoto).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProviderCommon).BeginInit();
            SuspendLayout();
            // 
            // txtStaffNo
            // 
            txtStaffNo.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtStaffNo.Location = new Point(232, 79);
            txtStaffNo.Name = "txtStaffNo";
            txtStaffNo.ReadOnly = true;
            txtStaffNo.Size = new Size(223, 26);
            txtStaffNo.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Georgia", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(393, 9);
            label1.Name = "label1";
            label1.Size = new Size(231, 25);
            label1.TabIndex = 1;
            label1.Text = "Staff Information Form";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(125, 87);
            label2.Name = "label2";
            label2.Size = new Size(69, 18);
            label2.TabIndex = 2;
            label2.Text = "Staff No.";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(125, 146);
            label3.Name = "label3";
            label3.Size = new Size(87, 18);
            label3.TabIndex = 4;
            label3.Text = "Staff Name";
            // 
            // txtStaffName
            // 
            txtStaffName.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtStaffName.Location = new Point(232, 138);
            txtStaffName.Name = "txtStaffName";
            txtStaffName.Size = new Size(223, 26);
            txtStaffName.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(125, 208);
            label4.Name = "label4";
            label4.Size = new Size(80, 18);
            label4.TabIndex = 6;
            label4.Text = "Join From";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(125, 263);
            label5.Name = "label5";
            label5.Size = new Size(98, 18);
            label5.TabIndex = 8;
            label5.Text = "Date of Birth";
            // 
            // txtAge
            // 
            txtAge.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtAge.Location = new Point(231, 309);
            txtAge.Name = "txtAge";
            txtAge.ReadOnly = true;
            txtAge.Size = new Size(223, 26);
            txtAge.TabIndex = 7;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(125, 309);
            label6.Name = "label6";
            label6.Size = new Size(35, 18);
            label6.TabIndex = 10;
            label6.Text = "Age";
            // 
            // txtNrcNo
            // 
            txtNrcNo.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNrcNo.Location = new Point(231, 419);
            txtNrcNo.Name = "txtNrcNo";
            txtNrcNo.Size = new Size(223, 26);
            txtNrcNo.TabIndex = 9;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(125, 364);
            label7.Name = "label7";
            label7.Size = new Size(82, 18);
            label7.TabIndex = 12;
            label7.Text = "Staff Type";
            // 
            // txtPhoneNo1
            // 
            txtPhoneNo1.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPhoneNo1.Location = new Point(622, 133);
            txtPhoneNo1.Name = "txtPhoneNo1";
            txtPhoneNo1.Size = new Size(223, 26);
            txtPhoneNo1.TabIndex = 11;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(125, 419);
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
            cbStaffType.Location = new Point(232, 361);
            cbStaffType.Name = "cbStaffType";
            cbStaffType.Size = new Size(222, 26);
            cbStaffType.TabIndex = 14;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(515, 141);
            label9.Name = "label9";
            label9.Size = new Size(76, 18);
            label9.TabIndex = 16;
            label9.Text = "Phone No";
            // 
            // txtPhoneNo2
            // 
            txtPhoneNo2.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPhoneNo2.Location = new Point(622, 200);
            txtPhoneNo2.Name = "txtPhoneNo2";
            txtPhoneNo2.Size = new Size(223, 26);
            txtPhoneNo2.TabIndex = 15;
            // 
            // label10
            // 
            label10.Location = new Point(0, 0);
            label10.Name = "label10";
            label10.Size = new Size(100, 24);
            label10.TabIndex = 27;
            // 
            // label11
            // 
            label11.Location = new Point(0, 0);
            label11.Name = "label11";
            label11.Size = new Size(100, 24);
            label11.TabIndex = 26;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.Location = new Point(515, 263);
            label12.Name = "label12";
            label12.Size = new Size(53, 18);
            label12.TabIndex = 22;
            label12.Text = "Image";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label13.Location = new Point(510, 361);
            label13.Name = "label13";
            label13.Size = new Size(66, 18);
            label13.TabIndex = 24;
            label13.Text = "Address";
            // 
            // rtxtAddress
            // 
            rtxtAddress.Location = new Point(622, 364);
            rtxtAddress.Name = "rtxtAddress";
            rtxtAddress.Size = new Size(278, 102);
            rtxtAddress.TabIndex = 25;
            rtxtAddress.Text = "";
            // 
            // pbStaffPhoto
            // 
            pbStaffPhoto.BorderStyle = BorderStyle.FixedSingle;
            pbStaffPhoto.Location = new Point(622, 261);
            pbStaffPhoto.Name = "pbStaffPhoto";
            pbStaffPhoto.Size = new Size(80, 85);
            pbStaffPhoto.SizeMode = PictureBoxSizeMode.StretchImage;
            pbStaffPhoto.TabIndex = 28;
            pbStaffPhoto.TabStop = false;
            // 
            // dJoinDate
            // 
            dJoinDate.Location = new Point(231, 208);
            dJoinDate.MinDate = new DateTime(1920, 1, 1, 0, 0, 0, 0);
            dJoinDate.Name = "dJoinDate";
            dJoinDate.Size = new Size(224, 27);
            dJoinDate.TabIndex = 29;
            dJoinDate.ValueChanged += dJoinDate_ValueChanged;
            dJoinDate.Validating += djoinDate_Validate;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label14.Location = new Point(515, 203);
            label14.Name = "label14";
            label14.Size = new Size(76, 18);
            label14.TabIndex = 30;
            label14.Text = "Phone No";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label15.Location = new Point(515, 82);
            label15.Name = "label15";
            label15.Size = new Size(61, 18);
            label15.TabIndex = 31;
            label15.Text = "Gender";
            // 
            // rdOther
            // 
            rdOther.AutoSize = true;
            rdOther.Location = new Point(622, 85);
            rdOther.Name = "rdOther";
            rdOther.Size = new Size(64, 24);
            rdOther.TabIndex = 32;
            rdOther.TabStop = true;
            rdOther.Text = "Other";
            rdOther.UseVisualStyleBackColor = true;
            // 
            // rdMale
            // 
            rdMale.AutoSize = true;
            rdMale.Location = new Point(724, 85);
            rdMale.Name = "rdMale";
            rdMale.Size = new Size(60, 24);
            rdMale.TabIndex = 33;
            rdMale.TabStop = true;
            rdMale.Text = "Male";
            rdMale.UseVisualStyleBackColor = true;
            // 
            // rdfemale
            // 
            rdfemale.AutoSize = true;
            rdfemale.Location = new Point(830, 85);
            rdfemale.Name = "rdfemale";
            rdfemale.Size = new Size(75, 24);
            rdfemale.TabIndex = 34;
            rdfemale.TabStop = true;
            rdfemale.Text = "Female";
            rdfemale.UseVisualStyleBackColor = true;
            // 
            // dBirthDate
            // 
            dBirthDate.Location = new Point(232, 263);
            dBirthDate.MinDate = new DateTime(1920, 1, 1, 0, 0, 0, 0);
            dBirthDate.Name = "dBirthDate";
            dBirthDate.Size = new Size(224, 27);
            dBirthDate.TabIndex = 35;
            dBirthDate.ValueChanged += dBirthDate_ValueChanged;
            dBirthDate.Validating += birthDate_Validation;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(301, 491);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(120, 36);
            btnAdd.TabIndex = 36;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(457, 491);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(120, 36);
            btnClear.TabIndex = 37;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(612, 491);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(120, 36);
            btnDelete.TabIndex = 38;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // lvStaffInfo
            // 
            lvStaffInfo.Columns.AddRange(new ColumnHeader[] { lvStaffNo, lvImage, lvStaffName, lvJoinForm, lvStaffType, lvNrcNo, lvGender, lvAge, lvPhoneNo, lvPhoneNo2, lvAddress });
            lvStaffInfo.Location = new Point(37, 559);
            lvStaffInfo.Name = "lvStaffInfo";
            lvStaffInfo.Size = new Size(929, 199);
            lvStaffInfo.TabIndex = 39;
            lvStaffInfo.UseCompatibleStateImageBehavior = false;
            lvStaffInfo.View = View.Details;
            // 
            // lvStaffNo
            // 
            lvStaffNo.Text = "Staff No.";
            lvStaffNo.Width = 75;
            // 
            // lvImage
            // 
            lvImage.Text = "Image";
            lvImage.Width = 65;
            // 
            // lvStaffName
            // 
            lvStaffName.Text = "Staff Name";
            lvStaffName.Width = 90;
            // 
            // lvJoinForm
            // 
            lvJoinForm.Text = "Join From";
            lvJoinForm.Width = 80;
            // 
            // lvStaffType
            // 
            lvStaffType.Text = "Staff Type";
            lvStaffType.Width = 80;
            // 
            // lvNrcNo
            // 
            lvNrcNo.Text = "NRC No";
            lvNrcNo.Width = 70;
            // 
            // lvGender
            // 
            lvGender.Text = "Gender";
            // 
            // lvAge
            // 
            lvAge.Text = "Age";
            // 
            // lvPhoneNo
            // 
            lvPhoneNo.Text = "Phone No";
            lvPhoneNo.Width = 80;
            // 
            // lvPhoneNo2
            // 
            lvPhoneNo2.Text = "Phone No";
            lvPhoneNo2.Width = 80;
            // 
            // lvAddress
            // 
            lvAddress.Text = "Address";
            lvAddress.Width = 85;
            // 
            // btnChooseFile
            // 
            btnChooseFile.Location = new Point(724, 261);
            btnChooseFile.Name = "btnChooseFile";
            btnChooseFile.Size = new Size(176, 36);
            btnChooseFile.TabIndex = 40;
            btnChooseFile.Text = "Choose File";
            btnChooseFile.UseVisualStyleBackColor = true;
            btnChooseFile.Click += clickChooseFile;
            // 
            // errorProviderCommon
            // 
            errorProviderCommon.ContainerControl = this;
            // 
            // StaffInformation
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1013, 749);
            Controls.Add(btnChooseFile);
            Controls.Add(lvStaffInfo);
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
            Text = "Staff Information";
            ((System.ComponentModel.ISupportInitialize)pbStaffPhoto).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProviderCommon).EndInit();
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
        private ListView lvStaffInfo;
        private ColumnHeader lvStaffNo;
        private ColumnHeader lvStaffName;
        private ColumnHeader lvJoinForm;
        private ColumnHeader lvAge;
        private ColumnHeader lvStaffType;
        private ColumnHeader lvNrcNo;
        private ColumnHeader lvGender;
        private ColumnHeader lvPhoneNo;
        private ColumnHeader lvImage;
        private ColumnHeader lvAddress;
        private ColumnHeader lvPhoneNo2;
        private Button btnChooseFile;
        private ErrorProvider errorProviderCommon;
    }
}
