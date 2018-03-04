using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using megacoolnew.userObjects;
using System.Text.RegularExpressions;

namespace megacoolnew
{
    public partial class Employee : Form
    {
        MegaCoolMethods mcm = new MegaCoolMethods();

        public String empid;
        public int notID;
        public Employee()
        {
            InitializeComponent();
            st_rec_cb_position.DropDownStyle = ComboBoxStyle.DropDownList;
            st_rec_dtp_joindate.MaxDate = DateTime.Today;

            //if (stafftab.SelectedTab == leave)
            //{
                string q = "SELECT EmployeeID,StartDate,EndDate,Duration,LeaveType,ApproveStatus FROM Leave ";
                st_le_vl_dgv_leaves.DataSource = mcm.loadGridView(q);

                st_le_al_dtp_start.MinDate = DateTime.Today.AddDays(1);
                st_le_al_dtp_end.MinDate = st_le_al_dtp_start.Value;
                st_le_al_dtp_end.MaxDate = DateTime.Today.AddMonths(6);

                int currentYear = DateTime.Today.Year;
                for (int i = 2000; i <= currentYear; i++)
                {
                    st_le_vl_cb_year.Items.Add(i);
                }
            //}
        }
        public Employee(String empid,String id)
        {
            this.notID = Convert.ToInt32(id);
            InitializeComponent();
            st_rec_cb_position.DropDownStyle = ComboBoxStyle.DropDownList;
            st_rec_dtp_joindate.MaxDate = DateTime.Today;
            this.empid = empid;
            stafftab.SelectedTab = leave;
            tabControl2.SelectedTab = applyLeaveTab;

            Leave le = new Leave();

            le = mcm.GetLeaveDetails(Convert.ToInt32(empid));
            if (le.reason != "error")
            {
                st_le_al_tb_empid.Text = le.empid.ToString();
                st_le_al_tb_empid.Enabled = false;
                st_le_al_dtp_start.MinDate = DateTime.Parse("2000-01-01");
                st_le_al_dtp_start.MaxDate = DateTime.Parse("8888-01-01");
                st_le_al_dtp_start.Value = le.start.Date;
                st_le_al_dtp_start.Enabled = false;
                st_le_al_dtp_end.Value = le.end;
                st_le_al_dtp_end.Enabled = false;
                st_le_al_lb_durationvalue.Text = le.duration.ToString();
                if (le.type == "Casual")
                {
                    st_le_al_rb_cashual.Checked = true;
                }
                else if (le.type == "Annual")
                {
                    st_le_al_rb_annual.Checked = true;
                }
                else if (le.type == "Medical")
                {
                    st_le_al_rb_medical.Checked = true;
                }
                else if (le.type == "Other")
                {
                    st_le_al_rb_other.Checked = true;
                }
                else
                {
                    st_le_al_rb_halfday.Checked = true;
                }
                st_le_al_rb_cashual.Enabled = false;
                st_le_al_rb_annual.Enabled = false;
                st_le_al_rb_medical.Enabled = false;
                st_le_al_rb_other.Enabled = false;
                st_le_al_rb_halfday.Enabled = false;

                st_le_al_cb_session.Text = le.session;
                st_le_al_cb_session.Enabled = false;
                st_le_al_rtb_reason.Text = le.reason;
                st_le_al_rtb_reason.Enabled = false;
                st_le_al_btn_clear.Visible = false;
                st_le_al_btn_apply.Visible = false;
                st_le_al_btn_reject.Visible = true;
                st_le_al_btn_approve.Visible = true;
            }
            else { }
        }
       

//When each tabs are opened
        private void stafftab_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (stafftab.SelectedTab == employees)
            {
                st_emp_ps_dgv_employees.DataSource = mcm.loadEmployees();
                st_emp_ea_dgv_emp.DataSource = mcm.loadGridView("SELECT EmployeeID,Name FROM Employee");

                String d = DateTime.Today.Date.ToString("yyyy-MM-dd");
                string q = "SELECT * FROM Attendance WHERE Date = '" + d + "'";
                st_emp_ea_dgv_attendance.DataSource = mcm.loadGridView(q);

                st_emp_ea_cb_position.Items.Clear();
                Positions pos = new Positions();
                st_emp_ea_cb_position.Items.Add("All");
                pos.posNames = mcm.AttendancePositionCB();
                for (int i = 0; i < pos.posNames.Length; i++)
                {
                    st_emp_ea_cb_position.Items.Add(pos.posNames[i]);
                }
                st_emp_ea_cb_position.SelectedIndex = 0;
            }

            else if (stafftab.SelectedTab == allowances)
            {
                string q = "SELECT a.AllowanceID,a.Name as Allowance_Name,p.PosName as Position,pa.Amount FROM Allowances a,Position p, Position_Allowance pa WHERE pa.AllowanceID = a.AllowanceID and pa.PositionID = p.PositionID ORDER BY a.AllowanceID";
                st_alw_v_dgv_allowances.DataSource = mcm.loadGridView(q);

                String q2 = "SELECT * FROM Allowances";
                st_alw_aa_dgv_allowances.DataSource = mcm.loadGridView(q2);

                st_alw_fa_cb_position.DropDownStyle = ComboBoxStyle.DropDownList;
                st_alw_fa_cb_allowances.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            else if (stafftab.SelectedTab == overtime)
            {
                string q = "SELECT * FROM OT";
                st_ot_vr_dgv_otemp.DataSource = mcm.loadGridView(q);

                string q2 = "SELECT PosName,OTRate FROM Position";
                st_ot_vr_dgv_otrates.DataSource = mcm.loadGridView(q2);

                st_ot_aoth_dtp_date.MaxDate = DateTime.Now;

            }
            else if (stafftab.SelectedTab == positiontab)
            {
                string q = "SELECT * FROM Position";
                st_pos_view_dgv_positions.DataSource = mcm.loadGridView(q);
            }
            
        }




//AddEmployee
        //A Demo of recruiting employees
        private void st_rec_btn_demo_Click(object sender, EventArgs e)
        {
            st_rec_tb_name.Text = "Demo Demo";
            st_rec_rtb_address.Text = "11, demo road, DEMO, Sri lanka";
            st_rec_tb_basicsal.Text = "10000";
            st_rec_tb_email.Text = "demo@gmail.com";
            st_rec_mtb_home.Text = "0112733733";
            st_rec_mtb_mobile.Text = "0715555555";
            st_rec_cb_position.Text = "DEO";
            st_rec_rtb_pastexp.Text = "None";
            st_rec_rtb_qualification.Text = "None";
            st_rec_mtb_nic.Text = "950688411V";
            st_rec_rb_male.Checked = true;
            st_rec_rb_female.Checked = false;
            st_rec_rb_married.Checked = false;
            st_rec_rb_single.Checked = true;
            st_rec_dtp_dob.Value = new DateTime(DateTime.Now.Year - 18, 01, 01);
            st_rec_dtp_joindate.Value = DateTime.Today;
        }
        //Get the basic salary according to the selected position
        private void st_rec_cb_position_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int position = Convert.ToInt32(st_rec_cb_position.SelectedValue);
            st_rec_tb_basicsal.Text = mcm.getPositionSal(position).ToString();
        }

