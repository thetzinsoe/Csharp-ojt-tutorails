namespace Tutorial04
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
            btnDelete = new Button();
            btnExcelExport = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvStaffInformation).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(1129, 180);
            button1.Margin = new Padding(4, 4, 4, 4);
            button1.Name = "button1";
            button1.Size = new Size(94, 42);
            button1.TabIndex = 0;
            button1.Text = "Search\r\n";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Georgia", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(561, 12);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(183, 47);
            label1.TabIndex = 2;
            label1.Text = "Staff List";
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Georgia", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearch.Location = new Point(789, 180);
            txtSearch.Margin = new Padding(4, 4, 4, 4);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(332, 40);
            txtSearch.TabIndex = 3;
            txtSearch.TextChanged += SearchBox_TextChange;
            // 
            // btnNext
            // 
            btnNext.Location = new Point(834, 742);
            btnNext.Margin = new Padding(4, 4, 4, 4);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(64, 45);
            btnNext.TabIndex = 53;
            btnNext.Text = ">>";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click_1;
            // 
            // btnPrevious
            // 
            btnPrevious.Location = new Point(388, 742);
            btnPrevious.Margin = new Padding(4, 4, 4, 4);
            btnPrevious.Name = "btnPrevious";
            btnPrevious.Size = new Size(69, 45);
            btnPrevious.TabIndex = 52;
            btnPrevious.Text = "<<";
            btnPrevious.UseVisualStyleBackColor = true;
            btnPrevious.Click += btnPrevious_Click_1;
            // 
            // btnEnd
            // 
            btnEnd.Location = new Point(740, 742);
            btnEnd.Margin = new Padding(4, 4, 4, 4);
            btnEnd.Name = "btnEnd";
            btnEnd.Size = new Size(69, 45);
            btnEnd.TabIndex = 51;
            btnEnd.Text = ">";
            btnEnd.UseVisualStyleBackColor = true;
            btnEnd.Click += btnEnd_Click_1;
            // 
            // btnStart
            // 
            btnStart.Location = new Point(479, 742);
            btnStart.Margin = new Padding(4, 4, 4, 4);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(61, 45);
            btnStart.TabIndex = 50;
            btnStart.Text = "<";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click_1;
            // 
            // txtPagination
            // 
            txtPagination.Font = new Font("Georgia", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPagination.Location = new Point(566, 742);
            txtPagination.Margin = new Padding(4, 4, 4, 4);
            txtPagination.Name = "txtPagination";
            txtPagination.ReadOnly = true;
            txtPagination.Size = new Size(148, 40);
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
            dgvStaffInformation.Location = new Point(-4, 230);
            dgvStaffInformation.Margin = new Padding(4, 4, 4, 4);
            dgvStaffInformation.MultiSelect = false;
            dgvStaffInformation.Name = "dgvStaffInformation";
            dgvStaffInformation.ReadOnly = true;
            dgvStaffInformation.RowHeadersWidth = 62;
            dgvStaffInformation.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStaffInformation.Size = new Size(1226, 475);
            dgvStaffInformation.TabIndex = 48;
            dgvStaffInformation.CellClick += cellClick_edit;
            // 
            // button2
            // 
            button2.Location = new Point(388, 80);
            button2.Margin = new Padding(4, 4, 4, 4);
            button2.Name = "button2";
            button2.Size = new Size(134, 54);
            button2.TabIndex = 54;
            button2.Text = "Add New";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button4
            // 
            button4.Location = new Point(1079, 16);
            button4.Margin = new Padding(4, 4, 4, 4);
            button4.Name = "button4";
            button4.Size = new Size(134, 54);
            button4.TabIndex = 56;
            button4.Text = "Log Out";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(580, 80);
            btnUpdate.Margin = new Padding(4, 4, 4, 4);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(134, 54);
            btnUpdate.TabIndex = 57;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(764, 80);
            btnDelete.Margin = new Padding(4, 4, 4, 4);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(134, 54);
            btnDelete.TabIndex = 58;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnExcelExport
            // 
            btnExcelExport.Location = new Point(15, 164);
            btnExcelExport.Margin = new Padding(4, 4, 4, 4);
            btnExcelExport.Name = "btnExcelExport";
            btnExcelExport.Size = new Size(134, 54);
            btnExcelExport.TabIndex = 59;
            btnExcelExport.Text = "Export to Excel";
            btnExcelExport.UseVisualStyleBackColor = true;
            btnExcelExport.Click += btnExcelExport_Click;
            // 
            // StaffList
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1228, 812);
            Controls.Add(btnExcelExport);
            Controls.Add(btnDelete);
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
            Margin = new Padding(4, 4, 4, 4);
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
        private Button btnDelete;
        private Button btnExcelExport;
    }
}