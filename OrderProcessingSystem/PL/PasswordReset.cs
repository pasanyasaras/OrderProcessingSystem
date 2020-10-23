using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net.Mail;
//using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace OrderProcessingSystem.PL
{
    public partial class PasswordReset : Form
    {
        public PasswordReset()
        {
            InitializeComponent();
            //this.FormClosing += PasswordReset_FormClosing;
            MaximizeBox = false;
        }

        private void ValidateEmail()
        {
            string email = this.txtEmail.Text;
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (match.Success)
            {
            }
            else
            {
                MessageBox.Show("Invalid Email Address", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }

        private void PasswordReset_Load(object sender, EventArgs e)
        {
            
        }

        private void PasswordReset_FormClosing(object sender, FormClosingEventArgs e)
        {
            Login lg = new Login();
            lg.Show();
            
        }

        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSend.PerformClick();
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            ValidateEmail();
            if (this.txtEmail.Text == "")
            {
                errorProvider.SetError(txtEmail, "Please enter your email");
            }
            else
            {
                string cs = @"Data Source=PASANYASARA;Initial Catalog=OrderDB;Integrated Security=True;User Instance=False";
                DataSet ds = new DataSet();
                SqlConnection con = new SqlConnection(cs);
                con.Open();
                string sql = "SELECT firstname, lastname, email,password,username FROM tblUser WHERE email='" + this.txtEmail.Text + "'";
                SqlCommand com = new SqlCommand(sql, con);
                SqlDataReader dr = com.ExecuteReader();

                if (dr.Read())
                {
                    try
                    {
                        MailMessage mail = new MailMessage();
                        SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                        mail.From = new MailAddress("pasanyasaranew@gmail.com");
                        mail.To.Add(txtEmail.Text);
                        mail.Subject = "Password Recovery - PYS Soft";
                        string username = "Username: ";
                        
                        mail.Body = dr.GetValue(0).ToString() + " " + dr.GetValue(1).ToString()+  "\n" +
                             username + dr.GetValue(4).ToString()+ "\n"+
                            " Your Login Password is: " + dr.GetValue(3).ToString();


                        SmtpServer.Port = 587;
                        SmtpServer.Credentials = new System.Net.NetworkCredential("pasanyasaranew@gmail.com", "pasanyasara@gmail.com");
                        SmtpServer.EnableSsl = true;

                        SmtpServer.Send(mail);
                        MessageBox.Show("Password is sent to your email. Please check your Inbox!", "Password Sent!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                        errorProvider.Dispose();
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("Please check your Internet Connection! ", "Internet Connection Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        errorProvider.Dispose();
                    }

                }
                else
                {
                    MessageBox.Show("Your email address is not Registered", "User unavailable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    errorProvider.Dispose();
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
