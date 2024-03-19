﻿namespace Tutorial04
{
    partial class Register
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
            components = new System.ComponentModel.Container();
            label5 = new Label();
            errorProviderCommon = new ErrorProvider(components);
            btnRegister = new Button();
            label16 = new Label();
            txtConfirmPassword = new TextBox();
            label11 = new Label();
            txtPassword = new TextBox();
            btnChooseFile = new Button();
            btnClear = new Button();
            dBirthDate = new DateTimePicker();
            rdfemale = new RadioButton();
            rdMale = new RadioButton();
            rdOther = new RadioButton();
            label15 = new Label();
            label14 = new Label();
            dJoinDate = new DateTimePicker();
            pbStaffPhoto = new PictureBox();
            rtxtAddress = new RichTextBox();
            label13 = new Label();
            label12 = new Label();
            label9 = new Label();
            txtPhoneNo2 = new TextBox();
            cbStaffType = new ComboBox();
            label8 = new Label();
            label7 = new Label();
            txtPhoneNo1 = new TextBox();
            label6 = new Label();
            txtNrcNo = new TextBox();
            label1 = new Label();
            txtAge = new TextBox();
            label4 = new Label();
            label3 = new Label();
            txtStaffName = new TextBox();
            label2 = new Label();
            label10 = new Label();
            txtStaffNo = new TextBox();
            ((System.ComponentModel.ISupportInitialize)errorProviderCommon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbStaffPhoto).BeginInit();
            SuspendLayout();
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Cursor = Cursors.Hand;
            label5.ForeColor = Color.Red;
            label5.Location = new Point(45, 531);
            label5.Name = "label5";
            label5.Size = new Size(206, 17);
            label5.TabIndex = 4;
            label5.Text = "Are you a member? Click to login!";
            label5.Click += label5_Click;
            // 
            // errorProviderCommon
            // 
            errorProviderCommon.ContainerControl = this;
            // 
            // btnRegister
            // 
            btnRegister.Location = new Point(290, 524);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(105, 30);
            btnRegister.TabIndex = 82;
            btnRegister.Text = "Register";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click_1;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label16.Location = new Point(46, 446);
            label16.Name = "label16";
            label16.Size = new Size(137, 18);
            label16.TabIndex = 80;
            label16.Text = "Confirm Password";
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtConfirmPassword.Location = new Point(194, 446);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new Size(196, 26);
            txtConfirmPassword.TabIndex = 79;
            txtConfirmPassword.UseSystemPasswordChar = true;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.Location = new Point(46, 406);
            label11.Name = "label11";
            label11.Size = new Size(76, 18);
            label11.TabIndex = 78;
            label11.Text = "Password";
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.Location = new Point(195, 406);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(196, 26);
            txtPassword.TabIndex = 77;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // btnChooseFile
            // 
            btnChooseFile.Location = new Point(606, 319);
            btnChooseFile.Name = "btnChooseFile";
            btnChooseFile.Size = new Size(154, 30);
            btnChooseFile.TabIndex = 76;
            btnChooseFile.Text = "Choose File";
            btnChooseFile.UseVisualStyleBackColor = true;
            btnChooseFile.Click += btnChooseFile_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(422, 524);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(105, 30);
            btnClear.TabIndex = 75;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            // 
            // dBirthDate
            // 
            dBirthDate.Location = new Point(195, 278);
            dBirthDate.MinDate = new DateTime(1920, 1, 1, 0, 0, 0, 0);
            dBirthDate.Name = "dBirthDate";
            dBirthDate.Size = new Size(196, 25);
            dBirthDate.TabIndex = 73;
            dBirthDate.ValueChanged += dBirthDate_valueChange;
            // 
            // rdfemale
            // 
            rdfemale.AutoSize = true;
            rdfemale.Location = new Point(697, 168);
            rdfemale.Name = "rdfemale";
            rdfemale.Size = new Size(67, 21);
            rdfemale.TabIndex = 72;
            rdfemale.TabStop = true;
            rdfemale.Text = "Female";
            rdfemale.UseVisualStyleBackColor = true;
            // 
            // rdMale
            // 
            rdMale.AutoSize = true;
            rdMale.Location = new Point(606, 168);
            rdMale.Name = "rdMale";
            rdMale.Size = new Size(55, 21);
            rdMale.TabIndex = 71;
            rdMale.TabStop = true;
            rdMale.Text = "Male";
            rdMale.UseVisualStyleBackColor = true;
            // 
            // rdOther
            // 
            rdOther.AutoSize = true;
            rdOther.Location = new Point(515, 168);
            rdOther.Name = "rdOther";
            rdOther.Size = new Size(59, 21);
            rdOther.TabIndex = 70;
            rdOther.TabStop = true;
            rdOther.Text = "Other";
            rdOther.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label15.Location = new Point(422, 167);
            label15.Name = "label15";
            label15.Size = new Size(61, 18);
            label15.TabIndex = 69;
            label15.Text = "Gender";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label14.Location = new Point(422, 269);
            label14.Name = "label14";
            label14.Size = new Size(76, 18);
            label14.TabIndex = 68;
            label14.Text = "Phone No";
            // 
            // dJoinDate
            // 
            dJoinDate.Location = new Point(194, 232);
            dJoinDate.MinDate = new DateTime(1920, 1, 1, 0, 0, 0, 0);
            dJoinDate.Name = "dJoinDate";
            dJoinDate.Size = new Size(196, 25);
            dJoinDate.TabIndex = 67;
            dJoinDate.ValueChanged += dJoinFrom_valueChange;
            // 
            // pbStaffPhoto
            // 
            pbStaffPhoto.BorderStyle = BorderStyle.FixedSingle;
            pbStaffPhoto.Location = new Point(515, 319);
            pbStaffPhoto.Name = "pbStaffPhoto";
            pbStaffPhoto.Size = new Size(70, 73);
            pbStaffPhoto.SizeMode = PictureBoxSizeMode.StretchImage;
            pbStaffPhoto.TabIndex = 66;
            pbStaffPhoto.TabStop = false;
            // 
            // rtxtAddress
            // 
            rtxtAddress.Location = new Point(515, 406);
            rtxtAddress.Name = "rtxtAddress";
            rtxtAddress.Size = new Size(244, 86);
            rtxtAddress.TabIndex = 65;
            rtxtAddress.Text = "";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label13.Location = new Point(417, 404);
            label13.Name = "label13";
            label13.Size = new Size(66, 18);
            label13.TabIndex = 64;
            label13.Text = "Address";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.Location = new Point(422, 320);
            label12.Name = "label12";
            label12.Size = new Size(53, 18);
            label12.TabIndex = 63;
            label12.Text = "Image";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(422, 217);
            label9.Name = "label9";
            label9.Size = new Size(76, 18);
            label9.TabIndex = 62;
            label9.Text = "Phone No";
            // 
            // txtPhoneNo2
            // 
            txtPhoneNo2.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPhoneNo2.Location = new Point(515, 267);
            txtPhoneNo2.Name = "txtPhoneNo2";
            txtPhoneNo2.Size = new Size(196, 26);
            txtPhoneNo2.TabIndex = 61;
            // 
            // cbStaffType
            // 
            cbStaffType.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbStaffType.FormattingEnabled = true;
            cbStaffType.Items.AddRange(new object[] { "Full Time", "Part Time" });
            cbStaffType.Location = new Point(195, 361);
            cbStaffType.Name = "cbStaffType";
            cbStaffType.Size = new Size(195, 26);
            cbStaffType.TabIndex = 60;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(419, 131);
            label8.Name = "label8";
            label8.Size = new Size(65, 18);
            label8.TabIndex = 59;
            label8.Text = "NRC No";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(46, 364);
            label7.Name = "label7";
            label7.Size = new Size(82, 18);
            label7.TabIndex = 58;
            label7.Text = "Staff Type";
            // 
            // txtPhoneNo1
            // 
            txtPhoneNo1.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPhoneNo1.Location = new Point(515, 208);
            txtPhoneNo1.Name = "txtPhoneNo1";
            txtPhoneNo1.Size = new Size(196, 26);
            txtPhoneNo1.TabIndex = 57;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(45, 318);
            label6.Name = "label6";
            label6.Size = new Size(35, 18);
            label6.TabIndex = 56;
            label6.Text = "Age";
            // 
            // txtNrcNo
            // 
            txtNrcNo.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNrcNo.Location = new Point(515, 123);
            txtNrcNo.Name = "txtNrcNo";
            txtNrcNo.Size = new Size(196, 26);
            txtNrcNo.TabIndex = 55;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(46, 278);
            label1.Name = "label1";
            label1.Size = new Size(98, 18);
            label1.TabIndex = 54;
            label1.Text = "Date of Birth";
            // 
            // txtAge
            // 
            txtAge.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtAge.Location = new Point(194, 318);
            txtAge.Name = "txtAge";
            txtAge.ReadOnly = true;
            txtAge.Size = new Size(196, 26);
            txtAge.TabIndex = 53;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(46, 232);
            label4.Name = "label4";
            label4.Size = new Size(80, 18);
            label4.TabIndex = 52;
            label4.Text = "Join From";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(46, 179);
            label3.Name = "label3";
            label3.Size = new Size(87, 18);
            label3.TabIndex = 51;
            label3.Text = "Staff Name";
            // 
            // txtStaffName
            // 
            txtStaffName.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtStaffName.Location = new Point(195, 171);
            txtStaffName.Name = "txtStaffName";
            txtStaffName.Size = new Size(196, 26);
            txtStaffName.TabIndex = 50;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(46, 130);
            label2.Name = "label2";
            label2.Size = new Size(69, 18);
            label2.TabIndex = 49;
            label2.Text = "Staff No.";
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label10.AutoSize = true;
            label10.Font = new Font("Georgia", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.Location = new Point(305, 32);
            label10.Name = "label10";
            label10.Size = new Size(186, 31);
            label10.TabIndex = 48;
            label10.Text = "Register Form";
            label10.TextAlign = ContentAlignment.TopCenter;
            // 
            // txtStaffNo
            // 
            txtStaffNo.Enabled = false;
            txtStaffNo.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtStaffNo.Location = new Point(195, 122);
            txtStaffNo.Name = "txtStaffNo";
            txtStaffNo.ReadOnly = true;
            txtStaffNo.Size = new Size(196, 26);
            txtStaffNo.TabIndex = 47;
            // 
            // Register
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(803, 580);
            Controls.Add(btnRegister);
            Controls.Add(label16);
            Controls.Add(txtConfirmPassword);
            Controls.Add(label11);
            Controls.Add(txtPassword);
            Controls.Add(btnChooseFile);
            Controls.Add(btnClear);
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
            Controls.Add(label9);
            Controls.Add(txtPhoneNo2);
            Controls.Add(cbStaffType);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(txtPhoneNo1);
            Controls.Add(label6);
            Controls.Add(txtNrcNo);
            Controls.Add(label1);
            Controls.Add(txtAge);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtStaffName);
            Controls.Add(label2);
            Controls.Add(label10);
            Controls.Add(txtStaffNo);
            Controls.Add(label5);
            Name = "Register";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Register";
            ((System.ComponentModel.ISupportInitialize)errorProviderCommon).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbStaffPhoto).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label5;
        private ErrorProvider errorProviderCommon;
        private Button btnRegister;
        private Label label16;
        private TextBox txtConfirmPassword;
        private Label label11;
        private TextBox txtPassword;
        private Button btnChooseFile;
        private Button btnClear;
        private DateTimePicker dBirthDate;
        private RadioButton rdfemale;
        private RadioButton rdMale;
        private RadioButton rdOther;
        private Label label15;
        private Label label14;
        private DateTimePicker dJoinDate;
        private PictureBox pbStaffPhoto;
        private RichTextBox rtxtAddress;
        private Label label13;
        private Label label12;
        private Label label9;
        private TextBox txtPhoneNo2;
        private ComboBox cbStaffType;
        private Label label8;
        private Label label7;
        private TextBox txtPhoneNo1;
        private Label label6;
        private TextBox txtNrcNo;
        private Label label1;
        private TextBox txtAge;
        private Label label4;
        private Label label3;
        private TextBox txtStaffName;
        private Label label2;
        private Label label10;
        private TextBox txtStaffNo;
    }
}