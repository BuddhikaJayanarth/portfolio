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
using System.Data.Sql;
using CrystalDecisions.CrystalReports.Engine;

namespace megacoolnew
{
    public partial class Offsite : Form
    {
        public Offsite()
        {
            InitializeComponent();
            PopulateInventoryComboBox();
            PopulateCIDComboBox();
            PopulateSIDComboBox();
            crystalReportViewer1.Hide();

        }

        public void fillassignedempdatagrid()
        {
            if (JID5Text.Text == "")
            {

                MessageBox.Show("Please fill the Job ID");
            }
            else
            {
                ConnectionManagerOffsite newconn = new ConnectionManagerOffsite();
                newconn.OpenCon();

                OffsiteObject off = new OffsiteObject();
                off.JobID = JID5Text.Text;

                SqlCommand checkJID = new SqlCommand("SELECT * FROM OffSiteJob WHERE ([JobID] = @JID)", ConnectionManagerOffsite.conn);
                checkJID.Parameters.AddWithValue("JID", off.JobID);
                SqlDataReader reader3 = checkJID.ExecuteReader();
                if (reader3.HasRows)
                {
                    reader3.Close();

                    off.AssDate = null;
                    newconn.OpenCon();
                    SqlCommand getUnDri = new SqlCommand("SELECT StartDate FROM OffSiteJob Where JobID='" + off.JobID + "'", ConnectionManagerOffsite.conn);
                    try
                    {
                        SqlDataReader dr2 = getUnDri.ExecuteReader();

                        while (dr2.Read())
                        {
                            off.AssDate = dr2["StartDate"].ToString();
                        }

                        dr2.Close();
                        dr2.Dispose();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }


                    newconn.OpenCon();

                    SqlDataAdapter sda1 = new SqlDataAdapter("Select E.EmployeeID, E.Name, W.WorkDate, P.PosName from Employee E, EmployeeWorkDates W, Position P where E.EmployeeID=W.EmpID AND E.Position=P.PositionID AND W.JobID='" + off.JobID + "'", ConnectionManagerOffsite.conn);

                    DataTable dt = new DataTable();

                    sda1.Fill(dt);

                    ScheduledataGridView.DataSource = dt;

                    AssEmpButt.Enabled = true;
                    AssVehButt.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Invalid Job Id");
                }
            }
        }

        public void fillassignedvehdatagrid()
        {
            if (JID5Text.Text == "")
            {

                MessageBox.Show("Please fill the Job ID");
            }
            else
            {
                ConnectionManagerOffsite newconn = new ConnectionManagerOffsite();
                newconn.OpenCon();

                OffsiteObject off = new OffsiteObject();
                off.JobID = JID5Text.Text;

                SqlCommand checkJID = new SqlCommand("SELECT * FROM OffSiteJob WHERE ([JobID] = @JID)", ConnectionManagerOffsite.conn);
                checkJID.Parameters.AddWithValue("JID", off.JobID);
                SqlDataReader reader3 = checkJID.ExecuteReader();
                if (reader3.HasRows)
                {
                    reader3.Close();

                    off.AssDate = null;
                    newconn.OpenCon();
                    SqlCommand getUnDri = new SqlCommand("SELECT StartDate FROM OffSiteJob Where JobID='" + off.JobID + "'", ConnectionManagerOffsite.conn);
                    try
                    {
                        SqlDataReader dr2 = getUnDri.ExecuteReader();

                        while (dr2.Read())
                        {
                            off.AssDate = dr2["StartDate"].ToString();
                        }

                        dr2.Close();
                        dr2.Dispose();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }


                    newconn.OpenCon();

                    SqlDataAdapter sda1 = new SqlDataAdapter("Select VH.VehicleNo, VH.Vehicle_Type, V.WorkDate from Vehicles VH, VehicleWorkDates V where VH.VehicleNo = V.VehicleNo AND V.JobID='" + off.JobID + "'", ConnectionManagerOffsite.conn);

                    DataTable dt = new DataTable();

                    sda1.Fill(dt);

                    ScheduledataGridView.DataSource = dt;

                    AssEmpButt.Enabled = true;
                    AssVehButt.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Invalid Job Id");
                }
            }
        }

        public void clearitemfields()
        {

            JID4text.Clear();
            InventorycomboBox1.SelectedItem = null;
            Itemtext.Clear();

        }

