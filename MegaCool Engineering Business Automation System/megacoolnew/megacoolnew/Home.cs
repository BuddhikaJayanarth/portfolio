using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Linq;

namespace megacoolnew
{
    public partial class Home : Form
    {
        private bool mouseDown;
        //string owner;
        private Point lastLocation;
        public int Clearancelevel;

        public Home(String name, int Clearancelevel)
        {
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            restoredown.Visible = false;
            user.Text = name;
            this.Clearancelevel = Clearancelevel;
        }
        //public Home(string s1) {
        //    owner = s1;
            
        //}


        private void logout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Close();
            Login lg = new Login();
            lg.ShowDialog();
        }
//Customized maximize Button properties
        private void maximize_MouseHover(object sender, EventArgs e)
        {
            maximize.Image = Properties.Resources.max_hover;
        }

        private void maximize_MouseLeave(object sender, EventArgs e)
        {
            maximize.Image = Properties.Resources.max_nor;
        }

        private void maximize_MouseDown(object sender, MouseEventArgs e)
        {
            maximize.Image = Properties.Resources.max_clicked;
        }

        private void maximize_MouseUp(object sender, MouseEventArgs e)
        {
            maximize.Image = Properties.Resources.max_hover;
        }

        private void maximize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            maximize.Visible = false;
            restoredown.Visible = true;
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
//Customized Restore Down Button properties
        private void restoredown_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            maximize.Visible = true;
            restoredown.Visible = false;
        }

        private void restoredown_MouseHover(object sender, EventArgs e)
        {
            restoredown.Image = Properties.Resources.res_hover;
        }

        private void restoredown_MouseLeave(object sender, EventArgs e)
        {
            restoredown.Image = Properties.Resources.res_nor;
        }

        private void restoredown_MouseDown(object sender, MouseEventArgs e)
        {
            restoredown.Image = Properties.Resources.res_clicked;
        }

        private void restoredown_MouseUp(object sender, MouseEventArgs e)
        {
            restoredown.Image = Properties.Resources.res_hover;
        }
 //Finished Implementation of the customized control box

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
//finished making dragable

//Main Menu Button Clicks
        private void staff_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            Employee EmployeeForm = new Employee();
            EmployeeForm.TopLevel = false;
            panel3.Controls.Add(EmployeeForm);
            EmployeeForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            EmployeeForm.Dock = DockStyle.Fill;
            EmployeeForm.Show();
        }

        private void customer_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            customer cusForm = new customer();
            cusForm.TopLevel = false;
            panel3.Controls.Add(cusForm);
            cusForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            cusForm.Dock = DockStyle.Fill;

            cusForm.Show();
        }

        private void stock_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            Stock inventoryForm = new Stock();
            inventoryForm.TopLevel = false;
            panel3.Controls.Add(inventoryForm);
            inventoryForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            inventoryForm.Dock = DockStyle.Fill;

            inventoryForm.Show();
        }

        private void buisnessanalysis_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            Account actForm = new Account();
            actForm.TopLevel = false;
            panel3.Controls.Add(actForm);
            actForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            actForm.Dock = DockStyle.Fill;

            actForm.Show();
        }

        private void delivery_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            delivery vehiForm = new delivery();
            vehiForm.TopLevel = false;
            panel3.Controls.Add(vehiForm);
            vehiForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            vehiForm.Dock = DockStyle.Fill;

            vehiForm.Show();
        }

        private void repair_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            Form1 repairForm = new Form1();
            repairForm.TopLevel = false;
            panel3.Controls.Add(repairForm);
            repairForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            repairForm.Dock = DockStyle.Fill;

            repairForm.Show();
        }

        private void offside_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            Offsite offsiteForm = new Offsite();
            offsiteForm.TopLevel = false;
            panel3.Controls.Add(offsiteForm);
            offsiteForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            offsiteForm.Dock = DockStyle.Fill;

            offsiteForm.Show();
        }

        private void sales_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            Sales SaleForm = new Sales();
            SaleForm.TopLevel = false;
            panel3.Controls.Add(SaleForm);
            SaleForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            SaleForm.Dock = DockStyle.Fill;

            SaleForm.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            //user levels for Business anlysis 
            /*Login lo = new Login();
            string own = lo.login_tb_username.Text;
            
            if ( own == "owner")
            {
                buisnessanalysis.Enabled = true;
            }
            else
            {
                buisnessanalysis.Enabled = false;
            }*/

            MegaCoolMethods mcm = new MegaCoolMethods();
            String q = "SELECT * FROM Notification WHERE Clearancelevel <= " + Clearancelevel;
            home_dgv_notification.DataSource = mcm.loadGridView(q);
        }

        private void home_dgv_notification_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            String cat = home_dgv_notification.CurrentRow.Cells[2].Value.ToString();
            String des = home_dgv_notification.CurrentRow.Cells[1].Value.ToString();
            String id = home_dgv_notification.CurrentRow.Cells[0].Value.ToString();
            string empid = des.Split(' ').Last();
            

            if (cat == "Leave Request")
            {
                panel3.Controls.Clear();
                Employee EmployeeForm = new Employee(empid,id);
                EmployeeForm.TopLevel = false;
                panel3.Controls.Add(EmployeeForm);
                EmployeeForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                EmployeeForm.Dock = DockStyle.Fill;
                EmployeeForm.Show();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            MegaCoolMethods mcm = new MegaCoolMethods();

            String q = "SELECT * FROM Notification WHERE Clearancelevel <= " + Clearancelevel;
            home_dgv_notification.DataSource = mcm.loadGridView(q);
        }

        



//------****------

    }
}
