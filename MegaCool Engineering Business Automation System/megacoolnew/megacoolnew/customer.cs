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
using System.Text.RegularExpressions;
using System.Net.Mail;
 

namespace megacoolnew
{
    public partial class customer : Form
    {
        public customer()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lbl_cus_email_Click(object sender, EventArgs e)
        {

        }

        private void tab_loyalitycard_Click(object sender, EventArgs e)
        {

        }

        //select nic cell value into text feild
        private void dgv_cus_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowindex = dgv_cus_table.CurrentCell.RowIndex;
            //int columnindex = dgv_cus_table.CurrentCell.ColumnIndex;
            string nic = dgv_cus_table.Rows[rowindex].Cells[0].Value.ToString();
          
            txtb_cus_nic.Text = nic;   
        }

        private void tab_customermanagement_Click(object sender, EventArgs e)
        {

        }

        private void btn_cus_demo_Click(object sender, EventArgs e)
        {
            txtb_cus_nic.Text = "955544433v";
            txtb_cus_name.Text = "Perera K.M";
            rtb_cus_address.Text = "12,Lellupitiya,Rathnapura";
            txtb_cus_mobileno.Text = "0778451258";
            txtb_cus_email.Text = "perera@gmail.com";
            cmb_cus_type.Text = "Regular";
          //  txtb_cus_rate.Text = "1";
    
        }

        //Clear button for customerManagement
        private void btn_cus_clear_Click(object sender, EventArgs e)
        {
            txtb_cus_nic.Clear();
            txtb_cus_name.Clear();
            rtb_cus_address.Clear();
            txtb_cus_mobileno.Clear();
            txtb_cus_email.Clear();
          //  cmb_cus_type.SelectedIndex = -1;
           // txtb_cus_rate.Clear();
            cmb_cus_type.SelectedIndex = 0;
           
            txtb_cus_nic.Enabled = true;
            btn_cus_add.Enabled = true;
            cmb_cus_type.Enabled = true;

            CustomerFillGrid();
           
           
        }

        private void gb_cus_Management_Enter(object sender, EventArgs e)
        {

        }

