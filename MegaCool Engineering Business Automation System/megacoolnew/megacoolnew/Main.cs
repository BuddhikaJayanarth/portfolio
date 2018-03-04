using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Accounts;
using Repair;


namespace megacoolnew
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_main_buisnessanalysis_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            lbl_panalname.Text = "Business Analysis";
            lbl_panalname.Visible = true;
            Account actForm = new Account();
            actForm.TopLevel = false;
            panel1.Controls.Add(actForm);
            actForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            actForm.Dock = DockStyle.Fill;

            actForm.Show();
        }

        private void btn_main_customer_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            lbl_panalname.Text = "Customer";
            lbl_panalname.Visible = true;
            customer cusForm = new customer();
            cusForm.TopLevel = false;
            panel1.Controls.Add(cusForm);
            cusForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            cusForm.Dock = DockStyle.Fill;

            cusForm.Show();
        }

        private void btn_main_delivery_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            lbl_panalname.Text = "Vehical";
            lbl_panalname.Visible = true;
            delivery vehiForm = new delivery();
            vehiForm.TopLevel = false;
            panel1.Controls.Add(vehiForm);
            vehiForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            vehiForm.Dock = DockStyle.Fill;

            vehiForm.Show();
        }

        private void btn_main_stock_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            lbl_panalname.Text = "Stock";
            lbl_panalname.Visible = true;
            Stock inventoryForm = new Stock();
            inventoryForm.TopLevel = false;
            panel1.Controls.Add(inventoryForm);
            inventoryForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            inventoryForm.Dock = DockStyle.Fill;

            inventoryForm.Show();
        }

        private void btn_main_Repair_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            lbl_panalname.Text = "Stock";
            lbl_panalname.Visible = true;
            Form1 repairForm = new Form1();
            repairForm.TopLevel = false;
            panel1.Controls.Add(repairForm);
            repairForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            repairForm.Dock = DockStyle.Fill;

            repairForm.Show();
        }

        private void btn_main_staff_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            lbl_panalname.Text = "Staff";
            lbl_panalname.Visible = true;
            Employee EmployeeForm = new Employee();
            EmployeeForm.TopLevel = false;
            panel1.Controls.Add(EmployeeForm);
            EmployeeForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            EmployeeForm.Dock = DockStyle.Fill;
            EmployeeForm.Show();
            
        }
    }
}
