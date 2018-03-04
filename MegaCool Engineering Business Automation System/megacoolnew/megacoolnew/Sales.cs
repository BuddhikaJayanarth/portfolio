using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using megacoolnew;
using megacoolnew.userObjects;

namespace megacoolnew
{
    public partial class Sales : Form
    {
       // string qLoad = "select * from ServiceInvoice";
        int invoiceID;
        CustomerObject co = new CustomerObject();

        public Sales()
        {
            InitializeComponent();
            FillComboIn();
            fillComboJobID();
            lblPurDate.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
            groupBox1.Enabled = false;
            btnPurSub.Enabled = false;
            

        }
        MegaCoolMethods mcm = new MegaCoolMethods();
        
        SqlConnection con = ConnectionManager.GetConnection();

        SalesObject so = new SalesObject();
        

        //Filling Product Type Combo box
        public void FillComboType()
        {
            
            if (con.State.ToString() == "Closed")
            {
                con.Open();
            }

            try
            {

                string q = "select distinct ProductType from dbo.Inventory";

                SqlCommand cmd = new SqlCommand(q, con);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);

                cmbPurType.DataSource = dt;
                cmbPurType.DisplayMember = "ProductType";
                cmbPurType.Text = "";


            }
            catch (SqlException ex)
            {
                throw ex;
            }
            con.Close();

        }
        //---------------Fill Combo inventory id---------------------------
        public void FillComboIn()
        {

            SqlConnection con = ConnectionManager.GetConnection();

            if (con.State.ToString() == "Closed")
            {
                con.Open();
            }
            try
            {

                SqlCommand cmd1 = con.CreateCommand();

                cmd1.Connection = con;
                cmd1.CommandType = CommandType.Text;

                cmd1.CommandText = "select distinct InventoryID from dbo.Inventory where Make = '"+cmbPurMake.Text+"' and ProductType='" + cmbPurType.Text + "'";

                SqlDataReader dr = cmd1.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                cmbPurIn.DataSource = dt;
                cmbPurIn.DisplayMember = "InventoryID";
                cmbPurIn.Text = "";


            }
            catch (SqlException ex)
            {
                throw ex;
            }
            con.Close();

        }

        //------------------------------------------

