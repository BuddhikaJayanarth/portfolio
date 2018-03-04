using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using megacoolnew.userObjects;
using megacoolnew;
using System.Data.SqlClient;
//using System.Text.RegularExpressions;


namespace megacoolnew
{
    public partial class Account : Form
    {
        public Account()
        {
            InitializeComponent();
        }

//Account form load
        private void Account_Load(object sender, EventArgs e)
        {
            ttb_Acc_ExpenditureID.Enabled = false;
            ExpenditureFillGrid();
            TaxFillGrid();
            
            

        }

//clear method for Text box
        public void Clear() {

//Clear Expenditure           
            //ttb_Acc_ExpenditureID.Clear();
            dtp_Acc_Expenditure.Value=DateTime.Now;
            cmb_Acc_Expenditure.SelectedIndex=-1;
            rtb_Acc_Description.Clear();
            txtb_acc_amount.Clear();
//Clear Tax
            dtp_Acc_Tax.Value=DateTime.Now;
            cmb_Tax.SelectedIndex=-1;
            ttb_Acc_Tax_TaxFileNo.Clear();
            txtb_Acc_Tax_Amount.Clear();


//Clear Budget Allocation
            mtb_Tax_Year.Clear();
            cmb_Acc_Month.Text="";
            ttb_TotalBudget.Clear();
            ttb_Payroll.Clear();
            ttb_Marketing.Clear();
            ttb_Insurance.Clear();
            ttb_Travel.Clear();
            ttb_Miselenius.Clear();
            ttb_Other.Clear();
            ttb_P.Clear();
            ttb_M.Clear();
            ttb_I.Clear();
            ttb_T.Clear();
            ttb_Mi.Clear();
            ttb_O.Clear();
            }

        //######### Clear ########

//Expenditure clear button click
        private void button4_Click(object sender, EventArgs e)
        {
            Clear();
        }

//Tax clear button Click
        private void btn_Acc_Tax_clear_Click_1(object sender, EventArgs e)
        {
            Clear();
        }

//Budget allocation clear button click
        private void btn_Acc_BudgetAl_Clear_Click(object sender, EventArgs e)
        {
           Clear();
        }


        //############# Demo Values ######


//Expenditure Demo button click
        private void btn_acc_demo_Click(object sender, EventArgs e)
        {   
            //ttb_Acc_ExpenditureID.Text="1";
            dtp_Acc_Expenditure.Text="2016.08.22";
            cmb_Acc_Expenditure.Text="Traveling cost";
            txtb_acc_amount.Text = "100000.00";
        }

//Tax Demo button click
        private void btn_Acc_Tax_Demo_Click(object sender, EventArgs e)
        {   
           
            dtp_Acc_Tax.Text = "2016.12.12";
            cmb_Tax.Text = "Income Tax";
            ttb_Acc_Tax_TaxFileNo.Text="4001";
            txtb_Acc_Tax_Amount.Text = "100000.00";
        }



//Budget Allocation Demo button click
        private void btn_Acc_BudgetAl_Demo_Click_2(object sender, EventArgs e)
        {
            mtb_Tax_Year.Text = "2012";
            cmb_Acc_Month.Text = "May";
            ttb_TotalBudget.Text = "100000.00";
            ttb_Payroll.Text= "40000.00";
            ttb_Marketing.Text="20000.00";
            ttb_Insurance.Text="10000.00";
            ttb_Travel.Text="8000.00";
            ttb_Miselenius.Text="10000.00";
            ttb_Other.Text="30000.00";
            ttb_P.Text="15";
            ttb_M.Text="30";
            ttb_I.Text="10";
            ttb_T.Text="15";
            ttb_Mi.Text="25";
            ttb_O.Text="5";
            
        }





