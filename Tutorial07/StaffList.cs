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
using Tutorial4;
using static System.Net.Mime.MediaTypeNames;

namespace Tutorial04
{
    public partial class StaffList : Form
    {
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
        }

        private void StaffList_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            string countQuery = "SELECT COUNT(*) FROM StaffInformation;";
            totalRecords = Convert.ToInt32(DB.ExecuteScalar(countQuery));
            countPage = (int)Math.Ceiling((double)totalRecords / pageSize);
            txtPagination.Text = $"{currentPage}/{countPage}";
            int offset = (currentPage - 1) * pageSize;

            string query = $"SELECT * FROM StaffInformation ORDER BY [Id] OFFSET {offset} ROWS FETCH NEXT {pageSize} ROWS ONLY;";
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
                dgvStaffInformation.Rows[0].Selected = false;
            }
            reader.Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
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

        private void btnPrevious_Click(object sender, EventArgs e)
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

        private void btnStart_Click(object sender, EventArgs e)
        {
            currentPage = 1;
            LoadData();
            btnPrevious.Enabled = false;
            btnNext.Enabled = true;
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            currentPage = countPage;
            LoadData();
            btnPrevious.Enabled = true;
            btnNext.Enabled = false;
        }
    }
}
