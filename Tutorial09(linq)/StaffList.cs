using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using static System.Net.Mime.MediaTypeNames;
using Image = System.Drawing.Image;

namespace Tutorial09_linq_
{
    public partial class StaffList : Form
    {
        StaffDataDataContext DB = new StaffDataDataContext();
        private byte[] noImage;
        string staffName = "";

        public StaffList()
        {
            InitializeComponent();
            noImage = File.ReadAllBytes(Path.Combine(Environment.CurrentDirectory, "Images", "noImage.png"));

        }

        private void StaffList_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void loadData()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Staff No.", typeof(int));
            dataTable.Columns.Add("Image", typeof(byte[])); // Use dataTable here, not staffDataTable
            dataTable.Columns.Add("Staff Name", typeof(string));
            dataTable.Columns.Add("Join From", typeof(DateTime));
            dataTable.Columns.Add("Staff Type", typeof(string));
            dataTable.Columns.Add("NRC No", typeof(string));
            dataTable.Columns.Add("Gender", typeof(string));
            dataTable.Columns.Add("Age", typeof(int));
            dataTable.Columns.Add("Phone No1", typeof(string));
            dataTable.Columns.Add("Phone No2", typeof(string));
            dataTable.Columns.Add("Address", typeof(string));
            dgvStaffInformation.DataSource = dataTable; // Set the data source to dataTable

            var dt = from s in DB.Tuto07s
                     select new
                     {
                         StaffNo = s.Id,
                         Image = s.Image,
                         StaffName = s.Name,
                         JoinFrom = s.JoinFrom,
                         StaffType = s.StaffType,
                         NRCNo = s.NrcNo,
                         Gender = s.Gender,
                         Age = CalculateAge(s.BirthDate), // Call the method to calculate age
                         PhoneNo1 = s.PhoneNo1,
                         PhoneNo2 = s.PhoneNo2,
                         Address = s.Address
                     };

            foreach (var item in dt)
            {
                DataRow newRow = dataTable.NewRow();
                newRow["Staff No."] = item.StaffNo;
                string imagePath = item.Image;
                if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
                {
                    byte[] imageData = File.ReadAllBytes(imagePath);
                    newRow["Image"] = imageData;
                }
                else
                {
                    newRow["Image"] = noImage;
                }
                newRow["Staff Name"] = item.StaffName;
                newRow["Join From"] = item.JoinFrom;
                newRow["Staff Type"] = item.StaffType;
                newRow["NRC No"] = item.NRCNo;
                newRow["Gender"] = item.Gender;
                newRow["Age"] = item.Age;
                newRow["Phone No1"] = item.PhoneNo1;
                newRow["Phone No2"] = item.PhoneNo2;
                newRow["Address"] = item.Address;
                dataTable.Rows.Add(newRow);
            }
        }

        private int CalculateAge(DateTime birthDate)
        {
            int age = DateTime.Today.Year - birthDate.Year;
            if (DateTime.Today < birthDate.AddYears(age)) // Adjust age if birthday hasn't occurred yet this year
            {
                age--;
            }
            return age;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register re = new Register();   
            re.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dgvStaffInformation.SelectedRows[0];
            var selectedCell = selectedRow.Cells[2].Value; // Assuming the staffName is in the second column (index 1)
            staffName = Convert.ToString(selectedCell);
            var dt = (from s in DB.Tuto07s
                      where s.Name == staffName
                      select s).First();
            DB.Tuto07s.DeleteOnSubmit(dt);
            MessageBox.Show("Delete Successful");
            loadData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dgvStaffInformation.SelectedRows[0];
            var selectedCell = selectedRow.Cells[2].Value; // Assuming the staffName is in the second column (index 1)
            staffName = Convert.ToString(selectedCell);
            var dt = (from s in DB.Tuto07s
                      where s.Name == staffName
                      select s).First();
            this.Hide();
            Register re = new Register(dt);
            re.Show();

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