        public void PopulateAssEmpCombo(string tempJobId)
        {
            AssEmpCombo.Items.Clear();
            OffsiteObject off5 = new OffsiteObject();
            off5.JobID = tempJobId;
            Console.WriteLine(tempJobId);
            ConnectionManagerOffsite newconn = new ConnectionManagerOffsite();
            off5.AssDate = null;
            newconn.OpenCon();
            SqlCommand getUnDri = new SqlCommand("SELECT StartDate FROM OffSiteJob Where JobID='" + off5.JobID + "'", ConnectionManagerOffsite.conn);
            try
            {
                SqlDataReader dr2 = getUnDri.ExecuteReader();

                while (dr2.Read())
                {
                    off5.AssDate = dr2["StartDate"].ToString();
                }

                dr2.Close();
                dr2.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            newconn.OpenCon();
            SqlCommand getUnMech = new SqlCommand("Select E.EmployeeID, P.PosName From Employee E, Position P where E.Position=P.PositionID AND E.EmployeeID NOT IN (Select E.EmployeeID from Employee E, EmployeeWorkDates W where E.EmployeeID=W.EmpID AND W.WorkDate = '" + off5.AssDate + "' UNION Select E.EmployeeID from Employee E, EmployeeWorkDates W where E.EmployeeID = W.EmpID AND W.JobType = 'PJ' GROUP BY E.EmployeeID having MIN(W.WorkDate) <= '" + off5.AssDate + "')", ConnectionManagerOffsite.conn);
            Console.WriteLine(off5.AssDate);
            try
            {
                SqlDataReader dr = getUnMech.ExecuteReader();

                while (dr.Read())
                {
                    String AssMechCombostring = dr["EmployeeID"] + " " + dr["PosName"];
                    AssEmpCombo.Items.Add(AssMechCombostring);
                }

                dr.Close();
                dr.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }


        }

        public void PopulateUnassEmpCombo(string tempJobId)
        {
            UnassEmpCombo.Items.Clear();
            OffsiteObject off5 = new OffsiteObject();
            off5.JobID = tempJobId;
            ConnectionManagerOffsite newconn = new ConnectionManagerOffsite();
            off5.AssDate = null;
            newconn.OpenCon();
            SqlCommand getUnDri = new SqlCommand("SELECT StartDate FROM OffSiteJob Where JobID='" + off5.JobID + "'", ConnectionManagerOffsite.conn);
            try
            {
                SqlDataReader dr2 = getUnDri.ExecuteReader();

                while (dr2.Read())
                {
                    off5.AssDate = dr2["StartDate"].ToString();
                }

                dr2.Close();
                dr2.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            newconn.OpenCon();
            SqlCommand getUnMech = new SqlCommand("Select E.EmployeeID, P.PosName from Employee E, EmployeeWorkDates W, Position P where E.EmployeeID=W.EmpID AND E.Position=P.PositionID AND W.JobID='" + off5.JobID + "'", ConnectionManagerOffsite.conn);
            try
            {
                SqlDataReader dr = getUnMech.ExecuteReader();

                while (dr.Read())
                {
                    String AssMechCombostring = dr["EmployeeID"] + " " + dr["PosName"];
                    UnassEmpCombo.Items.Add(AssMechCombostring);
                }

                dr.Close();
                dr.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }


        }

        public void PopulateAssVehCombo(string tempJobId)
        {
            AssVehCombo.Items.Clear();
            OffsiteObject off5 = new OffsiteObject();
            off5.JobID = tempJobId;
            Console.WriteLine(tempJobId);
            ConnectionManagerOffsite newconn = new ConnectionManagerOffsite();
            off5.AssDate = null;
            newconn.OpenCon();
            SqlCommand getUnDri = new SqlCommand("SELECT StartDate FROM OffSiteJob Where JobID='" + off5.JobID + "'", ConnectionManagerOffsite.conn);
            try
            {
                SqlDataReader dr2 = getUnDri.ExecuteReader();

                while (dr2.Read())
                {
                    off5.AssDate = dr2["StartDate"].ToString();
                }

                dr2.Close();
                dr2.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            newconn.OpenCon();
            Console.WriteLine("Tried");
            SqlCommand getUnMech = new SqlCommand("Select VH.VehicleNo, VH.Vehicle_Type From Vehicles VH where VH.VehicleNo NOT IN (Select VH.VehicleNo from Vehicles VH, VehicleWorkDates V where VH.VehicleNo=V.VehicleNo AND V.WorkDate = '" + off5.AssDate + "' UNION Select VH.VehicleNo from Vehicles VH, VehicleWorkDates V where VH.VehicleNo = V.VehicleNo AND V.JobType = 'PJ' GROUP BY VH.VehicleNo having MIN(V.WorkDate) <= '" + off5.AssDate + "')", ConnectionManagerOffsite.conn);
            try
            {
                SqlDataReader dr = getUnMech.ExecuteReader();

                while (dr.Read())
                {
                    String AssMechCombostring = dr["VehicleNo"] + " " + dr["Vehicle_Type"];
                    AssVehCombo.Items.Add(AssMechCombostring);
                }

                dr.Close();
                dr.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }


        }

        public void PopulateUnassVehCombo(string tempJobId)
        {
            UnassVehCombo.Items.Clear();
            OffsiteObject off5 = new OffsiteObject();
            off5.JobID = tempJobId;
            Console.WriteLine(tempJobId);
            ConnectionManagerOffsite newconn = new ConnectionManagerOffsite();
            off5.AssDate = null;
            newconn.OpenCon();
            SqlCommand getUnDri = new SqlCommand("SELECT StartDate FROM OffSiteJob Where JobID='" + off5.JobID + "'", ConnectionManagerOffsite.conn);
            try
            {
                SqlDataReader dr2 = getUnDri.ExecuteReader();

                while (dr2.Read())
                {
                    off5.AssDate = dr2["StartDate"].ToString();
                }

                dr2.Close();
                dr2.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            newconn.OpenCon();
            SqlCommand getUnMech = new SqlCommand("Select VH.VehicleNo, VH.Vehicle_Type from Vehicles VH, VehicleWorkDates V where VH.VehicleNo = V.VehicleNo AND V.JobID='" + off5.JobID + "'", ConnectionManagerOffsite.conn);
            try
            {
                SqlDataReader dr = getUnMech.ExecuteReader();

                while (dr.Read())
                {
                    String AssMechCombostring = dr["VehicleNo"] + " " + dr["Vehicle_Type"];
                    UnassVehCombo.Items.Add(AssMechCombostring);
                }

                dr.Close();
                dr.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }


        }

        public void PopulateInventoryComboBox()
        {
            ConnectionManagerOffsite newconn = new ConnectionManagerOffsite();
            newconn.OpenCon();
            SqlCommand getinventory = new SqlCommand("SELECT InventoryID FROM Inventory Order by InventoryID ASC", ConnectionManagerOffsite.conn);

            try
            {
                SqlDataReader dr = getinventory.ExecuteReader();

                while (dr.Read())
                {
                    InventorycomboBox1.Items.Add(dr["InventoryID"]);
                }

                dr.Close();
                dr.Dispose();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void PopulateCIDComboBox()
        {
            ConnectionManagerOffsite newconn = new ConnectionManagerOffsite();
            newconn.OpenCon();
            SqlCommand getinventory = new SqlCommand("SELECT NIC FROM Customer Order by NIC ASC", ConnectionManagerOffsite.conn);

            try
            {
                SqlDataReader dr = getinventory.ExecuteReader();

                while (dr.Read())
                {
                    CIDcombobox.Items.Add(dr["NIC"]);
                }

                dr.Close();
                dr.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void PopulateSIDComboBox()
        {
            ConnectionManagerOffsite newconn = new ConnectionManagerOffsite();
            newconn.OpenCon();
            SqlCommand getinventory = new SqlCommand("SELECT EmployeeID FROM Employee Order by EmployeeID ASC", ConnectionManagerOffsite.conn);

            try
            {
                SqlDataReader dr = getinventory.ExecuteReader();

                while (dr.Read())
                {
                    SIDComboBox.Items.Add(dr["EmployeeID"]);
                }

                dr.Close();
                dr.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void fillwithalljobs()
        {
            ConnectionManagerOffsite newconn = new ConnectionManagerOffsite();
            newconn.OpenCon();

            SqlDataAdapter sda1 = new SqlDataAdapter("select o.JobID, o.JobType, o.JobStatus, o.StartDate, o.CustomerNIC from OffSiteJob o", ConnectionManagerOffsite.conn);

            DataTable dt = new DataTable();

            sda1.Fill(dt);

            OffsitejobsdataGridView.DataSource = dt;
        }

        public void Resetfields()
        {
            JID2text.Clear();
            CIDcombobox.Items.Clear();
            SIDComboBox.Items.Clear();
            ODJradio.Checked = false;
            LTPradio.Checked = false;
            JobDescrText.Clear();
            Addbutt.Enabled = true;
            Savebutt.Enabled = false;
            PopulateCIDComboBox();
            PopulateSIDComboBox();
        }

        private void dataGridView9_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label117_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (JID2text.Text != "")
            {
                ConnectionManagerOffsite newconn = new ConnectionManagerOffsite();
                newconn.OpenCon();

                SqlCommand checkJobID = new SqlCommand("SELECT * FROM OffSiteJob WHERE ([JobID] = @JobID)", ConnectionManagerOffsite.conn);
                checkJobID.Parameters.AddWithValue("@JobID", JID2text.Text);
                SqlDataReader reader = checkJobID.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Close();
                    Addbutt.Enabled = false;
                    Savebutt.Enabled = true;

                    newconn.OpenCon();

                    SqlCommand checkJobID2 = new SqlCommand("SELECT * FROM OffSiteJob WHERE ([JobID] = @JobID)", ConnectionManagerOffsite.conn);
                    checkJobID2.Parameters.AddWithValue("@JobID", JID2text.Text);
                    SqlDataReader readfilltextbox = checkJobID2.ExecuteReader();

                    while (readfilltextbox.Read())
                    {
                        CIDcombobox.Text = (readfilltextbox["customerNIC"].ToString());
                        SIDComboBox.Text = (readfilltextbox["SUPERVISOR"].ToString());
                        String Jobtypeforfill = (readfilltextbox["JobType"].ToString());
                        if (Jobtypeforfill == "RJ")
                        {
                            ODJradio.Checked = true;
                            LTPradio.Checked = false;
                        }
                        else
                        {
                            ODJradio.Checked = false;
                            LTPradio.Checked = true;
                        }
                        JobDescrText.Text = (readfilltextbox["JobDescription"].ToString());
                    }
                    readfilltextbox.Close();
                }
                else
                {
                    MessageBox.Show("Invalid Job ID");
                }



            }
            else
            {
                MessageBox.Show("Please fill in the Job ID");
            }


        }

        private void button41_Click(object sender, EventArgs e)
        {
            Resetfields();
        }

        private void button40_Click(object sender, EventArgs e)
        {
            String Jobradio;
            if (ODJradio.Checked)
            {
                Jobradio = "RJ";
            }
            else
            {
                Jobradio = "PJ";
            }

            if (CIDcombobox.Text == "" || SIDComboBox.Text == "" || Jobradio == "" || JobDescrText.Text == "")
            {

                MessageBox.Show("Please fill the all required feilds");
            }
            else
            {
                OffsiteObject Off = new OffsiteObject();
                Off.CID = CIDcombobox.Text;
                String CIDTextlen = CIDcombobox.Text.Length.ToString();
                if (CIDTextlen != "10")
                    MessageBox.Show("Customer NIC should be 10 characters long");
                else if (Off.CID.EndsWith("v") || Off.CID.EndsWith("V"))
                {


                    int i;
                    if (!int.TryParse(SIDComboBox.Text, out i))
                    {
                        MessageBox.Show("Supervisor ID should only contain numbers");
                        return;
                    }
                    else
                    {
                        ConnectionManagerOffsite newconn = new ConnectionManagerOffsite();
                        newconn.OpenCon();
                        SqlCommand checkCID = new SqlCommand("SELECT * FROM Customer WHERE ([NIC] = @CID)", ConnectionManagerOffsite.conn);
                        checkCID.Parameters.AddWithValue("@CID", CIDcombobox.Text);
                        SqlDataReader reader3 = checkCID.ExecuteReader();
                        if (reader3.HasRows)
                        {
                            reader3.Close();
                            SqlCommand checkSID = new SqlCommand("SELECT * FROM Employee WHERE ([EmployeeID] = @SID)", ConnectionManagerOffsite.conn);
                            checkSID.Parameters.AddWithValue("@SID", SIDComboBox.Text);
                            SqlDataReader reader2 = checkSID.ExecuteReader();
                            if (reader2.HasRows)
                            {
                                reader2.Close();
                                Off.SID = SIDComboBox.Text;

                                if (ODJradio.Checked)
                                {
                                    Off.JobType = "RJ";
                                }
                                else
                                {
                                    Off.JobType = "PJ";
                                }

                                Off.JobStatus = "ON";
                                Off.JobDescription = JobDescrText.Text;

                                DateTime time = DateTime.Now;
                                string format = "yyyy-MM-dd HH:MM:ss";
                                string inserttime = time.ToString(format);
                                Off.JobStartDate = inserttime;

                                if (Off.JobType == "RJ")
                                {
                                    Off.JobEndDate = inserttime;
                                }

                                ConnectionManagerOffsite newconn2 = new ConnectionManagerOffsite();
                                newconn2.OpenCon();

                                try
                                {
                                    SqlCommand comm = new SqlCommand();
                                    comm.Connection = ConnectionManagerOffsite.conn;
                                    comm.CommandText = "INSERT INTO OffSiteJob (JobType, JobStatus, Startdate, Enddate, JobDescription, CustomerNIC, Supervisor) values ('" + Off.JobType + "' , '" + Off.JobStatus + "' , '" + Off.JobStartDate + "' , '" + Off.JobEndDate + "' , '" + Off.JobDescription + "' , '" + Off.CID + "' , '" + Off.SID + "')";
                                    comm.ExecuteNonQuery();
                                }
                                catch (SqlException ex)
                                {
                                    Console.WriteLine(ex);
                                    throw ex;
                                }

                                MessageBox.Show("Job added");
                                fillwithalljobs();
                                Resetfields();
                                OPsearchbutt.Enabled = true;
                                AllJobButt.Enabled = false;

                            }
                            else
                            {
                                MessageBox.Show("Invalid Supervisor ID");
                            }

                        }
                        else
                        {
                            MessageBox.Show("Invalid Customer ID");
                        }
                    }

                }
                else
                {
                    MessageBox.Show("NIC should end with V or v");
                }


            }


        }

        private void OPsearchbutt_Click(object sender, EventArgs e)
        {
            ConnectionManagerOffsite newconn = new ConnectionManagerOffsite();
            newconn.OpenCon();

            SqlDataAdapter sda1 = new SqlDataAdapter("select o.JobID, o.JobType, o.JobStatus, o.StartDate, o.CustomerNIC from OffSiteJob o where o.JobStatus = 'ON' ", ConnectionManagerOffsite.conn);

            DataTable dt = new DataTable();

            sda1.Fill(dt);

            OffsitejobsdataGridView.DataSource = dt;

            CID2text.Clear();
            OPsearchbutt.Enabled = false;
            AllJobButt.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            fillwithalljobs();
            CID2text.Clear();
            OPsearchbutt.Enabled = true;
            AllJobButt.Enabled = false;
        }

        private void Savebutt_Click(object sender, EventArgs e)
        {
            String Jobradio;
            if (ODJradio.Checked)
            {
                Jobradio = "RJ";
            }
            else
            {
                Jobradio = "PJ";
            }

            if (CIDcombobox.Text == "" || SIDComboBox.Text == "" || Jobradio == "" || JobDescrText.Text == "" || JID2text.Text == "")
            {

                MessageBox.Show("Please fill the all required feilds including the Job ID");
            }
            else
            {
                OffsiteObject Off = new OffsiteObject();
                Off.CID = CIDcombobox.Text;
                String CIDTextlen = CIDcombobox.Text.Length.ToString();
                if (CIDTextlen != "10")
                    MessageBox.Show("Customer NIC should be 10 characters long");
                else if (Off.CID.EndsWith("v") || Off.CID.EndsWith("V"))
                {


                    int i;
                    if (!int.TryParse(SIDComboBox.Text, out i))
                    {
                        MessageBox.Show("Supervisor ID should only contain numbers");
                        return;
                    }
                    else
                    {
                        ConnectionManagerOffsite newconn = new ConnectionManagerOffsite();
                        newconn.OpenCon();
                        SqlCommand checkCID = new SqlCommand("SELECT * FROM OffSiteJob WHERE ([CustomerNIC] = @CID)", ConnectionManagerOffsite.conn);
                        checkCID.Parameters.AddWithValue("@CID", CIDcombobox.Text);
                        SqlDataReader reader3 = checkCID.ExecuteReader();
                        if (reader3.HasRows)
                        {
                            reader3.Close();
                            SqlCommand checkSID = new SqlCommand("SELECT * FROM OffSiteJob WHERE ([SUPERVISOR] = @SID)", ConnectionManagerOffsite.conn);
                            checkSID.Parameters.AddWithValue("@SID", SIDComboBox.Text);
                            SqlDataReader reader2 = checkSID.ExecuteReader();
                            if (reader2.HasRows)
                            {
                                reader2.Close();
                                Off.SID = SIDComboBox.Text;

                                if (ODJradio.Checked)
                                {
                                    Off.JobType = "RJ";
                                }
                                else
                                {
                                    Off.JobType = "PJ";
                                }

                                Off.JobStatus = "ON";
                                Off.JobDescription = JobDescrText.Text;
                                Off.IID = JID2text.Text;

                                DateTime time = DateTime.Now;
                                string format = "yyyy-MM-dd HH:MM:ss";
                                string inserttime = time.ToString(format);
                                Off.JobStartDate = inserttime;

                                if (Off.JobType == "RJ")
                                {
                                    Off.JobEndDate = inserttime;
                                }

                                ConnectionManagerOffsite newconn2 = new ConnectionManagerOffsite();
                                newconn2.OpenCon();

                                try
                                {
                                    SqlCommand comm = new SqlCommand();
                                    comm.Connection = ConnectionManagerOffsite.conn;
                                    comm.CommandText = "Update OffSiteJob SET JobType='" + Off.JobType + "', JobDescription='" + Off.JobDescription + "', CustomerNIC='" + Off.CID + "', Supervisor='" + Off.SID + "' WHERE JobID = '" + Off.IID + "'";
                                    comm.ExecuteNonQuery();
                                    Console.WriteLine("Out 1");
                                }
                                catch (SqlException ex)
                                {
                                    Console.WriteLine(ex);
                                    throw ex;
                                }

                                MessageBox.Show("Job Updated");
                                fillwithalljobs();
                                Resetfields();
                                OPsearchbutt.Enabled = true;
                                AllJobButt.Enabled = false;

                            }
                            else
                            {
                                MessageBox.Show("Invalid Supervisor ID");
                            }

                        }
                        else
                        {
                            MessageBox.Show("Invalid Customer ID");
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Customer NIC should end in either 'v' or 'V'");
                }


            }
        }

        private void Endbutt_Click(object sender, EventArgs e)
        {
            if (JID2text.Text != "")
            {
                ConnectionManagerOffsite newconn = new ConnectionManagerOffsite();
                newconn.OpenCon();

                SqlCommand checkJobID = new SqlCommand("SELECT * FROM OffSiteJob WHERE ([JobID] = @JobID)", ConnectionManagerOffsite.conn);
                checkJobID.Parameters.AddWithValue("@JobID", JID2text.Text);
                SqlDataReader reader = checkJobID.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Close();
                    OffsiteObject Off = new OffsiteObject();
                    Off.JobID = JID2text.Text;

                    try
                    {
                        SqlCommand comm = new SqlCommand();
                        comm.Connection = ConnectionManagerOffsite.conn;
                        comm.CommandText = "Update OffSiteJob SET JobStatus='FN' where JobID = '" + Off.JobID + "'";
                        comm.ExecuteNonQuery();
                        Console.WriteLine("Out 1");
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine(ex);
                        throw ex;
                    }

                    try
                    {
                        SqlCommand comm = new SqlCommand();
                        comm.Connection = ConnectionManagerOffsite.conn;
                        comm.CommandText = "Delete from EmployeeOffSiteJob where JobID='" + Off.JobID + "'";
                        comm.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine(ex);
                        throw ex;
                    }

                    try
                    {
                        SqlCommand comm = new SqlCommand();
                        comm.Connection = ConnectionManagerOffsite.conn;
                        comm.CommandText = "Delete from EmployeeWorkDates where JobID='" + Off.JobID + "'";
                        comm.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine(ex);
                        throw ex;
                    }

                    Resetfields();
                    fillwithalljobs();

                }
                else
                {
                    MessageBox.Show("Invalid Job ID");
                }



            }
            else
            {
                MessageBox.Show("Please fill in the Job ID");
            }
        }

        private void tabPage9_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void OngoingButt2_Click(object sender, EventArgs e)
        {
            JID3text.Clear();
            ConnectionManagerOffsite newconn = new ConnectionManagerOffsite();
            newconn.OpenCon();

            SqlDataAdapter sda1 = new SqlDataAdapter("SELECT distinct o.JobID, o.JobType, o.JobStatus, Count(r.JobID) AS 'No. of Items' FROM OffsiteJob o LEFT JOIN Reserves r ON o.JobID = r.JobID GROUP BY o.JobID, o.JobType, o.JobStatus;", ConnectionManagerOffsite.conn);

            DataTable dt = new DataTable();

            sda1.Fill(dt);

            ItemsdataGridView.DataSource = dt;

            OngoingButt2.Enabled = false;
        }

        private void ViewItemsbutt_Click(object sender, EventArgs e)
        {
            if (JID3text.Text == "")
            {

                MessageBox.Show("Please fill the Job ID");
            }
            else
            {
              ConnectionManagerOffsite newconn = new ConnectionManagerOffsite();
              newconn.OpenCon();

              OffsiteObject off = new OffsiteObject();
              off.JobID = JID3text.Text;

              SqlCommand checkJID = new SqlCommand("SELECT * FROM OffSiteJob WHERE ([JobID] = @JID)", ConnectionManagerOffsite.conn);
              checkJID.Parameters.AddWithValue("JID", off.JobID);
              SqlDataReader reader3 = checkJID.ExecuteReader();
              if (reader3.HasRows)
              {
                  reader3.Close();

                  newconn.OpenCon();

                  SqlDataAdapter sda1 = new SqlDataAdapter("Select JobID, InventoryID, ItemNo from Reserves where JobID = '"+ off.JobID +"'", ConnectionManagerOffsite.conn);

                  DataTable dt = new DataTable();

                  sda1.Fill(dt);

                  ItemsdataGridView.DataSource = dt;

                  OngoingButt2.Enabled = true;
              }
              else
              {
                  MessageBox.Show("Invalid Job Id");
              }
            }
        }

        private void Jobsearchbutt_Click(object sender, EventArgs e)
        {
                if (CID2text.TextLength != 10)
                    MessageBox.Show("Customer NIC should be 10 characters long");
                else if (!CID2text.ToString().EndsWith("v") || CIDcombobox.ToString().EndsWith("V"))
                    MessageBox.Show("Customer NIC should end in either 'v' or 'V'");
                else
                {
                    OffsiteObject off = new OffsiteObject();
                    off.CID = CID2text.Text;

                    ConnectionManagerOffsite newconn = new ConnectionManagerOffsite();
                    newconn.OpenCon();
                    SqlCommand checkCID = new SqlCommand("SELECT * FROM OffSiteJob WHERE ([CustomerNIC] = @CID)", ConnectionManagerOffsite.conn);
                    checkCID.Parameters.AddWithValue("@CID", off.CID);
                    SqlDataReader reader3 = checkCID.ExecuteReader();
                    if (reader3.HasRows)
                    {
                        reader3.Close();
                        off.CID = CID2text.Text;
                        Console.WriteLine(off.CID);
                        SqlDataAdapter sda1 = new SqlDataAdapter("select o.JobID, o.JobType, o.JobStatus, o.StartDate, o.CustomerNIC from OffSiteJob o where o.CustomerNIC = '"+ off.CID +"' ", ConnectionManagerOffsite.conn);

                        DataTable dt = new DataTable();

                        sda1.Fill(dt);

                        OffsitejobsdataGridView.DataSource = dt;

                        OPsearchbutt.Enabled = true;
                        AllJobButt.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Invalid Customer NIC");
                    }

                }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (JID.Text == "")
            {

                MessageBox.Show("Please fill the Job ID");
            }
            else
            {
                ConnectionManagerOffsite newconn = new ConnectionManagerOffsite();
                newconn.OpenCon();

                OffsiteObject off2 = new OffsiteObject();
                off2.JobID = JID4text.Text;
                Console.WriteLine(off2.JobID);
                SqlCommand checkJID = new SqlCommand("SELECT * FROM OffSiteJob WHERE ([JobID] = @JID)", ConnectionManagerOffsite.conn);
                checkJID.Parameters.AddWithValue("@JID", off2.JobID);
                SqlDataReader reader3 = checkJID.ExecuteReader();
                if (reader3.HasRows)
                {
                    reader3.Close();

                    if (InventorycomboBox1.Text == "")
                    {

                        MessageBox.Show("Please choose or fill in an Inventory ID");
                    }
                    else
                    {
                        newconn.OpenCon();

                        off2.IID = InventorycomboBox1.Text;

                        SqlCommand checkIID = new SqlCommand("SELECT * FROM Inventory WHERE ([InventoryID] = @IID)", ConnectionManagerOffsite.conn);
                        checkIID.Parameters.AddWithValue("@IID", off2.IID);
                        SqlDataReader reader4 = checkIID.ExecuteReader();
                        if (reader4.HasRows)
                        {
                            reader4.Close();

                            if (Itemtext.TextLength != 10)
                            {
                                MessageBox.Show("Item Number should be 10 characters");
                            }
                            else
                            {
                                off2.Item = Itemtext.Text;
                                try
                                {
                                    SqlCommand comm = new SqlCommand();
                                    comm.Connection = ConnectionManagerOffsite.conn;
                                    comm.CommandText = "INSERT INTO Reserves (JobID, InventoryID, ItemNo) values ('" + off2.JobID + "' , '" + off2.IID + "' , '" + off2.Item +"')";
                                    comm.ExecuteNonQuery();
                                    Console.WriteLine("Out 1");

                                    newconn.OpenCon();

                                    SqlDataAdapter sda1 = new SqlDataAdapter("Select JobID, InventoryID, ItemNo from Reserves where JobID = '" + off2.JobID + "'", ConnectionManagerOffsite.conn);

                                    DataTable dt = new DataTable();

                                    sda1.Fill(dt);

                                    ItemsdataGridView.DataSource = dt;

                                    OngoingButt2.Enabled = true;

                                    clearitemfields();

                                }
                                catch (SqlException ex)
                                {
                                    Console.WriteLine(ex);
                                    throw ex;
                                }
                            }

                        }
                        else
                        {
                            MessageBox.Show("Invalid Inventory Id");
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Invalid Job Id");
                }
            }
        }

        private void IventorycomboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (JID.Text == "")
            {

                MessageBox.Show("Please fill the Job ID");
            }
            else
            {
                ConnectionManagerOffsite newconn = new ConnectionManagerOffsite();
                newconn.OpenCon();

                OffsiteObject off2 = new OffsiteObject();
                off2.JobID = JID4text.Text;
                Console.WriteLine(off2.JobID);
                SqlCommand checkJID = new SqlCommand("SELECT * FROM OffSiteJob WHERE ([JobID] = @JID)", ConnectionManagerOffsite.conn);
                checkJID.Parameters.AddWithValue("@JID", off2.JobID);
                SqlDataReader reader3 = checkJID.ExecuteReader();
                if (reader3.HasRows)
                {
                    reader3.Close();

                    if (InventorycomboBox1.Text == "")
                    {

                        MessageBox.Show("Please choose or fill in an Inventory ID");
                    }
                    else
                    {
                        newconn.OpenCon();

                        off2.IID = InventorycomboBox1.Text;

                        SqlCommand checkIID = new SqlCommand("SELECT * FROM Inventory WHERE ([InventoryID] = @IID)", ConnectionManagerOffsite.conn);
                        checkIID.Parameters.AddWithValue("@IID", off2.IID);
                        SqlDataReader reader4 = checkIID.ExecuteReader();
                        if (reader4.HasRows)
                        {
                            reader4.Close();

                            if (Itemtext.TextLength != 10)
                            {
                                MessageBox.Show("Item Number should be 10 characters");
                            }
                            else
                            {
                                newconn.OpenCon();
                                off2.Item = Itemtext.Text;
                                
                                SqlCommand checkItem = new SqlCommand("SELECT * FROM Reserves WHERE ([ItemNo] = @Item)", ConnectionManagerOffsite.conn);
                                checkItem.Parameters.AddWithValue("@Item", off2.Item);
                                SqlDataReader reader5 = checkItem.ExecuteReader();
                                if (reader5.HasRows)
                                {
                                    reader5.Close();

                                    try
                                    {
                                        SqlCommand comm = new SqlCommand();
                                        comm.Connection = ConnectionManagerOffsite.conn;
                                        comm.CommandText = "Delete from Reserves where ItemNo='"+ off2.Item +"'";
                                        comm.ExecuteNonQuery();
                                        Console.WriteLine("Out 1");

                                        newconn.OpenCon();

                                        SqlDataAdapter sda1 = new SqlDataAdapter("Select JobID, InventoryID, ItemNo from Reserves where JobID = '" + off2.JobID + "'", ConnectionManagerOffsite.conn);

                                        DataTable dt = new DataTable();

                                        sda1.Fill(dt);

                                        ItemsdataGridView.DataSource = dt;

                                        OngoingButt2.Enabled = true;

                                        clearitemfields();

                                    }
                                    catch (SqlException ex)
                                    {
                                        Console.WriteLine(ex);
                                        throw ex;
                                    }

                                }
                                else
                                {

                                 }

                            }

                        }
                        else
                        {
                            MessageBox.Show("Invalid Inventory Id");
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Invalid Job Id");
                }
            }
        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            if (JID6text.Text == "")
            {

                MessageBox.Show("Please fill the Job ID");
            }
            else
            {
                ConnectionManagerOffsite newconn = new ConnectionManagerOffsite();
                newconn.OpenCon();

                OffsiteObject off10 = new OffsiteObject();
                off10.JobID = JID6text.Text;

                SqlCommand checkJID = new SqlCommand("SELECT * FROM OffSiteJob WHERE ([JobID] = @JID)", ConnectionManagerOffsite.conn);
                checkJID.Parameters.AddWithValue("JID", off10.JobID);
                SqlDataReader reader3 = checkJID.ExecuteReader();
                if (reader3.HasRows)
                {

                    while (reader3.Read())
                    {
                        off10.JobID = reader3["JobID"].ToString();

                    }

                    reader3.Close();

                    if (UnassEmpCombo.Text == "")
                    {
                        MessageBox.Show("No Available Employees selected");
                    }
                    else
                    {

                        String RawUnassignEmp = UnassEmpCombo.Text;
                        string[] UnassignEmp = RawUnassignEmp.Split(' ');
                        off10.EmpID = UnassignEmp[0];
                        off10.EmpPos = UnassignEmp[1];

                        try
                        {
                            SqlCommand comm = new SqlCommand();
                            comm.Connection = ConnectionManagerOffsite.conn;
                            comm.CommandText = "Delete from EmployeeOffSiteJob where EmpId='" + off10.EmpID + "' AND JobID='"+ off10.JobID +"'";
                            comm.ExecuteNonQuery();
                        }
                        catch (SqlException ex)
                        {
                            Console.WriteLine(ex);
                            throw ex;
                        }

                        try
                        {
                            SqlCommand comm = new SqlCommand();
                            comm.Connection = ConnectionManagerOffsite.conn;
                            comm.CommandText = "Delete from EmployeeWorkDates where EmpId='" + off10.EmpID + "' AND JobID='" + off10.JobID + "'";
                            comm.ExecuteNonQuery();
                        }
                        catch (SqlException ex)
                        {
                            Console.WriteLine(ex);
                            throw ex;
                        }
                        JID5Text.Text = off10.JobID;
                        fillassignedempdatagrid();
                        JID6text.Clear();
                        AssEmpCombo.Items.Clear();
                        UnassEmpCombo.Items.Clear();
                    }

                }
                else
                {
                    MessageBox.Show("Invalid Job Id");
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            fillassignedempdatagrid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clearitemfields();
        }

        private void button13_Click(object sender, EventArgs e)
        {

        }

        private void JID4text_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (JID6text.Text == "")
            {

                MessageBox.Show("Please fill the Job ID");
            }
            else
            {
                ConnectionManagerOffsite newconn = new ConnectionManagerOffsite();
                newconn.OpenCon();

                OffsiteObject off = new OffsiteObject();
                off.JobID = JID6text.Text;

                SqlCommand checkJID = new SqlCommand("SELECT * FROM OffSiteJob WHERE ([JobID] = @JID)", ConnectionManagerOffsite.conn);
                checkJID.Parameters.AddWithValue("JID", off.JobID);
                SqlDataReader reader3 = checkJID.ExecuteReader();
                if (reader3.HasRows)
                {

                    while (reader3.Read())
                    {
                        off.JobID = reader3["JobID"].ToString();
                        off.JobType = reader3["JobType"].ToString();
                        off.AssDate = reader3["StartDate"].ToString();

                    }

                    reader3.Close();

                    if (AssEmpCombo.Text == "")
                    {
                        MessageBox.Show("No Available Employees selected");
                    }
                    else
                    {
                        
                    String RawAssignEmp = AssEmpCombo.Text;
                    string[] AssignEmp = RawAssignEmp.Split(' ');
                    off.EmpID = AssignEmp[0];
                    off.EmpPos = AssignEmp[1];

                    try
                    {
                        SqlCommand comm = new SqlCommand();
                        comm.Connection = ConnectionManagerOffsite.conn;
                        comm.CommandText = "INSERT INTO EmployeeOffSiteJob (JobID, EmpID) values ('" + off.JobID + "' , '" + off.EmpID + "')";
                        comm.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine(ex);
                        throw ex;
                    }

                    try
                    {
                        SqlCommand comm = new SqlCommand();
                        comm.Connection = ConnectionManagerOffsite.conn;
                        comm.CommandText = "INSERT INTO EmployeeWorkDates (EmpID, WorkDate, JobType, JobID) values ('" + off.EmpID + "' , '" + off.AssDate + "' , '" + off.JobType + "' , '" + off.JobID + "')";
                        comm.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine(ex);
                        throw ex;
                    }
                    JID5Text.Text = off.JobID;
                    fillassignedempdatagrid();
                    JID6text.Clear();
                    AssEmpCombo.Items.Clear();
                    UnassEmpCombo.Items.Clear();
                    }

                }
                else
                {
                    MessageBox.Show("Invalid Job Id");
                }
            }
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void JID6text_TextChanged(object sender, EventArgs e)
        {

        }

        private void JID6text_Leave(object sender, EventArgs e)
        {

            if (JID6text.Text == "")
            {
                MessageBox.Show("Please Enter a JobId");
            }
            else
            {
                ConnectionManagerOffsite newconn = new ConnectionManagerOffsite();
                newconn.OpenCon();

                OffsiteObject off = new OffsiteObject();
                off.JobID = JID6text.Text;

                SqlCommand checkJID = new SqlCommand("SELECT * FROM OffSiteJob WHERE ([JobID] = @JID)", ConnectionManagerOffsite.conn);
                checkJID.Parameters.AddWithValue("JID", off.JobID);
                SqlDataReader reader3 = checkJID.ExecuteReader();
                if (reader3.HasRows)
                {
                    reader3.Close();
                    string tempJobId;
                    tempJobId = JID6text.Text;
                    PopulateAssEmpCombo(tempJobId);
                    PopulateUnassEmpCombo(tempJobId);
                }
                else
                {
                    MessageBox.Show("Invalid JobID");
                }
            }

        }

        private void JID7text_Leave(object sender, EventArgs e)
        {
            if (JID7text.Text == "")
            {
                MessageBox.Show("Please Enter a JobId");
            }
            else
            {
                ConnectionManagerOffsite newconn = new ConnectionManagerOffsite();
                newconn.OpenCon();

                OffsiteObject off = new OffsiteObject();
                off.JobID = JID7text.Text;

                SqlCommand checkJID = new SqlCommand("SELECT * FROM OffSiteJob WHERE ([JobID] = @JID)", ConnectionManagerOffsite.conn);
                checkJID.Parameters.AddWithValue("JID", off.JobID);
                SqlDataReader reader3 = checkJID.ExecuteReader();
                if (reader3.HasRows)
                {
                    reader3.Close();
                    string tempJobId;
                    tempJobId = JID7text.Text;
                    PopulateAssVehCombo(tempJobId);
                    PopulateUnassVehCombo(tempJobId);
                }
                else
                {
                    MessageBox.Show("Invalid JobID");
                }
            }
        }

        private void JID7text_TextChanged(object sender, EventArgs e)
        {

        }

        private void AssignVehBut_Click(object sender, EventArgs e)
        {
            if (JID7text.Text == "")
            {

                MessageBox.Show("Please fill the Job ID");
            }
            else
            {
                ConnectionManagerOffsite newconn = new ConnectionManagerOffsite();
                newconn.OpenCon();

                OffsiteObject off = new OffsiteObject();
                off.JobID = JID7text.Text;

                SqlCommand checkJID = new SqlCommand("SELECT * FROM OffSiteJob WHERE ([JobID] = @JID)", ConnectionManagerOffsite.conn);
                checkJID.Parameters.AddWithValue("JID", off.JobID);
                SqlDataReader reader3 = checkJID.ExecuteReader();
                if (reader3.HasRows)
                {

                    while (reader3.Read())
                    {
                        off.JobID = reader3["JobID"].ToString();
                        off.JobType = reader3["JobType"].ToString();
                        off.AssDate = reader3["StartDate"].ToString();

                    }

                    reader3.Close();

                    if (AssVehCombo.Text == "")
                    {
                        MessageBox.Show("No Available Vehicles selected");
                    }
                    else
                    {

                        String RawAssignVeh = AssVehCombo.Text;
                        string[] AssignVeh = RawAssignVeh.Split(' ');
                        off.VehID = AssignVeh[0];
                        off.VehTy = AssignVeh[1];

                        try
                        {
                            SqlCommand comm = new SqlCommand();
                            comm.Connection = ConnectionManagerOffsite.conn;
                            comm.CommandText = "INSERT INTO OffSiteJobVehicle (JobID, VehicleNo) values ('" + off.JobID + "' , '" + off.VehID + "')";
                            comm.ExecuteNonQuery();
                        }
                        catch (SqlException ex)
                        {
                            Console.WriteLine(ex);
                            throw ex;
                        }

                        try
                        {
                            SqlCommand comm = new SqlCommand();
                            comm.Connection = ConnectionManagerOffsite.conn;
                            comm.CommandText = "INSERT INTO VehicleWorkDates (VehicleNo, WorkDate, JobType, JobID) values ('" + off.VehID + "' , '" + off.AssDate + "' , '" + off.JobType + "' , '" + off.JobID + "')";
                            comm.ExecuteNonQuery();
                        }
                        catch (SqlException ex)
                        {
                            Console.WriteLine(ex);
                            throw ex;
                        }
                        JID5Text.Text = off.JobID;
                        fillassignedvehdatagrid();
                        JID7text.Clear();
                        AssVehCombo.Items.Clear();
                        UnassVehCombo.Items.Clear();
                    }

                }
                else
                {
                    MessageBox.Show("Invalid Job Id");
                }
            }
        }

        private void UnassignVehBut_Click(object sender, EventArgs e)
        {
            if (JID7text.Text == "")
            {

                MessageBox.Show("Please fill the Job ID");
            }
            else
            {
                ConnectionManagerOffsite newconn = new ConnectionManagerOffsite();
                newconn.OpenCon();

                OffsiteObject off = new OffsiteObject();
                off.JobID = JID7text.Text;

                SqlCommand checkJID = new SqlCommand("SELECT * FROM OffSiteJob WHERE ([JobID] = @JID)", ConnectionManagerOffsite.conn);
                checkJID.Parameters.AddWithValue("JID", off.JobID);
                SqlDataReader reader3 = checkJID.ExecuteReader();
                if (reader3.HasRows)
                {

                    while (reader3.Read())
                    {
                        off.JobID = reader3["JobID"].ToString();
                        off.JobType = reader3["JobType"].ToString();
                        off.AssDate = reader3["StartDate"].ToString();

                    }

                    reader3.Close();

                    if (UnassVehCombo.Text == "")
                    {
                        MessageBox.Show("No Available Vehicles selected");
                    }
                    else
                    {

                        String RawUnassignVeh = UnassVehCombo.Text;
                        string[] UnassignVeh = RawUnassignVeh.Split(' ');
                        off.VehID = UnassignVeh[0];
                        off.VehTy = UnassignVeh[1];

                        try
                        {
                            SqlCommand comm = new SqlCommand();
                            comm.Connection = ConnectionManagerOffsite.conn;
                            comm.CommandText = "Delete from OffSiteJobVehicle where JobID='" + off.JobID + "' AND  VehicleNo='" + off.VehID + "'";
                            comm.ExecuteNonQuery();
                        }
                        catch (SqlException ex)
                        {
                            Console.WriteLine(ex);
                            throw ex;
                        }

                        try
                        {
                            SqlCommand comm = new SqlCommand();
                            comm.Connection = ConnectionManagerOffsite.conn;
                            comm.CommandText = "Delete from VehicleWorkDates where JobID='" + off.JobID + "' AND  VehicleNo='" + off.VehID + "'";
                            comm.ExecuteNonQuery();
                        }
                        catch (SqlException ex)
                        {
                            Console.WriteLine(ex);
                            throw ex;
                        }
                        JID5Text.Text = off.JobID;
                        fillassignedvehdatagrid();
                        JID7text.Clear();
                        AssVehCombo.Items.Clear();
                        UnassVehCombo.Items.Clear();
                    }

                }
                else
                {
                    MessageBox.Show("Invalid Job Id");
                }
            }
        }

        private void AssVehButt_Click(object sender, EventArgs e)
        {
            fillassignedvehdatagrid();
        }

        private void UnassEmpCombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            crystalReportViewer1.Show();
            crystalReportViewer1.Refresh();
        }
    }
}
                    