        private void st_rec_btn_addemp_Click(object sender, EventArgs e)
        {
            if (st_rec_tb_name.Text == "" || st_rec_rtb_address.Text == "" || st_rec_tb_basicsal.Text == "" || st_rec_tb_email.Text == "" ||
                st_rec_mtb_home.Text == "" || st_rec_mtb_mobile.Text == "" || st_rec_cb_position.Text == "" || st_rec_mtb_nic.Text.Length != 10 || 
                (!st_rec_rb_male.Checked && !st_rec_rb_female.Checked) || (!st_rec_rb_married.Checked && !st_rec_rb_single.Checked))
            {
                MessageBox.Show("Please Fill all the fields");
            }
            else
            {
                Validation val = new Validation();
                if (val.IsValidEmail(st_rec_tb_email.Text) && val.checkAge(st_rec_dtp_dob.Value.Date))
                {
                    EmployeeObject em = new EmployeeObject();
                    em.name = st_rec_tb_name.Text;
                    em.address = st_rec_rtb_address.Text;
                    em.basicsal = Convert.ToDouble(st_rec_tb_basicsal.Text);
                    em.email = st_rec_tb_email.Text;
                    em.home = st_rec_mtb_home.Text;
                    em.joindate = st_rec_dtp_joindate.Value.Date;
                    em.mobile = st_rec_mtb_mobile.Text;
                    em.pastexp = st_rec_rtb_pastexp.Text;
                    em.qualification = st_rec_rtb_qualification.Text;
                    em.position = Convert.ToInt32(st_rec_cb_position.SelectedValue);
                    if (st_rec_rb_male.Checked == true)
                        em.sex = 'M';
                    else
                        em.sex = 'F';
                    if (st_rec_rb_married.Checked == true)
                        em.status = 'M';
                    else
                        em.status = 'S';

                    em.dob = st_rec_dtp_dob.Value.Date;
                    em.nic = st_rec_mtb_nic.Text;

                    if (mcm.AddEmployeeDetails(em))
                    {
                        //clear the screen
                        st_rec_tb_name.Text = "";
                        st_rec_rtb_address.Text = "";
                        st_rec_tb_basicsal.Text = "";
                        st_rec_tb_email.Text = "";
                        st_rec_mtb_home.Text = "";
                        st_rec_mtb_mobile.Text = "";
                        st_rec_cb_position.Text = "";
                        st_rec_rtb_pastexp.Text = "None";
                        st_rec_lb_qualification.Text = "None";
                        st_rec_mtb_nic.Clear();
                        st_rec_rb_male.Checked = false;
                        st_rec_rb_female.Checked = false;
                        st_rec_rb_married.Checked = false;
                        st_rec_rb_single.Checked = false;
                        st_rec_dtp_dob.Value = DateTime.Today;
                        st_rec_dtp_joindate.Value = DateTime.Today;
                        //---***--
                    }
                    else { }
                }
                else
                {
                }
            }
        }
        //load position combobox
        private void st_rec_cb_position_Enter(object sender, EventArgs e)
        {
            st_rec_cb_position.DataSource = mcm.LoadPositionComboBox();
            st_rec_cb_position.ValueMember = "PositionID";
            st_rec_cb_position.DisplayMember = "PosName";
        }

    //basic salary text box validation
        private void st_rec_tb_basicsal_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            
            if (!Char.IsDigit(ch) && ch != 8 && ch != '.' )
            {
                e.Handled = true;
            }
            if (e.KeyChar == '.' && st_rec_tb_basicsal.Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }
    //mobile textbox validation
        private void st_rec_mtb_mobile_KeyPress(object sender, KeyPressEventArgs e)
        {

            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
            if (st_rec_mtb_mobile.Text.Length > 9 && ch != 8)
                e.Handled = true;
        }
    //home tel textbox validation
        private void st_rec_mtb_home_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
            if (st_rec_mtb_home.Text.Length > 9 && ch != 8)
                e.Handled = true;
        }
    //Clear screen buton
        private void st_rec_btn_clear_Click(object sender, EventArgs e)
        {
            st_rec_tb_name.Text = "";
            st_rec_rtb_address.Text = "";
            st_rec_tb_basicsal.Text = "";
            st_rec_tb_email.Text = "";
            st_rec_mtb_home.Text = "";
            st_rec_mtb_mobile.Text = "";
            st_rec_cb_position.Text = "";
            st_rec_rtb_pastexp.Text = "None";
            st_rec_rtb_qualification.Text = "None";
            st_rec_mtb_nic.Clear();
            st_rec_rb_male.Checked = false; 
            st_rec_rb_female.Checked = false;
            st_rec_rb_married.Checked = false;
            st_rec_rb_single.Checked = false;
            st_rec_dtp_dob.Value = DateTime.Today;
            st_rec_dtp_joindate.Value = DateTime.Today;

        }
    //Employee datagrid refresh button
        private void st_emp_ps_btn_refresh_Click(object sender, EventArgs e)
        {
            st_emp_ps_dgv_employees.DataSource = mcm.loadEmployees();
        }

        private void st_emp_ps_btn_Search_Click(object sender, EventArgs e)
        {
            int n;
            string q;
            MegaCoolMethods mcm = new MegaCoolMethods();
            
            if (int.TryParse(st_emp_ps_tb_empid.Text, out n))
            {
                q = "SELECT * FROM Employee WHERE EmployeeID = '" + Convert.ToInt32(st_emp_ps_tb_empid.Text)+"'";
                st_emp_ps_dgv_employees.DataSource = mcm.loadGridView(q);
            }
            else
            {
                q = "SELECT * FROM Employee WHERE Name LIKE  '%" + st_emp_ps_tb_empid.Text + "%'";
                st_emp_ps_dgv_employees.DataSource = mcm.loadGridView(q);
            }
        }