        //Filling Make Combo box
        public void FillComboMake()
        {

            SqlConnection con = ConnectionManager.GetConnection();

            if (con.State.ToString() == "Closed")
            {
                con.Open();
            }
            try
            {

                SqlCommand cmd1 = con.CreateCommand();

                cmd1.Connection = con;
                cmd1.CommandType = CommandType.Text;

                cmd1.CommandText = "select distinct Make from dbo.Inventory where ProductType='" + cmbPurType.Text + "'";

                SqlDataReader dr = cmd1.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                cmbPurMake.DataSource = dt;
                cmbPurMake.DisplayMember = "Make";
                cmbPurMake.Text = "";

                
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            con.Close();
            
        }

        //---Fill Combo jobID---
        DataTable dt = new DataTable();
        public void fillComboJobID()
        {
            SqlConnection con = ConnectionManager.GetConnection();
            if (con.State.ToString() == "Closed")
            {
                con.Open();
            }

            try
            {

                string q = "select distinct JobID from dbo.Repair_Inventory";

                SqlCommand cmd = new SqlCommand(q, con);
                SqlDataReader dr = cmd.ExecuteReader();
                
                dt.Load(dr);

                cmbSerJobID.DataSource = dt;
                cmbSerJobID.DisplayMember = "JobID";
                cmbSerJobID.Text = "";


            }
            catch (SqlException ex)
            {
                throw ex;
            }
            con.Close();
            
        }
        

        private void btnDemo_Click_1(object sender, EventArgs e)
        {
            txtPurSKey.Text = "569325";
            txtPurTot.Text = "5627";
            txtPurDis.Text = "627";
            txtPurGrand.Text = "5000";
            
        }
        

        //sales_invoice_search_btn
        private void button1_Click_2(object sender, EventArgs e) 
        {
            String q = "select InventoryID, ProductType, Make, Model, SellingPrice from Inventory Where Make = '" + cmbPurMake.Text + "' and ProductType = '" + cmbPurType.Text + "'";
            cmbPurModel.DataSource = mcm.loadGridView(q);
        }


        private void button7_Click_1(object sender, EventArgs e)
        {
            
            if(txtPurSKey.Text == ""  || txtPurNIC.Text == "" || lblPurName.Text == "" || cmbPurPayType.Text=="" || cmbPurIn.Text=="")
            {   
                MessageBox.Show("Fill all the fields");
            }
            else
            {
                string pt = cmbPurType.Text;
                string mk = cmbPurMake.Text;
                string md = cmbPurModel.Text;
                string inID = cmbPurIn.Text;
                string Skey = txtPurSKey.Text;
                so.InventoryID = inID;


                string q1 = "select InventoryID from Inventory where Make='"+mk+"' and Model='"+md+"' and InventoryID='"+inID+"'";
                string FindInvoiceQ = "SELECT TOP 1 InvoiceID FROM Invoice ORDER BY InvoiceID DESC";
                SqlCommand cmd1 = new SqlCommand(q1,con);
                SqlCommand cmdFindInvoice = new SqlCommand(FindInvoiceQ, con);
                so.InvoiceNo = invoiceID;
                
                con.Open();

                try
                {
                    SqlDataReader dr = cmd1.ExecuteReader(); 
                    dr.Read(); 
                    inID = dr.GetString(0);
                    so.InventoryID = inID;
                }

                catch (Exception ex)
                {
                    throw ex;
                }
                con.Close();

                string q2 = "insert into PurchaseItems (InvoiceID, InventoryID, SerialKey) values('"+invoiceID+"', '" + inID + "', '" + Skey + "')";
                 
                string q3 = "SELECT DISTINCT Inv.make, Inv.model, PIn.serialkey, Inv.sellingprice , PIn.idx " +
                            "FROM PurchaseItems PIn, Inventory Inv, Invoice Invc "+
                            "WHERE Pin.InvoiceID = '"+invoiceID+"' AND PIn.InventoryID = Inv.InventoryID "+
                            "order by PIn.idx";
                
                dataGridView4.DataSource = mcm.loadGridView(q3);
                SqlCommand cmd2 = new SqlCommand(q2,con);

                con.Open();
                try
                {
                    cmd2.ExecuteNonQuery();
                }
                //catch { }
                catch (Exception ex)
                {
                    MessageBox.Show("Error inserting data\n");
                    throw ex;
                }
                con.Close();

                dataGridView4.DataSource = mcm.loadGridView(q3);
                
                //---get the total to the text box---

                double sum = mcm.getPurchaseTotal(dataGridView4);
                so.Discount =  mcm.calcDiscount(so.CardType, sum);
                double netTot = sum - so.Discount;
                so.PurchaseGrand = netTot;
                txtPurTot.Text = sum.ToString();
                txtPurDis.Text = so.Discount.ToString();
                txtPurGrand.Text = netTot.ToString();

                mcm.DeductInventory(so.InventoryID);
                
            }
        }
        
        private void cmbPurMake_SelectedIndexChanged(object sender, EventArgs e)
        {
            String q = "select distinct Model from Inventory Where Make = '" + cmbPurMake.Text + "' and ProductType = '" + cmbPurType.Text + "'";
            cmbPurModel.DataSource = mcm.loadGridView(q);
            cmbPurModel.DisplayMember = "Model";
        }

  
        private void cmbPurType_Enter(object sender, EventArgs e)
        {
            FillComboType();
            cmbPurModel.Text= "";
            txtPurSKey.Text = "";

        }

        private void cmbPurType_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillComboMake();
            cmbPurModel.Text = "";
            cmbPurMake.SelectedIndex = -1;
        }

       

