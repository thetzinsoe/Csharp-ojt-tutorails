using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tutorial09_linq_
{
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection("Data Source=.\\sqlexpress01;Initial Catalog=Tutorial04;Integrated Security=True;");
        private void Report_Load(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SELECT * from Tuto07", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            reportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource datasource = new ReportDataSource("StaffData", dt);
            reportViewer1.LocalReport.DataSources.Add(datasource);
            reportViewer1.LocalReport.ReportPath = "Report.rdlc";
            reportViewer1.RefreshReport();
        }
    }
}
