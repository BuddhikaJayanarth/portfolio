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
    public partial class delivery : Form
    {
        public delivery()
        {
            InitializeComponent();
        }

        private void delivery_Load(object sender, EventArgs e)
        {
            deliveryFillGrid();
            dtp_del_delDate.Value = DateTime.Today.AddDays(-2);
            rbtn_del_delivery.Checked = true;
            deliveryDELIVERYFillGrid();
            deliveryProcessingDELIVERYFillGrid();
            comb_mngdel_status.SelectedIndex = 2;
            comb_mngdel_status.Enabled = false;
            txt_mngdel_delno.Enabled = false;
            txt_mngdel_vehino.Enabled = false;
            txt_mngdel_nic.Enabled = false;
            txt_mngdel_cusnic.Enabled = false;
            txtb_mngdel_invoiceno.Enabled = false;
            comb_mngdel_status.Enabled = false;
            
            serviceFillGrid();
        }

        private void tabPage8_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void comb_vehi_status_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtb_vehi_vehicalno.Text = "CAP-7716";
            txtb_vehi_capacity.Text = "5";
            txtb_vehi_model.Text = "forward";
            txtb_vehi_type.Text = "lorry";
            rtxt_vehi_description.Text = "service has to be done...";
            comb_vehi_make.SelectedIndex = 2;
            comb_vehi_status.SelectedIndex = 1;

        }


        public void vehi_clear()
        {

            txtb_vehi_vehicalno.Clear();
            txtb_vehi_capacity.Clear();
            txtb_vehi_model.Clear();
            txtb_vehi_type.Clear();
            rtxt_vehi_description.Clear();
            comb_vehi_make.SelectedIndex = -1;
            comb_vehi_status.SelectedIndex = -1;

        }

        public void del_clear()
        {
            txtb_del_deliveryno.Clear();
            txtb_del_deliveryno.Enabled = true;
            rtxtb_del_description.Clear();
            comb_del_status.SelectedIndex = -1;
            comb_del_status.Enabled = true;
            txtb_del_vehicalno.Clear();
            txtb_del_vehicalno.Enabled = true;
            txtb_del_driver.Clear();
            txtb_del_driver.Enabled = true;
            txtb_del_cusid.Clear();
            txtb_del_cusid.Enabled = true;
            txtb_del_from.Clear();
            txtb_del_to.Clear();
            txtb_del_distance.Clear();
            txtb_del_rate.Clear();
            txtb_del_cost.Clear();
            txtb_del_invoiceid.Clear();
            txtb_del_invoiceid.Enabled = true;
            
        }



        private void btn_vehi_clear_Click(object sender, EventArgs e)
        {
            vehi_clear();
        }

        //load vehicle table
        public void deliveryFillGrid()
        {

           

            SqlConnection con = ConnectionManager.GetConnection();

            if (con.State.ToString() == "Closed")
            {
                con.Open();
            }

            SqlDataAdapter sda1 = new SqlDataAdapter("select * from dbo.Vehicles ", con);

            DataTable dt = new DataTable();

            sda1.Fill(dt);

            dgv_vehi.DataSource = dt;
        }

        public void deliveryvehicleFillGrid()
        {

            DateTime d = dtp_del_delDate.Value;

            SqlConnection con = ConnectionManager.GetConnection();

            if (con.State.ToString() == "Closed")
            {
                con.Open();
            }

            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("select VehicleNo,Vehicle_Type,Capacity,Status from Vehicles where VehicleNo not in (select VehicleNo from Delivery where DiliveryDate = '" + d + "' and Status = 'Processing')", con);

                DataTable dt = new DataTable();

                sda.Fill(dt);

                dgv_del_invoice.DataSource = dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void deliveryinvoiceFillGrid()
        {

            

            SqlConnection con = ConnectionManager.GetConnection();

            if (con.State.ToString() == "Closed")
            {
                con.Open();
            }

            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("select * from Invoice where deliveryStatus = 'W' ORDER BY  Date", con);

                DataTable dt = new DataTable();

                sda.Fill(dt);

                dgv_del_invoice.DataSource = dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void deliverydriverFillGrid()
        {
            DateTime d = dtp_del_delDate.Value;

            SqlConnection con = ConnectionManager.GetConnection();

            if (con.State.ToString() == "Closed")
            {
                con.Open();
            }


            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("select * from EmpDriver where driverNo not in (select EmpID from Delivery where DiliveryDate = '" + d + "' and Status = 'Processing')", con);

                DataTable dt = new DataTable();

                sda.Fill(dt);

                dgv_del_invoice.DataSource = dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void serviceFillGrid()
        {

            SqlConnection con = ConnectionManager.GetConnection();

            if (con.State.ToString() == "Closed")
            {
                con.Open();
            }


            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("select * from Vehicle_Service", con);

                DataTable dt = new DataTable();

                sda.Fill(dt);

                dgv_service.DataSource = dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void deliveryDELIVERYFillGrid()
        {

            SqlConnection con = ConnectionManager.GetConnection();

            if (con.State.ToString() == "Closed")
            {
                con.Open();
            }

            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("select * from Delivery", con);

                DataTable dt = new DataTable();

                sda.Fill(dt);

                dgv_del_invoice.DataSource = dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
        public void deliveryProcessingDELIVERYFillGrid()
        {

            SqlConnection con = ConnectionManager.GetConnection();

            if (con.State.ToString() == "Closed")
            {
                con.Open();
            }

            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("select * from Delivery where Status = 'Processing'", con);

                DataTable dt = new DataTable();

                sda.Fill(dt);

                dgv_del_completedelivery.DataSource = dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }






        private void btn_vehi_add_Click(object sender, EventArgs e)
        {
            if (vehicalValidation())
            {
                VehicalObject objvehi = new VehicalObject();


                objvehi.VehicalNo = txtb_vehi_vehicalno.Text;
                objvehi.Type1 = txtb_vehi_type.Text;
                objvehi.Make = comb_vehi_make.Text;
                objvehi.Model = txtb_vehi_model.Text;
                objvehi.Status = comb_vehi_status.Text;
                objvehi.Capacity = txtb_vehi_capacity.Text;
                objvehi.Description = rtxt_vehi_description.Text;

                //chechk whether text feilds are empty or not
                if (objvehi.VehicalNo == "" || objvehi.Type1 == "" || objvehi.Make == "" || objvehi.Model == "" || objvehi.Status == "" || objvehi.Capacity == "" || objvehi.Description == "")
                {

                    MessageBox.Show("Please fill the all required feilds");
                }
                else
                {

                    //show the confirmation dialog box
                    DialogResult dr;
                    dr = MessageBox.Show("Do you want to save the record", "Confirm", MessageBoxButtons.YesNo);
                    string Dr = dr.ToString();

                    if (Dr == "Yes")
                    {
                        try
                        {


                            MegaCoolMethods mcm = new MegaCoolMethods();
                            bool result = mcm.AddNewvehical(objvehi);

                            if (result)
                            {
                                MessageBox.Show("Successfully Saved", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                // FillMemberDetails();

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

                        catch (SqlException ex)
                        {
                            if (ex.Number == 2627)
                            {
                                MessageBox.Show("This vehical Number is already Exsists");
                            }


                        }
                    }
                    else
                        MessageBox.Show("Data is not entered");

                    deliveryFillGrid();
                    vehi_clear();
                }
            }
        }

        private void btn_vehi_update_Click(object sender, EventArgs e)
        {
            VehicalObject objvehi = new VehicalObject();


            objvehi.VehicalNo = txtb_vehi_vehicalno.Text;
            objvehi.Capacity = txtb_vehi_capacity.Text;
            objvehi.Type1 = txtb_vehi_type.Text;
            objvehi.Make = comb_vehi_make.Text;
            objvehi.Model = txtb_vehi_model.Text;
            objvehi.Status = comb_vehi_status.Text;
            objvehi.Description = rtxt_vehi_description.Text;

            if (vehicalValidation())
            {

                try
                {


                    MegaCoolMethods mcm = new MegaCoolMethods();
                    bool result = mcm.Editvehical(objvehi);

                    if (result)
                    {
                        MessageBox.Show("Successfully Edited", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        deliveryFillGrid();
                        vehi_clear();
                    }
                    else
                    {
                        MessageBox.Show("Unable to Edit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        }

        private void rtxt_vehi_description_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgv_vehi_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                string vehicleno = ((DataGridView)sender).Rows[e.RowIndex].Cells[0].Value.ToString();
                string vehicletype = ((DataGridView)sender).Rows[e.RowIndex].Cells[1].Value.ToString();
                string capacity = ((DataGridView)sender).Rows[e.RowIndex].Cells[2].Value.ToString();
                string make = ((DataGridView)sender).Rows[e.RowIndex].Cells[3].Value.ToString();
                string model = ((DataGridView)sender).Rows[e.RowIndex].Cells[4].Value.ToString();
                string status = ((DataGridView)sender).Rows[e.RowIndex].Cells[5].Value.ToString();
                string description = ((DataGridView)sender).Rows[e.RowIndex].Cells[6].Value.ToString();



                txtb_vehi_vehicalno.Text = vehicleno;
                txtb_vehi_type.Text = vehicletype;
                txtb_vehi_capacity.Text = capacity;
                comb_vehi_make.Text = make;
                txtb_vehi_model.Text = model;
                comb_vehi_status.Text = status;
                rtxt_vehi_description.Text = description;




            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btn_vehi_delete_Click(object sender, EventArgs e)
        {
            string vehino = txtb_vehi_vehicalno.Text;
            if (vehino == "")
                MessageBox.Show("Select vehical to delete...");

            else
            {
                DialogResult dr;
                dr = MessageBox.Show("Do you want to delete the record", "Confirm", MessageBoxButtons.YesNo);

                string Dr = dr.ToString();

                if (Dr == "Yes")
                {
                    try
                    {

                        //  string vehino = txtb_vehi_vehicalno.Text;
                        MegaCoolMethods mcm = new MegaCoolMethods();
                        bool result = mcm.DeleteVehical(vehino);

                        if (result)
                        {
                            MessageBox.Show("Successfully Deleted", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            deliveryFillGrid();

                        }
                        else
                        {
                            MessageBox.Show("Unable to Delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                else
                    MessageBox.Show("Data is not Deleted");
            }
        }

        private void btn_vehi_search_Click(object sender, EventArgs e)
        {
            string vehino = txtb_vehi_vehicalno.Text;

            SqlConnection con = ConnectionManager.GetConnection();

            if (con.State.ToString() == "Closed")
            {
                con.Open();
            }

            SqlDataAdapter sda = new SqlDataAdapter("select * from Vehicles where VehicleNo =  '" + vehino + "'", con);

            DataTable dt = new DataTable();
            sda.Fill(dt);

            dgv_vehi.DataSource = dt;

            string data = (string)dgv_vehi[0, 0].Value;

            if (data == null)
            {
                MessageBox.Show("This Vehical is not exsist in system...");
            }
        }

        private void txtb_vehi_type_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtb_vehi_vehicalno_TextChanged(object sender, EventArgs e)
        {

        }
        public bool vehicalValidation()
        {
            bool status = false;


            if (txtb_vehi_vehicalno.Text == "")
                MessageBox.Show("Please fill the vehical No field");
            else if (txtb_vehi_vehicalno.TextLength > 8)
                MessageBox.Show("Length of vehical no is wrong");
            else if (!((txtb_vehi_vehicalno.ToString().Substring((txtb_vehi_vehicalno.ToString().Length - 4), 4)).All(char.IsDigit)))
                MessageBox.Show("please put valid vehical number...");
            else if (txtb_vehi_type.Text == "")
                MessageBox.Show("Please fill the Vehical Type field");
            else if (comb_vehi_make.Text == "")
                MessageBox.Show("Please select Make field");
            else if (txtb_vehi_model.Text == "")
                MessageBox.Show("Please fill the vehical Model field");
            else if (comb_vehi_status.Text == "")
                MessageBox.Show("Please select value for Status field");
            else if (comb_vehi_status.SelectedIndex == -1)
                MessageBox.Show("Please select the Status (Available/Not Available)");
            else if (txtb_vehi_capacity.Text == "")
                MessageBox.Show("Please Fill the mobile No field");
            else if (rtxt_vehi_description.Text == "")
                MessageBox.Show("Please fill description");
            else
            {
                status = true;

            }
            return status;
        }

        public bool deliveryValidation()
        {
            bool status = false;


            if (txtb_del_vehicalno.Text == "")
                MessageBox.Show("Please fill the vehical No field");
            else if (txtb_del_vehicalno.TextLength > 8)
                MessageBox.Show("Length of vehical no is wrong");
            else if (!((txtb_del_vehicalno.ToString().Substring((txtb_del_vehicalno.ToString().Length - 4), 4)).All(char.IsDigit)))
                MessageBox.Show("please put valid vehical number...");
            else if (dtp_del_delDate.Value  < DateTime.Today)
                MessageBox.Show("Fill Date Field Correctly... ");
            else if (txtb_del_cusid.TextLength != 10)
                MessageBox.Show("Required Length of Customer NIC is wrong");
            else if (!txtb_del_cusid.ToString().EndsWith("v") || txtb_del_cusid.ToString().EndsWith("V"))
                MessageBox.Show("please end the Customer NIC with letter 'v' or 'V'");
            else if (txtb_del_cusid.Text == "")
                MessageBox.Show("Please Fill Customer Feild");
            else if (txtb_del_driver.Text == "")
                MessageBox.Show("Please fill the Driver field");
            else if (txtb_del_invoiceid.Text == "")
                MessageBox.Show("Please Fill the InvoiceID field");
            else if (comb_del_status.SelectedIndex == -1)
                MessageBox.Show("Please select the Status (Not Deliverd/Processing/Deliverd)");
            else if (txtb_del_from.Text == "")
                MessageBox.Show("Please Fill the From field");
            else if (txtb_del_to.Text == "")
                MessageBox.Show("Please fill To field");
            else if (txtb_del_distance.Text == "")
                MessageBox.Show("Please fill Distance field");
            else if (txtb_del_rate.Text == "")
                MessageBox.Show("Please fill Rate field");
            else if (txtb_del_cost.Text == "")
                MessageBox.Show("Please fill Cost field");
            else
            {
                status = true;

            }
            return status;
        }

        public bool ServiceValidation()
        {
            bool status = false;

            if (txtb_service_vehiNo.Text == "")
                MessageBox.Show("Please fill the vehical No field");
            else if (txtb_service_vehiNo.TextLength > 8)
                MessageBox.Show("Length of vehical no is wrong");
            else if (!((txtb_service_vehiNo.ToString().Substring((txtb_service_vehiNo.ToString().Length - 4), 4)).All(char.IsDigit)))
                MessageBox.Show("please put valid vehical number...");
            else if (rtxtb_service_description.Text == "")
                MessageBox.Show("Please fill Description field");
            else if (dtp_service_nextserdate.Value < DateTime.Today)
                MessageBox.Show("Fill Next Service Date Field Correctly... ");
            else if (dtp_service_lastserdate.Value > DateTime.Today)
                MessageBox.Show("Fill Last Service Date Field Correctly... ");
            else if (txtb_service_lastsermilage.Text == "")
                MessageBox.Show("Please fill Last Service Milage field");
            else if (txtb_service_nextsermilage.Text == "")
                MessageBox.Show("Please fill Next Service Milage field");
            else
            {
                status = true;

            }



            return status;
        }
        private void txtb_vehi_model_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtb_vehi_model_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void gb_del_cost_Enter(object sender, EventArgs e)
        {

        }

        private void lbl_del_deliveryno_Click(object sender, EventArgs e)
        {

        }

        private void rbtn_del_vehical_Click(object sender, EventArgs e)
        {
            dgv_del_invoice.DataSource = null;
            if (dtp_del_delDate.Value < DateTime.Today)
            {
                MessageBox.Show("Set Delivery Date first... Then select the Invoice...");
            }
            else
            {
                deliveryvehicleFillGrid();
            }
            
        }

        private void rbtn_del_invoce_Click(object sender, EventArgs e)
        {
            
            deliveryinvoiceFillGrid();

            
        }

        private void rbtn_del_drivers_Click(object sender, EventArgs e)
        {
            dgv_del_invoice.DataSource = null;
            if (dtp_del_delDate.Value < DateTime.Today) 
            {
                MessageBox.Show("Set Delivery Date first... Then select the driver...");
            }
            else
            {
                deliverydriverFillGrid();
            }
            
        }

        private void rbtn_del_delivery_Click(object sender, EventArgs e)
        {

        }

        private void btn_del_add_Click(object sender, EventArgs e)
        {
            if(deliveryValidation())
            {
                DeliveryObject objdel = new DeliveryObject();
                CustomerObject objcus = new CustomerObject();
                SalesObject objInv = new SalesObject();
                EmployeeObject objemp = new EmployeeObject();
                VehicalObject objvehi = new VehicalObject();





                //chechk whether text feilds are empty or not
                if (txtb_del_deliveryno.Text == "" || txtb_del_invoiceid.Text == "" || txtb_del_cusid.Text == "" || txtb_del_driver.Text == "" || txtb_del_vehicalno.Text == "" || comb_del_status.Text == "" || rtxtb_del_description.Text == "" || txtb_del_from.Text == "" || txtb_del_to.Text == "" || txtb_del_distance.Text == "" || txtb_del_rate.Text == "" || txtb_del_cost.Text == "")
                {

                    MessageBox.Show("Please fill the all required feilds");
                }
                else
                {

                    objdel.DeliveryNo1 = txtb_del_deliveryno.Text;
                    objInv.InvoiceNo = Convert.ToInt32(txtb_del_invoiceid.Text);
                    objcus.Nic = txtb_del_cusid.Text;
                    objemp.empid = Convert.ToInt32(txtb_del_driver.Text);
                    objvehi.VehicalNo = txtb_del_vehicalno.Text;
                    objdel.Status1 = comb_del_status.Text;
                    objdel.Description1 = rtxtb_del_description.Text;
                    objdel.From1 = txtb_del_from.Text;
                    objdel.To1 = txtb_del_to.Text;
                    objdel.Distance1 = Convert.ToDouble(txtb_del_distance.Text);
                    objdel.Rate1 = Convert.ToDouble(txtb_del_rate.Text);
                    objdel.Cost1 = Convert.ToDouble(txtb_del_cost.Text);
                    objdel.Date = dtp_del_delDate.Value.Date;

                    //show the confirmation dialog box
                    DialogResult dr;
                    dr = MessageBox.Show("Do you want to save the record", "Confirm", MessageBoxButtons.YesNo);
                    string Dr = dr.ToString();

                    if (Dr == "Yes")
                    {
                        try
                        {


                            MegaCoolMethods mcm = new MegaCoolMethods();
                            bool result = mcm.AddNewdelivery(objdel, objcus, objInv, objemp, objvehi);
                        

                            if (result)
                            {
                                MessageBox.Show("Successfully Saved", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                // FillMemberDetails();

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

                        catch (SqlException ex)
                        {
                            if (ex.Number == 2627)
                            {
                                MessageBox.Show("This Delivery Number is already Exsists");
                            }


                        }

                        rbtn_del_delivery.Checked = true;
                        deliveryDELIVERYFillGrid();
                        deliveryProcessingDELIVERYFillGrid();
                        del_clear();
                        //else
                        //    MessageBox.Show("Data is not entered");

                        //deliveryFillGrid();
                        //vehi_clear();
                        }
                   }
            }

        }

        private void dgv_del_invoice_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_del_invoice_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (rbtn_del_drivers.Checked)
            {
                int rowindex = dgv_del_invoice.CurrentCell.RowIndex;
                ////  int columnindex = dgv_cus_table.CurrentCell.ColumnIndex;

                string driverName = dgv_del_invoice.Rows[rowindex].Cells[0].Value.ToString();
                //MessageBox.Show(nic);

                txtb_del_driver.Text = driverName;
            }

            if (rbtn_del_invoce.Checked)
            {
                int rowindex = dgv_del_invoice.CurrentCell.RowIndex;
                ////  int columnindex = dgv_cus_table.CurrentCell.ColumnIndex;

                string invoiceid = dgv_del_invoice.Rows[rowindex].Cells[0].Value.ToString();
                string nic = dgv_del_invoice.Rows[rowindex].Cells[2].Value.ToString();
                //MessageBox.Show(nic);

                txtb_del_invoiceid.Text = invoiceid;
                txtb_del_cusid.Text = nic;
            }

            if (rbtn_del_vehical.Checked)
            {
                int rowindex = dgv_del_invoice.CurrentCell.RowIndex;
                ////  int columnindex = dgv_cus_table.CurrentCell.ColumnIndex;

                string vehicleno = dgv_del_invoice.Rows[rowindex].Cells[0].Value.ToString();
                //MessageBox.Show(nic);

                txtb_del_vehicalno.Text = vehicleno;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        

       

        //update processing Delivery
        public bool updateprocessingdel(string delstatus, string delno, string empid, string vehi, string invid)
        {
            bool status = false;
            SqlConnection con = ConnectionManager.GetConnection();

            if (con.State.ToString() == "Closed")
            {
                con.Open();
            }


            try
            {
                SqlCommand newCmd1 = con.CreateCommand();
                SqlCommand newCmd2 = con.CreateCommand();
                SqlCommand newCmd3 = con.CreateCommand();
                SqlCommand newCmd5 = con.CreateCommand();

                newCmd1.Connection = con;
                newCmd1.CommandType = CommandType.Text;
                newCmd1.CommandText = "UPDATE dbo.Delivery SET Status ='" + delstatus + "' where DeliveryNo = '" + delno + "'";
                newCmd1.ExecuteNonQuery();

                newCmd2.Connection = con;
                newCmd2.CommandType = CommandType.Text;
                newCmd2.CommandText = "UPDATE dbo.EmpDriver SET Status ='A' where driverNo = '" + empid + "'";
                newCmd2.ExecuteNonQuery();

                newCmd3.Connection = con;
                newCmd3.CommandType = CommandType.Text;
                newCmd3.CommandText = "UPDATE dbo.Vehicles SET Status ='A' where VehicleNo = '" + vehi + "'";
                newCmd3.ExecuteNonQuery();
                
                newCmd5.Connection = con;
                newCmd5.CommandType = CommandType.Text;
                newCmd5.CommandText = "UPDATE dbo.Invoice SET deliveryStatus ='Done' where InvoiceID = " + invid;
                newCmd5.ExecuteNonQuery();


                status = true;

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return status;
        }

        private void btn_del_calccost_Click(object sender, EventArgs e)
        {
            if (txtb_del_distance.Text == "" || txtb_del_rate.Text == "")
            {
                MessageBox.Show("Fill Distance and Rate");
            }
            else
            {
                DeliveryObject delobj = new DeliveryObject();
                delobj.Distance1 = Convert.ToDouble(txtb_del_distance.Text);
                delobj.Rate1 = Convert.ToDouble(txtb_del_rate.Text);

                MegaCoolMethods mcm = new MegaCoolMethods();
                double cost = mcm.calcCost(delobj);
                delobj.Cost1 = cost;
                txtb_del_cost.Text = cost.ToString();
            }
        }

        private void dgv_del_invoice_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (rbtn_del_delivery.Checked)
            {
                string delno = ((DataGridView)sender).Rows[e.RowIndex].Cells[0].Value.ToString();
                string description = ((DataGridView)sender).Rows[e.RowIndex].Cells[1].Value.ToString();
                string status = ((DataGridView)sender).Rows[e.RowIndex].Cells[2].Value.ToString();
                string vehino = ((DataGridView)sender).Rows[e.RowIndex].Cells[3].Value.ToString();
                string empid = ((DataGridView)sender).Rows[e.RowIndex].Cells[4].Value.ToString();
                string cusnic = ((DataGridView)sender).Rows[e.RowIndex].Cells[5].Value.ToString();
                string from = ((DataGridView)sender).Rows[e.RowIndex].Cells[6].Value.ToString();
                string to = ((DataGridView)sender).Rows[e.RowIndex].Cells[7].Value.ToString();
                string distance = ((DataGridView)sender).Rows[e.RowIndex].Cells[8].Value.ToString();
                string rate = ((DataGridView)sender).Rows[e.RowIndex].Cells[9].Value.ToString();
                string cost = ((DataGridView)sender).Rows[e.RowIndex].Cells[10].Value.ToString();
                string invoiceid = ((DataGridView)sender).Rows[e.RowIndex].Cells[11].Value.ToString();
                string date = ((DataGridView)sender).Rows[e.RowIndex].Cells[12].Value.ToString();

                DateTime d = DateTime.Parse(date);

                txtb_del_deliveryno.Text = delno;
                rtxtb_del_description.Text = description;
                comb_del_status.Text = status;
                txtb_del_vehicalno.Text = vehino;
                txtb_del_driver.Text = empid;
                txtb_del_cusid.Text = cusnic;
                txtb_del_from.Text = from;
                txtb_del_to.Text = to;
                txtb_del_distance.Text = distance;
                txtb_del_rate.Text = rate;
                txtb_del_cost.Text = cost;
                txtb_del_invoiceid.Text = invoiceid;
                dtp_del_delDate.Value = d;

                txtb_del_deliveryno.Enabled = false;
                comb_del_status.Enabled = false;
                txtb_del_vehicalno.Enabled = false;
                txtb_del_driver.Enabled = false;
                txtb_del_cusid.Enabled = false;
                txtb_del_invoiceid.Enabled = false;

            }
        }

        private void txtb_de_searchkey_KeyPress(object sender, KeyPressEventArgs e)
        {
            string vehino = txtb_de_searchkey.Text;

            SqlConnection con = ConnectionManager.GetConnection();

            if (con.State.ToString() == "Closed")
            {
                con.Open();
            }

            SqlDataAdapter sda = new SqlDataAdapter("select * from Vehicles where VehicleNo like '%" + vehino + "%'", con);

            DataTable dt = new DataTable();
            sda.Fill(dt);

            dgv_del_invoice.DataSource = dt;

            string data = (string)dgv_del_invoice[0, 0].Value;
        }

        private void txtb_de_searchkey_Click(object sender, EventArgs e)
        {
            rbtn_del_delivery.Checked = true;
        }

        private void rbtn_del_delivery_CheckedChanged(object sender, EventArgs e)
        {
            deliveryDELIVERYFillGrid();
        }

        private void txt_mngdel_delno_KeyPress(object sender, KeyPressEventArgs e)
        {
            SqlConnection con = ConnectionManager.GetConnection();

            if (con.State.ToString() == "Closed")
            {
                con.Open();
            }
            try
            {

                string delno = txt_mngdel_delno.Text;

                SqlDataAdapter sda = new SqlDataAdapter("select * from Delivery where Status = 'Processing' AND DeliveryNo like '%" + delno + "%'", con);

                DataTable dt = new DataTable();

                sda.Fill(dt);

                dgv_del_completedelivery.DataSource = dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            string vehino = textBox1.Text;

            SqlConnection con = ConnectionManager.GetConnection();

            if (con.State.ToString() == "Closed")
            {
                con.Open();
            }

            SqlDataAdapter sda = new SqlDataAdapter("select * from Vehicles where VehicleNo like  '%" + vehino + "%'", con);

            DataTable dt = new DataTable();
            sda.Fill(dt);

            dgv_vehi.DataSource = dt;

            string data = (string)dgv_vehi[0, 0].Value;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
            rtxtb_del_description.Text = "has to be Done...";
            comb_del_status.Text = "Processing";
            
            
            
            txtb_del_from.Text = "Kaduwela";
            txtb_del_to.Text = "Battaramulla";
            txtb_del_distance.Text = "12";
            txtb_del_rate.Text = "15.5";
            
                        




        }

        private void txtb_del_deliveryno_Click(object sender, EventArgs e)
        {
            if (txtb_del_vehicalno.Text != "" && txtb_del_invoiceid.Text != "" && txtb_del_cusid.Text != "")
            {

                String card1 = txtb_del_vehicalno.Text.Substring(0, 2).ToUpper();
                String card2 = txtb_del_invoiceid.Text;
                String card3 = txtb_del_cusid.Text.Substring(0, 5);

                String cardNo = string.Concat(card1, card2, card3);
                txtb_del_deliveryno.Text = cardNo;
                txtb_del_deliveryno.Enabled = false;

            }
        }

        private void btn_del_update_Click(object sender, EventArgs e)
        {
            if(deliveryValidation())
            {
            DeliveryObject objdel = new DeliveryObject();
            CustomerObject objcus = new CustomerObject();
            SalesObject objInv = new SalesObject();
            EmployeeObject objemp = new EmployeeObject();
            VehicalObject objvehi = new VehicalObject();





            //chechk whether text feilds are empty or not
            if (txtb_del_deliveryno.Text == "" || txtb_del_invoiceid.Text == "" || txtb_del_cusid.Text == "" || txtb_del_driver.Text == "" || txtb_del_vehicalno.Text == "" || comb_del_status.Text == "" || rtxtb_del_description.Text == "" || txtb_del_from.Text == "" || txtb_del_to.Text == "" || txtb_del_distance.Text == "" || txtb_del_rate.Text == "" || txtb_del_cost.Text == "")
            {

                MessageBox.Show("Please fill the all required feilds");
            }
            else
            {

                objdel.DeliveryNo1 = txtb_del_deliveryno.Text;
                objInv.InvoiceNo = Convert.ToInt32(txtb_del_invoiceid.Text);
                objcus.Nic = txtb_del_cusid.Text;
                objemp.empid = Convert.ToInt32(txtb_del_driver.Text);
                objvehi.VehicalNo = txtb_del_vehicalno.Text;
                objdel.Status1 = comb_del_status.Text;
                objdel.Description1 = rtxtb_del_description.Text;
                objdel.From1 = txtb_del_from.Text;
                objdel.To1 = txtb_del_to.Text;
                objdel.Distance1 = Convert.ToDouble(txtb_del_distance.Text);
                objdel.Rate1 = Convert.ToDouble(txtb_del_rate.Text);
                objdel.Cost1 = Convert.ToDouble(txtb_del_cost.Text);
                objdel.Date = dtp_del_delDate.Value.Date;

                //show the confirmation dialog box
                DialogResult dr;
                dr = MessageBox.Show("Do you want to save the record", "Confirm", MessageBoxButtons.YesNo);
                string Dr = dr.ToString();

                if (Dr == "Yes")
                {

                    try
                    {


                        MegaCoolMethods mcm = new MegaCoolMethods();
                        bool result = mcm.EditDelivery(objdel, objcus, objInv, objemp, objvehi);


                        if (result)
                        {
                            MessageBox.Show("Successfully Saved", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // FillMemberDetails();

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

                    catch (SqlException ex)
                    {
                        if (ex.Number == 2627)
                        {
                            MessageBox.Show("This Delivery Number is already Exsists");
                        }


                    }

                    rbtn_del_delivery.Checked = true;
                    deliveryDELIVERYFillGrid();
                    deliveryProcessingDELIVERYFillGrid();
                    del_clear();
                    
                }
            }  
            }
        }

        private void tabp_vehi_service_Click(object sender, EventArgs e)
        {

        }

        private void txtb_service_search_KeyPress(object sender, KeyPressEventArgs e)
        {
             string vehino = txtb_service_search.Text;

            SqlConnection con = ConnectionManager.GetConnection();

            if (con.State.ToString() == "Closed")
            {
                con.Open();
            }

            SqlDataAdapter sda = new SqlDataAdapter("select * from Vehicle_Service where VehicleNo like  '%" + vehino + "%'", con);

            DataTable dt = new DataTable();
            sda.Fill(dt);

            dgv_service.DataSource = dt;

            string data = (string)dgv_service[0, 0].Value;
        }

        private void dgv_vehi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_service_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void dgv_service_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
            
            string vehino = ((DataGridView)sender).Rows[e.RowIndex].Cells[0].Value.ToString();
            string service_description = ((DataGridView)sender).Rows[e.RowIndex].Cells[1].Value.ToString();
            string last_ser_date = ((DataGridView)sender).Rows[e.RowIndex].Cells[2].Value.ToString();
            string last_ser_milage = ((DataGridView)sender).Rows[e.RowIndex].Cells[3].Value.ToString();
            string next_ser_date = ((DataGridView)sender).Rows[e.RowIndex].Cells[4].Value.ToString();
            string next_ser_milage = ((DataGridView)sender).Rows[e.RowIndex].Cells[5].Value.ToString();


            DateTime Last_Ser_d = DateTime.Parse(last_ser_date);
            DateTime next_Ser_d = DateTime.Parse(next_ser_date);

            txtb_service_vehiNo.Enabled = false;

            txtb_service_vehiNo.Text = vehino;
            rtxtb_service_description.Text = service_description;
            dtp_service_lastserdate.Value = Last_Ser_d;
            txtb_service_lastsermilage.Text = last_ser_milage;
            dtp_service_nextserdate.Value = next_Ser_d;
            txtb_service_nextsermilage.Text = next_ser_milage;
            
            

        }

        private void btn_service_add_Click(object sender, EventArgs e)
        {

            if (ServiceValidation())
            {
                VehicalObject objvehi = new VehicalObject();


                objvehi.VehicalNo = txtb_service_vehiNo.Text;
                objvehi.Ser_description = rtxtb_service_description.Text;
                objvehi.Last_ser_date = dtp_service_lastserdate.Value.Date;
                objvehi.Last_ser_milage = float.Parse(txtb_service_lastsermilage.Text);
                objvehi.Next_ser_date1 = dtp_service_nextserdate.Value.Date;
                objvehi.Next_ser_milage = float.Parse(txtb_service_nextsermilage.Text);


                //chechk whether text feilds are empty or not
                if (txtb_service_vehiNo.Text == "" || rtxtb_service_description.Text == "" || dtp_service_lastserdate.Value.ToString() == "" || txtb_service_lastsermilage.Text == "" || dtp_service_nextserdate.Value.ToString() == "" || txtb_service_nextsermilage.Text == "")
                {

                    MessageBox.Show("Please fill the all required feilds");
                }
                else
                {

                    //show the confirmation dialog box
                    DialogResult dr;
                    dr = MessageBox.Show("Do you want to save the record", "Confirm", MessageBoxButtons.YesNo);
                    string Dr = dr.ToString();

                    if (Dr == "Yes")
                    {
                        try
                        {


                            MegaCoolMethods mcm = new MegaCoolMethods();
                            MessageBox.Show("1");
                            bool result = mcm.AddNewservice(objvehi);

                            if (result)
                            {
                                MessageBox.Show("Successfully Saved", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                serviceFillGrid();

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

                        catch (SqlException ex)
                        {
                            if (ex.Number == 2627)
                            {
                                MessageBox.Show("This vehical records are already Exsists");
                            }


                        }
                    }
                    else
                        MessageBox.Show("Data is not entered");
                }
            }
        }

        private void btn_service_update_Click(object sender, EventArgs e)
        {

            if (ServiceValidation())
            {
                VehicalObject objvehi = new VehicalObject();


                objvehi.VehicalNo = txtb_service_vehiNo.Text;
                objvehi.Ser_description = rtxtb_service_description.Text;
                objvehi.Last_ser_date = dtp_service_lastserdate.Value.Date;
                objvehi.Last_ser_milage = float.Parse(txtb_service_lastsermilage.Text);
                objvehi.Next_ser_date1 = dtp_service_nextserdate.Value.Date;
                objvehi.Next_ser_milage = float.Parse(txtb_service_nextsermilage.Text);

                try
                {


                    MegaCoolMethods mcm = new MegaCoolMethods();
                    bool result = mcm.updateService(objvehi);

                    if (result)
                    {
                        MessageBox.Show("Successfully Edited", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        serviceFillGrid();
                    }
                    else
                    {
                        MessageBox.Show("Unable to Edit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        }

        private void btn_service_delete_Click(object sender, EventArgs e)
        {
            string vehino = txtb_service_vehiNo.Text;
            if (vehino == "")
                MessageBox.Show("Select vehical to delete...");

            else
            {
                DialogResult dr;
                dr = MessageBox.Show("Do you want to delete the record", "Confirm", MessageBoxButtons.YesNo);

                string Dr = dr.ToString();

                if (Dr == "Yes")
                {
                    try
                    {

                        //  string vehino = txtb_vehi_vehicalno.Text;
                        MegaCoolMethods mcm = new MegaCoolMethods();
                        bool result = mcm.DeleteService(vehino);

                        if (result)
                        {
                            MessageBox.Show("Successfully Deleted", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            serviceFillGrid();

                        }
                        else
                        {
                            MessageBox.Show("Unable to Delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                else
                    MessageBox.Show("Data is not Deleted");
            }
        }

        private void dgv_del_completedelivery_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                string delno = ((DataGridView)sender).Rows[e.RowIndex].Cells[0].Value.ToString();
                string vehi = ((DataGridView)sender).Rows[e.RowIndex].Cells[3].Value.ToString();
                string cusnic = ((DataGridView)sender).Rows[e.RowIndex].Cells[5].Value.ToString();
                //string status = ((DataGridView)sender).Rows[e.RowIndex].Cells[2].Value.ToString();
                string empid = ((DataGridView)sender).Rows[e.RowIndex].Cells[4].Value.ToString();
                string invid = ((DataGridView)sender).Rows[e.RowIndex].Cells[11].Value.ToString();



                txt_mngdel_nic.Text = empid;
                txt_mngdel_delno.Text = delno;
                txt_mngdel_vehino.Text = vehi;
                txt_mngdel_cusnic.Text = cusnic;
                txtb_mngdel_invoiceno.Text = invid;
                //comb_mngdel_status.Text = status;


                //txtb_cus_nic.Enabled = false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btn_del_complete_Click(object sender, EventArgs e)
        {
            string delstatus = comb_mngdel_status.Text;
            string delno = txt_mngdel_delno.Text;
            string invid = txtb_mngdel_invoiceno.Text;
            string empid = txt_mngdel_nic.Text;
            string vehi = txt_mngdel_vehino.Text;
            if (comb_mngdel_status.Text == "" || txt_mngdel_delno.Text == "" || txt_mngdel_nic.Text == "" || txt_mngdel_vehino.Text == "" || txt_mngdel_delno.Text == "")
                MessageBox.Show("Fill All required Feilds ");

            else
            {
                DialogResult dr;
                dr = MessageBox.Show("Do you want to Update the record", "Confirm", MessageBoxButtons.YesNo);
                string Dr = dr.ToString();

                if (Dr == "Yes")
                {
                    if (updateprocessingdel(delstatus,delno,empid,vehi,invid))
                    {
                        MessageBox.Show("Deivery is Successfully Updated");
                        deliveryProcessingDELIVERYFillGrid();
                        deliveryDELIVERYFillGrid();
                    }
                    else
                    {
                        MessageBox.Show("Deivery is not Updated");
                    }

                }
            }
            deliveryProcessingDELIVERYFillGrid();
        }

        private void btn_del_delete_Click(object sender, EventArgs e)
        {
            string delno = txtb_del_deliveryno.Text;
            if (delno == "")
                MessageBox.Show("Select delivery to delete...");

            else
            {
                DialogResult dr;
                dr = MessageBox.Show("Do you want to delete the record", "Confirm", MessageBoxButtons.YesNo);

                string Dr = dr.ToString();

                if (Dr == "Yes")
                {
                    try
                    {

                        //  string vehino = txtb_vehi_vehicalno.Text;
                        MegaCoolMethods mcm = new MegaCoolMethods();
                        bool result = mcm.DeleteDelivery(delno);

                        if (result)
                        {
                            MessageBox.Show("Successfully Deleted", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            deliveryFillGrid();

                        }
                        else
                        {
                            MessageBox.Show("Unable to Delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                else
                    MessageBox.Show("Data is not Deleted");
            }
            deliveryDELIVERYFillGrid();
            del_clear();
        }

        private void btn_del_clear_Click(object sender, EventArgs e)
        {
            del_clear();
        }

        private void txtb_del_cusid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == (char)Keys.Back || e.KeyChar == 'v' || e.KeyChar == 'V')
            {
                e.Handled = false; //not ignore input
            }
            else
            {
                e.Handled = true; //ignore the input
            }
        }

        private void txtb_del_distance_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
            if (txtb_del_distance.Text.Length > 9 && ch != 8)
                e.Handled = true;
        }

        private void txtb_del_rate_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
            if (txtb_del_rate.Text.Length > 9 && ch != 8)
                e.Handled = true;
        }

        private void txtb_service_lastsermilage_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
            if (txtb_service_lastsermilage.Text.Length > 9 && ch != 8)
                e.Handled = true;
        }

        private void txtb_service_nextsermilage_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
            if (txtb_service_nextsermilage.Text.Length > 9 && ch != 8)
                e.Handled = true;
        }

        private void dtp_service_lastserdate_ValueChanged(object sender, EventArgs e)
        {
            dtp_service_nextserdate.Value = dtp_service_nextserdate.Value.AddMonths(6);
        }


        
        
    }
}

