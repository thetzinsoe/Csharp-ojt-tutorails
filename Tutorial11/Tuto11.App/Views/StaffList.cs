using Services.Staff;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO.Staff;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace Tuto11.App.Views
{
    public partial class StaffList : Form
    {
        private StaffService staffService = new StaffService();
        private StaffDao staffDao = new StaffDao();
        DataTable staffDataTable = new DataTable();
        string imagePath = "";
        byte[] imageData = new byte[0];
        byte[] noImage = File.ReadAllBytes(Environment.CurrentDirectory + "\\Images\\noImage.png");

        public StaffList()
        {
            InitializeComponent();
           
        }

        private void StaffList_Load(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void BindGrid()
        {
            // Create a new DataTable
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Staff No.", typeof(int));
            dataTable.Columns.Add("Image", typeof(byte[])); // Assuming image data is stored as byte[]
            dataTable.Columns.Add("Staff Name", typeof(string));
            dataTable.Columns.Add("Join From", typeof(DateTime));
            dataTable.Columns.Add("Staff Type", typeof(string));
            dataTable.Columns.Add("NRC No", typeof(string));
            dataTable.Columns.Add("Gender", typeof(string));
            dataTable.Columns.Add("Age", typeof(int));
            dataTable.Columns.Add("Phone No1", typeof(string));
            dataTable.Columns.Add("Phone No2", typeof(string));
            dataTable.Columns.Add("Address", typeof(string));

            // Get data from the service
            DataTable dt = staffService.GetAll();

            // Loop through the fetched data and populate the DataTable
            foreach (DataRow row in dt.Rows)
            {
                DataRow newRow = dataTable.NewRow();
                newRow["Staff No."] = row["Id"];
                string imagePath = row["Image"].ToString();
                if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
                {
                    byte[] imageData = File.ReadAllBytes(imagePath);
                    newRow["Image"] = imageData;
                }
                else
                {
                    // Set default image if no image found
                    newRow["Image"] = noImage;
                }
                newRow["Staff Name"] = row["Name"];
                newRow["Join From"] = row["JoinFrom"];
                newRow["Staff Type"] = row["StaffType"];
                newRow["NRC No"] = row["NrcNo"];
                newRow["Gender"] = row["Gender"];
                DateTime birthDate = Convert.ToDateTime(row["BirthDate"]);
                int age = DateTime.Today.Year - birthDate.Year;
                newRow["Age"] = age.ToString();
                newRow["Phone No1"] = row["PhoneNo1"];
                newRow["Phone No2"] = row["PhoneNo2"];
                newRow["Address"] = row["Address"];
                dataTable.Rows.Add(newRow);
            }

            // Set the DataSource of the DataGridView to the populated DataTable
            dgvStaffInformation.DataSource = dataTable;
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(dgvStaffInformation.SelectedRows.Count > 0)
            {
                var staffId = Convert.ToInt32(dgvStaffInformation.SelectedRows[0].Cells["Id"].Value);
                //MessageBox.Show("" + staffId + "   " + staffId.GetType());
                bool success = staffService.Delete(Convert.ToInt32(staffId));
                if (success)
                {
                    MessageBox.Show("Delete Success.", "Success", MessageBoxButtons.OK);
                }
                BindGrid();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvStaffInformation.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvStaffInformation.SelectedRows[0];
                var selectedCell = selectedRow.Cells[0].Value.ToString(); // Assuming the staffName is in the second column (index 1)
                int staffId = int.Parse(selectedCell);
                var dt = staffDao.Get(staffId);
                this.Hide();
                Register re = new Register(dt);
                re.Show();
            }
            else
            {
                MessageBox.Show("Please select Staff to Update!");
            }
        }

        private void dgvStaffInformation_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewImageColumn imageColumn = dgvStaffInformation.Columns["Image"] as DataGridViewImageColumn;
            if (imageColumn != null)
            {
                // Set the image layout to Zoom
                imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
            }
        }
    }
}
