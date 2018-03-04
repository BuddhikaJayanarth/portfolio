using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using megacoolnew.userObjects;
using System.Data.SqlClient;


namespace megacoolnew
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            avCusFillGrid();

            RepairEmpFillGrid();

            RepairInvFillGrid();

            RepairFillGrid();

            
 
            comboBoxR_Type.Items.Add("PRO");

            comboBoxR_Type.Items.Add("VEH");
        }

        public void avCusFillGrid()
        {

            MegaCoolMethods mcm = new MegaCoolMethods();

            string q = "select NIC from Customer ";

            dgvCNIC.DataSource = mcm.loadGridView(q); 

        }

        public void RepairUpdateFillGrid()
        {  
            MegaCoolMethods mcm = new MegaCoolMethods();

            string q = "select * from Repair_Job ";

            dgv_re_table.DataSource = mcm.loadGridView(q); 
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            if (txtCus.Text == "" || comboBoxR_Type.Text == "" || txtDetails.Text == "" || comboSupervisor.Text == "")
            {

                MessageBox.Show("Please fill the all required feilds");
            }
            else
            {

               RepairObject objRepair = new RepairObject();

               CustomerObject objCustomer = new CustomerObject();

               EmployeeObject objEmployee = new EmployeeObject();

               objCustomer.Nic = txtCus.Text;

               objRepair.JobStartDate = dtpStart.Value;

               objRepair.JobEndDate = dtpEnd.Value;

               objRepair.rType = comboBoxR_Type.Text;

               objRepair.Details = txtDetails.Text;

               objEmployee.empid = Convert.ToInt32(comboSupervisor.SelectedValue);

          

               bool checker1 = false;

               bool checker2 = false;

     

               if (objRepair.JobStartDate >= DateTime.Today)
               {
                 checker1 = true;
               } 

               if (objRepair.JobEndDate >= DateTime.Today)
               {
                 checker2 = true;
               }

               if (checker1 == false || checker2 == false)
               {
                 MessageBox.Show("You cant enter this date");
               }
               else
               {

 
                    string nic = txtCus.Text;

                    if ((nic.Count(char.IsDigit) == 9) && nic.EndsWith("v", StringComparison.OrdinalIgnoreCase))
                    {

                        DialogResult dr;
                        dr = MessageBox.Show("Do you want to save the record", "Confirm", MessageBoxButtons.YesNo);
                        if (dr.ToString() == "Yes")
                        {
                            try
                            {


                                MegaCoolMethods mcm = new MegaCoolMethods();


                                bool result = mcm.AddNewRepairJob(objRepair, objCustomer, objEmployee);

                                if (result)
                                {
                                    MessageBox.Show("Successfully Saved", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);


                                    RepairFillGrid();

                                    avCusFillGrid();

                                    SqlConnection con = ConnectionManager.GetConnection();

                                    con.Open();

                                    string qu = "SELECT TOP 1 JobID FROM Repair_Job ORDER BY JobID DESC";

                                    SqlCommand newcmd = con.CreateCommand();

                                    newcmd.CommandText = qu;

                                    SqlDataReader reader = newcmd.ExecuteReader();

                                    reader.Read();

                                    int y = reader.GetInt32(0);

                                    txtJobID.Text = Convert.ToString(y);

                                    tabControl1.SelectedTab = tabPage2;

                                }
                                else
                                {
                                    MessageBox.Show("Unable to Save", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            catch (ApplicationException appEx)
                            {

                                MessageBox.Show(appEx.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }

                            catch (Exception ex)
                            {

                                throw ex;

                            }
                        }
                        else
                            MessageBox.Show("Record is not saved", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    else
                    {
                        MessageBox.Show("Error in NIC");
                    }
                }

            }
        
        }

        public void RepairFillGrid()
        {  
            MegaCoolMethods mcm = new MegaCoolMethods();

            string q = "select j.JobID, j.Type, j.JobStartDate, j.JobEndDate, j.Details, j.CustomerNIC, e.Name as Supervisor from Repair_Job j, Employee e where e.EmployeeID = j.Supervisor ";

            dgv_re_table.DataSource = mcm.loadGridView(q); 
        }

        public void RepairEmpCurrentFillGrid()
        {
    
            MegaCoolMethods mcm = new MegaCoolMethods();

            string q = "select e.EmployeeID, e.Name from Employee e, Employee_Repair_Job erj where e.EmployeeID = erj.EmployeeID AND erj.JobID = '" + txtJobID.Text + "'";

            dgvCurrentEmp.DataSource = mcm.loadGridView(q);  
        } 

        public void RepairEmpFillGrid()
        {
   
            MegaCoolMethods mcm = new MegaCoolMethods();

            string q = "select e.EmployeeID, e.Name, count(erj.JobID) as No_Of_Current_Working_Jobs from Employee_Repair_Job erj, Employee e where e.EmployeeID = erj.EmployeeID group by e.EmployeeID, e.Name ";

            dgv_reEm_table.DataSource = mcm.loadGridView(q);  
        }

        public void RepairInvFillGrid()
        {   

            MegaCoolMethods mcm = new MegaCoolMethods();

            string q = "select* from Inventory";

            dgv_reIn_table.DataSource = mcm.loadGridView(q); 


        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            RepairObject objRepair = new RepairObject();

            StockObject objStock = new StockObject();

            objStock.inventoryID = cbInventID.Text;

      //      objEmployee.empid = Convert.ToInt32(comboSupervisor.SelectedValue);


            objRepair.ItemNo = txtItemNO.Text;

            if (objStock.inventoryID == "" || txtJobID2.Text == "" || txtItemNO.Text == "" || txtCost.Text == "")
            {

                MessageBox.Show("Please fill the all required feilds");
            }
            else
            {

                objRepair.JobID = Convert.ToInt32(txtJobID2.Text);

                objStock.sellingPrice = Convert.ToDouble(txtCost.Text);
         
                DialogResult dr;
                dr = MessageBox.Show("Do you want to save the record", "Confirm", MessageBoxButtons.YesNo);
                if (dr.ToString() == "Yes")
                {

                    try
                    {


                        MegaCoolMethods mcm = new MegaCoolMethods();


                        bool result = mcm.RepairInventory(objRepair, objStock);

                        if (result)
                        {
                            MessageBox.Show("Successfully Saved", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);


                            RepairFillGrid();

                            RepairInvFillGrid();

                            RepairInventoryFillGrid();

                        }
                        else
                        {
                            MessageBox.Show("Unable to Save", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (ApplicationException appEx)
                    {

                        MessageBox.Show(appEx.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    catch (Exception ex)
                    {

                        throw ex;

                    }
                }
                else
                    MessageBox.Show("Record is not saved", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
         
            } 
        
        }



        private void btnEmployee_Click(object sender, EventArgs e)
        {
        

             string Jobss =  txtJobID.Text;

             string EmpIDss = txtEmployeeID.Text;

             if( Jobss == "" || EmpIDss == "")
            {

                MessageBox.Show("Please fill the all required feilds");
            }
            else
            {
                RepairObject objRepair = new RepairObject();

                EmployeeObject objEmployee = new EmployeeObject();

                objEmployee.empid = Convert.ToInt32(txtEmployeeID.Text);

                objRepair.JobID = Convert.ToInt32(txtJobID.Text);
             
                DialogResult dr;
                dr = MessageBox.Show("Do you want to save the record", "Confirm", MessageBoxButtons.YesNo);
                if (dr.ToString() == "Yes")
                {
                    try
                    {


                        MegaCoolMethods mcm = new MegaCoolMethods();


                        bool result = mcm.EmpRepair(objRepair, objEmployee);

                        if (result)
                        {
                            MessageBox.Show("Successfully Saved", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);


                            RepairEmpFillGrid();

                            RepairEmpCurrentFillGrid();

                            txtEmployeeID.Clear();

                        }
                        else
                        {
                            MessageBox.Show("Unable to Save", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }


                    catch (Exception ex)
                    {

                        MessageBox.Show("" + ex);

                    }
                }
                else
                    MessageBox.Show("Record is not saved", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } 
        }

        public void RepairInventoryFillGrid()
        {

            MegaCoolMethods mcm = new MegaCoolMethods();

            string q = "select InventoryID, ItemNo, SellingPrice AS Cost from Repair_Inventory where JobID =  '" + txtJobID2.Text + "'";
            dgv_Invde.DataSource = mcm.loadGridView(q);
        }

        private void btnReInv_Click(object sender, EventArgs e)
        {
            RepairObject objRepair = new RepairObject();

        //    objRepair.JobID = Convert.ToInt32(txtJobID2.Text);

            string jobIDss = txtJobID2.Text;

            if (jobIDss == "")
            {
                MessageBox.Show("Please Enter the Job ID");
            }

            else
            {
                int JobID = objRepair.JobID;

                RepairInventoryFillGrid();
            }

        }

        private void btnCurrentEmp_Click(object sender, EventArgs e)
        {
           // int? JobID = null;

        //   JobID = int.Parse(txtJobID.Text);

            string JobID = txtJobID.Text;

            if (JobID == "")
            {
                MessageBox.Show("Please Enter the Job ID");
            }

            else
            {
                RepairEmpCurrentFillGrid();
            }

        }



        private void btnClear1_Click(object sender, EventArgs e)
        {
            txtCus.Clear();

            txtDetails.Clear();

            //txtSupervisor1.Clear();

            txtJobID3.Clear();

        }

        private void btnClear2_Click(object sender, EventArgs e)
        {
            txtJobID2.Clear();          

            txtItemNO.Clear();

            txtCost.Clear();
        }

        private void btnReleaseEmp_Click(object sender, EventArgs e)
        {
            string Jobss =  txtJobID.Text;

            string EmpIDss = txtEmployeeID.Text;

            if (Jobss == "" || EmpIDss == "")
            {

                MessageBox.Show("Please fill the all required feilds");
            }
            else
            {

                

              //  string EmployeeID = txtEmployeeID.Text;

              //  string JobID = txtJobID.Text;
               RepairObject objRepair = new RepairObject();

               EmployeeObject objEmployee = new EmployeeObject();

               objEmployee.empid = Convert.ToInt32(txtEmployeeID.Text);

               objRepair.JobID = Convert.ToInt32(txtJobID.Text);

               
               

                DialogResult dr;

                dr = MessageBox.Show("Do you want to Release this Employee", "Confirm", MessageBoxButtons.YesNo);

                MegaCoolMethods mcm = new MegaCoolMethods();

                bool result = mcm.ReleaseEmployee(objRepair, objEmployee);

                if (dr.ToString() == "Yes")
                {
                    if (result)
                    {
                        MessageBox.Show("Employee Released", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        RepairEmpCurrentFillGrid();
                        RepairEmpFillGrid();

                        txtEmployeeID.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Unable to Delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    MessageBox.Show("Record is not deleted", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDEMO_Click(object sender, EventArgs e)
        {
            txtCus.Text = "859756435v";

            txtDetails.Text = "This is a Refrigerator that has a problem in cooling system";

            comboSupervisor.Text = "2";
        }


        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RepairUpdateFillGrid();
        }


        private void btnUpdateJob_Click(object sender, EventArgs e)
        {
            RepairObject objRepair = new RepairObject();

            EmployeeObject objEmployee = new EmployeeObject();

           

            objRepair.rType = comboBoxR_Type.Text;

            objRepair.JobEndDate = dtpEnd.Value;

            objRepair.Details = txtDetails.Text;

            string JobIDss = txtJobID3.Text;

            string Superviss = comboSupervisor.Text;

            if (JobIDss == "" || objRepair.rType == "" || txtDetails.Text == "" || comboSupervisor.Text == "")
            {

                MessageBox.Show("Please fill the all required feilds");
            }
            else
            {

                
                bool checker = false;

          

                if (objRepair.JobEndDate >= DateTime.Today)
                {
                    checker = true;
                }

                if (checker == false)
                {
                    MessageBox.Show("You cant enter this date");
                }
                else
                {
                    objRepair.JobID = Convert.ToInt32(txtJobID3.Text);

                    objEmployee.empid = Convert.ToInt32(comboSupervisor.SelectedValue);
       
                    DialogResult dr;
                    dr = MessageBox.Show("Do you want to save the record", "Confirm", MessageBoxButtons.YesNo);
                    if (dr.ToString() == "Yes")
                    {
                        try
                        {


                            MegaCoolMethods mcm = new MegaCoolMethods();


                            bool result = mcm.UpdateRepairJob(objEmployee, objRepair);

                            if (result)
                            {
                                MessageBox.Show("Successfully Saved", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                RepairUpdateFillGrid();

                                RepairFillGrid();

                            }
                            else
                            {
                                MessageBox.Show("Unable to Save", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }


                        catch (Exception ex)
                        {

                            MessageBox.Show("" + ex);

                        }


                    }
                    else
                        MessageBox.Show("Record is not saved", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        private void btnUpdateR_Click(object sender, EventArgs e)
        {
            txtJobID3.Visible = true;

            btnJobDetails.Visible = true;

            btnRefresh.Visible = true;

            btnUpdateJob.Visible = true;

            btnClear1.Visible = true;

            btnDEMO.Visible = false;

            dtpEnd.Visible = true;

            comboBoxR_Type.Visible = true;

            comboSupervisor.Visible = true;

            btnUpdateJob.Visible = true;            

            txtCus.Visible = false;

            dtpStart.Visible = false;

            btnAddEmployee.Visible = false;

            lbStartDate.Visible = false;

            lbCustomerNIC.Visible = false;

            lbJobID3.Visible = true;

        }

        private void btnNewJob_Click(object sender, EventArgs e)
        {
            btnUpdateJob.Visible = false;

            btnJobDetails.Visible = false;
           
            txtJobID3.Visible = false;

            dtpStart.Visible = true;

            dtpEnd.Visible = true;

            txtCus.Visible = true;
                    
            comboBoxR_Type.Visible = true;

            txtDetails.Visible = true;

            comboSupervisor.Visible = true;

            btnClear1.Visible = true;

            btnAddEmployee.Visible = true;

            btnDEMO.Visible = true;

            lbCustomerNIC.Visible = true;

            lbStartDate.Visible = true;

            lbEndDate.Visible = true;

            lbType.Visible = true;

            lbDetails.Visible = true;

            lbSupervisor1.Visible = true;

            lbJobID3.Visible = false;

        }

        private void dgv_re_table_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string JobID = ((DataGridView)sender).Rows[e.RowIndex].Cells[0].Value.ToString();
            string Type = ((DataGridView)sender).Rows[e.RowIndex].Cells[1].Value.ToString();
            dtpEnd.Value = (DateTime)((DataGridView)sender).Rows[e.RowIndex].Cells[3].Value;
            string Details = ((DataGridView)sender).Rows[e.RowIndex].Cells[4].Value.ToString();
            string Supervisor = ((DataGridView)sender).Rows[e.RowIndex].Cells[6].Value.ToString();



            txtJobID3.Text = JobID;
            comboBoxR_Type.Text = Type;
            txtDetails.Text = Details;
            comboSupervisor.Text = Supervisor;
        }

        private void btnJobDetails_Click(object sender, EventArgs e)
        {
            string JobIDss = txtJobID3.Text;

            if (JobIDss == "")
            {
                MessageBox.Show("Pleace Enter JobID");
            }

            else
            {
                MegaCoolMethods mcm = new MegaCoolMethods();

                string q = "select * from Repair_Job where JobID = '" + txtJobID3.Text + "'";
                dgv_re_table.DataSource = mcm.loadGridView(q);
            }
        }

        //load InventoryID combobox
        private void cbInventID_Enter(object sender, EventArgs e)
        {
            MegaCoolMethods mcm = new MegaCoolMethods();

            cbInventID.DataSource = mcm.LoadInventoryIDComboBox();
            cbInventID.ValueMember = "InventoryID";
            cbInventID.DisplayMember = "InventoryID";
        }


        private void txtCus_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtCus.Text == "")
            {
                avCusFillGrid();
            }

            else
            {
                MegaCoolMethods mcm = new MegaCoolMethods();

                string q = txtCus.Text;

                string qa = "select NIC from Customer where NIC like '" + q + "%'";

                dgvCNIC.DataSource = mcm.loadGridView(qa);
            }
        }

        private void dgvCNIC_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string NIC = ((DataGridView)sender).Rows[e.RowIndex].Cells[0].Value.ToString();

            txtCus.Text = NIC;
        }

        private void btnClear3_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtJobID.Clear();

            txtEmployeeID.Clear();
        }

        //Load Supervisor into Combobox

        private void comboSupervisor_Enter(object sender, EventArgs e)
        {
            MegaCoolMethods mcm = new MegaCoolMethods();

            comboSupervisor.DataSource = mcm.LoadSupervisorComboBox();
            comboSupervisor.ValueMember = "EmployeeID";
            comboSupervisor.DisplayMember = "Name";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmRep1 fr2 = new FrmRep1();

            fr2.Show();
        }


       
 
    }
}
