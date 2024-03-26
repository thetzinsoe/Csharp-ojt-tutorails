using System.Drawing;
using System.Windows.Forms;

namespace Tuto11.App.Views
{
    partial class StaffList
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
            button1 = new Button();
            label1 = new Label();
            txtSearch = new TextBox();
            btnNext = new Button();
            btnPrevious = new Button();
            btnEnd = new Button();
            btnStart = new Button();
            txtPagination = new TextBox();
            dgvStaffInformation = new DataGridView();
            button2 = new Button();
            button4 = new Button();
            btnUpdate = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvStaffInformation).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(790, 108);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(66, 25);
            button1.TabIndex = 0;
            button1.Text = "Search\r\n";
            button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Georgia", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(393, 7);
            label1.Name = "label1";
            label1.Size = new Size(122, 31);
            label1.TabIndex = 2;
            label1.Text = "Staff List";
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Georgia", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearch.Location = new Point(552, 108);
            txtSearch.Margin = new Padding(3, 2, 3, 2);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(233, 29);
            txtSearch.TabIndex = 3;
            // 
            // btnNext
            // 
            btnNext.Location = new Point(584, 445);
            btnNext.Margin = new Padding(3, 2, 3, 2);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(45, 27);
            btnNext.TabIndex = 53;
            btnNext.Text = ">>";
            btnNext.UseVisualStyleBackColor = true;
            // 
            // btnPrevious
            // 
            btnPrevious.Location = new Point(271, 445);
            btnPrevious.Margin = new Padding(3, 2, 3, 2);
            btnPrevious.Name = "btnPrevious";
            btnPrevious.Size = new Size(48, 27);
            btnPrevious.TabIndex = 52;
            btnPrevious.Text = "<<";
            btnPrevious.UseVisualStyleBackColor = true;
            // 
            // btnEnd
            // 
            btnEnd.Location = new Point(518, 445);
            btnEnd.Margin = new Padding(3, 2, 3, 2);
            btnEnd.Name = "btnEnd";
            btnEnd.Size = new Size(48, 27);
            btnEnd.TabIndex = 51;
            btnEnd.Text = ">";
            btnEnd.UseVisualStyleBackColor = true;
            // 
            // btnStart
            // 
            btnStart.Location = new Point(335, 445);
            btnStart.Margin = new Padding(3, 2, 3, 2);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(43, 27);
            btnStart.TabIndex = 50;
            btnStart.Text = "<";
            btnStart.UseVisualStyleBackColor = true;
            // 
            // txtPagination
            // 
            txtPagination.Font = new Font("Georgia", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPagination.Location = new Point(396, 445);
            txtPagination.Margin = new Padding(3, 2, 3, 2);
            txtPagination.Name = "txtPagination";
            txtPagination.ReadOnly = true;
            txtPagination.Size = new Size(105, 29);
            txtPagination.TabIndex = 49;
            txtPagination.TextAlign = HorizontalAlignment.Center;
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
            dgvStaffInformation.Location = new Point(-3, 138);
            dgvStaffInformation.Margin = new Padding(3, 2, 3, 2);
            dgvStaffInformation.MultiSelect = false;
            dgvStaffInformation.Name = "dgvStaffInformation";
            dgvStaffInformation.ReadOnly = true;
            dgvStaffInformation.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStaffInformation.Size = new Size(858, 285);
            dgvStaffInformation.TabIndex = 48;
            // 
            // button2
            // 
            button2.Location = new Point(284, 48);
            button2.Margin = new Padding(3, 2, 3, 2);
            button2.Name = "button2";
            button2.Size = new Size(94, 32);
            button2.TabIndex = 54;
            button2.Text = "Add New";
            button2.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(552, 48);
            button4.Margin = new Padding(3, 2, 3, 2);
            button4.Name = "button4";
            button4.Size = new Size(94, 32);
            button4.TabIndex = 56;
            button4.Text = "Log Out";
            button4.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(421, 48);
            btnUpdate.Margin = new Padding(3, 2, 3, 2);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(94, 32);
            btnUpdate.TabIndex = 57;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            // 
            // StaffList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(859, 487);
            Controls.Add(btnUpdate);
            Controls.Add(button4);
            Controls.Add(button2);
            Controls.Add(btnNext);
            Controls.Add(btnPrevious);
            Controls.Add(btnEnd);
            Controls.Add(btnStart);
            Controls.Add(txtPagination);
            Controls.Add(dgvStaffInformation);
            Controls.Add(txtSearch);
            Controls.Add(label1);
            Controls.Add(button1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "StaffList";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "StaffList";
            ((System.ComponentModel.ISupportInitialize)dgvStaffInformation).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
        private TextBox txtSearch;
        private Button btnNext;
        private Button btnPrevious;
        private Button btnEnd;
        private Button btnStart;
        private TextBox txtPagination;
        private DataGridView dgvStaffInformation;
        private Button button2;
        private Button button4;
        private Button btnUpdate;
    }
}