        private void button8_Click(object sender, EventArgs e)
        {
            //SalesObject so = new SalesObject();
            so.NIC = txtPurNIC.Text;
            string cusName = lblPurName.Text;
            string type = cmbPurPayType.Text;
            string Skey = txtPurSKey.Text;
            DateTime date = DateTime.Now;
            if (so.NIC == "" || cusName == "" || type == "")
            {
                MessageBox.Show("Please Enter all the details");
            }
            else
            { 
                string q = "INSERT INTO Invoice (NIC, Date) VALUES ('"+so.NIC+"', '"+date+"')";
                SqlCommand cmd = new SqlCommand(q, con);

                con.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception Ex)
                {

                    throw Ex;
                }
                con.Close();
                
                string cardType = mcm.getCardType(co,so);
                //label6.Text = cardType;
                string q2 = "select * from CustomerLoyalatyCard where NIC='" + so.NIC + "'";
                SqlCommand cmd2 = new SqlCommand(q2, con);

                con.Open();
                try
                {
                    SqlDataReader rd = cmd2.ExecuteReader();
                    if (rd.HasRows)
                    {
                        rd.Read();
                        so.CardType = rd[3].ToString();

                    }
                }
                catch (Exception ex) { throw ex; }
                con.Close();


                con.Open();
                try
                {
                    MessageBox.Show("Invoice created Successfully ");
                    //cmd.ExecuteNonQuery(); 
                    btnPurAdd.Enabled = true;
                    btnPurCreate.Enabled = false;
                    txtPurNIC.Enabled = false;
                    btnPurSub.Enabled = true;
                    btn9Demo.Enabled = false;
                    btn10Clear.Enabled = false;
                    groupBox1.Enabled = true;
                    cmbPurPayType.Enabled = false;
                    groupBox1.Enabled = true;
                    cmbPurType.Enabled = true;
                    cmbPurMake.Enabled = true;
                    cmbPurModel.Enabled = true;
                    txtPurSKey.Enabled = true;
                    cmbPurIn.Enabled = true;

                }
                catch (Exception ex)
                {

                    MessageBox.Show("not success");
                    throw ex;
                }
                

                string invIDquery = "select top 1 InvoiceID from Invoice order by InvoiceID desc";
                SqlCommand cmd1 = new SqlCommand(invIDquery, con);

                SqlDataReader reader;
                try
                {
                    reader = cmd1.ExecuteReader();
                    reader.Read();
                    invoiceID = reader.GetInt32(0);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                con.Close();
            }

        }
        