        private void txtb_acc_amount_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void btn_Acc_BudgetAl_Demo_Click_1(object sender, EventArgs e)
        {

        }



        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void label28_Click(object sender, EventArgs e)
        {

        }
//#####################################    Expenditure Tab      ############################################################### 

//Add Expenditure button click
        private void btn_Acc_Expenditure_Add_Click_1(object sender, EventArgs e)
        {
             
            if (cmb_Acc_Expenditure.Text==""||txtb_acc_amount.Text== null )
            {
                MessageBox.Show("Please fill the all required feilds");
            }
            
            else
            {
             AccountObject objAccount = new AccountObject();
            
            //objAccount.ExpenditureID = Convert.ToInt32(ttb_Acc_ExpenditureID.Text.ToString());
            objAccount.Date = dtp_Acc_Expenditure.Value.Date;
            objAccount.Expenditure = cmb_Acc_Expenditure.Text;
            objAccount.Description = rtb_Acc_Description.Text;
            objAccount.Amount = Convert.ToDouble(txtb_acc_amount.Text.ToString());


            
            int currentMonth = DateTime.Today.Month;
            string current_Item = cmb_Acc_Expenditure.Text.ToString();
            int count=0;
            
            while( count < 1 )
            {
                if(currentMonth==1||currentMonth==2||currentMonth==3||currentMonth==4||currentMonth==5||currentMonth==6||currentMonth==7||currentMonth==8||currentMonth==9||currentMonth==10||currentMonth==11||currentMonth==12)
                {   
                    count++;
                    if(current_Item=="Water Bill" || current_Item=="Electricity Bill")
                    MessageBox.Show("You have already paid the Bill");
                }

            }   
           MessageBox.Show("REMINDER!!!!!  You have to paid the Water Bill & Electricity Bill for this month");
                
         //chechk whether text feilds are empty or not
           

                //show the confirmation dialog box
                DialogResult dr;
                dr = MessageBox.Show("Do you want to save the record", "Confirm", MessageBoxButtons.YesNo);
                
                if(dr==DialogResult.Yes){
                try
                {
                    
                    MegaCoolMethods mcm = new MegaCoolMethods();
                    bool result = mcm.AddNewExpenditure(objAccount);

                    if (result)
                    {
                        MessageBox.Show("Successfully Saved", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ExpenditureFillGrid();

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
            }
            
        }


//Expenditure Delete button click
        private void btn_Acc_Expenditure_Delete_Click(object sender, EventArgs e)
        {

            DialogResult dr;
            dr = MessageBox.Show("Do you want to delete the record", "Confirm", MessageBoxButtons.YesNo);

            if (dr == DialogResult.Yes)
            {
                MegaCoolMethods mc = new MegaCoolMethods();

                int ExpenditureID = Convert.ToInt16(ttb_Acc_ExpenditureID.Text) ;
                bool result = mc.DeleteExpenditure(ExpenditureID);

                ExpenditureFillGrid();

                MessageBox.Show("Successfully Deleted");

                Clear();


            }
        }

  //Expenditure Fillgrid        
        public void ExpenditureFillGrid()
        {

            
            SqlConnection con = ConnectionManager.GetConnection();

            if (con.State.ToString() == "Closed")
            {
                con.Open();
            }
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM dbo.Expenditure   ", con);

            DataTable dt = new DataTable();

            sda.Fill(dt);

            dgv_Expenditure_table.DataSource = dt;
        }

        private void dgv_Expenditure_table_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

           
                int expenditureID= Convert.ToInt32(((DataGridView)sender).Rows[e.RowIndex].Cells[0].Value);
                string date = ((DataGridView)sender).Rows[e.RowIndex].Cells[2].Value.ToString();
                string expenditure = ((DataGridView)sender).Rows[e.RowIndex].Cells[4].Value.ToString();
                string description = ((DataGridView)sender).Rows[e.RowIndex].Cells[2].Value.ToString();
                double amount = Convert.ToDouble(dgv_Expenditure_table.CurrentRow.Cells[3].Value.ToString());
               
               
                ttb_Acc_ExpenditureID.Text = expenditureID.ToString();
                dtp_Acc_Expenditure.Text = date;
                cmb_Acc_Expenditure.Text = expenditure;
                rtb_Acc_Description.Text = description;
                txtb_acc_amount.Text = amount.ToString();


       }

//#############################################      Tax Tab  ###############################################################
        
//Tax Add button click
        private void btn_Acc_Tax_Add_Click_1(object sender, EventArgs e)
        {
//chechk whether text feilds are empty or not
           if ( cmb_Tax.Text==""||ttb_Acc_Tax_TaxFileNo.Text==""||txtb_Acc_Tax_Amount.Text== null )
            {
                MessageBox.Show("Please fill the all required feilds");
            }
            else
            {
            TaxObject objTax = new TaxObject();
            objTax.Date = dtp_Acc_Tax.Value.Date;
            objTax.Description = cmb_Tax.Text;
            objTax.TaxFileNo=Convert.ToInt32(ttb_Acc_Tax_TaxFileNo.Text.ToString());
            objTax.Amount = Convert.ToDouble(txtb_Acc_Tax_Amount.Text.ToString());
          
            
            
                //show the confirmation dialog box
                DialogResult dr;
                dr = MessageBox.Show("Do you want to save the record", "Confirm", MessageBoxButtons.YesNo);
                if(dr==DialogResult.Yes){

        //        try
          //      {
                    
                    MegaCoolMethods mcm = new MegaCoolMethods();
                    bool result = mcm.AddTax (objTax);

                    if (result)
                    {
                        MessageBox.Show("Successfully Saved", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        TaxFillGrid();
                    }
                    else
                    {
                        MessageBox.Show("Unable to Save", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }       
         }

       private void btn_Acc_Tax_Delete_Click(object sender, EventArgs e)
        {

            DialogResult dr;
            dr = MessageBox.Show("Do you want to delete the record", "Confirm", MessageBoxButtons.YesNo);

            if (dr == DialogResult.Yes)
            {
                MegaCoolMethods mc = new MegaCoolMethods();

                int TaxFileNo = Convert.ToInt16(ttb_Acc_Tax_TaxFileNo.Text) ;
                bool result = mc.DeleteTax(TaxFileNo);

                TaxFillGrid();

                MessageBox.Show("Successfully Deleted");

                Clear();


            }
            

        }



//############################################    Budget Allocation Tab  ######################################################

//Budget allocation Add button click
        private void btn_Acc_BudgetAl_Add_Click(object sender, EventArgs e)
        {
         if (mtb_Tax_Year.Text==""||cmb_Acc_Month.Text==""||ttb_TotalBudget.Text==null||ttb_Payroll.Text== null|| ttb_Marketing.Text==null||ttb_Insurance.Text==null||ttb_Travel.Text==null||ttb_Miselenius.Text==null||ttb_Other.Text==null||ttb_P.Text==""||ttb_M.Text==""||ttb_I.Text==""||ttb_T.Text==""||ttb_Mi.Text==""||ttb_O.Text=="" )
            {
                MessageBox.Show("Please fill the all required feilds");
            }
            else
            {
            BudgetObject objBudget = new BudgetObject();

            objBudget.Year =  Convert.ToInt16(mtb_Tax_Year.Text);
            objBudget.Month = cmb_Acc_Month.Text;
            objBudget.TotalBudget = Convert.ToDouble(ttb_TotalBudget.Text);
            objBudget.Payroll=Convert.ToDouble(ttb_Payroll.Text);
            objBudget.Marketing=Convert.ToDouble(ttb_Marketing.Text);
            objBudget.Insurance=Convert.ToDouble(ttb_Insurance.Text);
            objBudget.Travel=Convert.ToDouble(ttb_Travel.Text);
            objBudget.Miselenius=Convert.ToDouble(ttb_Miselenius.Text);
            objBudget.Other=Convert.ToDouble(ttb_Other.Text);
            objBudget.Payroll_Pres=Convert.ToDouble(ttb_P.Text.Trim());
            objBudget.Marketing_pres=Convert.ToDouble(ttb_M.Text);
            objBudget.Insurance_pres=Convert.ToDouble(ttb_I.Text);
            objBudget.Travel_pres=Convert.ToDouble(ttb_T.Text);
            objBudget.Miselenius_pres=Convert.ToDouble(ttb_Mi.Text);
            objBudget.Other_pres=Convert.ToDouble(ttb_O.Text);
            
             
            
//getting in from text box
             double tot=objBudget.Payroll_Pres+objBudget.Marketing_pres+objBudget.Insurance_pres+objBudget.Travel_pres+objBudget.Miselenius_pres+objBudget.Other_pres;
 
             if(tot>100.00)
             {
		             MessageBox.Show("Error!!! You have Exide Precentage Level(100).");
                     ttb_T.BackColor = Color.Red;   
             }
            
             else if(tot<100.00)
            {
                MessageBox.Show("Error!!! 100 is not cover.");
            }

           

             
            //chechk whether text feilds are empty or not
           


                //show the confirmation dialog box
                DialogResult dr;
                dr = MessageBox.Show("Do you want to save the record", "Confirm", MessageBoxButtons.YesNo);
                if(dr==DialogResult.Yes){

                try
                {
                    MegaCoolMethods mcm = new MegaCoolMethods();
                    bool result = mcm.AddBudgetAllocation(objBudget);

                    if (result)
                    {
                        MessageBox.Show("Successfully Saved", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

                catch (Exception exx)
                {

                    throw exx;

                }
                }
            }       }

       


//Search budget click event
        private void btn_Acc_Search_Click(object sender, EventArgs e)
        {
            
            SqlConnection con = new SqlConnection(@"Data Source=NIPUNTHENNAKOON\NIPUN;Initial Catalog=MegaCoolEngineering;Integrated Security=True");
            SqlCommand command = new SqlCommand ("SELECT * FROM dbo.budget WHERE Year='"+mtb_Tax_Year.Text +"' ",con);
            con.Open();
            SqlDataReader read = command.ExecuteReader();
            
            while(read.Read())
            {
                    mtb_Tax_Year.Text = (read["Year"].ToString());
                    cmb_Acc_Month.Text = (read["Month"].ToString());
                    ttb_TotalBudget.Text = (read["Total_Budget"].ToString());
                    ttb_Payroll.Text = (read["Payroll_Amn"].ToString());
                    ttb_Marketing.Text=(read["Marketing_Amn"].ToString());
                    ttb_Insurance.Text=(read["Insurance_Amn"].ToString());
                    ttb_Travel.Text=(read["Travel_Amn"].ToString());
                    ttb_Miselenius.Text=(read["Miselenius_Amn"].ToString());
                    ttb_Other.Text=(read["Other_Amn"].ToString());
                    ttb_P.Text=(read["Payroll_Pres"].ToString());
                    ttb_M.Text=(read["Marketing_pres"].ToString());
                    ttb_I.Text=(read["Insurance_pres"].ToString());
                    ttb_T.Text=(read["Travel_pres"].ToString());
                    ttb_Mi.Text=(read["Miselenius_pres"].ToString());
                    ttb_O.Text=(read["Other_pres"].ToString());
            
            }
            read.Close();
            
            var re = command.ExecuteScalar();
            
            if (re ==null)
            {
                MessageBox.Show("This Budget Plan is not exit!");
                
            }    
        
        }

    


//Budget Allocation Update button click
        private void btn_Acc_BudgetAl_Update_Click(object sender, EventArgs e)
        {

            BudgetObject objBudget = new BudgetObject();

            objBudget.Year =  Convert.ToInt16(mtb_Tax_Year.Text);
            objBudget.Month = cmb_Acc_Month.Text;
            objBudget.TotalBudget = Convert.ToDouble(ttb_TotalBudget.Text.ToString());
            objBudget.Payroll=Convert.ToDouble(ttb_Payroll.Text);
            objBudget.Marketing=Convert.ToDouble(ttb_Marketing.Text);
            objBudget.Insurance=Convert.ToDouble(ttb_Insurance.Text);
            objBudget.Travel=Convert.ToDouble(ttb_Travel.Text);
            objBudget.Miselenius=Convert.ToDouble(ttb_Miselenius.Text);
            objBudget.Other=Convert.ToDouble(ttb_Other.Text);
            objBudget.Payroll_Pres=Convert.ToDouble(ttb_P.Text);
            objBudget.Marketing_pres=Convert.ToDouble(ttb_M.Text);
            objBudget.Insurance_pres=Convert.ToDouble(ttb_I.Text);
            objBudget.Travel_pres=Convert.ToDouble(ttb_T.Text);
            objBudget.Miselenius_pres=Convert.ToDouble(ttb_Mi.Text);
            objBudget.Other_pres=Convert.ToDouble(ttb_O.Text);
      
    SqlConnection con = new SqlConnection(@"Data Source=NIPUNTHENNAKOON\NIPUN;Initial Catalog=MegaCoolEngineering;Integrated Security=True");
    SqlCommand cmd = new SqlCommand("UPDATE dbo.budget SET  [Total_Budget] = @totalBudget, [payroll_Amn] = @payroll_Amn, [marketing_Amn] = @marketing_Amn, [insurance_Amn] = @insurance_Amn, [travel_Amn] = @travel_Amn, [other_Amn] = @other_Amn,[payroll_Pres]=@payroll_Pres,[marketing_pres]=@marketing_pres,[insurance_pres]=@insurance_pres,[travel_pres]=@travel_pres,[miselenius_pres]=@miselenius_pres,[other_pres]=@other_pres  WHERE [year]= @year   " , con);
    //con.Open();

    cmd.Parameters.AddWithValue("@year",  mtb_Tax_Year.Text );
    cmd.Parameters.AddWithValue("@month",  cmb_Acc_Month.Text );
    cmd.Parameters.AddWithValue("@totalBudget", ttb_TotalBudget.Text);
    cmd.Parameters.AddWithValue("@payroll_Amn",  ttb_Payroll.Text);
    cmd.Parameters.AddWithValue("@marketing_Amn", ttb_Marketing.Text);
    cmd.Parameters.AddWithValue("@insurance_Amn", ttb_Insurance.Text);
    cmd.Parameters.AddWithValue("@travel_Amn",  ttb_Travel.Text);
    cmd.Parameters.AddWithValue("@miselenius_Amn", ttb_Miselenius.Text);
    cmd.Parameters.AddWithValue("@other_Amn", ttb_Other.Text);
    cmd.Parameters.AddWithValue("@payroll_Pres", ttb_P.Text);
    cmd.Parameters.AddWithValue("@marketing_pres", ttb_M.Text);
    cmd.Parameters.AddWithValue("@insurance_pres", ttb_I.Text);
    cmd.Parameters.AddWithValue("@travel_pres", ttb_T.Text);
    cmd.Parameters.AddWithValue("@miselenius_pres", ttb_Mi.Text);
    cmd.Parameters.AddWithValue("@other_pres", ttb_O.Text);
    cmd.Connection.Open();
    

        try
        {
            cmd.ExecuteNonQuery();
            MessageBox.Show("Update Succesfully");
        }
        catch (Exception ex)
        {
            //throw new Exception("Error " + ex.Message);
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        con.Close(); 
        }

        private void dgv_Expenditure_table_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

//Tax Fillgrid
        public void TaxFillGrid()
        {

            
            SqlConnection con = ConnectionManager.GetConnection();

            if (con.State.ToString() == "Closed")
            {
                con.Open();
            }
            SqlDataAdapter sda = new SqlDataAdapter("SELECT TaxFileNo,Date,Description,Amount FROM dbo.Taxes   ", con);

            DataTable dt = new DataTable();

            sda.Fill(dt);

            dgv_Acc_Tax_Table.DataSource = dt;
        }

        private void dgv_Acc_Tax_Table_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
                string date= ((DataGridView)sender).Rows[e.RowIndex].Cells[1].Value.ToString();
                string description = ((DataGridView)sender).Rows[e.RowIndex].Cells[2].Value.ToString();
                string taxFileNo = ((DataGridView)sender).Rows[e.RowIndex].Cells[0].Value.ToString();
                double amount = Convert.ToDouble(dgv_Acc_Tax_Table.CurrentRow.Cells[3].Value.ToString());
               
               
                dtp_Acc_Tax.Text = date;
                cmb_Tax.Text = description;
                ttb_Acc_Tax_TaxFileNo.Text = taxFileNo.ToString();
                txtb_Acc_Tax_Amount.Text = amount.ToString();
        }

       

//Budget validation
        private void txtb_acc_amount_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            
            if (!Char.IsDigit(ch) && ch != 8 && ch != '.' )
            {
                e.Handled = true;
                MessageBox.Show("Please Enter valid Amount!");
            }
            if (e.KeyChar == '.' && txtb_acc_amount.Text.IndexOf('.') > -1)
            {
                e.Handled = true;
                MessageBox.Show("Please Enter valid Amount!");
            }
        }

        private void ttb_Acc_Tax_TaxFileNo_KeyPress(object sender, KeyPressEventArgs e)
        {
             char ch = e.KeyChar;
            
            if (!Char.IsDigit(ch) && ch != 8 && ch != '.' )
            {
                e.Handled = true;
                
            }
            
        }

        private void txtb_Acc_Tax_Amount_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            
            if (!Char.IsDigit(ch) && ch != 8 && ch != '.' )
            {
                e.Handled = true;
                MessageBox.Show("Please Enter valid Amount!");
            }
            if (e.KeyChar == '.' && txtb_Acc_Tax_Amount.Text.IndexOf('.') > -1)
            {
                e.Handled = true;
                MessageBox.Show("Please Enter valid Amount!");
            }
        }

        private void ttb_TotalBudget_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            
            if (!Char.IsDigit(ch) && ch != 8 && ch != '.' )
            {
                e.Handled = true;
                MessageBox.Show("Please Enter valid Amount!");
            }
            if (e.KeyChar == '.' && ttb_TotalBudget.Text.IndexOf('.') > -1)
            {
                e.Handled = true;
                MessageBox.Show("Please Enter valid Amount!");
            }
        }

        private void ttb_Payroll_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            
            if (!Char.IsDigit(ch) && ch != 8 && ch != '.' )
            {
                e.Handled = true;
                MessageBox.Show("Please Enter valid Amount!");
            }
            if (e.KeyChar == '.' && ttb_Payroll.Text.IndexOf('.') > -1)
            {
                e.Handled = true;
                MessageBox.Show("Please Enter valid Amount!");
            }
        }

        private void ttb_Marketing_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            
            if (!Char.IsDigit(ch) && ch != 8 && ch != '.' )
            {
                e.Handled = true;
                MessageBox.Show("Please Enter valid Amount!");
            }
            if (e.KeyChar == '.' && ttb_Marketing.Text.IndexOf('.') > -1)
            {
                e.Handled = true;
                MessageBox.Show("Please Enter valid Amount!");
            }
        }

        private void ttb_Insurance_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            
            if (!Char.IsDigit(ch) && ch != 8 && ch != '.' )
            {
                e.Handled = true;
                MessageBox.Show("Please Enter valid Amount!");
            }
            if (e.KeyChar == '.' && ttb_Insurance.Text.IndexOf('.') > -1)
            {
                e.Handled = true;
                MessageBox.Show("Please Enter valid Amount!");
            }
        }

        private void ttb_Travel_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            
            if (!Char.IsDigit(ch) && ch != 8 && ch != '.' )
            {
                e.Handled = true;
                MessageBox.Show("Please Enter valid Amount!");
            }
            if (e.KeyChar == '.' && ttb_Travel.Text.IndexOf('.') > -1)
            {
                e.Handled = true;
                MessageBox.Show("Please Enter valid Amount!");
            }
        
        }

        private void ttb_Miselenius_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            
            if (!Char.IsDigit(ch) && ch != 8 && ch != '.' )
            {
                e.Handled = true;
                MessageBox.Show("Please Enter valid Amount!");
            }
            if (e.KeyChar == '.' && ttb_Miselenius.Text.IndexOf('.') > -1)
            {
                e.Handled = true;
                MessageBox.Show("Please Enter valid Amount!");
            }
        }

        private void ttb_Other_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            
            if (!Char.IsDigit(ch) && ch != 8 && ch != '.' )
            {
                e.Handled = true;
                MessageBox.Show("Please Enter valid Amount!");
            }
            if (e.KeyChar == '.' && ttb_Other.Text.IndexOf('.') > -1)
            {
                e.Handled = true;
                MessageBox.Show("Please Enter valid Amount!");
            }
        
        }

        private void ttb_P_KeyPress(object sender, KeyPressEventArgs e)
        {
             char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 2)
            {
                e.Handled = true;
            }
            if (ttb_P.Text.Length >= 1&& ch != 2)
                e.Handled = true;
        }

