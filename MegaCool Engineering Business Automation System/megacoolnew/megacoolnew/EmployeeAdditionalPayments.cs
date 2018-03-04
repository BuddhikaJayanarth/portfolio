using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using megacoolnew.userObjects;
using System.Text.RegularExpressions;

namespace megacoolnew
{
    public partial class EmployeeAdditionalPayments : Form
    {
        public int EmployeID;
        MegaCoolMethods mcm = new MegaCoolMethods();
        Employee empForm = null;
        public EmployeeAdditionalPayments()
        {
            InitializeComponent();
            
        }
        public EmployeeAdditionalPayments(Employee formEmp,int empid)
        {
            InitializeComponent();
            this.empForm = formEmp;
            EmployeID = empid;
            

            //Load the grid view
            String q = "SELECT * FROM EmployeeAdditionalPayments WHERE EmployeeID = " + empid;
            eap_dgv_payemts.DataSource = mcm.loadGridView(q);
        }
        private void eap_btn_clear_Click(object sender, EventArgs e)
        {
            eap_tb_reason.Text = "";
            eap_tb_amount.Text = "";
        }

        private void eap_btn_delete_Click(object sender, EventArgs e)
        {
            if(eap_dgv_payemts.Rows.Count == 0)
            {
                MessageBox.Show("There is nothing to delete.");
            }
            else
            {
                int id = Convert.ToInt32(eap_dgv_payemts.CurrentRow.Cells[0].Value);
                
                if(mcm.DeleteAdditionalPayment(id))
                {
                    String q = "SELECT * FROM EmployeeAdditionalPayments WHERE EmployeeID = " + EmployeID;
                    eap_dgv_payemts.DataSource = mcm.loadGridView(q);
                }
                else { }
            }
        }

        private void eap_btn_add_Click(object sender, EventArgs e)
        {
            if (eap_tb_reason.Text != "" && eap_tb_amount.Text != "")
            {
                String r = eap_tb_reason.Text;
                Double a = Convert.ToDouble(eap_tb_amount.Text);
                String date = DateTime.Today.ToString("yyyy-MM-dd");
                if (mcm.AddAdditionalPayment(EmployeID, date, r, a))
                {
                    eap_btn_clear_Click(sender, e);

                    String q = "SELECT * FROM EmployeeAdditionalPayments WHERE EmployeeID = " + EmployeID;
                    eap_dgv_payemts.DataSource = mcm.loadGridView(q);
                }
                else { }
            }
            else
            {
                MessageBox.Show("Amount or reason is missing");
            }
        }

        private void eap_btn_done_Click(object sender, EventArgs e)
        {
            Employee frm = new Employee();
            Double tot = mcm.getTotAdditionalPayment(EmployeID);
            empForm.totAdditional(tot.ToString());
            empForm.grossLabelrefresh();
            
            this.Close();
        }

        private void eap_tb_amount_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != '.')
            {
                e.Handled = true;
            }
            if (Regex.IsMatch(eap_tb_amount.Text, @"\.\d\d") && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
    }
}
