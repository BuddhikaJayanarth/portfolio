using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using megacoolnew.userObjects;

namespace megacoolnew
{
    public partial class Login : Form
    {
        private bool mouseDown;
        private Point lastLocation;


        public Login()
        {
            InitializeComponent();
        }
//Customized Close Button properties
        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void close_MouseDown(object sender, MouseEventArgs e)
        {
            close.Image = Properties.Resources.cl_clicked;
        }

        private void close_MouseHover(object sender, EventArgs e)
        {
            close.Image = Properties.Resources.cl_hover;
        }

        private void close_MouseLeave(object sender, EventArgs e)
        {
            close.Image = Properties.Resources.cl_nor;
        }

        private void close_MouseUp(object sender, MouseEventArgs e)
        {
            close.Image = Properties.Resources.cl_hover;
        }

//Customized minimize Button properties
        private void minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void minimize_MouseDown(object sender, MouseEventArgs e)
        {
            minimize.Image = Properties.Resources.min_clicked;
        }

        private void minimize_MouseHover(object sender, EventArgs e)
        {
            minimize.Image = Properties.Resources.min_hover;
        }

        private void minimize_MouseLeave(object sender, EventArgs e)
        {
            minimize.Image = Properties.Resources.min_nor;
        }

        private void minimize_MouseUp(object sender, MouseEventArgs e)
        {
            minimize.Image = Properties.Resources.min_hover;
        }
//**end**
        private void loginbtn_Click(object sender, EventArgs e)
        {
            if(login_tb_username.Text != "" && login_tb_password.Text != "")
            {
                if (login_tb_password.Text.Length == 12)
                {
                    DBAccess db = new DBAccess();
                    LoginObj lg = new LoginObj();
                    lg = db.ValidateLogin(login_tb_username.Text, login_tb_password.Text);
                    if (lg.Name != "")
                    {
                        //MessageBox.Show(name);
                        this.Hide();
                        Home hm = new Home(lg.Name,lg.Clearancelevel1);
                        hm.ShowDialog();
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Incorrect username or password");
                    }
                }
                else
                {
                    MessageBox.Show("Password must have 12 characters");
                }
            }
            else
            {
                MessageBox.Show("Username / Password missing.");
            }
        }
        //making the application dragable 
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);
                this.Update();
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void login_tb_password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (login_tb_password.Text.Length == 12)
            {
                if(e.KeyChar != 8)
                    e.Handled = true;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        // ***end***


    }
}