        //Add customer
        private void btn_cus_add_Click(object sender, EventArgs e)
        {
            
            if (CustomerValidation())
            {
                Validation vlemail = new Validation();
                if (vlemail.IsValidEmail(txtb_cus_email.Text) == false)
                {
                    MessageBox.Show("Please Enter Valid Email");
                }
                else
                {

                    CustomerObject objCustomer = new CustomerObject();

                    objCustomer.Nic = txtb_cus_nic.Text;
                    objCustomer.CustomrName = txtb_cus_name.Text;
                    objCustomer.Address = rtb_cus_address.Text;
                    objCustomer.Phone = txtb_cus_mobileno.Text;
                    objCustomer.Email = txtb_cus_email.Text;
                    objCustomer.CustomerType = cmb_cus_type.Text;
                   // objCustomer.Rate = Convert.ToInt32(txtb_cus_rate.Text);

                    
                    //show the confirmation dialog box
                    DialogResult dr;
                    dr = MessageBox.Show("Do you want to save the record", "Confirm", MessageBoxButtons.YesNo);
                    if (dr.ToString() == "Yes")
                    {
                        try
                        {
                            MegaCoolMethods mcm = new MegaCoolMethods();
                            bool result = mcm.AddNewCustomer(objCustomer);

                            if (result)
                            {
                                MessageBox.Show("Successfully Saved", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                //redirect to loyalty card tab
                                if (cmb_cus_type.Text == "Loyalty")
                                {
                                    tb_cus_tabcontroller.SelectedTab = tab_loyalitycard;
                                }
                                else
                                    Clear();
                            }
                            else
                            {
                                MessageBox.Show("Unable to Save", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                Clear();

                            }

                        }
                        catch (ApplicationException appEx)
                        {
                            MessageBox.Show(appEx.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            Clear();
                        }
                        catch (SqlException ex)
                        {
                            if (ex.Number == 2627)
                            {
                                MessageBox.Show("This customer is alreay exist, please add new customer ");
                                //Violation of primary key. Handle Exception
                                Clear();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Record is not saved", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Clear();
                    }

                }
            }
            else
                MessageBox.Show("Add customer request cannot complete");

            

            CustomerFillGrid();

            
        }

        //customer form loading
        private void customer_Load(object sender, EventArgs e)
        {

             CustomerFillGrid();
             CustomerLotaltyCardFillGrid();
             FillComboEmailCusNIC();

             cmb_cus_type.Items.Add("Regular");
             cmb_cus_type.Items.Add("Loyalty");
             cmb_cus_type.SelectedIndex = 0;
             cmb_cus_type.Enabled = true;

             cmb_loy_cardtype.Items.Add("GOLD");
             cmb_loy_cardtype.Items.Add("SILVER");
             cmb_loy_cardtype.Items.Add("BRONZE");
             cmb_loy_selectCardType.SelectedItem = 0;
             lbl_loymem_cardno.Visible = false;


             
        }

        //update customer
        private void btn_cus_update_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            if (CustomerValidation())
            {
                dr = MessageBox.Show("Do you want to update the record", "Confirm", MessageBoxButtons.YesNo);
                if (dr.ToString() == "Yes")
                {
                    Validation vlemail = new Validation();
                    if (vlemail.IsValidEmail(txtb_cus_email.Text) == false)
                    {
                        MessageBox.Show("Please Enter Valid Email");
                    }
                    else
                    {

                        CustomerObject objCustomer = new CustomerObject();

                        //txtb_cus_rate.Text = "0";

                        objCustomer.Nic = txtb_cus_nic.Text;
                        objCustomer.CustomrName = txtb_cus_name.Text;
                        objCustomer.Address = rtb_cus_address.Text;
                        objCustomer.Phone = txtb_cus_mobileno.Text;
                        objCustomer.Email = txtb_cus_email.Text;
                        objCustomer.CustomerType = cmb_cus_type.Text;
                      //  objCustomer.Rate = Convert.ToInt32(txtb_cus_rate.Text);

                        try
                        {


                            MegaCoolMethods mcm = new MegaCoolMethods();
                            bool result = mcm.EditCustomer(objCustomer);

                            if (result)
                            {
                                MessageBox.Show("Successfully updated customer  details", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                CustomerFillGrid();
                            }
                            else
                            {
                                MessageBox.Show("Unable to update customer details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            }
            else
                MessageBox.Show("Record updation request can not be completed", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

            CustomerFillGrid();
            Clear();

            btn_cus_add.Enabled = true;
            cmb_cus_type.SelectedIndex = -1;
            cmb_cus_type.Enabled = true;
        }

        //pass values to text feilds from grid view
        private void dgv_cus_table_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btn_cus_add.Enabled = false;

            try
            {
                string nic = ((DataGridView)sender).Rows[e.RowIndex].Cells[0].Value.ToString();
                string name = ((DataGridView)sender).Rows[e.RowIndex].Cells[1].Value.ToString();
                string email = ((DataGridView)sender).Rows[e.RowIndex].Cells[2].Value.ToString();
                string address = ((DataGridView)sender).Rows[e.RowIndex].Cells[3].Value.ToString();
                int rate = Convert.ToInt32(((DataGridView)sender).Rows[e.RowIndex].Cells[4].Value);
                string type = ((DataGridView)sender).Rows[e.RowIndex].Cells[5].Value.ToString();
                string contactNo = ((DataGridView)sender).Rows[e.RowIndex].Cells[6].Value.ToString();



                txtb_cus_nic.Text = nic;
                txtb_cus_name.Text = name;
                txtb_cus_email.Text = email;
                rtb_cus_address.Text = address;
               // txtb_cus_rate.Text = (rate).ToString();
                cmb_cus_type.Text = type;
                txtb_cus_mobileno.Text = contactNo;

                txtb_cus_nic.Enabled = false;
                if (cmb_cus_type.Text == "Loyalty")
                {
                    cmb_cus_type.Enabled = false;
                }
                else
                    cmb_cus_type.Enabled = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //customer fillgrid
        public void CustomerFillGrid()
        {

            //SqlConnection con = new SqlConnection();
            //con.ConnectionString = @"Data Source=THARAKA-PC;Initial Catalog=MegaCoolEngineers; Integrated Security = SSPI";
            //con.Open();

            SqlConnection con = ConnectionManager.GetConnection();

            if (con.State.ToString() == "Closed")
            {
                con.Open();
            }


            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("select cu.NIC,cu.Name,cu.Email,cu.Address,cu.Rate,cu.CustomerType,cc.ContactNo from Customer cu,CustomerContact cc where cu.NIC=cc.NIC  order by Rate", con);

                DataTable dt = new DataTable();

                sda.Fill(dt);

                dgv_cus_table.DataSource = dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //customer feilds validation
        public bool CustomerValidation()
        {
            bool status = false;

            if (txtb_cus_nic.Text == "")
                MessageBox.Show("Please fill the Customer NIC field");
            else if (txtb_cus_nic.TextLength != 10)
                MessageBox.Show("Required Length of Customer NIC is wrong");
            else if (!txtb_cus_nic.ToString().EndsWith("v") || txtb_cus_nic.ToString().EndsWith("V"))
                MessageBox.Show("please end the Customer NIC with letter 'v' or 'V'");
            else if (txtb_cus_name.Text == "")
                MessageBox.Show("Please fill the Customer name field");
            else if (rtb_cus_address.Text == "")
                MessageBox.Show("Please fill the Customer Address field");
            else if (txtb_cus_mobileno.Text == "")
                MessageBox.Show("Please fill the mobile No field");
            else if (txtb_cus_mobileno.TextLength != 10)
                MessageBox.Show("Please enter valid mobile no");
            else if (txtb_cus_email.Text == "")
                MessageBox.Show("Please fill the email address field");
            //else if (txtb_cus_rate.Text == "")
              //  MessageBox.Show("Please fill the customer Rate field");
           // else if (Convert.ToInt32(txtb_cus_rate.Text) < 0)
             //   MessageBox.Show("Please enter only positive values for the Rate feild");
            else if (cmb_cus_type.Text == "")
                MessageBox.Show("Please select the Customer Type (Loyalty/Regular) ");
            
            else
            {
                status = true;

            }
            return status;
        }

        //Delete customer
        private void btn_cus_delete_Click(object sender, EventArgs e)
        {
          
            if (CustomerValidation())
            {
                try
                {

                    string nic = txtb_cus_nic.Text;
                    MegaCoolMethods mcm = new MegaCoolMethods();
                    bool result = mcm.DeleteCustomer(nic);
                    bool result2 = mcm.DeleteLoyaltyCard(nic);


                    //show the confirmation dialog box
                    DialogResult dr;
                    dr = MessageBox.Show("Do you want to delete the record", "Confirm", MessageBoxButtons.YesNo);
                    if (dr.ToString() == "Yes")
                    {
                        if (result)
                        {
                            MessageBox.Show("Successfully Deleted the Customer", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CustomerFillGrid();

                            //delete loyalty card with customer
                            if (result2)
                            {
                               // MessageBox.Show("Successfully Deleted Loyalty Card", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                CustomerLotaltyCardFillGrid();
                            }

                        }
                        else
                        {
                            MessageBox.Show("Unable to Delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                        MessageBox.Show("Record is not deleted", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
                MessageBox.Show("Customer deletion request Can not be completed");

            Clear();
            btn_cus_add.Enabled = true;
        }

        private void btn_cus_refresh_Click(object sender, EventArgs e)
        {
            CustomerFillGrid();
        }

        public void Clear() {
            txtb_cus_nic.Clear();
            txtb_cus_name.Clear();
            rtb_cus_address.Clear();
            txtb_cus_mobileno.Clear();
            txtb_cus_email.Clear();
            cmb_cus_type.SelectedIndex = -1;
           // txtb_cus_rate.Clear();
            txt_loy_nic.Clear();
            cmb_loy_cardtype.SelectedIndex = -1;
            lbl_loymem_cardno.Text = "Click";
            cmb_email_nic.Text = "";

            txtb_cus_nic.Enabled = true;
            txt_loy_nic.Enabled = true;

            txt_email_address.Clear();
            txt_email_subject.Clear();
            rtb_cus_email_body.Clear();  

        }

        private void txtb_cus_nic_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == (char)Keys.Back || e.KeyChar == 'v' || e.KeyChar == 'V')
            {
                e.Handled = false; //Do not reject the input
            }
            else
            {
                e.Handled = true; //Reject the input
            }
    
        }

        private void txtb_cus_mobileno_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
            if (txtb_cus_mobileno.Text.Length > 9 && ch != 8)
                e.Handled = true;
        }

        private void gpb_cuc_loyalty_Enter(object sender, EventArgs e)
        {

        }


        //CUSTOMER_LOYALTY

        public void CustomerLotaltyCardFillGrid()
        {

            SqlConnection con = ConnectionManager.GetConnection();

            if (con.State.ToString() == "Closed")
            {
                con.Open();
            }

            try
            {
                String str_all = "select cu.Name, cusl.NIC, cusl.Card_No, cusl.Card_Points, cusl.CardType  from CustomerLoyalatyCard cusl,Customer cu where cusl.NIC=cu.NIC and cu.CustomerType = 'Loyalty'";
                String str_Gold = "select cu.Name, cusl.NIC, cusl.Card_No, cusl.Card_Points, cusl.CardType  from CustomerLoyalatyCard cusl,Customer cu where cusl.NIC=cu.NIC AND cusl.CardType = 'Gold'";
                String str_Silver = "select cu.Name, cusl.NIC, cusl.Card_No, cusl.Card_Points, cusl.CardType  from CustomerLoyalatyCard cusl,Customer cu where cusl.NIC=cu.NIC AND cusl.CardType = 'Silver'";
                String str_Bronze = "select cu.Name, cusl.NIC, cusl.Card_No, cusl.Card_Points, cusl.CardType  from CustomerLoyalatyCard cusl,Customer cu where cusl.NIC=cu.NIC AND cusl.CardType = 'Bronze'";

                if (cmb_loy_selectCardType.Text == "All")
                {
                    SqlDataAdapter sda = new SqlDataAdapter(str_all, con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dgv_loyalty_table.DataSource = dt;
                }
                else if (cmb_loy_selectCardType.Text == "GOLD Customers")
                {
                    SqlDataAdapter sda = new SqlDataAdapter(str_Gold, con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dgv_loyalty_table.DataSource = dt;
                }
                else if (cmb_loy_selectCardType.Text == "Silver Customers")
                {
                    SqlDataAdapter sda = new SqlDataAdapter(str_Silver, con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dgv_loyalty_table.DataSource = dt;
                }
                else if (cmb_loy_selectCardType.Text == "Bronze Customers")
                {
                    SqlDataAdapter sda = new SqlDataAdapter(str_Bronze, con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dgv_loyalty_table.DataSource = dt;
                }



            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //customer loyalty card rowheader mouseclick event
        private void dgv_loyalty_table_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
             try
            {
                string nic = ((DataGridView)sender).Rows[e.RowIndex].Cells[1].Value.ToString();
                string cardNo = ((DataGridView)sender).Rows[e.RowIndex].Cells[2].Value.ToString();
                string cardPoints = ((DataGridView)sender).Rows[e.RowIndex].Cells[3].Value.ToString();
                string cardType = ((DataGridView)sender).Rows[e.RowIndex].Cells[4].Value.ToString();

                txt_loy_nic.Text = nic;
                lbl_loymem_cardno.Text = cardNo;
                cmb_loy_cardtype.Text = cardType;
           
                txt_loy_nic.Enabled = false;
                btn_loy_add.Enabled = false;
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        
        }

        public bool CustomerLoyaltyCardValidation()
        {
            bool status = false;


            if (txt_loy_nic.Text == "")
                MessageBox.Show("Please fill the Customer NIC field");
            else if (txt_loy_nic.TextLength != 10)
                MessageBox.Show("Required Length of Customer NIC is wrong");
            else if (!txt_loy_nic.ToString().EndsWith("v") || txtb_cus_nic.ToString().EndsWith("V"))
                MessageBox.Show("please end the Customer NIC with letter 'v' or 'V'");
            else if (cmb_loy_cardtype.Text == "")
                MessageBox.Show("Please click on the card type feild to generate card type (Gold / Silver / bronze)");
            else if (lbl_loymem_cardno.Text == "")
                MessageBox.Show("Please click on the card no feild");
           // else if (txtb_loy_cardpoints == null)
               // MessageBox.Show("Please add card points");
           // else if (Convert.ToInt32(txtb_loy_cardpoints) < 0)
                //MessageBox.Show("Please enter only positive values");
            else
            {
                status = true;

            }
            return status;
        }

        //validate customer nic in loyalty
        private void txt_loy_nic_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == (char)Keys.Back || e.KeyChar == 'v' || e.KeyChar == 'V')
            {
                e.Handled = false; //Do not reject the input
            }
            else
            {
                e.Handled = true; //Reject the input
            }
        }


        //Add loyalty card customer
        private void btn_loy_add_Click(object sender, EventArgs e)
        {
            CustomerObject co = new CustomerObject();

            SqlConnection con = ConnectionManager.GetConnection();

            if (con.State.ToString() == "Closed")
            {
                con.Open();
            }
            if (CustomerLoyaltyCardValidation())
            {
                try
                {
                    SqlCommand cmd = con.CreateCommand();

                    string nic = "select NIC from Customer where NIC = '" + txt_loy_nic.Text + "'";

                    cmd.CommandText = nic;
                    SqlDataReader rd = cmd.ExecuteReader();
                    rd.Read();

                    bool result1 = rd.HasRows;

                    if (!result1)
                    {
                        MessageBox.Show("This customer is not registered customer cannot issue a loyalty card");
                    }
                    else
                    {

                        if (CustomerLoyaltyCardValidation())
                        {
                            CustomerObject objCustomer = new CustomerObject();

                            objCustomer.Nic = txt_loy_nic.Text;
                            objCustomer.CardType = cmb_loy_cardtype.SelectedItem.ToString();
                            objCustomer.CardNo = lbl_loymem_cardno.Text;
                            //  objCustomer.CardPoints = Convert.ToInt32(txtb_loy_cardpoints.Text);
                            objCustomer.CardPoints = 0;

                            //show the confirmation dialog box
                            DialogResult dr;
                            dr = MessageBox.Show("Do you want to save the record", "Confirm", MessageBoxButtons.YesNo);
                            if (dr.ToString() == "Yes")
                            {
                                try
                                {
                                    MegaCoolMethods mcm = new MegaCoolMethods();
                                    bool result = mcm.AddLoyaltyCustomer(objCustomer);

                                    if (result)
                                    {
                                        MessageBox.Show("Successfully Saved", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        tb_cus_tabcontroller.SelectedTab = tab_customermanagement;
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
                                        MessageBox.Show("This loyalty customer is alreay exist, please add new customer ");
                                        //Violation of primary key. Handle Exception
                                    }
                                }
                            }
                            else
                                MessageBox.Show("Record is not saved", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }


                }
                catch (SqlException ex)
                {

                    throw ex;
                }
            }

            CustomerLotaltyCardFillGrid();
            Clear();
            CustomerFillGrid();
           
        }
    

        //update loyalty card

         private void btn_loy_update_Click(object sender, EventArgs e)
        {
          
             if (CustomerLoyaltyCardValidation())
            {
                DialogResult dr;
                dr = MessageBox.Show("Do you want to update the record", "Confirm", MessageBoxButtons.YesNo);
                if (dr.ToString() == "Yes")
                {


                    CustomerObject objCustomer = new CustomerObject();

                    objCustomer.Nic = txt_loy_nic.Text;
                    objCustomer.CardType = cmb_loy_cardtype.SelectedItem.ToString();
                    objCustomer.CardNo = lbl_loymem_cardno.Text;
                    //  objCustomer.CardPoints = Convert.ToInt32(txtb_loy_cardpoints.Text);
                    objCustomer.CardPoints = 0;

                    try
                    {
                        MegaCoolMethods mcm = new MegaCoolMethods();
                        bool result = mcm.EditLoyaltyCard(objCustomer);

                        if (result)
                        {
                            MessageBox.Show("Successfully Updated", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CustomerFillGrid();
                        }
                        else
                        {
                            MessageBox.Show("Unable to Update", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("Record is not updated", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            CustomerLotaltyCardFillGrid();
            Clear();
            btn_loy_add.Enabled = true;


        }

        //Delete a loyalty card
        private void btn_loy_delete_Click(object sender, EventArgs e)
        {
            
            try{
                string nic = txt_loy_nic.Text;
                //string cardno = lbl_loymem_cardno.Text;
                MegaCoolMethods mcm = new MegaCoolMethods();
                //bool result = mcm.DeleteLoyaltyCard(cardno, nic);

                //show the confirmation dialog box
                DialogResult dr;
                dr = MessageBox.Show("Do you want to delete the record", "Confirm", MessageBoxButtons.YesNo);
                if (dr.ToString() == "Yes")
                {
                    if (mcm.DeleteLoyaltyCard(nic))
                    {
                        
                        MessageBox.Show("Successfully Deleted", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CustomerLotaltyCardFillGrid();

                    }
                    else 
                    {
                        MessageBox.Show("Unable to Delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    MessageBox.Show("Record is not deleted", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            CustomerLotaltyCardFillGrid();
            Clear();
            btn_loy_add.Enabled = true;

        }
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        //email send button 
        private void btn_cus_email_send_Click(object sender, EventArgs e)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("megacooleng@gmail.com");
                //mail.To.Add("megacooleng@gmail.com");
                //mail.Subject = "Test Mail";
                //mail.Body = "This is for testing SMTP mail from GMAIL";
                if (txt_email_address.Text != " ")
                {
                    Validation vlemail = new Validation();
                    if (vlemail.IsValidEmail(txt_email_address.Text) == false)
                    {
                        MessageBox.Show("Please Enter Valid Email");
                    }
                    else
                    {

                        mail.To.Add(txt_email_address.Text);
                        mail.Subject = txt_email_subject.Text;
                        mail.Body = rtb_cus_email_body.Text;


                        string username = "megacooleng@gmail.com";
                        string password = "qnmghgzgrjtzphpc";

                        SmtpServer.Port = 587;
                        SmtpServer.Credentials = new System.Net.NetworkCredential(username, password);
                        SmtpServer.EnableSsl = true;

                        SmtpServer.Send(mail);
                        MessageBox.Show("Successfully Sent");
                    }
                }
                else
                    MessageBox.Show("Please fill a Email Address feild");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            Clear();
        }

        //email demo
        private void btn_email_demo_Click(object sender, EventArgs e)
        {
            cmb_email_nic.Text = "985645451v";
            txt_email_address.Text = "tharakamadushanki@gmail.com";
            txt_email_subject.Text = "Test Mail";
            rtb_cus_email_body.Text = "Hello tharka, This is for testing SMTP mail from GMAIL";
        }

        private void btn_crdmngr_addpoints_Click(object sender, EventArgs e)
        {

        }
        private void rbtn_cus_loy_allloyalitycustomers_Click(object sender, EventArgs e)
        {
            CustomerLotaltyCardFillGrid();
        }

        private void rbtn_cus_loy_Goldloyalitycustomers_Click(object sender, EventArgs e)
        {
            CustomerLotaltyCardFillGrid();
        }

        private void rbtn_cus_loy_silverloyalitycustomers_Click(object sender, EventArgs e)
        {
            CustomerLotaltyCardFillGrid();
        }

        private void rbtn_cus_loy_Bronzeloyalitycustomers_Click(object sender, EventArgs e)
        {
            CustomerLotaltyCardFillGrid();
        }

        private void txt_loy_nic_KeyDown(object sender, KeyEventArgs e)
        {
            string nic = txt_loy_nic.Text;

            SqlConnection con = ConnectionManager.GetConnection();

            if (con.State.ToString() == "Closed")
            {
                con.Open();
            }

            string str = "select cu.Name, cusl.NIC, cusl.Card_No, cusl.Card_Points, cusl.CardType from CustomerLoyalatyCard cusl,Customer cu where cusl.NIC=cu.NIC  and cusl.NIC like  '%" + txt_loy_nic.Text + "%' and cu.CustomerType = 'Loyalty'";
            SqlDataAdapter sda = new SqlDataAdapter(str,con);
            DataTable dt = new DataTable();

            sda.Fill(dt);
            

            dgv_loyalty_table.DataSource = dt;
        }

       
        private void cmb_loy_cardtype_SelectedIndexChanged(object sender, EventArgs e)
        {
           // if (txt_loy_nic.Text != "")
            lbl_loymem_cardno.Visible = true;
        }


        //customer search key by name and nic
        private void txt_cus_searchkey_KeyPress(object sender, KeyPressEventArgs e)
        {
            string x = txt_cus_searchkey.Text;

            SqlConnection con = ConnectionManager.GetConnection();

            if (con.State.ToString() == "Closed")
            {
                con.Open();
            }

            SqlDataAdapter sda = new SqlDataAdapter("select cu.NIC,cu.Name,cu.Email,cu.Address,cu.Rate,cu.CustomerType,cc.ContactNo from Customer cu,CustomerContact cc where (cu.NIC=cc.NIC  and cu.NIC LIKE  '%" + x + "%') or (cu.NIC=cc.NIC  and cu.Name LIKE  '%" + x + "%') ", con);

            DataTable dt = new DataTable();

            sda.Fill(dt);
            dgv_cus_table.DataSource = dt;
        }
  
        //get email address when gives nic
        private void txt_email_address_MouseClick(object sender, MouseEventArgs e)
        {
            SqlConnection con = ConnectionManager.GetConnection();
           

            if (con.State.ToString() == "Closed")
            {
                con.Open();
            }

            if (cmb_email_nic.Text != "")
            {
                try
                {
                    string email = "select Email from Customer where NIC = '" + cmb_email_nic.Text + "'";
                    SqlCommand cmd = new SqlCommand(email, con);
                    SqlDataReader dr;

                    dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        dr.Read();
                        txt_email_address.Text = dr.GetString(0);
                    }
                    else
                        MessageBox.Show("This customer is not a existing customer, please enter NIC of existing customer");
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
            }
            else
                MessageBox.Show("Please fill the NIC field");
            

        }

        

        private void txt_loy_nic_MouseClick(object sender, MouseEventArgs e)
        {
            string nic = txtb_cus_nic.Text;
            txt_loy_nic.Text = nic;
        }

        //card no generation
        private void lbl_loymem_cardno_Click(object sender, EventArgs e)
        {
            if (txt_loy_nic.Text != "" && cmb_loy_cardtype.Text != "")
            {

                String card1 = cmb_loy_cardtype.Text.Substring(0, 2).ToUpper();
                String card2 = txt_loy_nic.Text.Substring(0, 9);

                String cardNo = string.Concat(card1, card2);
                lbl_loymem_cardno.Text = cardNo;

            }
            else if (txt_loy_nic.Text == "")
                MessageBox.Show("Please fill the NIC feild");
            
            
            
        }

        private void combo_grid_SelectedIndexChanged(object sender, EventArgs e)
        {
            CustomerLotaltyCardFillGrid();
        }

        private void btn_cusLoy_clear_Click(object sender, EventArgs e)
        {
            txt_loy_nic.Clear();
            cmb_loy_cardtype.SelectedIndex = -1;
            lbl_loymem_cardno.Text = "";
           

            txt_loy_nic.Enabled = true;
            btn_loy_add.Enabled = true;
            CustomerLotaltyCardFillGrid();
        }

        private void btn_cusEmail_clear_Click(object sender, EventArgs e)
        {
            cmb_email_nic.SelectedIndex = -1;
            txt_email_address.Clear();
            txt_email_subject.Clear();
        }

        private void cmb_loy_cardtype_Click(object sender, EventArgs e)
        {
             lbl_loymem_cardno.Text = "Click";
        }

        //change card type according to the customer rating
        private void cmb_loy_cardtype_MouseClick(object sender, MouseEventArgs e)
        {
            MegaCoolMethods mcm = new MegaCoolMethods();
            string crdtype = mcm.setCardType(txt_loy_nic.Text);

            if (crdtype == "")
            {
                cmb_loy_cardtype.Text = "BRONZE";
            }
            else
                cmb_loy_cardtype.Text = crdtype;

         

        }

        //fill customer nic combo box in email tab
        public void FillComboEmailCusNIC() 
        {

            SqlConnection con = ConnectionManager.GetConnection();
            if (con.State.ToString() == "Closed")
            {
                con.Open();
            }

            try {

                SqlCommand newCmd = con.CreateCommand();

                newCmd.Connection = con;
                newCmd.CommandType = CommandType.Text;
                newCmd.CommandText = "select NIC from dbo.Customer ";

                SqlDataReader dr = newCmd.ExecuteReader();
                while (dr.Read()) {
                    string nic = Convert.ToString(dr[0]);
                    cmb_email_nic.Items.Add(nic);
                }


            }catch(SqlException ex){
                throw ex;
            }

        }

        
       
        
        private void btnCusRep1_Click(object sender, EventArgs e)
        {
            CusRep1 CS1 = new CusRep1();

            CS1.Show();
        }

        private void btnCusRep2_Click(object sender, EventArgs e)
        {
            CusRep2 CS2 = new CusRep2();

            CS2.Show();
        }

        
    
        
    }
}