        private void ttb_M_KeyPress(object sender, KeyPressEventArgs e)
        {
                         char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 2)
            {
                e.Handled = true;
            }
            if (ttb_M.Text.Length > 1&& ch != 2)
                e.Handled = true;
        }

        private void ttb_I_KeyPress(object sender, KeyPressEventArgs e)
        {
                         char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 2)
            {
                e.Handled = true;
            }
            if (ttb_I.Text.Length > 1&& ch != 2)
                e.Handled = true;
        }

        private void ttb_T_KeyPress(object sender, KeyPressEventArgs e)
        {
                         char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 2)
            {
                e.Handled = true;
            }
            if (ttb_T.Text.Length > 1&& ch != 2)
                e.Handled = true;
        }

        private void ttb_Mi_KeyPress(object sender, KeyPressEventArgs e)
        {
                         char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 2)
            {
                e.Handled = true;
            }
            if (ttb_Mi.Text.Length > 1&& ch != 2)
                e.Handled = true;
        }

        private void ttb_O_KeyPress(object sender, KeyPressEventArgs e)
        {
                         char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 2)
            {
                e.Handled = true;
            }
            if (ttb_O.Text.Length > 1&& ch != 2)
                e.Handled = true;
        }

        //making budget plan
       
        private void btn_Budgetplan_Click(object sender, EventArgs e)
        {
            
            BudgetObject objBudget = new BudgetObject();
            
             if (String.IsNullOrEmpty(ttb_TotalBudget.Text))
            {
                    MessageBox.Show("Please Total Budget.");
            }

            objBudget.TotalBudget = Convert.ToDouble(ttb_TotalBudget.Text);
            objBudget.Payroll_Pres=Convert.ToDouble(ttb_P.Text);
            objBudget.Marketing_pres=Convert.ToDouble(ttb_M.Text);
            objBudget.Insurance_pres=Convert.ToDouble(ttb_I.Text);
            objBudget.Travel_pres=Convert.ToDouble(ttb_I.Text);
            objBudget.Miselenius_pres=Convert.ToDouble(ttb_Mi.Text);
            objBudget.Other_pres=Convert.ToDouble(ttb_O.Text);
            
            //double c;
            //c = Math.Round(c, 2);
            
            double payroll;
            //payroll=Math.Round(payroll,2);
            double Marketing;
            double Insurance;
            double Travel;
            double Misallaneous;
            double Other;

            double tot=objBudget.Payroll_Pres+objBudget.Marketing_pres+objBudget.Insurance_pres+objBudget.Travel_pres+objBudget.Miselenius_pres+objBudget.Other_pres;
            tot=Math.Round(tot,2);

             if(tot>100.00)
             {
		             MessageBox.Show("Error!!! You have Exide Precentage Level(100).");
                     ttb_T.BackColor = Color.Red;   
             }
            
             //else if(tot<100.00)
            //{
                //MessageBox.Show("Error!!! 100 is not cover.");
            //}
                        

            
                else
                    {

                        
                        
                        payroll=(objBudget.TotalBudget *objBudget.Payroll_Pres)/100.00;
                        ttb_Payroll.Text=payroll.ToString();

                        Marketing=((objBudget.TotalBudget-payroll) * objBudget.Marketing_pres)/100.00;
                        ttb_Marketing.Text=Marketing.ToString();

                        double tot1= payroll + Marketing;
                        tot1=Math.Round(tot1,2);
                        

                        Insurance=((objBudget.TotalBudget-tot1) * objBudget.Insurance_pres)/100.00;
                        ttb_Insurance.Text=Insurance.ToString();
                        
                        double tot2=payroll + Marketing+Insurance;
                        tot2=Math.Round(tot2,2);

                        Travel=((objBudget.TotalBudget-tot2) * objBudget.Insurance_pres)/100.00;
                        ttb_Travel.Text=Travel.ToString();
                        
                        double tot3 =payroll + Marketing+Insurance+Travel;
                        tot3=Math.Round(tot3,2);
                        
                        Misallaneous=((objBudget.TotalBudget-tot3) * objBudget.Miselenius_pres)/100.00;
                        ttb_Miselenius.Text=Misallaneous.ToString();

                        double tot4=payroll + Marketing+Insurance+Travel+Misallaneous;
                        tot4=Math.Round(tot4,2);

                        Other=((objBudget.TotalBudget-tot4) * objBudget.Other_pres)/100.00;
                        ttb_Other.Text=Other.ToString();
                    }

            }