//UPDATE EMPLOYEE        
        int tmpID;
        private void st_emp_ps_btn_update_Click(object sender, EventArgs e)
        {
            st_emp_ps_btn_update.Enabled = false;
            st_emp_ps_btn_remove.Enabled = false;
            st_emp_ps_btn_refresh.Enabled = false;
            st_emp_ps_btn_promote.Enabled = false;

            st_emp_ps_btn_cancel.Visible = true;
            st_emp_ps_btn_save.Visible = true;
            st_emp_ps_panelUp1.Visible = true;
            Char status;
            
//getting the values to update
            tmpID = Convert.ToInt32(st_emp_ps_dgv_employees.CurrentRow.Cells[0].Value);
            st_emp_ps_tb_mobile.Text = st_emp_ps_dgv_employees.CurrentRow.Cells[7].Value.ToString();
            st_emp_ps_tb_home.Text = st_emp_ps_dgv_employees.CurrentRow.Cells[6].Value.ToString();
            st_emp_ps_rtb_addr.Text = st_emp_ps_dgv_employees.CurrentRow.Cells[2].Value.ToString();
            status = st_emp_ps_dgv_employees.CurrentRow.Cells[9].Value.ToString().First();
            if (status == 'M')
                st_emp_ps_rb_married.Checked = true;
            else
                st_emp_ps_rb_single.Checked = true;

            st_emp_ps_tb_email.Text = st_emp_ps_dgv_employees.CurrentRow.Cells[3].Value.ToString();

            st_emp_ps_btn_save.Visible = true;

        }

        //mobile textbox validation in update
        private void st_emp_ps_tb_mobile_KeyPress(object sender, KeyPressEventArgs e)
        {

            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
            if (st_emp_ps_tb_mobile.Text.Length > 9 && ch != 8)
                e.Handled = true;
        }
        //home textbox validation in update
        private void st_emp_ps_tb_home_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
            if (st_emp_ps_tb_home.Text.Length > 9 && ch != 8)
                e.Handled = true;
        }

        private void st_emp_ps_btn_save_Click(object sender, EventArgs e)
        {
            if (st_emp_ps_tb_mobile.Text == "" || st_emp_ps_tb_home.Text == "" || st_emp_ps_rtb_addr.Text == "" || st_emp_ps_tb_email.Text == "")
            {
                MessageBox.Show("Please fill all the fields");
            }
            else
            {
                EmployeeObject emp = new EmployeeObject();

                emp.empid = tmpID;
                emp.mobile = st_emp_ps_tb_mobile.Text;
                emp.home = st_emp_ps_tb_home.Text;
                emp.address = st_emp_ps_rtb_addr.Text;

                if (st_emp_ps_rb_married.Checked == true)
                    emp.status = 'M';
                else
                    emp.status = 'S';
                emp.email = st_emp_ps_tb_email.Text;
                Validation val = new Validation();
                if (val.IsValidEmail(st_emp_ps_tb_email.Text))
                {
                    mcm.UpdateEmployeeDetails(emp);
                    st_emp_ps_dgv_employees.DataSource = mcm.loadEmployees();
                
                    st_emp_ps_btn_update.Enabled = true;
                    st_emp_ps_btn_remove.Enabled = true;
                    st_emp_ps_btn_refresh.Enabled = true;
                    st_emp_ps_btn_promote.Enabled = true;

                    st_emp_ps_btn_cancel.Visible = false;
                    st_emp_ps_btn_save.Visible = false;
                    st_emp_ps_panelUp1.Visible = false;

                }
                else { }
            }
            
        }
    //cancel the update event
        private void st_emp_ps_btn_cancel_Click(object sender, EventArgs e)
        {
            st_emp_ps_btn_update.Enabled = true;
            st_emp_ps_btn_remove.Enabled = true;
            st_emp_ps_btn_refresh.Enabled = true;
            st_emp_ps_btn_promote.Enabled = true;

            st_emp_ps_btn_cancel.Visible = false;
            st_emp_ps_btn_save.Visible = false;
            st_emp_ps_panelUp1.Visible = false;
        }
    //Promote / give increments to an emplpoyee
        int oldpos;
        double oldsal;
        private void st_emp_ps_btn_promote_Click(object sender, EventArgs e)
        {
            st_emp_ps_btn_update.Enabled = false;
            st_emp_ps_btn_remove.Enabled = false;
            st_emp_ps_btn_refresh.Enabled = false;
            st_emp_ps_btn_promote.Enabled = false;

            st_emp_ps_btn_cancel2.Visible = true;
            st_emp_ps_btn_save2.Visible = true;
            st_emp_ps_panelPr1.Visible = true;

            st_emp_ps_cb_position.DropDownStyle = ComboBoxStyle.DropDownList;
            st_emp_ps_cb_position.DataSource = mcm.LoadPositionComboBox();
            st_emp_ps_cb_position.ValueMember = "PositionID";
            st_emp_ps_cb_position.DisplayMember = "PosName";

            oldpos = Convert.ToInt32(st_emp_ps_dgv_employees.CurrentRow.Cells[10].Value.ToString());
            oldsal = Convert.ToDouble(st_emp_ps_dgv_employees.CurrentRow.Cells[11].Value.ToString());

            tmpID = Convert.ToInt32(st_emp_ps_dgv_employees.CurrentRow.Cells[0].Value);
            st_emp_ps_cb_position.SelectedValue = Convert.ToInt32(st_emp_ps_dgv_employees.CurrentRow.Cells[10].Value.ToString());
            st_emp_ps_tb_basicsal.Text = st_emp_ps_dgv_employees.CurrentRow.Cells[11].Value.ToString();

        }

        private void st_emp_ps_btn_save2_Click(object sender, EventArgs e)
        {
            if (st_emp_ps_cb_position.Text == "" || st_emp_ps_tb_basicsal.Text == "" || st_emp_ps_rtb_reason.Text == "")
            {
                MessageBox.Show("Please fill all the fields");
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to promote this employee?\nOnce promoted cannot be undone\nOnly one prmotion or salary increment can be donr in 1 day", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                 
                
                    st_emp_ps_btn_update.Enabled = true;
                    st_emp_ps_btn_remove.Enabled = true;
                    st_emp_ps_btn_refresh.Enabled = true;
                    st_emp_ps_btn_promote.Enabled = true;

                    st_emp_ps_btn_cancel2.Visible = false;
                    st_emp_ps_btn_save2.Visible = false;
                    st_emp_ps_panelPr1.Visible = false;

                    EmployeeObject emp = new EmployeeObject();

                    emp.empid = tmpID;
                    emp.position = Convert.ToInt32(st_emp_ps_cb_position.SelectedValue);
                    emp.basicsal = Convert.ToDouble(st_emp_ps_tb_basicsal.Text);
                    string reason = st_emp_ps_rtb_reason.Text;
                    mcm.PromoteEmployee(emp, reason,oldpos,oldsal);

                    st_emp_ps_dgv_employees.DataSource = mcm.loadEmployees();

                    st_emp_ps_cb_position.Text = "";
                    st_emp_ps_tb_basicsal.Text = "";
                    st_emp_ps_rtb_reason.Text = "";
                }
                else { }
            }
        }
    //Cancel the promote event
        private void st_emp_ps_btn_cancel2_Click(object sender, EventArgs e)
        {
            st_emp_ps_btn_update.Enabled = true;
            st_emp_ps_btn_remove.Enabled = true;
            st_emp_ps_btn_refresh.Enabled = true;
            st_emp_ps_btn_promote.Enabled = true;

            st_emp_ps_btn_cancel2.Visible = false;
            st_emp_ps_btn_save2.Visible = false;
            st_emp_ps_panelPr1.Visible = false;

            st_emp_ps_rtb_reason.Text = "";
        }
    //DELETE AN EMPLOYEE
        private void st_emp_ps_btn_remove_Click(object sender, EventArgs e)
        {
            int empid = Convert.ToInt32(st_emp_ps_dgv_employees.CurrentRow.Cells[0].Value);
            if (MessageBox.Show("Are You sure you want to remove this Employee?\nThis will delete all his records saved in the system", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                mcm.DeleteEmployee(empid);
                st_emp_ps_dgv_employees.DataSource = mcm.loadEmployees();
            }
            else { }
        }
    


    //Loading position combo boxes and allowances combo box
        private void st_alw_fa_cb_position_Enter(object sender, EventArgs e)
        {
            st_alw_fa_cb_position.DataSource = mcm.LoadPositionComboBox();
            st_alw_fa_cb_position.ValueMember = "PositionID";
            st_alw_fa_cb_position.DisplayMember = "PosName";
        }

        private void st_alw_fa_cb_allowances_Enter(object sender, EventArgs e)
        {
            st_alw_fa_cb_allowances.DataSource = mcm.LoadAllowanceComboBox();
            st_alw_fa_cb_allowances.ValueMember = "AllowanceID";
            st_alw_fa_cb_allowances.DisplayMember = "Name";
        }
//ADD POSITIONS
        private void st_pos_add_btn_save_Click(object sender, EventArgs e)
        {
            if (st_pos_add_tb_name.Text == "" || st_pos_add_tb_bsal.Text == "" || st_pos_add_tb_ot.Text == "")
            {
                MessageBox.Show("Please fill all the fields");
            }
            else
            {
                Positions ps = new Positions();

                ps.posName = st_pos_add_tb_name.Text;
                ps.bsal = Convert.ToDouble(st_pos_add_tb_bsal.Text);
                ps.otrate = Convert.ToDouble(st_pos_add_tb_ot.Text);

                if (mcm.AddPosition(ps))
                {
                    st_pos_view_dgv_positions.DataSource = mcm.loadGridView("SELECT * FROM Position");
                    st_pos_add_tb_name.Text = "";
                    st_pos_add_tb_bsal.Text = "";
                    st_pos_add_tb_ot.Text = "";
                }
                else { }
            }
        }
    //add position basic salary validation
        private void st_pos_add_tb_bsal_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != '.')
            {
                e.Handled = true;
            }
            if (Regex.IsMatch(st_pos_add_tb_bsal.Text, @"\.\d\d") && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
    //add position ot rate validation
        private void st_pos_add_tb_ot_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != '.')
            {
                e.Handled = true;
            }
            if (Regex.IsMatch(st_pos_add_tb_ot.Text, @"\.\d\d") && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void st_pos_view_btn_update_Click(object sender, EventArgs e)
        {
            st_pos_view_btn_update.Enabled = false;
            st_pos_view_btn_delete.Enabled = false;
            st_pos_view_panel_update.Visible = true;

            tmpID = Convert.ToInt32(st_pos_view_dgv_positions.CurrentRow.Cells[0].Value);
            st_pos_view_tb_bsal.Text = st_pos_view_dgv_positions.CurrentRow.Cells[2].Value.ToString();
            st_pos_view_tb_ot.Text = st_pos_view_dgv_positions.CurrentRow.Cells[3].Value.ToString();
        }
    //basic sal in position update validation
        private void st_pos_view_tb_bsal_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != '.')
            {
                e.Handled = true;
            }
            //if (e.KeyChar == '.' && st_pos_view_tb_bsal.Text.IndexOf('.') > -1)
            //{
            //    e.Handled = true;
            //}
            if (Regex.IsMatch(st_pos_view_tb_bsal.Text, @"\.\d\d") && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
    //ot rate in position update validation
        private void st_pos_view_tb_ot_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != '.')
            {
                e.Handled = true;
            }
            if (Regex.IsMatch(st_pos_view_tb_ot.Text, @"\.\d\d") && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
    //save the updated position details
        private void st_pos_view_btn_save_Click(object sender, EventArgs e)
        {
            Positions ps = new Positions();
            ps.id = tmpID;
            ps.bsal = Convert.ToDouble(st_pos_view_tb_bsal.Text);
            ps.otrate = Convert.ToDouble(st_pos_view_tb_ot.Text);

            if(mcm.UpdatePositionDetails(ps))
            {
                st_pos_view_dgv_positions.DataSource = mcm.loadGridView("SELECT * FROM Position");
                st_pos_view_panel_update.Visible = false;
                st_pos_view_btn_update.Enabled = true;
                st_pos_view_btn_delete.Enabled = true;
            }
            else {}
        }

        private void st_pos_view_btn_cancel_Click(object sender, EventArgs e)
        {
            st_pos_view_panel_update.Visible = false;
            st_pos_view_btn_update.Enabled = true;
            st_pos_view_btn_delete.Enabled = true;
        }
    //DELETE A POSITION
        private void st_pos_view_btn_delete_Click(object sender, EventArgs e)
        {
            String posName = st_pos_view_dgv_positions.CurrentRow.Cells[0].Value.ToString();
            if (posName == "Manager" || posName == "Driver" || posName == "Mechanic")
            {
                MessageBox.Show("Sorry you cannot delete this position.");
            }
            else
            {
                Positions ps = new Positions();
                ps.id = Convert.ToInt32(st_pos_view_dgv_positions.CurrentRow.Cells[0].Value);
                if (MessageBox.Show("Are You sure you want to remove this Position from the system?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (mcm.DeletePosition(ps))
                    {
                        st_pos_view_dgv_positions.DataSource = mcm.loadGridView("SELECT * FROM Position");
                    }
                    else { }
                }
                else { }
            }
        }
    //ADD NEW ALLOWANCE
        private void st_alw_aa_btn_add_Click(object sender, EventArgs e)
        {
            if (st_alw_aa_tb_name.Text == "")
            {
                MessageBox.Show("Please input the name of the allowance.");
            }
            else
            {
                String name = st_alw_aa_tb_name.Text;
                if(mcm.AddNewAllowance(name))
                {
                    st_alw_aa_tb_name.Text = "";
                    st_alw_aa_dgv_allowances.DataSource = mcm.loadGridView("SELECT * FROM Allowances");
                }
                else {} 
            }
        }
    //FIX POSITION AND AMOUNTS TO AN ALLOWANCE
        private void st_alw_fa_btn_fix_Click(object sender, EventArgs e)
        {
            if (st_alw_fa_cb_position.Text == "" || st_alw_fa_cb_allowances.Text == "" || st_alw_fa_tb_amount.Text == "")
            {
                MessageBox.Show("Please input the name of the allowance.");
            }
            else
            {
                int posid = Convert.ToInt32(st_alw_fa_cb_position.SelectedValue);
                int allid = Convert.ToInt32(st_alw_fa_cb_allowances.SelectedValue);
                double amount = Convert.ToDouble(st_alw_fa_tb_amount.Text);
                if(mcm.FixAllowance(posid,allid,amount))
                {
                    st_alw_fa_cb_position.Text = "";
                    st_alw_fa_cb_allowances.Text = "";
                    st_alw_fa_tb_amount.Text = "";
                    st_alw_v_dgv_allowances.DataSource = mcm.loadGridView("SELECT a.AllowanceID,a.Name as Allowance_Name,p.PosName as Position,pa.Amount FROM Allowances a,Position p, Position_Allowance pa WHERE pa.AllowanceID = a.AllowanceID and pa.PositionID = p.PositionID ORDER BY a.AllowanceID");
                }
                else {} 
            }
        }
    //amount in fix allowance validation
        private void st_alw_fa_tb_amount_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != '.')
            {
                e.Handled = true;
            }
            if (Regex.IsMatch(st_alw_fa_tb_amount.Text, @"\.\d\d") && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
    //amount in allowance update validation
        private void st_alw_v_tb_amount_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != '.')
            {
                e.Handled = true;
            }
            if (Regex.IsMatch(st_alw_v_tb_amount.Text, @"\.\d\d") && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void st_alw_v_btn_update_Click(object sender, EventArgs e)
        {
            st_alw_v_btn_update.Enabled = false;
            st_alw_v_btn_remove.Enabled = false;
            st_alw_v_panel_update.Visible = true;

            st_alw_v_tb_allid.Text = st_alw_v_dgv_allowances.CurrentRow.Cells[0].Value.ToString();
            st_alw_v_tb_posname.Text = st_alw_v_dgv_allowances.CurrentRow.Cells[2].Value.ToString();
        }

        private void st_alw_v_btn_save_Click(object sender, EventArgs e)
        {
            int aid = Convert.ToInt32(st_alw_v_tb_allid.Text);
            String posname = st_alw_v_tb_posname.Text;
            double amount = Convert.ToDouble(st_alw_v_tb_amount.Text);

            if(mcm.UpdateAllowance(aid,posname,amount))
            {
                st_alw_v_tb_amount.Text = "";
                st_alw_v_btn_update.Enabled = true;
                st_alw_v_btn_remove.Enabled = true;
                st_alw_v_panel_update.Visible = false;

                st_alw_v_dgv_allowances.DataSource = mcm.loadGridView("SELECT a.AllowanceID,a.Name as Allowance_Name,p.PosName as Position,pa.Amount FROM Allowances a,Position p, Position_Allowance pa WHERE pa.AllowanceID = a.AllowanceID and pa.PositionID = p.PositionID ORDER BY a.AllowanceID");
            }
            else { }
        }

        private void st_alw_v_btn_remove_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you need to stop giving this allowance\nand remove it from the system?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int allid = Convert.ToInt32(st_alw_v_dgv_allowances.CurrentRow.Cells[0].Value.ToString());
                String posname = st_alw_v_dgv_allowances.CurrentRow.Cells[2].Value.ToString();

                if (mcm.DeletePositionAllowance(allid,posname))
                {
                    st_alw_v_dgv_allowances.DataSource = mcm.loadGridView("SELECT a.AllowanceID,a.Name as Allowance_Name,p.PosName as Position,pa.Amount FROM Allowances a,Position p, Position_Allowance pa WHERE pa.AllowanceID = a.AllowanceID and pa.PositionID = p.PositionID ORDER BY a.AllowanceID");
                }
                else { }
            }
            else { }

            
        }
    //DELETE THE ALLOWANCE FROM EVERYWHERE
        private void st_alw_aa_btn_delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you need to stop giving this allowance?\nA lot of employees might be geting this allowance.", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int aid = Convert.ToInt32(st_alw_aa_dgv_allowances.CurrentRow.Cells[0].Value.ToString());

                if (mcm.DeleteAllowance(aid))
                {
                    st_alw_aa_dgv_allowances.DataSource = mcm.loadGridView("SELECT * FROM Allowances");
                }
                else { }
            }
            else { }
            

        }
    //SEARCH FOR WORKED OT HOURS OF AN EMPLOYEE
        private void st_ot_vr_btn_search_Click(object sender, EventArgs e)
        {
            string empid = st_ot_vr_tb_empid.Text;
            string q2 = "SELECT * FROM OT WHERE EmployeeID ='"+empid+"' ORDER BY Date DESC";
            st_ot_vr_dgv_otemp.DataSource = mcm.loadGridView(q2);
        }
    //SEARCH TEXT BOX INPUT ONLY NUMBERS
        private void st_ot_vr_tb_empid_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }
    //REFRESH THE GRID
        private void st_ot_vr_btn_refresh_Click(object sender, EventArgs e)
        {
            string q2 = "SELECT * FROM OT ORDER BY Date DESC";
            st_ot_vr_dgv_otemp.DataSource = mcm.loadGridView(q2);
        }

        private void st_ot_aoth_btn_save_Click(object sender, EventArgs e)
        {
            if (st_ot_aoth_tb_empid.Text == "" || st_ot_aoth_tb_othours.Text == "")
            {
                MessageBox.Show("Please fill all the fields");
            }
            else
            {
                int empid = Convert.ToInt32(st_ot_aoth_tb_empid.Text);
                int hours = Convert.ToInt32(st_ot_aoth_tb_othours.Text);
                DateTime dt = st_ot_aoth_dtp_date.Value.Date;

                if(mcm.AddOTHours(empid,hours,dt))
                {
                    MessageBox.Show("OT Hours added successfully");

                    st_ot_aoth_tb_empid.Text = "";
                    st_ot_aoth_tb_othours.Text = "";
                    st_ot_aoth_dtp_date.Value = DateTime.Today;
                    st_ot_vr_btn_refresh_Click(sender, e);
                }
                else
                {
                }
            }
        }

        private void st_alw_v_btn_cancel_Click(object sender, EventArgs e)
        {
            st_alw_v_panel_update.Visible = false;
            st_alw_v_btn_update.Enabled = true;
            st_alw_v_btn_remove.Enabled = true;
        }

    //LEAVE.. clear
        private void st_le_al_btn_clear_Click(object sender, EventArgs e)
        {
            st_le_al_tb_empid.Text = "";
            st_le_al_dtp_start.Value = DateTime.Today.AddDays(1);
            st_le_al_dtp_end.Value = st_le_al_dtp_start.Value;
            st_le_al_rb_cashual.Checked = false;
            st_le_al_rb_annual.Checked = false;
            st_le_al_rb_medical.Checked = false;
            st_le_al_rb_other.Checked = false;
            st_le_al_rb_halfday.Checked = false;
            st_le_al_cb_session.Text = "";
            st_le_al_rtb_reason.Text = "Personal";
            st_le_al_lb_durationvalue.Text = "";
        }
    //Request Leave
        private void st_le_al_btn_apply_Click(object sender, EventArgs e)
        {
            Leave le = new Leave();

            if(st_le_al_tb_empid.Text == "" || (st_le_al_rb_cashual.Checked == false && st_le_al_rb_annual.Checked == false &&
            st_le_al_rb_medical.Checked == false && st_le_al_rb_other.Checked == false && st_le_al_rb_halfday.Checked == false)
                || st_le_al_rtb_reason.Text == "")
            {
                MessageBox.Show("Please fill all the fields");
            }
            else
            {
                if (0 == le.CalculateWorkingDays(st_le_al_dtp_start.Value.Date, st_le_al_dtp_end.Value.Date))
                {
                    MessageBox.Show("Please select valid dates");
                }
                else
                {
                    if (st_le_al_rb_halfday.Checked == true && st_le_al_cb_session.Text == "")
                    {
                        MessageBox.Show("Please select the session you need to have the half day");
                    }
                    else
                    {
                        le.empid = Convert.ToInt32(st_le_al_tb_empid.Text);
                        le.start = st_le_al_dtp_start.Value.Date;
                        le.end = st_le_al_dtp_end.Value.Date;
                        le.duration = le.CalculateWorkingDays(le.start, le.end);
                        le.status = false;
                        le.reason = st_le_al_rtb_reason.Text;

                        if (st_le_al_rb_other.Checked == true)
                        {
                            le.type = st_le_al_rb_other.Text;
                        }
                        else if (st_le_al_rb_annual.Checked == true)
                        {
                            le.type = st_le_al_rb_annual.Text;
                        }
                        else if (st_le_al_rb_cashual.Checked == true)
                        {
                            le.type = st_le_al_rb_cashual.Text;
                        }
                        else if (st_le_al_rb_medical.Checked == true)
                        {
                            le.type = st_le_al_rb_medical.Text;
                        }
                        else
                        {
                            le.type = st_le_al_rb_halfday.Text;
                            le.session = st_le_al_cb_session.Text;
                        }

                        if (mcm.CheckLeaveBalance(le))
                        {
                            if (mcm.checkIfOnLeave(le))
                            {
                                MessageBox.Show("This person has already applied for a leave in this duration");
                            }
                            else
                            {
                                if (MessageBox.Show("Are you sure you need to request for a leave?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                {
                                    if (mcm.RequestLeave(le))
                                    {
                                        Notification not = new Notification();
                                        not.Description1 = "Outstanding leave request from "+le.empid;
                                        not.Category1 = "Leave Request";
                                        not.ClearanceLevel1 = 2;
                                        mcm.SendNotification(not);

                                        MessageBox.Show("Leave has been sent to approve");
                                        st_le_al_btn_clear_Click(sender, e);
                                        string q = "SELECT EmployeeID,StartDate,EndDate,Duration,LeaveType,ApproveStatus FROM Leave ";
                                        st_le_vl_dgv_leaves.DataSource = mcm.loadGridView(q);
                                    }
                                    else { }
                                }
                                else { }
                            }
                        }
                    }
                }
            }
        }

        private void st_le_al_dtp_end_ValueChanged(object sender, EventArgs e)
        {
            Leave le = new Leave();
            //TimeSpan ts = st_le_al_dtp_end.Value - st_le_al_dtp_start.Value;
            //int du = ts.Days + 1;

           // st_le_al_lb_durationvalue.Text = du.ToString();
            st_le_al_lb_durationvalue.Text = le.CalculateWorkingDays(st_le_al_dtp_start.Value.Date, st_le_al_dtp_end.Value.Date).ToString();
        }

        private void st_le_al_dtp_start_ValueChanged(object sender, EventArgs e)
        {
            st_le_al_dtp_end.MinDate = st_le_al_dtp_start.Value.Date;
            st_le_al_dtp_end.Value = st_le_al_dtp_start.Value;
        }

        private void st_emp_ea_btn_in_Click(object sender, EventArgs e)
        {
            Attendance att = new Attendance();

            att.empid = Convert.ToInt32(st_emp_ea_dgv_emp.CurrentRow.Cells[0].Value);
            att.date = DateTime.Today.Date;
            att.timein = DateTime.Now.TimeOfDay;
            if (att.timein > TimeSpan.Parse("09:00:00"))
            {
                att.late = att.timein - TimeSpan.Parse("09:00:00");
                att.status = "LT";
            }
            else
            {
                att.late = TimeSpan.Parse("00:00:00");
                att.status = "PP";
            }
            if (mcm.EmployeeIn(att))
            {
                st_emp_ea_btn_refresh_Click(sender, e);
            }
            else { }
        }

        private void st_emp_ea_btn_refresh_Click(object sender, EventArgs e)
        {
            st_emp_ea_dgv_emp.DataSource = mcm.loadGridView("SELECT EmployeeID,Name FROM Employee");
        }

        private void st_emp_ea_btn_out_Click(object sender, EventArgs e)
        {
            Attendance att = new Attendance();
            att.timeout = DateTime.Now.TimeOfDay;
            att.empid = Convert.ToInt32(st_emp_ea_dgv_emp.CurrentRow.Cells[0].Value);
            att.date = DateTime.Today.Date;

            if (mcm.EmployeeOut(att))
            {
                string q = "SELECT * FROM Attendance";
                st_emp_ea_dgv_attendance.DataSource = mcm.loadGridView(q);
            }
            else { }
        }

        private void st_le_al_rb_halfday_CheckedChanged(object sender, EventArgs e)
        {
            DateTime dt = st_le_al_dtp_end.Value;
            st_le_al_cb_session.Enabled = (st_le_al_rb_halfday.Checked == true) ? true : false;
            if (st_le_al_rb_halfday.Checked == true)
            {
                st_le_al_dtp_end.Value = st_le_al_dtp_start.Value;
                st_le_al_dtp_end.Enabled = false;
            }
            else
            {
                st_le_al_dtp_end.Value = dt;
                st_le_al_dtp_end.Enabled = true;
            }
        }

        private void st_le_vl_lb_search_Click(object sender, EventArgs e)
        {
            if(st_le_vl_tb_empid.Text != "")
            {
                if (st_le_vl_checkbox_year.Checked == false && st_le_vl_checkbox_month.Checked == false)
                {
                    String q = "SELECT EmployeeID,StartDate,EndDate,Duration,LeaveType,ApproveStatus FROM Leave "
                                +" WHERE EmployeeID = '"+ Convert.ToInt32(st_le_vl_tb_empid.Text) + "'";
                    st_le_vl_dgv_leaves.DataSource = mcm.loadGridView(q);
                }
                else if (st_le_vl_checkbox_year.Checked == true && st_le_vl_checkbox_month.Checked == false)
                {
                    if (st_le_vl_cb_year.Text != "")
                    {
                        String q = "SELECT EmployeeID,StartDate,EndDate,Duration,LeaveType,ApproveStatus FROM Leave "
                                + " WHERE EmployeeID = '" + Convert.ToInt32(st_le_vl_tb_empid.Text) + "'"
                                + " AND (YEAR(StartDate) = '" + st_le_vl_cb_year.Text + "' OR YEAR(EndDate) = '"
                                + st_le_vl_cb_year.Text + "')";
                        st_le_vl_dgv_leaves.DataSource = mcm.loadGridView(q);
                    }
                    else
                    {
                        MessageBox.Show("Please Select a Year");
                    }
                }
                else if (st_le_vl_checkbox_year.Checked == true && st_le_vl_checkbox_month.Checked == true)
                {
                    if (st_le_vl_cb_year.Text != "" && st_le_vl_cb_month.Text != "")
                    {
                        int month = st_le_vl_cb_month.SelectedIndex + 1;
                        String q = "SELECT EmployeeID,StartDate,EndDate,Duration,LeaveType,ApproveStatus FROM Leave "
                                + " WHERE EmployeeID = '" + Convert.ToInt32(st_le_vl_tb_empid.Text) + "'"
                                + " AND (YEAR(StartDate) = '" + st_le_vl_cb_year.Text + "' OR YEAR(EndDate) = '"
                                + st_le_vl_cb_year.Text + "') AND (MONTH(StartDate) = '" + month
                                + "' OR MONTH(EndDate) = '" + month + "')";
                        st_le_vl_dgv_leaves.DataSource = mcm.loadGridView(q);
                    }
                    else
                    {
                        MessageBox.Show("Year or Month is missing");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please enter the Employee ID");
            }
        }

        private void st_le_vl_lb_refresh_Click(object sender, EventArgs e)
        {
            String q = "SELECT EmployeeID,StartDate,EndDate,Duration,LeaveType,ApproveStatus FROM Leave ";
            st_le_vl_dgv_leaves.DataSource = mcm.loadGridView(q);
        }

        private void st_le_vl_llb_adsearch_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
             
            st_le_vl_gb_advance.Visible = (st_le_vl_gb_advance.Visible == false) ? true : false;

            if (st_le_vl_gb_advance.Visible == false)
            {
                st_le_vl_checkbox_year.Checked = false;
                st_le_vl_checkbox_month.Checked = false;
                st_le_vl_llb_adsearch.Text = "Advance Seach Options";
            }
            else
            {
                st_le_vl_llb_adsearch.Text = "Advance Seach Options ^";
            }
        }

        private void st_le_vl_checkbox_year_CheckedChanged(object sender, EventArgs e)
        {
            st_le_vl_checkbox_month.Enabled = (st_le_vl_checkbox_year.Checked == true) ? true : false;
            if (st_le_vl_checkbox_year.Checked == false)
            {
                st_le_vl_checkbox_month.Checked = false;
            }
        }

        private void st_le_vl_btn_leavebal_Click(object sender, EventArgs e)
        {
            if (st_le_vl_tb_empid2.Text != "")
            {
                Leave le = new Leave();
                le.empid = Convert.ToInt32(st_le_vl_tb_empid2.Text);
                le.duration = 0;
                mcm.CheckLeaveBalance(le);
            }
            else
            {
                MessageBox.Show("Please input the employee id");
            }
        }

        private void st_emp_ea_dtp_date_ValueChanged(object sender, EventArgs e)
        {
            //DateTime dt = st_emp_ea_dtp_date.Value.Date;
            //String date = dt.ToString("yyyy-MM-dd");
            //MessageBox.Show(date);
            //string q = "SELECT * FROM Attendance WHERE Date = '" + date + "'";
            //st_emp_ea_dgv_attendance.DataSource = mcm.loadGridView(q);

            String d = st_emp_ea_dtp_date.Value.ToString("yyyy-MM-dd");
            if (st_emp_ea_cb_position.Text == "All")
            {
                string q = "SELECT * FROM Attendance WHERE Date = '" + d + "'";
                st_emp_ea_dgv_attendance.DataSource = mcm.loadGridView(q);
            }
            else
            {
                String pos = st_emp_ea_cb_position.Text;
                String q = "select a.* FROM Employee e, Position p, Attendance a"
                          + " WHERE p.PosName = '" + pos + "' AND a.EmployeeID = e.EmployeeID"
                          + " AND e.Position = p.PositionID AND Date = '" + d + "'";
                st_emp_ea_dgv_attendance.DataSource = mcm.loadGridView(q);
            }
        }

        private void st_emp_ea_cb_position_SelectedIndexChanged(object sender, EventArgs e)
        {
            String d = st_emp_ea_dtp_date.Value.ToString("yyyy-MM-dd");
            if (st_emp_ea_cb_position.Text == "All")
            {
                string q = "SELECT * FROM Attendance WHERE Date = '" + d + "'";
                st_emp_ea_dgv_attendance.DataSource = mcm.loadGridView(q);
            }
            else
            {
                String pos = st_emp_ea_cb_position.Text;
                String q = "select a.* FROM Employee e, Position p, Attendance a"
                          + " WHERE p.PosName = '" + pos + "' AND a.EmployeeID = e.EmployeeID"
                          + " AND e.Position = p.PositionID AND Date = '" + d + "'";
                st_emp_ea_dgv_attendance.DataSource = mcm.loadGridView(q);
            }
        }
//SALARY CALCULATION EMPLOYEE SEARCH
        private void st_emp_sal_btn_search_Click(object sender, EventArgs e)
        {
            if (st_emp_sal_tb_empid.Text != "")
            {
                Salary sal = new Salary();
                sal.empid = Convert.ToInt32(st_emp_sal_tb_empid.Text);
                if (mcm.checkEmployeeExistence(sal.empid))
                {
                    st_emp_sal_btn_search.Enabled = false;
                    st_emp_sal_tb_empid.Enabled = false;

                    sal = mcm.GetEmployeeDetails(sal);

                    st_emp_sal_tb_name.Text = sal.name;
                    st_emp_sal_tb_position.Text = sal.position;
                    st_emp_sal_tb_basicsalary.Text = sal.basicsal.ToString();

                    sal = mcm.CalculateOTPayment(sal);
                    st_emp_sal_tb_ot.Text = sal.ot.ToString();

                    String q2 = "SELECT pa.Amount, a.Name FROM Position_Allowance pa, Allowances a,Position p " +
                            "WHERE  p.PosName = '" + sal.position + "' AND pa.PositionID = p.PositionID AND pa.AllowanceID = a.AllowanceID";
                    st_emp_sal_dgv_allwoances.DataSource = mcm.loadGridView(q2);

                    sal.totalallowance = mcm.CalculateTotalAllowances(sal);
                    st_emp_sal_tb_totalallwoances.Text = sal.totalallowance.ToString();

                    double totaddi = mcm.getTotAdditionalPayment(sal.empid);
                    totAdditional(totaddi.ToString());

                    sal.grosssalary = sal.basicsal + sal.ot + totAdditional() + sal.totalallowance;
                    st_emp_sal_tb_grosssalary.Text = sal.grosssalary.ToString();

                    sal = sal.CalculateEPF(sal);
                    st_emp_sal_tb_epf.Text = sal.epfEmployeeAmount.ToString();
                    st_emp_sal_tb_etf.Text = sal.etf.ToString();

                    sal = mcm.CalculateNoPay(sal);
                    st_emp_sal_tb_nopay.Text = sal.nopay.ToString();

                    sal.netsalary = sal.grosssalary - sal.epfEmployeeAmount - sal.nopay;
                    st_emp_sal_tb_netsalary.Text = sal.netsalary.ToString();
                }
                else
                {
                    MessageBox.Show("Please Enter a valid employee id");
                }
            }
            else
            {
                MessageBox.Show("Please Enter the employee id");
            }
        }
        public void totAdditional(String value)
        {
            st_emp_sal_tb_additionalpayments.Text = value;
        }
        public Double totAdditional()
        {
            return Convert.ToDouble(st_emp_sal_tb_additionalpayments.Text);
        }

        private void st_emp_sal_btn_addpayment_Click(object sender, EventArgs e)
        {
            if (st_emp_sal_tb_empid.Text != "" && st_emp_sal_tb_name.Text != "")
            {
                int empid = Convert.ToInt32(st_emp_sal_tb_empid.Text);
                EmployeeAdditionalPayments eap = new EmployeeAdditionalPayments(this,empid);
                eap.Show();
            }
            else
            {
                MessageBox.Show("Please search for an employee first.");
            }
 
        }
        public void grossLabelrefresh()
        {
            st_emp_sal_lb_gross.Text = "Refresh";
        }

        private void st_emp_sal_btn_clear_Click(object sender, EventArgs e)
        {
            st_emp_sal_tb_empid.Enabled = true;
            st_emp_sal_btn_search.Enabled = true;
            st_emp_sal_tb_empid.Text = "";
            st_emp_sal_tb_name.Text = "";
            st_emp_sal_tb_position.Text = "";
            st_emp_sal_tb_basicsalary.Text = "";
            st_emp_sal_tb_etf.Text = "";
            st_emp_sal_tb_ot.Text = "";
            st_emp_sal_tb_totalallwoances.Text = "";
            st_emp_sal_tb_additionalpayments.Text = "";
            st_emp_sal_tb_grosssalary.Text = "";
            st_emp_sal_lb_gross.Text = "Gross";
            st_emp_sal_tb_epf.Text = "";
            st_emp_sal_tb_nopay.Text = "";
            st_emp_sal_tb_netsalary.Text = "";
            st_emp_sal_dgv_allwoances.DataSource = null;
        }

        private void st_emp_sal_lb_gross_TextChanged(object sender, EventArgs e)
        {
            if (st_emp_sal_lb_gross.Text == "Refresh")
            {
                double basicsal = Convert.ToDouble(st_emp_sal_tb_basicsalary.Text);
                double ot = Convert.ToDouble(st_emp_sal_tb_ot.Text);
                Double totAll = Convert.ToDouble(st_emp_sal_tb_totalallwoances.Text);
                double grosssalary = basicsal + totAdditional() + totAll;
                st_emp_sal_tb_grosssalary.Text = grosssalary.ToString();
                
                Double epf = Double.Parse(st_emp_sal_tb_epf.Text);
                double nopay = Double.Parse(st_emp_sal_tb_nopay.Text);
                Double netSal = grosssalary - epf - nopay;
                st_emp_sal_tb_netsalary.Text = netSal.ToString();
                st_emp_sal_lb_gross.Text = "Gross";
            }
        }

        private void st_emp_sal_btn_save_Click(object sender, EventArgs e)
        {
            Salary sal = new Salary();

            sal.empid = Int32.Parse(st_emp_sal_tb_empid.Text);
            sal.name = st_emp_sal_tb_name.Text;
            sal.basicsal = Double.Parse(st_emp_sal_tb_basicsalary.Text);
            sal.netsalary = Double.Parse(st_emp_sal_tb_netsalary.Text);
            sal = sal.CalculateEPF(sal);

            mcm.SaveSalaryDetails(sal);
        }

        private void st_le_al_btn_approve_Click(object sender, EventArgs e)
        {
            int eid = Convert.ToInt32(st_le_al_tb_empid.Text);
            DateTime dt = st_le_al_dtp_start.Value;
            int notiID = notID;

            if (mcm.ApproveLeave(eid, dt))
            {
                MessageBox.Show("Leave is approved.");
                mcm.DeleteNotification(notiID);
                st_le_al_btn_clear_Click(sender, e);

                st_le_al_tb_empid.Enabled = true;

                st_le_al_dtp_start.MinDate = DateTime.Today.AddDays(1);
                st_le_al_dtp_end.MinDate = st_le_al_dtp_start.Value;
                st_le_al_dtp_end.MaxDate = DateTime.Today.AddMonths(6);
                
                st_le_al_dtp_start.Enabled = true;
                st_le_al_dtp_end.Enabled = true;

                st_le_al_rb_cashual.Enabled = true;
                st_le_al_rb_annual.Enabled = true;
                st_le_al_rb_medical.Enabled = true;
                st_le_al_rb_other.Enabled = true;
                st_le_al_rb_halfday.Enabled = true;

                st_le_al_cb_session.Enabled = false;
                st_le_al_rtb_reason.Enabled = true;
                st_le_al_btn_clear.Visible = true;
                st_le_al_btn_apply.Visible = true;
                st_le_al_btn_reject.Visible = false;
                st_le_al_btn_approve.Visible = false;
            }
            else { }
        }

        private void st_le_al_btn_reject_Click(object sender, EventArgs e)
        {
            int eid = Convert.ToInt32(st_le_al_tb_empid.Text);
            DateTime dt = st_le_al_dtp_start.Value;
            int notiID = notID;
            if (mcm.deleteLeave(eid, dt))
            {
                MessageBox.Show("Leave is rejected");
                mcm.DeleteNotification(notiID);
                st_le_al_btn_clear_Click(sender, e);

                st_le_al_tb_empid.Enabled = true;

                st_le_al_dtp_start.MinDate = DateTime.Today.AddDays(1);
                st_le_al_dtp_end.MinDate = st_le_al_dtp_start.Value;
                st_le_al_dtp_end.MaxDate = DateTime.Today.AddMonths(6);

                st_le_al_dtp_start.Enabled = true;
                st_le_al_dtp_end.Enabled = true;

                st_le_al_rb_cashual.Enabled = true;
                st_le_al_rb_annual.Enabled = true;
                st_le_al_rb_medical.Enabled = true;
                st_le_al_rb_other.Enabled = true;
                st_le_al_rb_halfday.Enabled = true;

                st_le_al_cb_session.Enabled = false;
                st_le_al_rtb_reason.Enabled = true;
                st_le_al_btn_clear.Visible = true;
                st_le_al_btn_apply.Visible = true;
                st_le_al_btn_reject.Visible = false;
                st_le_al_btn_approve.Visible = false;
            }
            else { }
        }



    }
}
