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

namespace megacoolnew
{
    public partial class Stock : Form
    {

        public Stock()
        {
            InitializeComponent();
            
        }

        //Filling Product Type Combo box
        public void FillComboType()
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
                cmd1.CommandText = "select distinct ProductType from dbo.Inventory";

                SqlDataReader dr = cmd1.ExecuteReader();

                while (dr.Read())
                {
                    string tp = Convert.ToString(dr[0]);
                    cmbINType.Items.Add(tp);
                }

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            con.Close();
        }

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

                cmd1.CommandText = "select distinct Make from dbo.Inventory where ProductType='" + cmbINType.Text + "'";

                SqlDataReader dr = cmd1.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(dr);
                cmbINMake.DataSource = dt;
                cmbINMake.DisplayMember = "Make";
                cmbINMake.Text = "";

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            con.Close();

        }

        //Filling Model Combo box
        public void FillComboModel()
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
                cmd1.CommandText = "select distinct Model from dbo.Inventory where ProductType='" + cmbINType.Text + "' and Make='" + cmbINMake.Text + "' ";

                SqlDataReader dr = cmd1.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(dr);
                cmbINModel.DataSource = dt;
                cmbINModel.DisplayMember = "Model";
                cmbINModel.Text = "";

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            con.Close();

        }

        //Filling Inventory Grid
        public void InventoryFillGrid() {

            SqlConnection con = ConnectionManager.GetConnection();

            if (con.State.ToString() == "Closed")
            {
                con.Open();
            }
            SqlDataAdapter sda = new SqlDataAdapter("select inv.InventoryID,inv.ProductType,inv.Make,inv.Model,inv.BuyingPrice,inv.SellingPrice,inv.Quantity,ss.SupplierID from Inventory inv,Supplies ss where inv.InventoryID=ss.InventoryID", con);

            DataTable dt = new DataTable();
                
            sda.Fill(dt);

            dgvINinventory.DataSource = dt;

            con.Close();


        }

        //Filling Supplier Combo box
        public void FillComboSupplier()
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

                cmd1.CommandText = "select SupplierID from dbo.Supplier ";

                SqlDataReader dr = cmd1.ExecuteReader();


                while (dr.Read())
                {
                    string sup = Convert.ToString(dr[0]);
                    txtINsupplier.Items.Add(sup);

                }

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            con.Close();

        }

        //Filling Inventory Search Combo box
        public void FillComboInventorySearch()
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

                cmd1.CommandText = "select InventoryID from dbo.Inventory where ProductType='" + cmbINType.Text + "' and Make='" + cmbINMake.Text + "' and Model='" + cmbINModel.Text + "' ";

                SqlDataReader dr = cmd1.ExecuteReader();

                while (dr.Read())
                {
                    string inv = Convert.ToString(dr[0]);
                    cmbINsearchInventory.Items.Add(inv);

                }

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            con.Close();

        }


        //Clear Inventory
        public void Clear() {

            cmbINType.Text = "";

            cmbINMake.Text = "";

            cmbINModel.Text = "";

            txtINinventoryID1.Clear();
            txtINbuyingPrice.Clear();
            txtINsellingPrice.Clear();
            txtINquantity.Clear();

            txtINsupplier.SelectedIndex = -1;

            cmbINsearchInventory.SelectedIndex = -1;
            cmbINsearchInventory.Items.Clear();

            txtINquantity.Enabled = true;
            
        }

        private void btnINadd2_Click(object sender, EventArgs e)
        {

        }

        private void lblINsupplierID_Click(object sender, EventArgs e)
        {

        }

        private void txtINsupplierID_TextChanged(object sender, EventArgs e)
        {

        }

        private void Stock_Load(object sender, EventArgs e)
        {

            //Inventory tab
            InventoryFillGrid();

            FillComboType();
            FillComboSupplier();

            cmbINMake.Items.Clear();
            cmbINModel.Items.Clear();

            //Supplier tab
            SupplierFillGrid();
            

            //Update Stock Tab
            InventoryReorderFillGrid();
            FillComboReorderType();
            fillReorderListBox();

            //Payment Tab
            SuppliesFillGrid();
            FillComboSupplierID();
            
                

        }

        //Validation for Inventory 
        public bool InventoryValidation() { 
        
            bool status=false;          

            if (cmbINType.Text == "")
                MessageBox.Show("Please select the Product Type");
            
            else if (cmbINMake.Text == "")
                MessageBox.Show("Please select the Make");

            else if (cmbINModel.Text == "")
                MessageBox.Show("Please select the Model");

            else if (txtINbuyingPrice.Text == "")
                MessageBox.Show("Please fill the Buying Price");

            else if (txtINsellingPrice.Text == "")
                MessageBox.Show("Please fill the Selling Price");

            else if (txtINquantity.Text == "")
                MessageBox.Show("Please fill the Quantity");

            else if (txtINsupplier.Text == "")
                MessageBox.Show("Please fill the Supplier ID");

            else if (Convert.ToDouble(txtINbuyingPrice.Text) <= 0)
            {
                MessageBox.Show("Please enter a valid amount for Buying Price");
                txtINbuyingPrice.Clear();
            }

            else if (Convert.ToDouble(txtINsellingPrice.Text) <= 0)
            {
                MessageBox.Show("Please enter a valid amount for Selling Price");
                txtINsellingPrice.Clear();
            }

            else
            {
                status = true;
            }
            return status;
        }

        //Add Inventory button click
        private void btnINadd1_Click(object sender, EventArgs e)
        {
            if (InventoryValidation())
            {

                StockObject stk = new StockObject();
                SupplierObject sup = new SupplierObject();

                stk.productType = cmbINType.Text;
                stk.make = cmbINMake.Text;
                stk.model = cmbINModel.Text;
                
                stk.inventoryID = txtINinventoryID1.Text;

                stk.buyingPrice = Convert.ToDouble(txtINbuyingPrice.Text);
                stk.sellingPrice = Convert.ToDouble(txtINsellingPrice.Text);
                
                stk.quantity = Convert.ToInt16(txtINquantity.Text);

                sup.supplierID = txtINsupplier.Text;


                    DialogResult dr;
                    dr = MessageBox.Show("Do you want to save the record", "Confirm", MessageBoxButtons.YesNo);

                    if (dr == DialogResult.Yes)
                    {
                        try
                        {
                            MegaCoolMethods mc = new MegaCoolMethods();
                            bool result = mc.addInventory(stk, sup);

                            if (result)
                            {

                                MessageBox.Show("Successfully Saved", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                InventoryFillGrid();
                                cmbINType.Items.Clear();
                                FillComboType();
                                Clear();
                                FillComboInventoryID();

                                cmbINTypeReorder.Items.Clear();
                                FillComboReorderType();

                            }
                            else
                            {
                                MessageBox.Show("Unable to Save", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }

                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
            }

        }

        //Inventory ID generation 
        private void txtINinventoryID1_MouseClick(object sender, MouseEventArgs e)
        {

            if (cmbINType.Text != "" && cmbINMake.Text != "" && cmbINModel.Text != "")
            {

                String inven1 = cmbINType.Text.Replace(" ", "").Substring(0, 3).ToUpper();
                String inven2 = cmbINMake.Text.Substring(0, 1).ToUpper();
                String inven3 = cmbINModel.Text.Substring(0, 1).ToUpper();

                String invID = string.Concat(inven1, inven2, inven3);

                SqlConnection con = ConnectionManager.GetConnection();

                if (con.State.ToString() == "Closed")
                {
                    con.Open();
                }

                    SqlCommand cmd1 = con.CreateCommand();

                    cmd1.Connection = con;
                    cmd1.CommandType = CommandType.Text;

                    cmd1.CommandText = "SELECT TOP 1 InventoryID FROM dbo.Inventory WHERE InventoryID like'" + invID + "%' ORDER BY InventoryID DESC";

                    var re=cmd1.ExecuteScalar();

                    int num;

                    if (re != null)
                    {

                        string id = re.ToString();
                        string id2 = id.Substring(5);
                        num = Convert.ToInt16(id2);
                        num = num + 1;
                    }
                    else {

                        num = 1;
                    }    

                    string idPart2 = Convert.ToString(num);

                    txtINinventoryID1.Text = string.Concat(invID, idPart2);
                 

            }
        }


        //Update Inventory button click
        private void btnINupdate_Click(object sender, EventArgs e)
        {
            if (InventoryValidation())
            {

                StockObject stk = new StockObject();
                SupplierObject sup = new SupplierObject();

                stk.productType = cmbINType.Text;
                stk.make = cmbINMake.Text;
                stk.model = cmbINModel.Text;
                stk.inventoryID = string.Concat(txtINinventoryID1.Text);
                stk.buyingPrice = Convert.ToDouble(txtINbuyingPrice.Text);
                stk.sellingPrice = Convert.ToDouble(txtINsellingPrice.Text);

                stk.quantity = Convert.ToInt16(txtINquantity.Text);

                sup.supplierID = txtINsupplier.Text;

                try
                {
                    MegaCoolMethods mc = new MegaCoolMethods();
                    bool result = mc.editInventory(stk, sup);

                    if (result)
                    {
                        MessageBox.Show("Successfully Edited", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        InventoryFillGrid();

                        Clear();
                        cmbINType.Enabled = true;
                        cmbINMake.Enabled = true;
                        cmbINModel.Enabled = true;
                        txtINinventoryID1.Enabled = true;
                        txtINquantity.Enabled = true;

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

        //Row click of  Inventory grid
        private void dgvINinventory_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            cmbINType.Text = dgvINinventory.Rows[e.RowIndex].Cells[1].Value.ToString();
            cmbINMake.Text = dgvINinventory.Rows[e.RowIndex].Cells[2].Value.ToString();
            cmbINModel.Text = dgvINinventory.Rows[e.RowIndex].Cells[3].Value.ToString();
            
            string invID = dgvINinventory.Rows[e.RowIndex].Cells[0].Value.ToString();

            txtINinventoryID1.Text = invID;

            txtINbuyingPrice.Text = dgvINinventory.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtINsellingPrice.Text = dgvINinventory.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtINquantity.Text = dgvINinventory.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtINsupplier.Text = dgvINinventory.Rows[e.RowIndex].Cells[7].Value.ToString();

            cmbINType.Enabled = false;
            cmbINMake.Enabled = false;
            cmbINModel.Enabled = false;
            txtINinventoryID1.Enabled = false;
            txtINquantity.Enabled = false;


        }

        //Selected Index change event of Product type combo box
        private void cmbINType_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbINMake.Text = "";
            cmbINModel.Text = "";

            FillComboMake();           
            
        }

        //Clear Inventory button click
        private void btnINclearInv_Click(object sender, EventArgs e)
        {
            Clear();

            cmbINType.Enabled = true;
            cmbINMake.Enabled = true;
            cmbINModel.Enabled = true;
            txtINinventoryID1.Enabled = true;

            InventoryFillGrid();

        }

        //Delete Inventory button click
        private void btnINDeleteInv_Click(object sender, EventArgs e)
        {
            if (InventoryValidation())
            {
                DialogResult dr;
                dr = MessageBox.Show("Do you want to delete the record", "Confirm", MessageBoxButtons.YesNo);

                if (dr == DialogResult.Yes)
                {
                    MegaCoolMethods mc = new MegaCoolMethods();

                    string invID = txtINinventoryID1.Text;
                    string supID = txtINsupplier.Text;

                    bool result = mc.deleteInventory(invID, supID);

                    InventoryFillGrid();
                    cmbINType.Items.Clear();
                    FillComboType();

                    MessageBox.Show("Successfully Deleted");

                    Clear();
                    cmbINType.Enabled = true;
                    cmbINMake.Enabled = true;
                    cmbINModel.Enabled = true;
                    txtINinventoryID1.Enabled = true;

                }
            }
        }

        //Demo button for inventory
        private void btnINDemo_Click(object sender, EventArgs e)
        {
            cmbINType.Text = "AC Filter";
            cmbINMake.Text = "Filter Free";
            cmbINModel.Text = "PF10RD";
            txtINinventoryID1.Text = "ACFFP1";
            txtINbuyingPrice.Text = "1600";
            txtINsellingPrice.Text = "2450";
            txtINquantity.Text = "16";
            txtINsupplier.Text = "SU0004";

        }

        //Search Inventory button click
        private void btnINsearch_Click(object sender, EventArgs e)
        {
            
            string inventoryID = cmbINsearchInventory.Text;

            SqlConnection con = ConnectionManager.GetConnection();

            if (con.State.ToString() == "Closed")
            {
                con.Open();
            }

            SqlDataAdapter sda = new SqlDataAdapter("select inv.InventoryID,inv.ProductType,inv.Make,inv.Model,inv.BuyingPrice,inv.SellingPrice,inv.Quantity,su.SupplierID from Inventory inv,Supplies su where inv.InventoryID= '" + inventoryID + "' and inv.InventoryID=su.InventoryID ", con);

            DataTable dt = new DataTable();

            sda.Fill(dt);

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("This Inventory does not exist");
                cmbINsearchInventory.Text = "";
            }
            dgvINinventory.DataSource = dt;
        }

        private void cmbINModel_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbINModel_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtINbuyingPrice_TextChanged(object sender, EventArgs e)
        {

        }

        //Add Supplier button click
        private void btnINaddsup_Click(object sender, EventArgs e)
        {
            if (SupplierValidation())
            {
                Validation email = new Validation();
                if (email.IsValidEmail(txtINemail.Text) == false)
                {
                    MessageBox.Show("Please Enter a Valid Email");
                    txtINemail.Clear();
                }
                else
                {
                    SupplierObject sp = new SupplierObject();

                    sp.name = txtINsupplierName.Text;
                    sp.supplierID = txtINsupplierID.Text;
                    sp.contactNo = txtINcontact.Text;
                    sp.Email = txtINemail.Text;
                    sp.address = rtxtINaddress.Text;

                    DialogResult dr;
                    dr = MessageBox.Show("Do you want to save the record", "Confirm", MessageBoxButtons.YesNo);

                    if (dr == DialogResult.Yes)
                    {
                        try
                        {
                            MegaCoolMethods mc = new MegaCoolMethods();
                            bool result = mc.addSupplier(sp);

                            if (result)
                            {

                                MessageBox.Show("Successfully Saved", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                SupplierFillGrid();
                                ClearSup();
                                txtINsupplier.Items.Clear();
                                FillComboSupplier();

                                cmbINsupPay.Items.Clear();
                                FillComboSupplierID();

                            }
                            else
                            {
                                MessageBox.Show("Unable to Save", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }

                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                }
            }
        }


        //Clear Supplier
        public void ClearSup()
        {

            txtINsupplierName.Clear();
            txtINsupplierID.Clear();
            rtxtINaddress.Clear();
            txtINcontact.Clear();
            txtINemail.Clear();
            txtINsupSearch.Clear();
            listBox1.Items.Clear();

        }

        //Key press event for buying price text box
        private void txtINbuyingPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }

        }

        //Key press event for selling price text box
        private void txtINsellingPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }


        private void txtINreorder_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        
        //Key press event for quantity text box
        private void txtINquantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }


        private void txtINinventoryID2_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        //Validation for Supplier
        public bool SupplierValidation()
        {

            bool status = false;

            if (txtINsupplierName.Text == "")
                MessageBox.Show("Please fill the Supplier Name");

            else if (txtINsupplierID.Text == "")
                MessageBox.Show("Please fill the Supplier ID");

            else if (rtxtINaddress.Text == "")
                MessageBox.Show("Please fill the address");

            else if (txtINcontact.Text == "")
                MessageBox.Show("Please fill the Contact No");

            else if (txtINemail.Text == "")
                MessageBox.Show("Please fill the email");

            else if (txtINcontact.TextLength != 10)
                MessageBox.Show("Please enter a valid contact no");

            else
            {
                status = true;
            }
            return status;
        }

        //Filling Supplier Grid
        public void SupplierFillGrid()
        {

            SqlConnection con = ConnectionManager.GetConnection();

            if (con.State.ToString() == "Closed")
            {
                con.Open();
            }
            SqlDataAdapter sda = new SqlDataAdapter(" select sp.SupplierID,sp.Name,sp.Address,sp.email,sc.ContactNo from Supplier sp,SupplierContact sc where sp.SupplierID=sc.SupplierID ", con);

            DataTable dt = new DataTable();

            sda.Fill(dt);

            dgvINsupplier.DataSource = dt;

            con.Close();


        }

        private void txtINsupplier_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        //Key press event for contact no text box
        private void txtINcontact_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
            if (txtINcontact.Text.Length > 9 && ch != 8)
                e.Handled = true;
        }
        
        //Row header click event for Supplier grid
        private void dgvINsupplier_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            listBox1.Items.Clear();

            txtINsupplierName.Text = dgvINsupplier.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtINsupplierID.Text = dgvINsupplier.Rows[e.RowIndex].Cells[0].Value.ToString();
            rtxtINaddress.Text = dgvINsupplier.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtINcontact.Text = dgvINsupplier.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtINemail.Text = dgvINsupplier.Rows[e.RowIndex].Cells[3].Value.ToString();

            txtINsupplierID.Enabled = false;

            SqlConnection con = ConnectionManager.GetConnection();

            if (con.State.ToString() == "Closed")
            {
                con.Open();
            }

            SqlCommand cmd1 = con.CreateCommand();
            cmd1.Connection = con;
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "select * from dbo.Inventory inv,Supplies ss where inv.InventoryID=ss.InventoryID and ss.SupplierID='" + txtINsupplierID.Text + "'";
            SqlDataReader dr = cmd1.ExecuteReader();
            while (dr.Read())
            {
                listBox1.Items.Add(dr[1].ToString()+" - "+dr[0].ToString());
            }

            con.Close();
            
        }


        //Edit Supplier button click
        private void btnINupdatesup_Click(object sender, EventArgs e)
        {
            if (SupplierValidation())
            {
                SupplierObject sp = new SupplierObject();

                sp.name = txtINsupplierName.Text;
                sp.supplierID = txtINsupplierID.Text;
                sp.contactNo = txtINcontact.Text;
                sp.Email = txtINemail.Text;
                sp.address = rtxtINaddress.Text;

                try
                {
                    MegaCoolMethods mc = new MegaCoolMethods();
                    bool result = mc.editSupplier(sp);

                    if (result)
                    {
                        MessageBox.Show("Successfully Edited", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        SupplierFillGrid();
                        ClearSup();
                        txtINsupplierID.Enabled = true;

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
        
        //Delete supplier button click
        private void btnINdeleteSup_Click(object sender, EventArgs e)
        {
            if (SupplierValidation())
            {
                DialogResult dr;
                dr = MessageBox.Show("Do you want to delete the record", "Confirm", MessageBoxButtons.YesNo);

                if (dr == DialogResult.Yes)
                {
                    MegaCoolMethods mc = new MegaCoolMethods();

                    string supID = txtINsupplierID.Text;

                    bool result = mc.deleteSupplier(supID);

                    SupplierFillGrid();

                    MessageBox.Show("Successfully Deleted");

                    txtINsupplier.Items.Clear();
                    FillComboSupplier();

                    cmbINsupPay.Items.Clear();
                    FillComboSupplierID();

                    ClearSup();

                    txtINsupplierID.Enabled = true;


                }
            }
        }

        //Clear button click 
        private void btnINclearSup_Click(object sender, EventArgs e)
        {
            ClearSup();

            txtINsupplierID.Enabled = true;

            SupplierFillGrid();
            
        }

        //Demo button click
        private void btnINdemoSup_Click(object sender, EventArgs e)
        {
            txtINsupplierName.Text = "SD Auto Parts";
            txtINsupplierID.Text = "SU1111";
            rtxtINaddress.Text = "44, Main Road, Kaluthara";
            txtINcontact.Text = "0341122334";
            txtINemail.Text = "sdap@gmail.com";
            
        }

        //Search Supplier button click
        private void btnINsearch2_Click(object sender, EventArgs e)
        {

            SqlConnection con = ConnectionManager.GetConnection();

            DataTable dt = new DataTable();

            if (con.State.ToString() == "Closed")
            {
                con.Open();
            }
     

            if (txtINsupSearch.Text.StartsWith("SU") && txtINsupSearch.Text.Length==6)
            {
                SqlDataAdapter sda1 = new SqlDataAdapter("SELECT sp.SupplierID,sp.Name,sp.Address,sp.email,sc.ContactNo from Supplier sp,SupplierContact sc where sp.SupplierID=sc.SupplierID and sp.SupplierID = '" + txtINsupSearch.Text + "' ", con);
                sda1.Fill(dt);
            }

            else if (txtINsupSearch.Text.StartsWith("su") && txtINsupSearch.Text.Length == 6)
            {
                SqlDataAdapter sda2 = new SqlDataAdapter("SELECT sp.SupplierID,sp.Name,sp.Address,sp.email,sc.ContactNo from Supplier sp,SupplierContact sc where sp.SupplierID=sc.SupplierID and sp.SupplierID = '" + txtINsupSearch.Text + "' ", con);
                sda2.Fill(dt);
            }
            else
            {
                SqlDataAdapter sda3 = new SqlDataAdapter("SELECT sp.SupplierID,sp.Name,sp.Address,sp.email,sc.ContactNo from Supplier sp,SupplierContact sc where sp.SupplierID=sc.SupplierID and sp.Name LIKE  '%" + txtINsupSearch.Text + "%'", con);
                sda3.Fill(dt);

            }           

            if (dt.Rows.Count == 0)
                MessageBox.Show("This Supplier does not exist");

            dgvINsupplier.DataSource = dt;

            ClearSup();
            con.Close();

        }

        private void txtINsupSearch_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtINsupplier_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //Selected Index change event of Make combo box
        private void cmbINMake_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbINModel.Text = "";
            FillComboModel();

        }

        //Selected Index change event of Model combo box
        private void cmbINModel_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            cmbINsearchInventory.Items.Clear();

            FillComboInventorySearch();
        }

        private void txtINreorder_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //Filling Reorder Grid
        public void InventoryReorderFillGrid()
        {
            SqlConnection con = ConnectionManager.GetConnection();

            if (con.State.ToString() == "Closed")
            {
                con.Open();
            }
            SqlDataAdapter sda = new SqlDataAdapter(" select ProductType,Make,Model,Re_orderLevel,TotalQuantity from InventoryReorder ", con);

            DataTable dt = new DataTable();

            sda.Fill(dt);

            dgvINreorder.DataSource = dt;

            con.Close();

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //Filling Reorder Product Type Combo box
        public void FillComboReorderType()
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
                cmd1.CommandText = "select distinct ProductType from dbo.Inventory";

                SqlDataReader dr = cmd1.ExecuteReader();

                while (dr.Read())
                {
                    string tp = Convert.ToString(dr[0]);
                    cmbINTypeReorder.Items.Add(tp);
                }

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            con.Close();
        }

        //Filling Reorder Make Combo box
        public void FillComboReorderMake()
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

                cmd1.CommandText = "select distinct Make from dbo.Inventory where ProductType='" + cmbINTypeReorder.Text + "'";

                SqlDataReader dr = cmd1.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(dr);
                cmbINMakeReorder.DataSource = dt;
                cmbINMakeReorder.DisplayMember = "Make";
                cmbINMakeReorder.Text = "";

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            con.Close();

        }

        //Filling Reorder Model Combo box
        public void FillComboReorderModel()
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

                cmd1.CommandText = "select distinct Model from dbo.Inventory where ProductType='" + cmbINTypeReorder.Text + "' and Make='" + cmbINMakeReorder.Text + "' ";

                SqlDataReader dr = cmd1.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(dr);
                cmbINModelReorder.DataSource = dt;
                cmbINModelReorder.DisplayMember = "Model";
                cmbINModelReorder.Text = "";

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            con.Close();

        }

        private void cmbINTypeReorder_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbINMakeReorder.Text = "";
            cmbINModelReorder.Text = "";

            FillComboReorderMake();

        }

        //Validation for Update Stock 
        public bool UpdateStockValidation()
        {
            bool status = false;

            if (cmbINTypeReorder.Text == "")
                MessageBox.Show("Please select the Product Type");

            else if (cmbINMakeReorder.Text == "")
                MessageBox.Show("Please select the Make");

            else if (cmbINModelReorder.Text == "")
                MessageBox.Show("Please select the Model");
            
            else
            {
                status = true;
            }
            return status;
        }


        //Set Reorder Levels button click
        private void btnINaddReorder_Click(object sender, EventArgs e)
        {
            StockObject stk = new StockObject();

            stk.productType = cmbINTypeReorder.Text;
            stk.make = cmbINMakeReorder.Text;
            stk.model = cmbINModelReorder.Text;

            if (UpdateStockValidation())
            {
                if (txtINreorderLevel.Text != "")
                {
                    stk.reorderLevel = Convert.ToInt16(txtINreorderLevel.Text);

                    if (stk.reorderLevel > 0)
                    {
                        DialogResult dr;
                        dr = MessageBox.Show("Do you want to save the record", "Confirm", MessageBoxButtons.YesNo);

                        if (dr == DialogResult.Yes)
                        {
                            try
                            {
                                MegaCoolMethods mc = new MegaCoolMethods();
                                bool result = mc.addReorderInventory(stk);

                                if (result)
                                {

                                    MessageBox.Show("Successfully Saved", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    InventoryReorderFillGrid();
                                    ltbINreorder.Items.Clear();
                                    fillReorderListBox();


                                }
                                else
                                {
                                    MessageBox.Show("Unable to Save", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    txtINreorderLevel.Text = "";
                                }
                            }

                            catch (Exception ex)
                            {
                                throw ex;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Enter a valid reorder level");
                    }
                }
                else
                {
                    MessageBox.Show("Enter a value for re-order level");
                }
            }
            }
        
        
        //Search Reorder Inventory button click
        private void btnINsearchReorder_Click(object sender, EventArgs e)
        {
            SqlConnection con = ConnectionManager.GetConnection();

            if (con.State.ToString() == "Closed")
            {
                con.Open();
            }
            if (UpdateStockValidation())
            {
                SqlDataAdapter sda = new SqlDataAdapter("select ProductType,Make,Model,Re_orderLevel,TotalQuantity from InventoryReorder where ProductType='" + cmbINTypeReorder.Text + "' and Make='" + cmbINMakeReorder.Text + "' and Model='" + cmbINModelReorder.Text + "' ", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dgvINreorder.DataSource = dt;

                InventoryIDincreasedFillGrid();

            }
            con.Close();


        }

        //Update Reorder Inventory button click
        private void btnINupdateReorder_Click(object sender, EventArgs e)
        {
            StockObject stk = new StockObject();

            stk.productType = cmbINTypeReorder.Text;
            stk.make = cmbINMakeReorder.Text;
            stk.model = cmbINModelReorder.Text;

            if (UpdateStockValidation())
            {
                if (txtINreorderLevel.Text != "")
                {

                    stk.reorderLevel = Convert.ToInt16(txtINreorderLevel.Text);

                    if (stk.reorderLevel > 0)
                    {
                        try
                        {
                            MegaCoolMethods mc = new MegaCoolMethods();
                            bool result = mc.editReorderInventory(stk);

                            if (result)
                            {
                                MessageBox.Show("Successfully Edited", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                InventoryReorderFillGrid();
                                ltbINreorder.Items.Clear();
                                fillReorderListBox();
                                txtINreorderLevel.Text = "";

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

                    else
                    {
                        MessageBox.Show("Enter a valid reorder level");
                    }
                }
                else
                {
                    MessageBox.Show("Enter a value for re-order level");
                }
            }
        }

        //Row click of Inventory Reorder Grid
        private void dgvINreorder_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            cmbINTypeReorder.Text = dgvINreorder.Rows[e.RowIndex].Cells[0].Value.ToString();
            cmbINMakeReorder.Text = dgvINreorder.Rows[e.RowIndex].Cells[1].Value.ToString();
            cmbINModelReorder.Text = dgvINreorder.Rows[e.RowIndex].Cells[2].Value.ToString();
            
            txtINreorderLevel.Text = dgvINreorder.Rows[e.RowIndex].Cells[3].Value.ToString();
            
            cmbINTypeReorder.Enabled = false;
            cmbINMakeReorder.Enabled = false;
            cmbINModelReorder.Enabled = false;
            btnINaddReorder.Enabled = false;

        }

        private void txtINreorderLevel_TextChanged(object sender, EventArgs e)
        {

        }


        //Filling increase inventory Grid
        public void InventoryIDincreasedFillGrid()
        {

            SqlConnection con = ConnectionManager.GetConnection();

            if (con.State.ToString() == "Closed")
            {
                con.Open();
            }

            SqlDataAdapter sda = new SqlDataAdapter(" select InventoryID,Quantity from dbo.Inventory where ProductType='" + cmbINTypeReorder.Text + "' and Make='" + cmbINMakeReorder.Text + "' and Model='" + cmbINModelReorder.Text + "' ", con);

            DataTable dt = new DataTable();

            sda.Fill(dt);

            dgvUpdateStock.DataSource = dt;

            con.Close();
        }

        //Row header click event for update stock grid
        private void dgvUpdateStock_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtINinventoryIncrease.Text = dgvUpdateStock.Rows[e.RowIndex].Cells[0].Value.ToString();

        }
        
        //Increase Stock button click
        private void btnINadd2_Click_1(object sender, EventArgs e)
        {
            StockObject stk = new StockObject();
           
            stk.productType = cmbINTypeReorder.Text;
            stk.make = cmbINMakeReorder.Text;
            stk.model = cmbINModelReorder.Text;

            if (UpdateStockValidation())
            {
                if (txtINinventoryIncrease.Text != "")
                {
                    stk.inventoryID = txtINinventoryIncrease.Text;

                    if (txtINincrease.Text != "")
                    {
                        int increase = Convert.ToInt32(txtINincrease.Text);

                        if (increase < 100 && increase>0)
                        {
                            DialogResult dr;
                            dr = MessageBox.Show("Do you want to increase the quantity by " + txtINincrease.Text + " ", "Confirm", MessageBoxButtons.YesNo);

                            if (dr == DialogResult.Yes)
                            {
                                try
                                {
                                    MegaCoolMethods mc = new MegaCoolMethods();
                                    bool result = mc.increaseStock(stk, increase);

                                    if (result)
                                    {
                                        MessageBox.Show("Successfully Saved", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        InventoryReorderFillGrid();
                                        InventoryIDincreasedFillGrid();
                                        txtINinventoryIncrease.Text = "";
                                        txtINincrease.Text = "";

                                    }
                                    else
                                    {
                                        MessageBox.Show("Unable to Save", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }

                                catch (Exception ex)
                                {
                                    throw ex;
                                }
                            }
                        }
                        else {

                            MessageBox.Show("Enter a valid amount to increase");
                            txtINincrease.Clear();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Fill the increasing amount");
                    }
                }
                else
                {
                    MessageBox.Show("Fill the Inventory ID");
                }
             }
        }

        //Fill reorder inventories list box
        public void fillReorderListBox() { 
        
            ltbINreorder.Items.Clear();

            SqlConnection con = ConnectionManager.GetConnection();

            if (con.State.ToString() == "Closed")
            {
                con.Open();
            }

            SqlCommand cmd1 = con.CreateCommand();
            cmd1.Connection = con;
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "select ProductType,Make,Model from dbo.InventoryReorder where Re_orderLevel >= (TotalQuantity-5)";
            SqlDataReader dr = cmd1.ExecuteReader();
            while (dr.Read())
            {
                ltbINreorder.Items.Add(dr[0].ToString() + " - " + dr[1].ToString() + " - " + dr[2].ToString());
            }

            con.Close();


        }

        //Key press event for reorder level text box
        private void txtINreorderLevel_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        //SelectedIndex change event for Make reorder combo box
        private void cmbINMakeReorder_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbINModelReorder.Text = "";
            FillComboReorderModel();
        }

        //Key press event for Increase quantity text box
        private void txtINincrease_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            txtINinventoryIncrease.Clear();
            txtINincrease.Clear();           
        }

        //Key press event for Type combo box
        private void cmbINType_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        //Key press event for Make combo box
        private void cmbINMake_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void cmbINModel_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void cmbINsearchInventory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void btnINclearRe_Click(object sender, EventArgs e)
        {
            cmbINTypeReorder.SelectedIndex = -1;
            cmbINMakeReorder.SelectedIndex = -1;
            cmbINModelReorder.SelectedIndex = -1;

            InventoryReorderFillGrid();

            cmbINTypeReorder.Enabled = true;
            cmbINMakeReorder.Enabled = true;
            cmbINModelReorder.Enabled = true;
            btnINaddReorder.Enabled = true;
            txtINreorderLevel.Clear();

            dgvUpdateStock.DataSource = null;
            dgvUpdateStock.Rows.Clear();
            txtINinventoryIncrease.Clear();

        }

        //Filling Supplier Payment Grid
        public void SuppliesFillGrid()
        {
            SqlConnection con = ConnectionManager.GetConnection();

            if (con.State.ToString() == "Closed")
            {
                con.Open();
            }
            SqlDataAdapter sda = new SqlDataAdapter("select sp.InventoryID,sp.SupplierID,sr.Name,sp.Date,sp.PaidAmount from SupplierPayment sp,Supplier sr where sp.SupplierID=sr.SupplierID", con);

            DataTable dt = new DataTable();

            sda.Fill(dt);

            dgvINpayment.DataSource = dt;

            con.Close();
        }

        private void lblINDate_Click(object sender, EventArgs e)
        {

        }

        //Filling SupplierID Combo box
        public void FillComboSupplierID()
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

                cmd1.CommandText = "select SupplierID from dbo.Supplier ";

                SqlDataReader dr = cmd1.ExecuteReader();


                while (dr.Read())
                {
                    string sup = Convert.ToString(dr[0]);
                    cmbINsupPay.Items.Add(sup);

                }

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            con.Close();

        }

        //Filling InventoryID Combo box
        public void FillComboInventoryID()
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

                cmd1.CommandText = "select InventoryID from dbo.Supplies where SupplierID='"+cmbINsupPay.Text+"' ";

                SqlDataReader dr = cmd1.ExecuteReader();


                while (dr.Read())
                {
                    string inv = Convert.ToString(dr[0]);
                    cmbINinvPay.Items.Add(inv);

                }

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            con.Close();

        }

        //Key press event for amount text box
        private void txtINpaidAm_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        //Clear supplier payment
        public void clearPay() {

            cmbINsupPay.SelectedIndex = -1;
            cmbINinvPay.SelectedIndex = -1;
            txtINpaidAm.Text = " ";
            dtpINsupPay.Value = DateTime.Today;

        }

        //Validation for Payment 
        public bool paymentValidation()
        {
            bool status = false;

            if (cmbINsupPay.Text == "")
                MessageBox.Show("Please select the Supplier ID");

            else if (cmbINinvPay.Text == "")
                MessageBox.Show("Please select the Inventory ID");

            else if (dtpINsupPay.Text == "")
                MessageBox.Show("Please Fill the Date");

            else if (dtpINsupPay.Value >= DateTime.Today)
            {
                MessageBox.Show("Please enter a valid date");
                dtpINsupPay.Value = DateTime.Today;
                
            }

            else if (txtINpaidAm.Text == "")
                MessageBox.Show("Please Fill the Amount");

            else
            {
                status = true;
            }
            return status;
        }

        //Fill the Totally Paid Amount
        public bool fillTotAmt()
        {    
            bool status = false;

            SqlConnection con = ConnectionManager.GetConnection();

            if (con.State.ToString() == "Closed")
            {
                con.Open();
            }
            try
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select sum(PaidAmount) from dbo.SupplierPayment where SupplierID='" + cmbINsupPay.Text + "' and InventoryID='" + cmbINinvPay.Text + "' ";

                string str = cmd.ExecuteScalar().ToString();

                txtINtotPay.Text = str;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return status;
        }

        //Add Supplier Payment button click
        private void btnINAddPay_Click(object sender, EventArgs e)
        {
            if (paymentValidation())
            {
                    SupplierObject sp = new SupplierObject();
                    StockObject st = new StockObject();

                    sp.supplierID = cmbINsupPay.Text;
                    sp.paidDate = dtpINsupPay.Value;
                    sp.paidAmt = Convert.ToDouble(txtINpaidAm.Text);
                    st.inventoryID = cmbINinvPay.Text;

                    DialogResult dr;
                    dr = MessageBox.Show("Do you want to save the record", "Confirm", MessageBoxButtons.YesNo);

                    if (dr == DialogResult.Yes)
                    {
                        try
                        {
                            MegaCoolMethods mc = new MegaCoolMethods();
                            bool result = mc.addSupplierPayment(sp, st);

                            if (result)
                            {
                                MessageBox.Show("Successfully Saved", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                SuppliesFillGrid();
                                
                                clearPay();
                                
                                fillTotAmt();
                                
                            }
                            else
                            {
                                MessageBox.Show("Unable to Save", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }

                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void cmbINsupPay_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbINinvPay.Items.Clear();
            FillComboInventoryID();
        }

        //Clear Payment button click
        private void btnINclearPay_Click(object sender, EventArgs e)
        {
            clearPay();

            SuppliesFillGrid();
            btnINAddPay.Enabled = true;
            cmbINsupPay.Enabled = true;
            cmbINinvPay.Enabled = true;
            dtpINsupPay.Enabled = true;

        }

        //Update Supplier payment button click
        private void btnINupdPay_Click(object sender, EventArgs e)
        {
            if (paymentValidation())
            {
                SupplierObject sp = new SupplierObject();
                StockObject st = new StockObject();

                sp.supplierID = cmbINsupPay.Text;
                st.inventoryID = cmbINinvPay.Text;
                sp.paidDate = dtpINsupPay.Value;
                
                sp.paidAmt = Convert.ToDouble(txtINpaidAm.Text);

                try
                {
                    MegaCoolMethods mc = new MegaCoolMethods();
                    bool result = mc.editSupplierPayment(st, sp);

                    if (result)
                    {
                        MessageBox.Show("Successfully Edited", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        SuppliesFillGrid();
                        clearPay();
                        fillTotAmt();

                        btnINAddPay.Enabled = true;
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

        //Row click of Supplies grid
        private void dgvINpayment_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            cmbINsupPay.Text = dgvINpayment.Rows[e.RowIndex].Cells[1].Value.ToString();
            cmbINinvPay.Text = dgvINpayment.Rows[e.RowIndex].Cells[0].Value.ToString();
            dtpINsupPay.Text = dgvINpayment.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtINpaidAm.Text = dgvINpayment.Rows[e.RowIndex].Cells[4].Value.ToString();

            cmbINsupPay.Enabled = false;
            cmbINinvPay.Enabled = false;
            dtpINsupPay.Enabled = false;

            btnINAddPay.Enabled = false;
            
        }

        //Delete Supplier Payment button click
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (paymentValidation())
            {
                DialogResult dr;
                dr = MessageBox.Show("Do you want to delete the record", "Confirm", MessageBoxButtons.YesNo);

                if (dr == DialogResult.Yes)
                {
                    MegaCoolMethods mc = new MegaCoolMethods();

                    string ss = cmbINsupPay.Text;
                    string ii = cmbINinvPay.Text;
                    DateTime dt = dtpINsupPay.Value;

                    bool result = mc.deleteSupplierPayment(ss, ii, dt);

                    SuppliesFillGrid();
                    cmbINsupPay.Items.Clear();
                    FillComboSupplierID();

                    MessageBox.Show("Successfully Deleted");

                    clearPay();
                    cmbINsupPay.Enabled = true;
                    cmbINinvPay.Enabled = true;
                    btnINAddPay.Enabled = true;

                    dtpINsupPay.Enabled = true;

                }
            }
        }

        //Decrease Quantity button click event
        private void btnINundo_Click(object sender, EventArgs e)
        {
            StockObject stk = new StockObject();

            stk.productType = cmbINTypeReorder.Text;
            stk.make = cmbINMakeReorder.Text;
            stk.model = cmbINModelReorder.Text;

            if (UpdateStockValidation())
            {
                if (txtINinventoryIncrease.Text != "")
                {
                    stk.inventoryID = txtINinventoryIncrease.Text;

                    if (txtINdecrease.Text != "")
                    {
                        int decrease = Convert.ToInt32(txtINdecrease.Text);

                        if (decrease < 100 && decrease > 0)
                        {
                            DialogResult dr;
                            dr = MessageBox.Show("Do you want to decrese the quantity by " + txtINdecrease.Text + " ", "Confirm", MessageBoxButtons.YesNo);

                            if (dr == DialogResult.Yes)
                            {
                                try
                                {
                                    MegaCoolMethods mc = new MegaCoolMethods();
                                    bool result = mc.decreaseStock(stk, decrease);

                                    if (result)
                                    {
                                        MessageBox.Show("Successfully Saved", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        InventoryReorderFillGrid();
                                        InventoryIDincreasedFillGrid();
                                        txtINinventoryIncrease.Text = "";
                                        txtINincrease.Text = "";
                                        txtINdecrease.Text = "";

                                        ltbINreorder.Items.Clear();
                                        fillReorderListBox();


                                    }
                                    else
                                    {
                                        MessageBox.Show("Unable to Save", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }

                                catch (Exception ex)
                                {
                                    throw ex;
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Enter a valid amount to decrease");
                            txtINdecrease.Clear();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Fill the decreasing amount");
                    }
                }
                else
                {
                    MessageBox.Show("Fill the Inventory ID");
                }
            }
        }

        //Search button click of Payment
        private void btnINsearchPay_Click(object sender, EventArgs e)
        {
            SqlConnection con = ConnectionManager.GetConnection();

            if (con.State.ToString() == "Closed")
            {
                con.Open();
            }

            if (cmbINsupPay.Text != "")
            {
                if (cmbINinvPay.Text != "")
                {
                    SqlDataAdapter sda = new SqlDataAdapter("select sp.InventoryID,sp.SupplierID,sr.Name,sp.Date,sp.PaidAmount from SupplierPayment sp,Supplier sr where sp.SupplierID=sr.SupplierID and sp.SupplierID='" + cmbINsupPay.Text + "' and sp.InventoryID='" + cmbINinvPay.Text + "' ", con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dgvINpayment.DataSource = dt;
                    fillTotAmt();

                }
                else {

                    MessageBox.Show("Please select the Inventory ID");
                }
            }
            else {

                MessageBox.Show("Please select the Supplier ID");
            }
            con.Close();
        }

        //Demo butoon click for Payment
        private void btnINpayDemo_Click(object sender, EventArgs e)
        {
            cmbINsupPay.SelectedIndex = 1 ;
            cmbINinvPay.SelectedIndex = 0 ;
            dtpINsupPay.Text = "2016-05-10";
            txtINpaidAm.Text = "10000";
        }

        private void lblINpay_MouseClick(object sender, MouseEventArgs e)
        {

        }

        //Increase button click event
        private void btnINadd2_Click_2(object sender, EventArgs e)
        {
            StockObject stk = new StockObject();

            stk.productType = cmbINTypeReorder.Text;
            stk.make = cmbINMakeReorder.Text;
            stk.model = cmbINModelReorder.Text;

            if (UpdateStockValidation())
            {
                if (txtINinventoryIncrease.Text != "")
                {
                    stk.inventoryID = txtINinventoryIncrease.Text;

                    if (txtINincrease.Text != "")
                    {
                        int increase = Convert.ToInt32(txtINincrease.Text);

                        if (increase < 100 && increase > 0)
                        {
                            DialogResult dr;
                            dr = MessageBox.Show("Do you want to increase the quantity by " + txtINincrease.Text + " ", "Confirm", MessageBoxButtons.YesNo);

                            if (dr == DialogResult.Yes)
                            {
                                try
                                {
                                    MegaCoolMethods mc = new MegaCoolMethods();
                                    bool result = mc.increaseStock(stk, increase);

                                    if (result)
                                    {
                                        MessageBox.Show("Successfully Saved", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        InventoryReorderFillGrid();
                                        InventoryIDincreasedFillGrid();
                                        txtINinventoryIncrease.Text = "";
                                        txtINincrease.Text = "";
                                        txtINdecrease.Text = "";

                                        ltbINreorder.Items.Clear();
                                        fillReorderListBox();

                                    }
                                    else
                                    {
                                        MessageBox.Show("Unable to Save", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }

                                catch (Exception ex)
                                {
                                    throw ex;
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Enter a valid amount to increase");
                            txtINincrease.Clear();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Fill the increasing amount");
                    }
                }
                else
                {
                    MessageBox.Show("Fill the Inventory ID");
                }
            }
        }
            
      }      
}