        private void txtPurNIC_Leave(object sender, EventArgs e)
        {
            
            string NIC = txtPurNIC.Text;
            if (NIC != "")
            {

                string q = "select * from Customer where NIC='"+NIC+"'";
                SqlCommand cmd = new SqlCommand(q,con);
                
                con.Open();
                try
                {
                    SqlDataReader rd = cmd.ExecuteReader();
                    if (rd.HasRows)
                    {
                        rd.Read();
                        co.CustomrName = rd[1].ToString();
                        lblPurName.Text = co.CustomrName;
                    }
                    else{
                        MessageBox.Show("Invalid NIC");
                        txtPurNIC.Text = "";
                    }
                    rd.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                
                string q1 = "select * from CustomerLoyalatyCard where NIC='"+NIC+"' ";
                SqlCommand cmd1 = new SqlCommand(q1, con);
                
                try
                {
                    SqlDataReader rd = cmd1.ExecuteReader();
                    if (rd.HasRows)
                    {
                        rd.Read();
                        co.CardPoints= Convert.ToInt16(rd[2]);
                    }
                    
                }
                catch(Exception ex)
                {
                    throw ex;
                }
                con.Close();
                
                try
                {

                }
                catch (Exception ex)
                {

                    throw ex;
                }


            }

        }

        private void btn9Demo_Click(object sender, EventArgs e)
        {
            lblPurDate.Text = DateTime.Now.ToString();
            txtPurNIC.Text = "923456789v";
            cmbPurPayType.Text = "Card";
        }

        private void btn10Clear_Click(object sender, EventArgs e)
        {
            txtPurNIC.Text = "";
            lblPurName.Text = "";
            cmbPurPayType.SelectedIndex = -1;
        }

       

        private void button1_Click_1(object sender, EventArgs e)
        {
            double tot_amount = 0;
            string jobID = cmbSerJobID.Text;
            DateTime date = DateTime.Now;
            
            string mobile = txtSerMobile.Text;
            double grandTotal = Convert.ToDouble(lblSerGrand.Text);
            bool invoiceAlreadyCreated=false;
            so.ServiceGrand = grandTotal;

            
            so.CustomerName = txtSerCusName.Text;

            //--------------------------------
            string q1 = "select * from ServiceInvoice where JobID= '"+jobID+"' ";

            SqlCommand cmd1 = new SqlCommand(q1, con);
            con.Open();
            try
            {
                SqlDataReader rd1 = cmd1.ExecuteReader();
                if (rd1.HasRows)
                {
                    invoiceAlreadyCreated = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            con.Close();
            //-----------------------------

            if (!invoiceAlreadyCreated)
            {
               
                if (co.CardPoints > 0)
                {
                    DialogResult dr;
                    dr = MessageBox.Show("           " + co.CustomrName + " have " + co.CardPoints + " points \n" +
                        "                   want to spend?", "Confirm", MessageBoxButtons.YesNo);
                    double amountToPay;
                    if (dr.ToString() == "Yes")
                    {
                        amountToPay = so.ServiceGrand - co.CardPoints;
                        MessageBox.Show("amount to pay " + amountToPay);

                        mcm.DeductPoints(co, so);

                    }
                    
                    //call LoyaltyCardAddPoints method to update loyalty points
                    tot_amount = Convert.ToDouble(txtPurGrand.Text);
                    mcm.LoyaltyCardAddPoints(tot_amount, txtPurNIC.Text);
                }


                string q = "INSERT INTO ServiceInvoice VALUES('" + jobID + "','" + so.NIC + "','" + so.CustomerName + "','" + date + "','" + mobile + "','" + grandTotal + "' )";
                SqlCommand cmd = new SqlCommand(q, con);
                con.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Invoice Created Successfully");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                con.Close();

                //call LoyaltyCardAddPoints method to update loyalty points
                mcm.LoyaltyCardAddPoints(tot_amount, txtPurNIC.Text);


            }
            else
                MessageBox.Show("Invoice Already Created");

        }

        private void btnDelete_Click(object sender, EventArgs e)
        { 
            string idx = dataGridView4.CurrentRow.Cells[4].Value.ToString();
            

            if (mcm.deletePurchaseItem(idx))
            {
                string q3 = "SELECT DISTINCT Inv.make, Inv.model, PIn.serialkey, Inv.sellingprice , PIn.idx " +
                               "FROM PurchaseItems PIn, Inventory Inv, Invoice Invc " +
                               "WHERE Pin.InvoiceID = '" + invoiceID + "' AND PIn.InventoryID = Inv.InventoryID " +
                               "order by PIn.idx";
                dataGridView4.DataSource = mcm.loadGridView(q3);
              
                double sum = mcm.getPurchaseTotal(dataGridView4);
                double discount = mcm.calcDiscount(so.CardType, sum);
                double netTot = sum - discount;

                txtPurTot.Text = sum.ToString();
                txtPurDis.Text = discount.ToString();
                txtPurGrand.Text = netTot.ToString();
                mcm.ResetInventory(so.InventoryID);
            }
            

        }

        private void cmbSerJobID_SelectedIndexChanged(object sender, EventArgs e)
        {
            string jobID = cmbSerJobID.Text;
            string cusName;
            
            so.JobID = jobID;
            so.NIC= mcm.getNIC(so, jobID);
            if (jobID != "")
            {
                string q = "select C.* from Repair_Job R, Customer C where R.CustomerNIC=C.NIC and R.JobID='" + jobID + "'";
                SqlCommand cmd = new SqlCommand(q, con);
                string cardType = mcm.getCardType(co,so);
                
                con.Open();
                try
                {
                    SqlDataReader rd = cmd.ExecuteReader();
                    if (rd.HasRows)
                    {
                        rd.Read();
                        cusName = rd[1].ToString();
                        string email = rd[2].ToString();
                        txtSerCusName.Text = cusName;
                        txtSerEmail.Text = email;
                        txtSerMobile.Clear();
                        co.CustomrName = cusName;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                con.Close();

                string q1 = "SELECT i.ProductType, i.Make, i.Model, r.ItemNo, r.SellingPrice " +
                            "FROM Inventory i ,Repair_Inventory r " +
                            "WHERE i.InventoryID=r.InventoryID AND r.JobID='" + jobID + "'";

                SqlCommand cmd1 = new SqlCommand(q1, con);
                con.Open();
                try
                {
                    SqlDataReader rd1 = cmd1.ExecuteReader();
                    if (rd1.HasRows)
                    {
                        dataGridView1.DataSource = mcm.loadGridView(q1);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                con.Close();

                string q2 = "select * from CustomerLoyalatyCard where NIC='"+so.NIC+"'";
                SqlCommand cmd2 = new SqlCommand(q2, con);
                
                
                con.Open();
                try
                {
                    SqlDataReader rd = cmd2.ExecuteReader();
                    if (rd.HasRows)
                    {
                        rd.Read();
                        so.CardType = rd[3].ToString();
                        co.CardPoints = Convert.ToInt16( rd[2]);
                    }
                    else
                    {
                        so.CardType = null;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                double serviceTotal = mcm.getServiceTotal(dataGridView1);
                double serviceDiscount = mcm.calcDiscount(so.CardType, serviceTotal);
                double grandTotal = serviceTotal - serviceDiscount;

                lblSerDis.Text = serviceDiscount.ToString();
                lblGTotalD.Text = serviceTotal.ToString();
                lblSerGrand.Text = grandTotal.ToString();
                
                con.Close();
                
                tstpoints.Text = mcm.getCardCardPoints(so);

            }
        }
        
        private void btnPurSub_Click(object sender, EventArgs e)
        {
            delivery de = new delivery();
            
            if (co.CardPoints > 0)
            {
                DialogResult dr;
                dr = MessageBox.Show("           " + co.CustomrName + " have " + co.CardPoints + " points \n" +
                    "                   want to spend?", "Confirm", MessageBoxButtons.YesNo);
                double amountToPay;
                if (dr.ToString() == "Yes")
                {
                    amountToPay = so.PurchaseGrand - co.CardPoints;
                    MessageBox.Show("amount to pay " + amountToPay);

                    mcm.DeductPoints(co, so);

                }
               
            }

            //call LoyaltyCardAddPoints method to update loyalty points
            double tot_amount = Convert.ToDouble(txtPurGrand.Text);
            mcm.LoyaltyCardAddPoints(tot_amount, txtPurNIC.Text);


            string q = "update Invoice set Amount='"+ so.PurchaseGrand +"' where NIC= '"+so.NIC+"' and InvoiceID='"+ so.InvoiceNo + "' ";
            SqlCommand cmd = new SqlCommand(q,con);
            con.Open();
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Succesfully Submitted");

                //Ask to change the  card type when customer reaching new card level by getting tot invoice amount
                mcm.changeCardType(txtPurNIC.Text);

                btnPurCreate.Enabled = true;
                txtPurNIC.Enabled = true;
                cmbPurPayType.Enabled = true;
                btn9Demo.Enabled = true;
                btn10Clear.Enabled = true;

                //update customer rating level when new invoice generate
                mcm.rating();
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
            con.Close();


            string q1= "select* from Delivery where InvoiceID ='"+so.InvoiceNo+"'";
            SqlCommand cmd1 = new SqlCommand(q,con);
            con.Open();
            try
            {
                SqlDataReader rd = cmd1.ExecuteReader();
                if (rd.HasRows);
                {

                }
            }catch(Exception ex)
            {
                throw ex;
            }
            con.Close();


            if (chkPurDel.Checked)
            {
                string q2 = "update Invoice set deliveryStatus='W' where InvoiceID='"+so.InvoiceNo+"'";
                SqlCommand cmd2 = new SqlCommand(q2,con);
                con.Open();
                try
                {
                    cmd2.ExecuteNonQuery();
                    
                }
                catch(Exception ex)
                {
                    throw ex;
                }
                con.Close();

            }
            else
            {
                string q2 = "update Invoice set deliveryStatus='NW' where InvoiceID='" + so.InvoiceNo + "'";
                SqlCommand cmd2 = new SqlCommand(q2, con);
                con.Open();
                try
                {
                    cmd2.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                con.Close();
            }


            cmbPurType.Enabled = false;
            cmbPurMake.Enabled = false;
            cmbPurModel.Enabled = false;
            txtPurSKey.Enabled = false;
            cmbPurIn.Enabled = false;
            txtPurNIC.Clear();
            cmbPurPayType.SelectedIndex = -1;
            lblPurName.Text = "";

            
            btnPurSub.Enabled = false;
            btnPurAdd.Enabled = false;
            btnPurDelete.Enabled = false;
            btn2Demo.Enabled = false;

            txtPurTot.Text = "";
            txtPurDis.Text = "";
            txtPurGrand.Text = "";




            if (chkPurDel.Checked)
            {
                de.Show();
            }
            
        }
        

        private void cmbSumType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSumType.SelectedIndex == 0)
            {
                string q = "select * from Invoice"; 
                dataGridView2.DataSource = mcm.loadGridView(q);
                
            }
            else if (cmbSumType.SelectedIndex == 1)
            {
                string q = "select * from ServiceInvoice";
                dataGridView2.DataSource = mcm.loadGridView(q);
            }
        }

        private void cmbPurModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            string in_ID = cmbPurIn.Text;

            FillComboIn();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            mcm.DeductInventory(cmbPurIn.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cmbSerJobID.SelectedIndex=-1;
            txtSerCusName.Text = "";
            txtSerEmail.Text = "";
            txtSerMobile.Text = "";
            
        }

        private void btn4Demo_Click(object sender, EventArgs e)
        {
            cmbSerJobID.Text = "1";
            txtSerCusName.Text = "Liyanage T.M.";
            txtSerEmail.Text = "tharakamadushanki@gmail.com";
            txtSerMobile.Text = "0717274849";
        }

        private void txtSerMobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
            if (txtSerMobile.Text.Length > 9 && ch != 8)
                e.Handled = true;
        }
        
    }
}
