using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tutorial03;
using Tutorial4;
using static System.Net.Mime.MediaTypeNames;

namespace Tutorial04
{
    public partial class StaffList : Form
    {
        string staffName = "";
        private int currentPage = 1;
        private int pageSize = 5;
        private int totalRecords = 0;
        private int countPage = 0;
        private readonly DataTable staffDataTable = new DataTable();
        DBAccess DB = new DBAccess();
        string imagePath = "";
        byte[] imageData = new byte[0];
        byte[] noImage = File.ReadAllBytes(Environment.CurrentDirectory + "\\Images\\noImage.png");

        public StaffList()
        {
            InitializeComponent();
            staffDataTable.Columns.Add("Staff No.", typeof(int));
            staffDataTable.Columns.Add("Image", typeof(byte[]));
            staffDataTable.Columns.Add("Staff Name", typeof(string));
            staffDataTable.Columns.Add("Join From", typeof(DateTime));
            staffDataTable.Columns.Add("Staff Type", typeof(string));
            staffDataTable.Columns.Add("NRC No", typeof(string));
            staffDataTable.Columns.Add("Gender", typeof(string));
            staffDataTable.Columns.Add("Age", typeof(int));
            staffDataTable.Columns.Add("Phone No1", typeof(string));
            staffDataTable.Columns.Add("Phone No2", typeof(string));
            staffDataTable.Columns.Add("Address", typeof(string));

            DataGridViewTextBoxColumn staffNoColumn = new DataGridViewTextBoxColumn();
            staffNoColumn.HeaderText = "Staff No.";
            staffNoColumn.DataPropertyName = "Staff No.";
            dgvStaffInformation.Columns.Add(staffNoColumn);
            DataGridViewImageColumn imgColumn = new DataGridViewImageColumn();
            imgColumn.HeaderText = "Image";
            imgColumn.DataPropertyName = "Image";
            imgColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
            dgvStaffInformation.Columns.Add(imgColumn);
            dgvStaffInformation.DataSource = staffDataTable;
            LoadData();
        }

        private void LoadData()
        {
            string countQuery = "SELECT COUNT(*) FROM Tuto07;";
            totalRecords = Convert.ToInt32(DB.ExecuteScalar(countQuery));
            countPage = (int)Math.Ceiling((double)totalRecords / pageSize);
            txtPagination.Text = $"{currentPage}/{countPage}";
            int offset = (currentPage - 1) * pageSize;

            string query = $"SELECT * FROM Tuto07 ORDER BY [Id] OFFSET {offset} ROWS FETCH NEXT {pageSize} ROWS ONLY;";
            SqlDataReader reader = DB.readDatathroughReader(query);

            if (reader.HasRows)
            {
                staffDataTable.Clear(); // Clear existing data
                while (reader.Read())
                {
                    DataRow newRow = staffDataTable.NewRow();
                    newRow["Staff No."] = reader.GetInt32(0);
                    imagePath = reader.GetString(1);
                    if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
                    {
                        imageData = File.ReadAllBytes(imagePath);
                        newRow["Image"] = imageData;
                    }
                    else
                    {
                        newRow["Image"] = noImage;
                    }
                    newRow["Staff Name"] = reader.GetString(2);
                    newRow["Join From"] = reader.GetDateTime(3).Date;
                    newRow["Staff Type"] = reader.GetString(4);
                    newRow["NRC No"] = reader.GetString(5);
                    newRow["Gender"] = reader.GetString(6);
                    newRow["Age"] = (DateTime.Today.Year - reader.GetDateTime(10).Year).ToString();
                    newRow["Phone No1"] = reader.GetInt32(7);
                    newRow["Phone No2"] = reader.GetInt32(8);
                    newRow["Address"] = reader.GetString(9);
                    staffDataTable.Rows.Add(newRow);
                }
                DataGridViewRow selectedRow = dgvStaffInformation.Rows[0];
                var selectedCell = selectedRow.Cells[2].Value; // Assuming the staffName is in the second column (index 1)
                staffName = Convert.ToString(selectedCell);
              
                 //   dgvStaffInformation.Rows[0].Selected = false; // Deselect the first row
                
            }
            reader.Close();
        }


        private void btnStart_Click_1(object sender, EventArgs e)
        {
            currentPage = 1;
            LoadData();
            btnPrevious.Enabled = false;
            btnNext.Enabled = true;
        }

        private void btnEnd_Click_1(object sender, EventArgs e)
        {
            currentPage = countPage;
            LoadData();
            btnPrevious.Enabled = true;
            btnNext.Enabled = false;
        }

        private void btnPrevious_Click_1(object sender, EventArgs e)
        {

            if (currentPage > 1)
            {
                currentPage--;
                LoadData();
                btnNext.Enabled = true;
            }
            else
            {
                btnPrevious.Enabled = false;
            }
        }

        private void btnNext_Click_1(object sender, EventArgs e)
        {
            currentPage++;
            LoadData();
            if (currentPage == countPage)
            {
                btnNext.Enabled = false;
            }
            else
            {
                btnNext.Enabled = true;
            }
            btnPrevious.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register re = new Register();
            re.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login lg = new Login();
            lg.Show();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            this.Hide();
            StaffInformation si = new StaffInformation(staffName);
            si.Show();
        }

        private void cellClick_edit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvStaffInformation.Rows[e.RowIndex];
                var selectedCell = selectedRow.Cells[2].Value; // Assuming the staffName is in the second column (index 1)
                staffName = Convert.ToString(selectedCell);
            }
        }
    }
}