//###################################################### Profit Tab ###########################################################

     
        private void btn_Profit_Select_Click(object sender, EventArgs e)
        {
        
                        SqlConnection conn = ConnectionManager.GetConnection();
                        DateTime dt = this.dtp_Gross.Value.Date;
                        DateTime dt2 = this.dateTimePicker6.Value.Date;
                        ProfitObject objProfit = new ProfitObject();
                        objProfit.MonthGross = dtp_Gross.Value.ToString("MMMM");
                        txtb_GMonth.Text=objProfit.MonthGross.ToString();
                
                if(dtp_Gross.Text==""||dateTimePicker6.Text=="")
                {
                     MessageBox.Show("Please Select the date range that the profit you want.");
                }

                else{
///////////////////////////////////////////////////////////////////////get Gross profit details
 
/////////////////////////////////////////Product sales (Sales chathu)  
            if (conn.State.ToString() == "Closed")
            {
                conn.Open();
            }

            SqlCommand cmd1 = new SqlCommand("SELECT SUM (Amount) FROM dbo.Invoice  WHERE Date BETWEEN '" + dt.ToShortDateString() + "' AND '" + dt2.ToShortDateString() + "'  ", conn);
            SqlDataReader rd1 = cmd1.ExecuteReader();
            while (rd1.Read()) 
            {
                txtb_Profit_Sales.Text = rd1.GetValue(0).ToString();
                
                
            }
            rd1.Close();
            conn.Close();         
/////////////////////////////////////////Order cost (From inventory pooja)
            if (conn.State.ToString() == "Closed")
            {
                conn.Open();
            }

            SqlCommand cmd2 = new SqlCommand("SELECT SUM (PaidAmount) FROM dbo.SupplierPayment  WHERE Date BETWEEN '" + dt.ToShortDateString() + "' AND '" + dt2.ToShortDateString() + "'  ", conn);
            SqlDataReader rd2 = cmd2.ExecuteReader();
            while (rd2.Read()) 
            {
                txtb_Gross_OrderCost.Text = rd2.GetValue(0).ToString();
                
                
            }
            rd2.Close();
            conn.Close();
////////////////////////////////////////// Repair Services (Nipun)
            if (conn.State.ToString() == "Closed")
            {
                conn.Open();
            }

            SqlCommand cmd3 = new SqlCommand("SELECT SUM (GrandTotal) FROM dbo.ServiceInvoice  WHERE Date BETWEEN '" + dt.ToShortDateString() + "' AND '" + dt2.ToShortDateString() + "' ", conn);
            SqlDataReader rd3 = cmd3.ExecuteReader();
            while (rd3.Read()) 
            {
                txtb_Profit_Repair.Text = rd3.GetValue(0).ToString();
                
                
            }
            rd3.Close();
            conn.Close();
////////////////////////////////////////////Offsite Servise (Buddih)
            if (conn.State.ToString() == "Closed")
            {
                conn.Open();
            }

            SqlCommand cmd4 = new SqlCommand("SELECT SUM (PaidAmount) FROM dbo.SupplierPayment  WHERE Date BETWEEN '" + dt.ToShortDateString() + "' AND '" + dt2.ToShortDateString() + "'  ", conn);
            SqlDataReader rd4 = cmd4.ExecuteReader();
            while (rd4.Read()) 
            {
                txtb_Offsite.Text = rd4.GetValue(0).ToString();
                
                
            }
            rd4.Close();
            conn.Close();
//////////////////////////////////////////////Delivery servise(Nadi)
            if (conn.State.ToString() == "Closed")
            {
                conn.Open();
            }

            SqlCommand cmd5 = new SqlCommand("SELECT SUM (Cost) FROM dbo.Delivery  WHERE DiliveryDate BETWEEN '" + dt.ToShortDateString() + "' AND '" + dt2.ToShortDateString() + "' ", conn);
            SqlDataReader rd5 = cmd5.ExecuteReader();
            while (rd5.Read()) 
            {
                txtb_Delivery.Text = rd5.GetValue(0).ToString();
                
                
            }
            rd5.Close();
            conn.Close();}

///Gross Profit calculation

                if(dtp_Gross.Text==""||dateTimePicker6.Text=="")
                {
                     MessageBox.Show("Please Select the date range that the profit you want.");
                }

                else{ 
            
            double Product_Sales = Convert.ToDouble(txtb_Profit_Sales.Text);
            double Order_cost= Convert.ToDouble(txtb_Gross_OrderCost.Text);
            double Repair_Servise= Convert.ToDouble(txtb_Profit_Repair.Text);
            double Offsite_Servise= Convert.ToDouble(txtb_Offsite.Text);
            double Delivery_Servise= Convert.ToDouble(txtb_Delivery.Text);

double Total_income = Product_Sales + Order_cost + Repair_Servise + Offsite_Servise + Delivery_Servise;
txtb_Profit_Income.Text = Total_income.ToString();

double Gross_Profit = Total_income - Order_cost; 
txtb_GrossProfit.Text = Gross_Profit.ToString();}
       

        }

 ///////////////////////////////////////////////////////////////////get Total Expenses  
        private void btn_NetSelect_Click(object sender, EventArgs e)
        {
            SqlConnection conn = ConnectionManager.GetConnection();
            DateTime dt = this.dtp_NetProfit.Value.Date;
            DateTime dt2 = this.dateTimePicker2.Value.Date;
            ProfitObject objProfit = new ProfitObject();
            objProfit.Month =dtp_NetProfit.Value.ToString("MMMM");
            txtb_NetMonth.Text=objProfit.Month.ToString();

/////////////////////////////////////////Payroll
            if (conn.State.ToString() == "Closed")
            {
                conn.Open();
            }
            

            SqlCommand cmd1 = new SqlCommand("SELECT SUM (Salary) FROM dbo.Paid_Salary WHERE Date BETWEEN '" + dt.ToShortDateString() + "' AND '" + dt2.ToShortDateString() + "' ", conn);
            SqlDataReader rd1 = cmd1.ExecuteReader();
            while (rd1.Read()) 
            {
                txtb_Profit_Payroll.Text = rd1.GetValue(0).ToString();
                
                
            }
            rd1.Close();
            conn.Close();
////////////////////////////////////////Marketing            
            if (conn.State.ToString() == "Closed")
            {
                conn.Open();
            }

                        
            SqlCommand cmd2 = new SqlCommand("SELECT SUM (Amount) FROM dbo.Expenditure WHERE Date BETWEEN '" + dt.ToShortDateString() + "' AND '" + dt2.ToShortDateString() + "' AND Category= 'Marketing cost' ", conn);
            SqlDataReader rd2 = cmd2.ExecuteReader();
            while (rd2.Read()) 
            {
                txtb_Profit_Marketing.Text = rd2.GetValue(0).ToString();
            }
            rd2.Close();
            conn.Close();
//////////////////////////////////////////Insurance
            if (conn.State.ToString() == "Closed")
            {
                conn.Open();
            }


            SqlCommand cmd3 = new SqlCommand("SELECT SUM (Amount) FROM dbo.Expenditure WHERE Date BETWEEN '" + dt.ToShortDateString() + "' AND '" + dt2.ToShortDateString() + "' AND  Category= 'Insurance cost'", conn);
            SqlDataReader rd3 = cmd3.ExecuteReader();
            while (rd3.Read()) 
            {
                txtb_Profit_Insurance.Text = rd3.GetValue(0).ToString();
            }
            rd3.Close();
            conn.Close();
//////////////////////////////////////////////Travel
            if (conn.State.ToString() == "Closed")
            {
                conn.Open();
            }


            SqlCommand cmd4 = new SqlCommand("SELECT SUM (Amount) FROM dbo.Expenditure WHERE Date BETWEEN '" + dt.ToShortDateString() + "' AND '" + dt2.ToShortDateString() + "' AND Category= 'Traveling cost'", conn);
            SqlDataReader rd4 = cmd4.ExecuteReader();
            while (rd4.Read()) 
            {
                txtb_Profit_Travel.Text = rd4.GetValue(0).ToString();
            }
            rd4.Close();
            conn.Close();
///////////////////////////////////////////////Misalenious
            if (conn.State.ToString() == "Closed")
            {
                conn.Open();
            }
            

            SqlCommand cmd5= new SqlCommand("SELECT SUM (Amount) FROM dbo.Expenditure WHERE Date BETWEEN '" + dt.ToShortDateString() + "' AND '" + dt2.ToShortDateString() + "' AND Category= 'Miselenius cost'", conn);
            SqlDataReader rd5 = cmd5.ExecuteReader();
            while (rd5.Read()) 
            {
                txtb_Profit_Misallaneous.Text = rd5.GetValue(0).ToString();
            }
            rd5.Close();
            conn.Close();
///////////////////////////////////////////Purchase bill
            if (conn.State.ToString() == "Closed")
            {
                conn.Open();
            }
            

            SqlCommand cmd6 = new SqlCommand("SELECT SUM (Amount) FROM dbo.Expenditure WHERE Date BETWEEN '" + dt.ToShortDateString() + "' AND '" + dt2.ToShortDateString() + "' AND Category= 'Water Bill' ", conn);
            SqlDataReader rd6 = cmd6.ExecuteReader();
            while (rd6.Read()) 
            {
                txtb_Profit_Bill.Text = rd6.GetValue(0).ToString();
            }
            rd6.Close();
            conn.Close();
        
            
            
            
///////////////////////////////////////////Tax
            if (conn.State.ToString() == "Closed")
            {
                conn.Open();
            }
            


            SqlCommand cmd7 = new SqlCommand("SELECT SUM (Amount) FROM dbo.Taxes WHERE Date BETWEEN '" + dt.ToShortDateString() + "' AND '" + dt2.ToShortDateString() + "'", conn);
            SqlDataReader rd7 = cmd7.ExecuteReader();
            while (rd7.Read()) 
            {
                txtb_Profit_Tax.Text = rd7.GetValue(0).ToString();
            }
            rd7.Close();
            conn.Close();
//////////////////////////////////////////other
            if (conn.State.ToString() == "Closed")
            {
                conn.Open();
            }
            
;

            SqlCommand cmd8 = new SqlCommand("SELECT SUM (Amount) FROM dbo.Expenditure  WHERE Date BETWEEN '" + dt.ToShortDateString() + "' AND '" + dt2.ToShortDateString() + "' AND Category= 'Other'", conn);
            SqlDataReader rd8 = cmd8.ExecuteReader();
            while (rd8.Read()) 
            {
                txtb_Profit_other.Text = rd8.GetValue(0).ToString();
            }
            rd8.Close();
            conn.Close();

/////////////////////////////////////////Calculation Total Expenses

            double payroll  = Convert.ToDouble(txtb_Profit_Payroll.Text);
            double marketing= Convert.ToDouble(txtb_Profit_Marketing.Text);
            double insurance= Convert.ToDouble(txtb_Profit_Insurance.Text);
            double travel   = Convert.ToDouble(txtb_Profit_Travel.Text);
            double Misallaneous=Convert.ToDouble(txtb_Profit_Misallaneous.Text);
            double Bill     = Convert.ToDouble(txtb_Profit_Bill.Text);
            double Tax      = Convert.ToDouble(txtb_Profit_Tax.Text); 
            double Other    = Convert.ToDouble(txtb_Profit_other.Text);

            double Total_Expenses = payroll + marketing + insurance + travel + Misallaneous + Bill  + Tax + Other; 
            txtb_Profit_TotalExpences.Text = Total_Expenses.ToString();

            //Total_Expenses=Math.Round(Total_Expenses,2);

            
            
            
            objProfit.GrossProfit=Convert.ToDouble(txtb_GrossProfit.Text);
            double Net_Profit = ((objProfit.GrossProfit)-(Total_Expenses));
            txtb_NetProfit.Text = Net_Profit.ToString();
        }

