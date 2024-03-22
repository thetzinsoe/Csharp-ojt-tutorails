using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace Tutorial09_linq_
{
    public partial class PasswordRecovery : Form
    {
        StaffDataDataContext DB = new StaffDataDataContext();
        EncryptionHelper EncryptionHelper = new EncryptionHelper();
        public PasswordRecovery()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login lg = new Login();
            lg.Show();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string alphaPattern = @"^[\p{L}\s]+$";
            if (!Regex.IsMatch(txtStaffName.Text, alphaPattern))
            {
                errorProviderCommon.SetError(txtStaffName, "Invalid staff name.");
            }
            else
            {
                errorProviderCommon.SetError(txtStaffName, "");
            }

            string email = txtEmail.Text.Trim();

            if (string.IsNullOrEmpty(email))
            {
                errorProviderCommon.SetError(txtEmail, "Email address is required.");
            }
            else if (!Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
            {
                errorProviderCommon.SetError(txtEmail, "Invalid email address.");
            }
            else
            {
                errorProviderCommon.SetError(txtEmail, "");
            }


            bool errorsPresent = errorProviderCommon.ContainerControl.Controls
               .OfType<Control>()
               .Any(control => !string.IsNullOrEmpty(errorProviderCommon.GetError(control)));


            if (!errorsPresent)
            {

                string staffName = txtStaffName.Text.Trim();
                string staffEmail = txtEmail.Text.Trim();
                var nameExists = DB.Tuto10s.Any(s => s.Name == staffName);

                if (nameExists)
                {
                    var staffRecord = DB.Tuto10s.FirstOrDefault(s => s.Name == staffName && s.Email == staffEmail);

                    if (staffRecord != null)
                    {
                        string password = EncryptionHelper.Decrypt(staffRecord.Password);
                        try
                        {
                            MailMessage message = new MailMessage();
                            SmtpClient smtp = new SmtpClient();
                            message.From = new MailAddress("youremail.com");
                            message.To.Add(new MailAddress(txtEmail.Text));
                            message.Subject = "Recovery Password";
                            message.IsBodyHtml = true; 
                            message.Body = "Your Login Password is : " + password;
                            smtp.Port = 587;
                            smtp.Host = "smtp.gmail.com";
                            smtp.EnableSsl = true;
                            smtp.UseDefaultCredentials = false;
                            smtp.Credentials = new NetworkCredential("youremail.com", "yourapppass");
                            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                            smtp.Send(message);
                            MessageBox.Show("Email Send Successful! Please check your mailbox and Login Again.");
                            this.Hide();
                            Login lg = new Login();
                            lg.Show();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Failed to send email: " + ex.Message);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Email does not match the name. Please confirm your email.");
                    }
                }
                else
                {
                    MessageBox.Show("Name not found in the database.");
                }

            }
            else
            {
                MessageBox.Show("Still Error", "Error");
            }
        }
    }
}
