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
using OrderProcessingSystem.BL;

namespace OrderProcessingSystem.PL
{
    public partial class OPS : Form
    {
        private bool mouseDown;
        private Point lastLocation;
        
        public OPS()
        {
            
            InitializeComponent();
            
        }

        /*SqlCommand cmd;
        SqlConnection con;
        string cs = @"Data Source=PASANYASARA;Initial Catalog=OrderDB;Integrated Security=True;User Instance=False";
        */


        private void panelLogin_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void panelLogin_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void panelLogin_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OPS_Load(object sender, EventArgs e)
        {
            /*con = new SqlConnection(cs);
            con.Open();
            cmd = new SqlCommand("cd", con);
            cmd.CommandType = CommandType.StoredProcedure;
            object obj = cmd.ExecuteScalar();*/
            

            BL.Customer cus = new BL.Customer();

            //txtCID.Text = cus.cusIDAuto();

            //this.txtCID.Text = obj.ToString();

            lblUser.Text = "User: "+Login.setValue;
            timer.Start();
            btnRegister.PerformClick();
            txtCName.Focus();
            this.ActiveControl = txtCName;
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToString("dd/MM/yyyy h:mm:ss tt");
        }

        private void tabCustomer_Click(object sender, EventArgs e)
        {
            
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            //OPS ops = new OPS();
            //Panel p = (Panel)ops.Controls["panelRegister"];
            //p.Visible = true;
            //panelRegister.Visible = true;
            //panelTemp.Visible = false;
            
            panelRegister.Show();

            var panelButtons = panel.Controls.OfType<Button>();
            foreach (Button button in panelButtons)
            {
                button.BackColor = Color.Transparent;
            }

            var clickedButton = (Button)sender;
            clickedButton.BackColor = Color.DarkCyan;

            txtCName.Focus();
            this.ActiveControl = txtCName;
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            //panelRegister.Visible = false;
            panelRegister.Hide();
            
            

            var panelButtons = panel.Controls.OfType<Button>();
            foreach (Button button in panelButtons)
            {
                button.BackColor = Color.Transparent;
            }

            var clickedButton = (Button)sender;
            clickedButton.BackColor = Color.DarkCyan;
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            panelRegister.Hide();

            var panelButtons = panel.Controls.OfType<Button>();
            foreach (Button button in panelButtons)
            {
                button.BackColor = Color.Transparent;
            }

            var clickedButton = (Button)sender;
            clickedButton.BackColor = Color.DarkCyan;
        }

        

        
        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Supplier Updated Successfully","Supplier Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tabSupplier_Click(object sender, EventArgs e)
        {

        }

        private void btnUserPwdChange_Click(object sender, EventArgs e)
        {
            ChangeUserPassword cup = new ChangeUserPassword();
            cup.ShowDialog();
        }

        private void btnCustomerClear_Click(object sender, EventArgs e)
        {
            this.txtCID.Text = "";
            this.txtCName.Text = "";
            this.txtCEmail.Text = "";
            this.txtCTel.Text = "";
            this.dgvCustomer.Rows.Clear();
        }

        private void btnItemClear_Click(object sender, EventArgs e)
        {
            this.txtItemCode.Text = "";
            this.txtItemName.Text = "";
            this.txtPrice.Text = "";
            this.cmbItemSupplier.Text = "";
            this.dgvItem.Rows.Clear();
        }
    }
}
