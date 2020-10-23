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
using OrderProcessingSystem.DL;


namespace OrderProcessingSystem.PL
{
    public partial class Login : Form
    {
        public static string setValue = "";
        public Login()
        {
            InitializeComponent();
            MaximizeBox = false;
        }

        private void Login_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(this.btnFogot, "Forgot your password? Click here");
            toolTip1.SetToolTip(this.txtUser, "Please enter your Username");
            toolTip1.SetToolTip(this.txtPwd,"Please enter your password");
        }

        private void txtUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPwd.Focus();
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }

        private void txtPwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }
        private void btnFogot_Click(object sender, EventArgs e)
        {
            /*PasswordReset pr = new PasswordReset();
            Login l = new Login();
            pr.ShowDialog();
            this.Close();*/

            this.Hide();
            var pr = new PasswordReset();
            pr.Closed += (s, args) => this.Show();
            pr.ShowDialog();
            errorProvider.Dispose();

        }

        public void btnLogin_Click(object sender, EventArgs e)
        {
            if (this.txtUser.Text == "" && this.txtPwd.Text == "")
            {
                errorProvider.SetError(txtUser, "Please Enter the Username");
                errorProvider.SetError(txtPwd, "Please Enter the Password");
                this.txtUser.Focus();
            }
            else if(this.txtUser.Text=="")
            {
                errorProvider.SetError(txtUser, "Please Enter the Username");
                this.txtUser.Focus();
            }
            else if(this.txtPwd.Text == "")
            {
                errorProvider.SetError(txtPwd, "Please Enter the Password");
                this.txtPwd.Focus();
            }
            
            else
            {
                errorProvider.Dispose();
                string cs = @"Data Source=PASANYASARA;Initial Catalog=OrderDB;Integrated Security=True;User Instance=False";
                DataSet ds = new DataSet();
                SqlConnection con = new SqlConnection(cs);
                con.Open();
                string sql = "SELECT * FROM tblUser WHERE username='" + this.txtUser.Text + "' AND password='" + this.txtPwd.Text + "'";
                SqlCommand com = new SqlCommand(sql, con);
                SqlDataReader dr = com.ExecuteReader();

                if (dr.Read())
                {
                    setValue = this.txtUser.Text;
                    this.Hide();
                    var ops = new OPS();
                    
                    ops.Closed += (s, args) => this.Show();
                    ops.Show();
                    this.txtUser.Focus();
                    this.txtUser.Text = "";
                    this.txtPwd.Text = "";
                    
                }
                /* else if((attempt == 3) && (attempt > 0))
                 {
                     lblError.Text = ("You Have Only " + Convert.ToString(attempt) + " Attempt Left To Try");
                     --attempt;
                 }*/
                else
                {
                    MessageBox.Show("Invalid Username or Password", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtUser.Focus();
                    this.txtPwd.Text = "";
                }
                con.Close();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