////////Save Net Profit
        private void btn_SaveNetProfit_Click(object sender, EventArgs e)
        {
            if (txtb_Profit_Payroll == null || txtb_Profit_Marketing == null || txtb_Profit_Insurance == null || ttb_Insurance.Text == null || txtb_Profit_Travel.Text == null || txtb_Profit_Misallaneous == null || txtb_Profit_Bill == null || txtb_Profit_Tax == null || txtb_Profit_other == null || txtb_Profit_TotalExpences==null)
            {
                MessageBox.Show("Please fill the all required feilds");
            }
            else
            {
            ProfitObject objProfit = new ProfitObject();
            
            objProfit.YearNet =Convert.ToInt32( dtp_NetProfit.Value.ToString("yyyy"));
            objProfit.Month = dtp_NetProfit.Value.ToString("MMMM");
            objProfit.DateN = dtp_NetProfit.Value;
            objProfit.Payroll=Convert.ToDouble(txtb_Profit_Payroll.Text);
            objProfit.Marketing=Convert.ToDouble(txtb_Profit_Marketing.Text);
            objProfit.Insurance=Convert.ToDouble(txtb_Profit_Insurance.Text);
            objProfit.Travel=Convert.ToDouble(txtb_Profit_Travel.Text);
            objProfit.Miselenius=Convert.ToDouble(txtb_Profit_Misallaneous.Text);
            objProfit.Bill=Convert.ToDouble(txtb_Profit_Bill.Text);
            objProfit.Tax=Convert.ToDouble(txtb_Profit_Tax.Text);
            objProfit.Other=Convert.ToDouble(txtb_Profit_other.Text);
            objProfit.Net_Profit=Convert.ToDouble(txtb_NetProfit.Text);
            objProfit.Tot_Ex = Convert.ToDouble(txtb_Profit_TotalExpences.Text); 
             
            //chechk whether text feilds are empty or not
           


                //show the confirmation dialog box
                DialogResult dr;
                dr = MessageBox.Show("Do you want to save the record", "Confirm", MessageBoxButtons.YesNo);
                if(dr==DialogResult.Yes){

                try
                {
                    MegaCoolMethods mcm = new MegaCoolMethods();
                    bool result = mcm.SaveNetProfit(objProfit);

                    if (result)
                    {
                        MessageBox.Show("Successfully Saved", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

                catch (Exception exx)
                {

                    throw exx;

                }
                }
            }       
        }
///////////Save Gross
        private void btn_Save_GrossProfit_Click(object sender, EventArgs e)
        {

            if (dtp_Gross.Text==""||dateTimePicker6.Text==""||txtb_GMonth.Text==null||txtb_Profit_Sales.Text==null||txtb_Gross_OrderCost.Text== null|| txtb_Profit_Repair.Text==null||txtb_Offsite.Text==null||txtb_Delivery.Text==null||txtb_Profit_Income.Text==null||txtb_GrossProfit.Text==null )
            {
                MessageBox.Show("Please fill the all required feilds");
            }
            else
            {
            ProfitObject objProfit = new ProfitObject();
            
            objProfit.YearGross = Convert.ToInt32(dtp_Gross.Value.ToString("yyyy"));
            objProfit.DateG = dtp_Gross.Value;
            objProfit.MonthGross = dtp_Gross.Value.ToString("MMMM");
            objProfit.ProductSales=Convert.ToDouble(txtb_Profit_Sales.Text);
            objProfit.OrderCost=Convert.ToDouble(txtb_Gross_OrderCost.Text);
            objProfit.RepairServices=Convert.ToDouble(txtb_Profit_Repair.Text);
            objProfit.OffsiteServices=Convert.ToDouble(txtb_Offsite.Text);
            objProfit.DeliveryServices=Convert.ToDouble(txtb_Delivery.Text);
            objProfit.TotalIncome=Convert.ToDouble(txtb_Profit_Income.Text);
            objProfit.GrossProfit=Convert.ToDouble(txtb_GrossProfit.Text);
             
             
            //chechk whether text feilds are empty or not
           


                //show the confirmation dialog box
                DialogResult dr;
                dr = MessageBox.Show("Do you want to save the record", "Confirm", MessageBoxButtons.YesNo);
                if(dr==DialogResult.Yes){

                try
                {
                    MegaCoolMethods mcm = new MegaCoolMethods();
                    bool result = mcm.SaveGrossProfit(objProfit);

                    if (result)
                    {
                        MessageBox.Show("Successfully Saved", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

                catch (Exception exx)
                {

                    throw exx;

                }
                }
            }

        }

        private void btn_Calculate_Annual_profit_Click(object sender, EventArgs e)
        {
            ProfitObject objProfit = new ProfitObject();
            SqlConnection conn = ConnectionManager.GetConnection();
            DateTime dt = this.dtc_Ann1.Value.Date;
            DateTime dt2 = this.dtp_Ann2.Value.Date;
            objProfit.Year =Convert.ToInt32( dtc_Ann1.Value.ToString("yyyy"));
            txt_Anu_year.Text=objProfit.Year.ToString();

/////////////////////////////////////////tot product
            if (conn.State.ToString() == "Closed")
            {
                conn.Open();
            }
            

            SqlCommand cmd1 = new SqlCommand("SELECT SUM (Product_Sales) FROM dbo.GrossProfit WHERE Date BETWEEN '" + dt.ToShortDateString() + "' AND '" + dt2.ToShortDateString() + "' ", conn);
            SqlDataReader rd1 = cmd1.ExecuteReader();
            while (rd1.Read()) 
            {
                txtb_Anu_Product.Text = rd1.GetValue(0).ToString();
                
                
            }
            rd1.Close();
            conn.Close();
////////////////////////////tot servises
 if (conn.State.ToString() == "Closed")
            {
                conn.Open();
            }
            

            SqlCommand cmd2 = new SqlCommand("SELECT SUM (Repair_Service) FROM dbo.GrossProfit WHERE Date BETWEEN '" + dt.ToShortDateString() + "' AND '" + dt2.ToShortDateString() + "' ", conn);
            SqlDataReader rd2 = cmd2.ExecuteReader();
            while (rd2.Read()) 
            {
                txtb_Anu_Services.Text = rd2.GetValue(0).ToString();
                
                
            }
            rd2.Close();
            conn.Close();
/////////////////////////////////tit revenue
if (conn.State.ToString() == "Closed")
            {
                conn.Open();
            }
            

            SqlCommand cmd3 = new SqlCommand("SELECT SUM (Total_Revenu) FROM dbo.GrossProfit WHERE Date BETWEEN '" + dt.ToShortDateString() + "' AND '" + dt2.ToShortDateString() + "' ", conn);
            SqlDataReader rd3 = cmd3.ExecuteReader();
            while (rd3.Read()) 
            {
                txtb_AnnuIncome.Text = rd3.GetValue(0).ToString();
                
                
            }
            rd3.Close();
            conn.Close();
////////////////////////////////////tot expenses
if (conn.State.ToString() == "Closed")
            {
                conn.Open();
            }
            

            SqlCommand cmd4 = new SqlCommand("SELECT SUM (Total_Expes) FROM dbo.NetProfit WHERE Date BETWEEN '" + dt.ToShortDateString() + "' AND '" + dt2.ToShortDateString() + "' ", conn);
            SqlDataReader rd4 = cmd4.ExecuteReader();
            while (rd4.Read()) 
            {
                txtb_Anu_Ex.Text = rd4.GetValue(0).ToString();
                
                
            }
            rd1.Close();
            conn.Close();
////////////////////////////////tot gross profit
if (conn.State.ToString() == "Closed")
            {
                conn.Open();
            }
            

            SqlCommand cmd5 = new SqlCommand("SELECT SUM (Gross_Profit) FROM dbo.GrossProfit WHERE Date BETWEEN '" + dt.ToShortDateString() + "' AND '" + dt2.ToShortDateString() + "' ", conn);
            SqlDataReader rd5 = cmd5.ExecuteReader();
            while (rd5.Read()) 
            {
                txtb_Anu_Gross.Text = rd5.GetValue(0).ToString();
                
                
            }
            rd5.Close();
            conn.Close();
/////////////////////////////tot net profit
if (conn.State.ToString() == "Closed")
            {
                conn.Open();
            }
            

            SqlCommand cmd6 = new SqlCommand("SELECT SUM (Net_profit) FROM dbo.NetProfit WHERE Date BETWEEN '" + dt.ToShortDateString() + "' AND '" + dt2.ToShortDateString() + "' ", conn);
            SqlDataReader rd6 = cmd6.ExecuteReader();
            while (rd6.Read()) 
            {
                txtb_Annu_net.Text = rd6.GetValue(0).ToString();
                
                
            }
            rd6.Close();
            conn.Close();

    
        }

        private void btn_Save_AnnualProfit_Click(object sender, EventArgs e)
        {
            if (txt_Anu_year.Text==null||txtb_Anu_Product.Text== null|| txtb_Anu_Services.Text==null||txtb_AnnuIncome.Text==null||txtb_Anu_Ex.Text==null||txtb_Anu_Gross.Text==null||txtb_Annu_net.Text==null )
            {
                MessageBox.Show("Please fill the all required feilds");
            }
            else
            {
            ProfitObject objProfit = new ProfitObject();
            
            objProfit.Year=Convert.ToInt32(txt_Anu_year.Text);
            objProfit.TotalProduct=Convert.ToDouble(txtb_Anu_Product.Text);
            objProfit.TotalService=Convert.ToDouble(txtb_Anu_Services.Text);
            objProfit.TotalIncome1=Convert.ToDouble(txtb_AnnuIncome.Text);
            objProfit.TotalExpences=Convert.ToDouble(txtb_Anu_Ex.Text);
            objProfit.AnnualGrossProfit=Convert.ToDouble(txtb_Anu_Gross.Text);
            objProfit.AnnualNetProfit=Convert.ToDouble(txtb_Annu_net.Text);
             
             
            //chechk whether text feilds are empty or not
           


                //show the confirmation dialog box
                DialogResult dr;
                dr = MessageBox.Show("Do you want to save the record", "Confirm", MessageBoxButtons.YesNo);
                if(dr==DialogResult.Yes){

                try
                {
                    MegaCoolMethods mcm = new MegaCoolMethods();
                    bool result = mcm.SaveAnnualProfit(objProfit);

                    if (result)
                    {
                        MessageBox.Show("Successfully Saved", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

                catch (Exception exx)
                {

                    throw exx;

                }
                }
        }




}

        private void button6_Click(object sender, EventArgs e)
        {
            dtp_Gross.Text = "2016.08.01";
            dateTimePicker6.Text = "2016.08.31";
        }

        private void btn_NetDemo_Click(object sender, EventArgs e)
        {
            dtp_NetProfit.Text = "2016.08.01";
            dateTimePicker2.Text = "2016.08.31";
        }

        private void btn_AnnuDEmo_Click(object sender, EventArgs e)
        {
            dtc_Ann1.Text = "2016.01.01";
            dtp_Ann2.Text = "2016.12.31";

        }

        private void btn_Gross_Cear_Click(object sender, EventArgs e)
        {
            dtp_Gross.Value = DateTime.Now;
            dateTimePicker6.Value = DateTime.Now;
            txtb_GMonth.Clear();
            txtb_Gross_OrderCost.Clear();
            txtb_Profit_Repair.Clear();
            txtb_Offsite.Clear();
            txtb_Delivery.Clear();
            txtb_Profit_Income.Clear();
            txtb_GrossProfit.Clear();
            txtb_Profit_Sales.Clear();
        }

        private void btn_Net_Clear_Click(object sender, EventArgs e)
        {
            dtp_NetProfit.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
            txtb_NetMonth.Clear();
            txtb_Profit_Payroll.Clear();
            txtb_Profit_Marketing.Clear();
            txtb_Profit_Insurance.Clear();
            txtb_Profit_Travel.Clear();
            txtb_Profit_Misallaneous.Clear();
            txtb_Profit_Tax.Clear();
            txtb_Profit_Bill.Clear();
            txtb_Profit_other.Clear();
            txtb_Profit_TotalExpences.Clear();
            txtb_NetProfit.Clear();


        }

        private void bt_Ann_clear_Click(object sender, EventArgs e)
        {
            dtc_Ann1.Value = DateTime.Now;
            dtp_Ann2.Value = DateTime.Now;
            txt_Anu_year.Clear();
            txtb_Anu_Product.Clear();
            txtb_Anu_Services.Clear();
            txtb_AnnuIncome.Clear();
            txtb_Anu_Ex.Clear();
            txtb_Anu_Gross.Clear();
            txtb_Annu_net.Clear();
                   }

////Newly Added
///Netprofit tab validation
        private void txtb_Profit_Sales_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 2)
            {
                e.Handled = true;
            }
            if (txtb_Profit_Sales.Text.Length >= 1&& ch != 2)
                e.Handled = true;
        }

        private void txtb_Gross_OrderCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 2)
            {
                e.Handled = true;
            }
            if (txtb_Gross_OrderCost.Text.Length >= 1&& ch != 2)
                e.Handled = true; 
        }

        private void txtb_Profit_Repair_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 2)
            {
                e.Handled = true;
            }
            if (txtb_Profit_Repair.Text.Length >= 1&& ch != 2)
                e.Handled = true; 
        }

        private void txtb_Offsite_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 2)
            {
                e.Handled = true;
            }
            if (txtb_Offsite.Text.Length >= 1&& ch != 2)
                e.Handled = true; 
        }

        private void txtb_Delivery_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 2)
            {
                e.Handled = true;
            }
            if (txtb_Delivery.Text.Length >= 1&& ch != 2)
                e.Handled = true; 
        }

        private void txtb_Profit_Income_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 2)
            {
                e.Handled = true;
            }
            if (txtb_Profit_Income.Text.Length >= 1&& ch != 2)
                e.Handled = true; 
        }

        private void txtb_GrossProfit_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 2)
            {
                e.Handled = true;
            }
            if (txtb_GrossProfit.Text.Length >= 1&& ch != 2)
                e.Handled = true;
        }

        private void txtb_Profit_Payroll_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 2)
            {
                e.Handled = true;
            }
            if (txtb_Profit_Payroll.Text.Length >= 1&& ch != 2)
                e.Handled = true;
        }

        private void txtb_Profit_Marketing_KeyPress(object sender, KeyPressEventArgs e)
        {
             char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 2)
            {
                e.Handled = true;
            }
            if (txtb_Profit_Marketing.Text.Length >= 1&& ch != 2)
                e.Handled = true;
        }

        private void txtb_Profit_Insurance_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 2)
            {
                e.Handled = true;
            }
            if (txtb_Profit_Insurance.Text.Length >= 1&& ch != 2)
                e.Handled = true;

        }

        private void txtb_Profit_Travel_KeyPress(object sender, KeyPressEventArgs e)
        {
             char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 2)
            {
                e.Handled = true;
            }
            if (txtb_Profit_Travel.Text.Length >= 1&& ch != 2)
                e.Handled = true;
        }

        private void txtb_Profit_Misallaneous_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 2)
            {
                e.Handled = true;
            }
            if (txtb_Profit_Misallaneous.Text.Length >= 1&& ch != 2)
                e.Handled = true;
        }

        private void txtb_Anu_Product_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 2)
            {
                e.Handled = true;
            }
            if (txtb_Anu_Product.Text.Length >= 1&& ch != 2)
                e.Handled = true;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            AccountReport2 AC2 = new AccountReport2();

            AC2.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            AccountReport1 AC1 = new AccountReport1();

            AC1.Show();
        }

        


  }}
        

         


