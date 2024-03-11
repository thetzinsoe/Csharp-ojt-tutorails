namespace Tutorial02_Loan_Window_Form_App__Thetzinsoe
{
    partial class Form1
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            btnCalculate = new Button();
            label5 = new Label();
            label6 = new Label();
            numUpLoan = new NumericUpDown();
            numUpInterest = new NumericUpDown();
            numUpDuration = new NumericUpDown();
            txtInterest = new TextBox();
            txtTotal = new TextBox();
            ((System.ComponentModel.ISupportInitialize)numUpLoan).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numUpInterest).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numUpDuration).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Georgia", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(232, 18);
            label1.Name = "label1";
            label1.Size = new Size(306, 31);
            label1.TabIndex = 0;
            label1.Text = "Interest Rate Calcuation";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Georgia", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(104, 100);
            label2.Name = "label2";
            label2.Size = new Size(158, 29);
            label2.TabIndex = 2;
            label2.Text = "Loan Amount";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Georgia", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(104, 167);
            label3.Name = "label3";
            label3.Size = new Size(189, 29);
            label3.TabIndex = 4;
            label3.Text = "Interest Rate(%)";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Georgia", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(104, 226);
            label4.Name = "label4";
            label4.Size = new Size(267, 29);
            label4.TabIndex = 6;
            label4.Text = "Loan Duration(Months)";
            // 
            // btnCalculate
            // 
            btnCalculate.BackColor = Color.Blue;
            btnCalculate.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCalculate.ForeColor = Color.White;
            btnCalculate.Location = new Point(278, 297);
            btnCalculate.Name = "btnCalculate";
            btnCalculate.Size = new Size(200, 40);
            btnCalculate.TabIndex = 7;
            btnCalculate.Text = "Calculate";
            btnCalculate.UseVisualStyleBackColor = false;
            btnCalculate.Click += btnCalculate_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Georgia", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(174, 417);
            label5.Name = "label5";
            label5.Size = new Size(188, 29);
            label5.TabIndex = 8;
            label5.Text = "Interest Amount";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Georgia", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(174, 459);
            label6.Name = "label6";
            label6.Size = new Size(160, 29);
            label6.TabIndex = 9;
            label6.Text = "Total Amount";
            // 
            // numUpLoan
            // 
            numUpLoan.Font = new Font("Georgia", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numUpLoan.Location = new Point(453, 100);
            numUpLoan.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            numUpLoan.Name = "numUpLoan";
            numUpLoan.Size = new Size(164, 35);
            numUpLoan.TabIndex = 10;
            // 
            // numUpInterest
            // 
            numUpInterest.Font = new Font("Georgia", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numUpInterest.Location = new Point(453, 161);
            numUpInterest.Name = "numUpInterest";
            numUpInterest.Size = new Size(164, 35);
            numUpInterest.TabIndex = 11;
            // 
            // numUpDuration
            // 
            numUpDuration.Font = new Font("Georgia", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numUpDuration.Location = new Point(453, 220);
            numUpDuration.Maximum = new decimal(new int[] { 12, 0, 0, 0 });
            numUpDuration.Name = "numUpDuration";
            numUpDuration.Size = new Size(164, 35);
            numUpDuration.TabIndex = 12;
            // 
            // txtInterest
            // 
            txtInterest.Font = new Font("Georgia", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtInterest.Location = new Point(414, 411);
            txtInterest.Name = "txtInterest";
            txtInterest.ReadOnly = true;
            txtInterest.Size = new Size(100, 35);
            txtInterest.TabIndex = 13;
            // 
            // txtTotal
            // 
            txtTotal.Font = new Font("Georgia", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTotal.Location = new Point(414, 456);
            txtTotal.Name = "txtTotal";
            txtTotal.ReadOnly = true;
            txtTotal.Size = new Size(100, 35);
            txtTotal.TabIndex = 14;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(732, 541);
            Controls.Add(txtTotal);
            Controls.Add(txtInterest);
            Controls.Add(numUpDuration);
            Controls.Add(numUpInterest);
            Controls.Add(numUpLoan);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(btnCalculate);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Loan Interest";
            ((System.ComponentModel.ISupportInitialize)numUpLoan).EndInit();
            ((System.ComponentModel.ISupportInitialize)numUpInterest).EndInit();
            ((System.ComponentModel.ISupportInitialize)numUpDuration).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button btnCalculate;
        private Label label5;
        private Label label6;
        private NumericUpDown numUpLoan;
        private NumericUpDown numUpInterest;
        private NumericUpDown numUpDuration;
        private TextBox txtInterest;
        private TextBox txtTotal;
    }
}
