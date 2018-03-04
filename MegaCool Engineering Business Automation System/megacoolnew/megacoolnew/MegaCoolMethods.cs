using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using megacoolnew.userObjects;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace megacoolnew
{
    public class MegaCoolMethods
    {

        //NOTIFICATION
        public void SendNotification(Notification not)
        {
            String q = "INSERT INTO Notification VALUES (@Notification,@cat,@cl)";
            SqlCommand cmd = new SqlCommand(q, con);
            cmd.Parameters.AddWithValue("@Notification", not.Description1);
            cmd.Parameters.AddWithValue("@cat", not.Category1);
            cmd.Parameters.AddWithValue("@cl", not.ClearanceLevel1);
            con.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error sending notification.\n\n" + ex);
            }
            con.Close();
        }


        //Employee
        SqlConnection con = ConnectionManager.GetConnection();

        //get the position salary
        public double getPositionSal(int position)
        {
            string q = "SELECT TOP 1 Salary FROM Position WHERE PositionID = '" + position + "'";
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataReader reader;
            double s;

            con.Open();
            try
            {
                reader = cmd.ExecuteReader();
                reader.Read();
                s = reader.GetDouble(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Retreiving the basic Salary for the above position\n" + ex);
                return 0;
            }
            con.Close();
            return s;
        }
        //ADD EMPLOYEE
        public bool AddEmployeeDetails(megacoolnew.userObjects.EmployeeObject emp)
        {
            bool status = false;
            String q1 = "INSERT INTO Employee VALUES(@name,@addr,@email,@dob,@nic,@home,@mobile,@sex,@status,@position,@basicsal,@pastexp,@qualification,@joindate)";
            String q2 = "SELECT TOP 1 EmployeeID FROM Employee ORDER BY EmployeeID Desc";

            SqlCommand cmd = new SqlCommand(q1, con);
            cmd.Parameters.AddWithValue("@name", emp.name);
            cmd.Parameters.AddWithValue("@addr", emp.address);
            cmd.Parameters.AddWithValue("@email", emp.email);
            cmd.Parameters.AddWithValue("@dob", emp.dob);
            cmd.Parameters.AddWithValue("@nic", emp.nic);
            cmd.Parameters.AddWithValue("@home", emp.home);
            cmd.Parameters.AddWithValue("@mobile", emp.mobile);
            cmd.Parameters.AddWithValue("@sex", emp.sex);
            cmd.Parameters.AddWithValue("@status", emp.status);
            cmd.Parameters.AddWithValue("@position", emp.position);
            cmd.Parameters.AddWithValue("@basicsal", emp.basicsal);
            cmd.Parameters.AddWithValue("@pastexp", emp.pastexp);
            cmd.Parameters.AddWithValue("@joindate", emp.joindate);
            cmd.Parameters.AddWithValue("@qualification", emp.qualification);

            //getting the employee id of the newly added user
            SqlCommand cmd2 = new SqlCommand(q2, con);
            SqlDataReader reader;

            con.Open();
            try
            {
                cmd.ExecuteNonQuery();
                reader = cmd2.ExecuteReader();
                reader.Read();
                int id = reader.GetInt32(0);
                MessageBox.Show("Employee added successfully\nEmployee ID is " + id);

                if (emp.position == 2)
                {
                    string q3 = "insert into EmpDriver values(" + id + ",'" + emp.name + "','A')";
                    SqlCommand cmd3 = new SqlCommand(q3, con);
                    reader.Close();
                    cmd3.ExecuteNonQuery();
                }
                status = true;
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    MessageBox.Show("This employees is already added");
                    status = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex + "\nError adding employess");
                status = false;
            }

            con.Close();
            return status;
        }
        //Employees grid view
        public DataTable loadEmployees()
        {
            //  SqlConnection con = ConnectionManager.GetConnection();

            DataTable dt = new DataTable();

            String q1 = "SELECT * FROM Employee";
            SqlCommand cmd = new SqlCommand(q1, con);
            SqlDataReader reader;

            con.Open();
            try
            {
                reader = cmd.ExecuteReader();
                dt.Load(reader);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Reading from database\n" + ex);
            }

            con.Close();
            return (dt);
        }
        //Load any GridView
        public DataTable loadGridView(String q)
        {
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataReader reader;

            con.Open();
            try
            {
                reader = cmd.ExecuteReader();
                dt.Load(reader);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Reading from database\n" + ex);
            }
            con.Close();
            return (dt);
        }
        //Update Employee Details
        public void UpdateEmployeeDetails(EmployeeObject emp)
        {
            String q = "UPDATE Employee SET Mobile=@mobile,Home=@home,Address=@addr,MaritalStatus=@status,Email=@email WHERE EmployeeID = @empid";

            SqlCommand cmd = new SqlCommand(q, con);

            cmd.Parameters.AddWithValue("@mobile", emp.mobile);
            cmd.Parameters.AddWithValue("@home", emp.home);
            cmd.Parameters.AddWithValue("@addr", emp.address);
            cmd.Parameters.AddWithValue("@email", emp.email);
            cmd.Parameters.AddWithValue("@status", emp.status);
            cmd.Parameters.AddWithValue("@empid", emp.empid);

            con.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Updating\n" + ex);
            }
            MessageBox.Show("Employee details updated successfully");
            con.Close();
        }
        //Give Promotion or Salary Increments
        public void PromoteEmployee(EmployeeObject emp, string reason, int oldpos, double oldsal)
        {
            String OldPos = "";
            String NewPos = "";

            String q = "UPDATE Employee SET Position = @pos, BasicSalary = @bs WHERE EmployeeID = @empid";
            String q2 = "INSERT INTO Promotion VALUES (@eid,@date,@reason,@oldpos,@newpos,@oldsal,@newsal)";
            String q3 = "SELECT PosName FROM Position WHERE PositionID = @id";

            SqlCommand cmd3 = new SqlCommand(q3, con);
            cmd3.Parameters.AddWithValue("@id", oldpos);

            SqlCommand cmd4 = new SqlCommand(q3, con);
            cmd4.Parameters.AddWithValue("@id", emp.position);

            SqlDataReader reader;
            con.Open();
            try
            {
                reader = cmd3.ExecuteReader();
                reader.Read();
                OldPos = reader.GetString(0);
                reader.Close();
                reader = cmd4.ExecuteReader();
                reader.Read();
                NewPos = reader.GetString(0);
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }

            SqlCommand cmd = new SqlCommand(q, con);
            cmd.Parameters.AddWithValue("@pos", emp.position);
            cmd.Parameters.AddWithValue("@bs", emp.basicsal);
            cmd.Parameters.AddWithValue("@empid", emp.empid);

            SqlCommand cmd2 = new SqlCommand(q2, con);
            cmd2.Parameters.AddWithValue("@eid", emp.empid);
            cmd2.Parameters.AddWithValue("@date", DateTime.Today);
            cmd2.Parameters.AddWithValue("@reason", reason);
            cmd2.Parameters.AddWithValue("@oldpos", OldPos);
            cmd2.Parameters.AddWithValue("@newpos", NewPos);
            cmd2.Parameters.AddWithValue("@oldsal", oldsal);
            cmd2.Parameters.AddWithValue("@newsal", emp.basicsal);

            try
            {

                cmd2.ExecuteNonQuery();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Employee is Promoted");
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    MessageBox.Show("Sorry you cannot promote this employee again today");
                }
                else
                {
                    MessageBox.Show("Error Updating the Database\n\n" + ex);
                }
            }
            con.Close();
        }
        //Delete Employees
        public void DeleteEmployee(int id)
        {
            string q = "DELETE FROM Employee Where EmployeeID = '" + id + "'";
            SqlCommand cmd = new SqlCommand(q, con);
            con.Open();

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Employee Deleted Successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Employee could not be deleted\n\n" + ex);
            }
            con.Close();
        }
        //Load positions into combo boxes
        public DataTable LoadPositionComboBox()
        {
            con.Open();
            String q = "SELECT PositionID, PosName FROM Position";
            SqlDataReader reader;
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(q, con);
            try
            {
                reader = cmd.ExecuteReader();
                dt.Load(reader);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading the positions\n\n" + ex);
            }
            con.Close();
            return dt;
        }
        //Load Attendance Position Combo Box
        public String[] AttendancePositionCB()
        {
            String[] posNames;
            String q = "Select PosName FROM Position";
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataReader reader;
            List<String> lst = new List<String>();
            con.Open();
            try
            {
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lst.Add(reader.GetString(0));
                }
            }
            catch (Exception ex)
            {
                lst.Add("Error");
                MessageBox.Show("Error \n\n" + ex);
            }
            con.Close();
            posNames = lst.ToArray();
            return posNames;
        }
        //Load allowances into combo boxes
        public DataTable LoadAllowanceComboBox()
        {
            con.Open();
            String q = "SELECT a.AllowanceID, a.Name FROM Allowances a";
            SqlDataReader reader;
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(q, con);
            try
            {
                reader = cmd.ExecuteReader();
                dt.Load(reader);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading the allowances\n\n" + ex);
            }
            con.Close();
            return dt;
        }
        //ADD POSITIONS
        public bool AddPosition(Positions ps)
        {
            String q = "INSERT INTO Position VALUES (@pname,@bsal,@otrate)";
            SqlCommand cmd = new SqlCommand(q, con);
            cmd.Parameters.AddWithValue("@pname", ps.posName);
            cmd.Parameters.AddWithValue("@bsal", ps.bsal);
            cmd.Parameters.AddWithValue("@otrate", ps.otrate);

            con.Open();
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Position added successfully");
                con.Close();
                return true;
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    MessageBox.Show("This Position is already existing");
                }
                else
                {
                    MessageBox.Show("Error adding new position\n\n" + ex);
                }
                con.Close();
                return false;
            }
        }

        public bool UpdatePositionDetails(Positions ps)
        {
            string q = "UPDATE Position SET Salary = @bsal,OTRate = @otrate WHERE PositionID = @id";
            SqlCommand cmd = new SqlCommand(q, con);
            cmd.Parameters.AddWithValue("@bsal", ps.bsal);
            cmd.Parameters.AddWithValue("@otrate", ps.otrate);
            cmd.Parameters.AddWithValue("@id", ps.id);

            con.Open();
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Position details upated successfully");
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Updating Position details\n\n" + ex);
                con.Close();
                return false;
            }

        }

        public bool DeletePosition(Positions ps)
        {
            String q = "DELETE FROM Position WHERE PositionID = '" + ps.id + "'";
            SqlCommand cmd = new SqlCommand(q, con);

            con.Open();
            try
            {
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Position Deleted Successfully");
                return true;
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547)
                {
                    MessageBox.Show("There are Employees Working currently working under this positiin\nYou cannot delete this position");
                }
                else
                {
                    MessageBox.Show("Error Deleting the position\n\n" + ex);
                }
                con.Close();
                return false;
            }
        }
        //ADD NEW ALLOWANCE
        public bool AddNewAllowance(String name)
        {
            string q = "INSERT INTO Allowances VALUES('" + name + "')";
            SqlCommand cmd = new SqlCommand(q, con);

            con.Open();
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Allowance successfully added.");
                con.Close();
                return true;
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    MessageBox.Show("This allowance is already added.");
                }
                else
                {
                    MessageBox.Show("Error adding the allowance\n\n" + ex);
                }
                con.Close();
                return false;
            }
        }
        //FIX THE ALLOWANCE AMOUNT TO A POSITION 
        public bool FixAllowance(int posid, int allid, double amount)
        {
            String q = "INSERT INTO Position_Allowance VALUES (@posid,@aid,@amount)";
            SqlCommand cmd = new SqlCommand(q, con);
            cmd.Parameters.AddWithValue("@posid", posid);
            cmd.Parameters.AddWithValue("@aid", allid);
            cmd.Parameters.AddWithValue("@amount", amount);

            con.Open();
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Allowance is fixed successfully");
                con.Close();
                return true;
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    MessageBox.Show("This you have already assigned this allowance to this position\nif u need to update the amount go to the view allowance tab and then select update");
                }
                else
                {
                    MessageBox.Show("Error fixing the allowance!\n\n" + ex);
                }
                con.Close();
                return false;
            }
        }
        //UPDATE THE ALLOWANCE AMOUNT GIVING FROM A PARTICULAR POSITION
        public bool UpdateAllowance(int aid, String posname, double amount)
        {
            int posid;
            string q1 = "SELECT PositionID FROM Position WHERE PosName LIKE '%" + posname + "%'";
            String q2 = "UPDATE Position_Allowance SET Amount = @amount WHERE PositionID =@posid AND AllowanceID = @aid";

            SqlCommand cmd1 = new SqlCommand(q1, con);
            SqlCommand cmd2 = new SqlCommand(q2, con);
            SqlDataReader reader;

            con.Open();
            try
            {
                reader = cmd1.ExecuteReader();
                reader.Read();
                posid = reader.GetInt32(0);
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Couldnt find the position id of " + posname + ".\n\n" + ex);
                con.Close();
                return false;
            }

            cmd2.Parameters.AddWithValue("@amount", amount);
            cmd2.Parameters.AddWithValue("@posid", posid);
            cmd2.Parameters.AddWithValue("@aid", aid);

            try
            {
                cmd2.ExecuteNonQuery();
                MessageBox.Show("Allowance Successfully Updated");
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating the allowance.\n\n" + ex);
                con.Close();
                return false;
            }
        }
        //DELETE ALLOWANCES ADDIGNED FOR POSITIONS
        public bool DeletePositionAllowance(int allid, String posname)
        {
            int posid;
            string q1 = "SELECT PositionID FROM Position WHERE PosName LIKE '%" + posname + "%'";
            string q2 = "DELETE FROM Position_Allowance WHERE PositionID = @pid AND AllowanceID = @aid";

            SqlCommand cmd1 = new SqlCommand(q1, con);
            SqlCommand cmd2 = new SqlCommand(q2, con);

            SqlDataReader reader;

            con.Open();
            try
            {
                reader = cmd1.ExecuteReader();
                reader.Read();
                posid = reader.GetInt32(0);
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Couldnt find the position id of " + posname + ".\n\n" + ex);
                con.Close();
                return false;
            }

            cmd2.Parameters.AddWithValue("@pid", posid);
            cmd2.Parameters.AddWithValue("@aid", allid);

            try
            {
                cmd2.ExecuteNonQuery();
                MessageBox.Show("Allowance is successfully removed from the system");
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured when deleting\n\n" + ex);
                con.Close();
                return false;
            }
        }
        //REMOVE THE ALLOWANCE COMPLETELY FROM THE SYSTEM
        public bool DeleteAllowance(int aid)
        {
            string q = "DELETE FROM Allowances WHERE AllowanceID = '" + aid + "'";
            SqlCommand cmd = new SqlCommand(q, con);
            con.Open();
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Allowance deleted succecssfully");
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured while deleting the allowance\n\n" + ex);
                con.Close();
                return false;
            }
        }
        //OVER TIME
        public bool AddOTHours(int empid, int hours, DateTime dt)
        {
            bool status = false;

            string q = "INSERT INTO OT VALUES (@eid,@date,@hrs)";
            SqlCommand cmd = new SqlCommand(q, con);
            cmd.Parameters.AddWithValue("@eid", empid);
            cmd.Parameters.AddWithValue("@date", dt);
            cmd.Parameters.AddWithValue("@hrs", hours);

            con.Open();
            try
            {
                cmd.ExecuteNonQuery();
                status = true;
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    MessageBox.Show("This record is already added");
                }
                else
                {
                    MessageBox.Show("Error adding OT hours.\n\n" + ex);
                }
                status = false;
            }

            con.Close();
            return status;
        }
        //LEAVES..chk balance
        double annualbal = 0;
        Double casualbal = 0;
        int medicalbal = 0;
        int halfdaybal = 0;
        public bool CheckLeaveBalance(Leave le)
        {
            bool status = true;
            double annual;
            double casual;
            int medical;
            double other;
            int halfday;
            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;

            String q1 = "SELECT SUM(Annual) FROM Leave WHERE EmployeeID = '" + le.empid + "' AND YEAR(StartDate) = " + year;
            String q2 = "SELECT SUM(Casual) FROM Leave WHERE EmployeeID = '" + le.empid + "' AND YEAR(StartDate) = " + year;
            String q3 = "SELECT SUM(Medical) FROM Leave WHERE EmployeeID = '" + le.empid + "' AND YEAR(StartDate) = " + year;
            String q4 = "SELECT SUM(Other) FROM Leave WHERE EmployeeID = '" + le.empid + "' AND YEAR(StartDate) = " + year;
            String q5 = "SELECT SUM(Halfday) FROM Leave WHERE EmployeeID = '" + le.empid + "' AND LeaveType = 'Half Day' AND YEAR(StartDate) = " + year + " AND MONTH(StartDate) = " + month;

            SqlCommand cmd1 = new SqlCommand(q1, con);
            SqlCommand cmd2 = new SqlCommand(q2, con);
            SqlCommand cmd3 = new SqlCommand(q3, con);
            SqlCommand cmd4 = new SqlCommand(q4, con);
            SqlCommand cmd5 = new SqlCommand(q5, con);

            SqlDataReader reader;

            con.Open();
            try
            {
                reader = cmd1.ExecuteReader();
                reader.Read();
                if (reader[0] == DBNull.Value)
                    annual = 0;
                else
                    annual = Convert.ToDouble(reader.GetValue(0));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            reader.Dispose();
            try
            {
                reader = cmd2.ExecuteReader();
                reader.Read();
                if (reader[0] == DBNull.Value)
                    casual = 0;
                else
                    casual = Convert.ToDouble(reader.GetValue(0));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            reader.Dispose();
            try
            {
                reader = cmd3.ExecuteReader();
                reader.Read();
                if (reader[0] == DBNull.Value)
                    medical = 0;
                else
                    medical = reader.GetInt32(0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            reader.Dispose();
            try
            {
                reader = cmd4.ExecuteReader();
                reader.Read();
                if (reader[0] == DBNull.Value)
                    other = 0;
                else
                    other = Convert.ToDouble(reader.GetValue(0));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            reader.Dispose();
            try
            {
                reader = cmd5.ExecuteReader();
                reader.Read();
                if (reader[0] == DBNull.Value)
                    halfday = 0;
                else
                    halfday = reader.GetInt32(0);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            con.Close();

            annualbal = le.annualleaves - annual;
            casualbal = le.casualleaves - casual;
            medicalbal = le.medicalleaves - medical;
            halfdaybal = le.halfdayleaves - halfday;

            string msg1, msg2, msg3, msg4;
            if (casualbal > 0)
                msg2 = casual + " used\t" + casualbal + " left";
            else
                msg2 = casual + " used\t0 left";

            if (annualbal > 0)
                msg1 = annual + " used\t" + annualbal + " left";
            else
                msg1 = annual + " used\t0 left";
            if (medicalbal > 0)
                msg3 = medical + " used\t" + medicalbal + " left";
            else
                msg3 = medical + " used\t0 left";
            if (halfdaybal > 0)
                msg4 = halfday + " used\t" + halfdaybal + " left for this month";
            else
                msg4 = halfday + " used\t0 left for this month";

            String msg5;
            if (le.type == "Annual" && annualbal <= 0)
            {
                status = false;
                msg5 = "Please select another option as your annual leaves are over";
            }
            else if (le.type == "Annual" && annualbal > 0 && le.duration > annualbal)
            {
                status = false;
                msg5 = "Please select another option as the duration of your leave exceeds the number of annual leaves left";
            }
            else if (le.type == "Casual" && casualbal <= 0)
            {
                status = false;
                msg5 = "Please select another option as your casual leaves are over";
            }
            else if (le.type == "Casual" && casualbal > 0 && le.duration > casualbal)
            {
                status = false;
                msg5 = "Please select another option as the duration of your leave exceeds the number of casual leaves left";
            }
            else if (le.type == "Medical" && medicalbal <= 0)
            {
                status = false;
                msg5 = "Please select another option as your medical leaves are over";
            }
            else if (le.type == "Medical" && medicalbal > 0 && le.duration > medicalbal)
            {
                status = false;
                msg5 = "Please select another option as the duration of your leave exceeds the number of medical leaves left";
            }
            else if (le.type == "Half Day" && halfdaybal <= 0)
            {
                status = true;
                msg5 = "Please note that your half day leaves for this month are over";
            }
            else
            {
                status = true;
                msg5 = "";
            }


            String msg6 = other + " used";
            MessageBox.Show("Annual Leaves  \t" + msg1 + "\n" +
                            "Casual Leaves  \t" + msg2 + "\n" +
                            "Medical Leaves \t" + msg3 + "\n" +
                            "Half Day Leaves\t" + msg4 + "\n" +
                            "Other Leaves   \t" + msg6 + "\n\n" + msg5);
            return status;
        }
        //CHECK IF DATES CONFLICTS WITH ANOTHER LEAVE
        public bool checkIfOnLeave(Leave le)
        {
            bool status = false;
            String q = "select StartDate,EndDate From Leave WHERE ((@start BETWEEN StartDate AND EndDate)" +
                        " OR (@end BETWEEN StartDate AND EndDate)) AND EmployeeID = @eid";
            SqlDataReader reader;
            SqlCommand cmd = new SqlCommand(q, con);
            cmd.Parameters.AddWithValue("@start", le.start);
            cmd.Parameters.AddWithValue("@end", le.end);
            cmd.Parameters.AddWithValue("@eid", le.empid);

            con.Open();
            try
            {
                reader = cmd.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    status = true;
                }
                else
                {
                    status = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            con.Close();
            return status;
        }

        //SEND THE LEAVE REQUEST AND SAVE TO THE DATABASE
        public bool RequestLeave(Leave le)
        {
            bool status = false;
            double annual = 0.0;
            double casual = 0.0;
            double other = 0.0;
            int medical = 0;
            double total = 0.0;
            int halfday = 0;

            con.Open();
            if (le.type == "Other")
            {
                other = le.duration - casualbal - annualbal + 0.0;
                annual = le.duration - other - casualbal + 0.0;
                casual = le.duration - other - annual + 0.0;
                total = other + annual + casual;

                string q = "INSERT INTO Leave(EmployeeID,StartDate,EndDate,Reason,LeaveType,Casual,Annual,Medical,Halfday,Other,Duration,ApproveStatus)" +
                            " Values(@eid,@start,@end,@reason,@type,@casual,@annual,@medical,@halfday,@other,@duration,@status)";

                SqlCommand cmd1 = new SqlCommand(q, con);
                cmd1.Parameters.AddWithValue("@eid", le.empid);
                cmd1.Parameters.AddWithValue("@start", le.start);
                cmd1.Parameters.AddWithValue("@end", le.end);
                cmd1.Parameters.AddWithValue("@reason", le.reason);
                cmd1.Parameters.AddWithValue("@type", le.type);
                cmd1.Parameters.AddWithValue("@casual", casual);
                cmd1.Parameters.AddWithValue("@annual", annual);
                cmd1.Parameters.AddWithValue("@medical", medical);
                cmd1.Parameters.AddWithValue("@halfday", halfday);
                cmd1.Parameters.AddWithValue("@other", other);
                cmd1.Parameters.AddWithValue("@duration", total);
                cmd1.Parameters.AddWithValue("@status", le.status);

                try
                {
                    cmd1.ExecuteNonQuery();
                    status = true;
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627)
                    {
                        MessageBox.Show("You have already applied for a leave on " + le.start.Date);
                    }
                    else
                    {
                        MessageBox.Show("Error applying for leave\n\n" + ex);
                    }
                    status = false;

                }
            }
            else if (le.type == "Half Day")
            {
                String q = "INSERT INTO Leave Values(@eid,@start,@end,@reason,@type,@session,@casual,@annual,@medical,@halfday,@other,@duration,@status)";

                SqlCommand cmd = new SqlCommand(q, con);

                if (halfdaybal <= 0)
                {
                    if (casualbal > 0.5)
                    {
                        casualbal = casualbal - 0.5;
                        casual = 0.5;
                        halfday = 1;
                    }
                    else if (annualbal > 0.5)
                    {
                        annualbal = annualbal - 0.5;
                        annual = 0.5;
                        halfday = 1;
                    }
                    else
                    {
                        other = 0.5;
                        halfday = 1;
                    }
                    total = annual + casual + other;
                }
                else
                {
                    halfday = 1;
                    total = 0.5;
                }



                cmd.Parameters.AddWithValue("@eid", le.empid);
                cmd.Parameters.AddWithValue("@start", le.start);
                cmd.Parameters.AddWithValue("@end", le.end);
                cmd.Parameters.AddWithValue("@reason", le.reason);
                cmd.Parameters.AddWithValue("@type", le.type);
                cmd.Parameters.AddWithValue("@session", le.session);
                cmd.Parameters.AddWithValue("@status", le.status);
                cmd.Parameters.AddWithValue("@casual", casual);
                cmd.Parameters.AddWithValue("@annual", annual);
                cmd.Parameters.AddWithValue("@medical", medical);
                cmd.Parameters.AddWithValue("@halfday", halfday);
                cmd.Parameters.AddWithValue("@other", other);
                cmd.Parameters.AddWithValue("@duration", total);

                try
                {
                    cmd.ExecuteNonQuery();
                    status = true;
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627)
                    {
                        MessageBox.Show("You have already applied for a half day leave on " + le.start.Date);
                    }
                    else
                    {
                        MessageBox.Show("Error applying for half day leave\n\n" + ex);
                    }
                    status = false;

                }
            }
            else if (le.type == "Medical")
            {
                other = le.duration - medicalbal + 0.0;
                medical = (int)le.duration - medicalbal - (int)other;
                total = medical + other;

                string q = "INSERT INTO Leave(EmployeeID,StartDate,EndDate,Reason,LeaveType,Casual,Annual,Medical,Halfday,Other,Duration,ApproveStatus)" +
                            " Values(@eid,@start,@end,@reason,@type,@casual,@annual,@medical,@halfday,@other,@duration,@status)";

                SqlCommand cmd1 = new SqlCommand(q, con);
                cmd1.Parameters.AddWithValue("@eid", le.empid);
                cmd1.Parameters.AddWithValue("@start", le.start);
                cmd1.Parameters.AddWithValue("@end", le.end);
                cmd1.Parameters.AddWithValue("@reason", le.reason);
                cmd1.Parameters.AddWithValue("@type", le.type);
                cmd1.Parameters.AddWithValue("@casual", casual);
                cmd1.Parameters.AddWithValue("@annual", annual);
                cmd1.Parameters.AddWithValue("@medical", medical);
                cmd1.Parameters.AddWithValue("@halfday", halfday);
                cmd1.Parameters.AddWithValue("@other", other);
                cmd1.Parameters.AddWithValue("@duration", total);
                cmd1.Parameters.AddWithValue("@status", le.status);

                try
                {
                    cmd1.ExecuteNonQuery();
                    status = true;
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627)
                    {
                        MessageBox.Show("You have already applied for a medical leave on " + le.start.Date);
                    }
                    else
                    {
                        MessageBox.Show("Error applying for medical leave\n\n" + ex);
                    }
                    status = false;
                }
            }
            else if (le.type == "Casual")
            {
                casual = le.duration + 0.0;
                total = casual + annual + other;
                string q = "INSERT INTO Leave(EmployeeID,StartDate,EndDate,Reason,LeaveType,Casual,Annual,Medical,Halfday,Other,Duration,ApproveStatus)" +
                            " Values(@eid,@start,@end,@reason,@type,@casual,@annual,@medical,@halfday,@other,@duration,@status)";

                SqlCommand cmd1 = new SqlCommand(q, con);
                cmd1.Parameters.AddWithValue("@eid", le.empid);
                cmd1.Parameters.AddWithValue("@start", le.start);
                cmd1.Parameters.AddWithValue("@end", le.end);
                cmd1.Parameters.AddWithValue("@reason", le.reason);
                cmd1.Parameters.AddWithValue("@type", le.type);
                cmd1.Parameters.AddWithValue("@casual", casual);
                cmd1.Parameters.AddWithValue("@annual", annual);
                cmd1.Parameters.AddWithValue("@medical", medical);
                cmd1.Parameters.AddWithValue("@halfday", halfday);
                cmd1.Parameters.AddWithValue("@other", other);
                cmd1.Parameters.AddWithValue("@duration", total);
                cmd1.Parameters.AddWithValue("@status", le.status);

                try
                {
                    cmd1.ExecuteNonQuery();
                    status = true;
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627)
                    {
                        MessageBox.Show("You have already applied for a casual leave on " + le.start.Date);
                    }
                    else
                    {
                        MessageBox.Show("Error applying for casual leave\n\n" + ex);
                    }
                    status = false;
                }
            }
            else
            {
                annual = le.duration + 0.0;
                total = casual + annual + other;
                string q = "INSERT INTO Leave(EmployeeID,StartDate,EndDate,Reason,LeaveType,Casual,Annual,Medical,Halfday,Other,Duration,ApproveStatus)" +
                            " Values(@eid,@start,@end,@reason,@type,@casual,@annual,@medical,@halfday,@other,@duration,@status)";

                SqlCommand cmd1 = new SqlCommand(q, con);
                cmd1.Parameters.AddWithValue("@eid", le.empid);
                cmd1.Parameters.AddWithValue("@start", le.start);
                cmd1.Parameters.AddWithValue("@end", le.end);
                cmd1.Parameters.AddWithValue("@reason", le.reason);
                cmd1.Parameters.AddWithValue("@type", le.type);
                cmd1.Parameters.AddWithValue("@casual", casual);
                cmd1.Parameters.AddWithValue("@annual", annual);
                cmd1.Parameters.AddWithValue("@medical", medical);
                cmd1.Parameters.AddWithValue("@halfday", halfday);
                cmd1.Parameters.AddWithValue("@other", other);
                cmd1.Parameters.AddWithValue("@duration", total);
                cmd1.Parameters.AddWithValue("@status", le.status);

                try
                {
                    cmd1.ExecuteNonQuery();
                    status = true;
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627)
                    {
                        MessageBox.Show("You have already applied for a annual leave on " + le.start.Date);
                    }
                    else
                    {
                        MessageBox.Show("Error applying for annual leave\n\n" + ex);
                    }
                    status = false;
                }
            }
            con.Close();
            return status;
        }


        public bool EmployeeIn(Attendance att)
        {
            String q = "INSERT INTO Attendance(EmployeeID,Date,timeIn,Late,status) VALUES(@eid,@date,@in,@late,@status)";
            SqlCommand cmd = new SqlCommand(q, con);
            cmd.Parameters.AddWithValue("@eid", att.empid);
            cmd.Parameters.AddWithValue("@date", att.date);
            cmd.Parameters.AddWithValue("@in", att.timein);
            cmd.Parameters.AddWithValue("@late", att.late);
            cmd.Parameters.AddWithValue("@status", att.status);

            con.Open();
            try
            {
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    MessageBox.Show("This Employee is already marked as present");
                }
                else
                {
                    MessageBox.Show("Error\n\n" + ex);
                }
                con.Close();
                return false;
            }
        }

        public bool EmployeeOut(Attendance att)
        {
            TimeSpan ts;
            String q = "SELECT timeOut FROM Attendance WHERE EmployeeID = '" + att.empid + "'";
            String q2 = "UPDATE Attendance SET timeOut = @out WHERE EmployeeID = @eid AND Date = @date";

            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataReader reader;

            SqlCommand cmd2 = new SqlCommand(q2, con);
            cmd2.Parameters.AddWithValue("@out", att.timeout);
            cmd2.Parameters.AddWithValue("@eid", att.empid);
            cmd2.Parameters.AddWithValue("@date", att.date);

            con.Open();
            try
            {
                reader = cmd.ExecuteReader();
                reader.Read();
                ts = reader.GetTimeSpan(0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            reader.Close();
            if (ts == TimeSpan.Parse("00:00:00"))
            {
                try
                {
                    cmd2.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error\n\n" + ex);
                    con.Close();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("This is already marked as duty off");
                con.Close();
                return false;
            }

        }
        //SALARY CALCULATIONS
        public bool checkEmployeeExistence(int empid)
        {
            bool status = false;
            String q = "SELECT * FROM Employee WHERE EmployeeID = " + empid;
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataReader reader;
            con.Open();
            try
            {
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    status = true;
                }
                else
                    status = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error finding employee id\n\n" + ex);
            }
            con.Close();
            return status;
        }
        public Salary GetEmployeeDetails(Salary sal)
        {
            SqlDataReader reader;
            SqlCommand cmd;
            con.Open();

            String q1 = "SELECT e.Name,p.PosName,e.BasicSalary FROM Employee e,Position p " +
                        "WHERE EmployeeID = " + sal.empid + " AND e.Position = p.PositionID";

            cmd = new SqlCommand(q1, con);
            try
            {
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    sal.name = reader.GetString(0);
                    sal.position = reader.GetString(1);
                    sal.basicsal = Convert.ToDouble(reader.GetValue(2));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Getting the values\n\n" + ex);
            }
            con.Close();
            return sal;
        }
        //Calculate NO PAY
        public Salary CalculateNoPay(Salary sal)
        {
            Double others;
            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;
            int days = DateTime.DaysInMonth(year, month);
            String q = "SELECT SUM(Other) FROM Leave WHERE EmployeeID = '" + sal.empid + "' AND YEAR(StartDate) = " + year
                    + " AND MONTH(StartDate) = " + month;
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataReader reader;
            con.Open();
            try
            {
                reader = cmd.ExecuteReader();
                reader.Read();
                if (reader[0] != DBNull.Value)
                    others = reader.GetDouble(0);
                else
                    others = 0;
                sal.nopay = (sal.basicsal / days) * others;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Calculating NoPay\n\n" + ex);
            }

            con.Close();
            return sal;
        }
        //Calculate total allowances
        public Double CalculateTotalAllowances(Salary sal)
        {
            Double tot = 0;
            String q = "SELECT SUM(pa.Amount) FROM Position_Allowance pa, Allowances a,Position p " +
                  "WHERE  p.PosName = '" + sal.position + "' AND pa.PositionID = p.PositionID AND pa.AllowanceID = a.AllowanceID";
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataReader reader;

            con.Open();
            try
            {
                reader = cmd.ExecuteReader();
                reader.Read();
                if (reader[0] != DBNull.Value)
                    tot = reader.GetDouble(0);
                else
                    tot = 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Calculating the total allowances\n\n" + ex);
            }
            con.Close();
            return tot;
        }
        //Calculate OT Payments
        public Salary CalculateOTPayment(Salary sal)
        {
            int hours = 0;
            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;
            int days = DateTime.DaysInMonth(year, month);
            Double OTRate;
            String q = "SELECT SUM(NO_Of_Hours) FROM OT WHERE YEAR(Date) = " + year
                + " AND MONTH(Date) = " + month + " AND EmployeeID = " + sal.empid;
            SqlCommand cmd;
            SqlDataReader reader;

            con.Open();
            try
            {
                cmd = new SqlCommand(q, con);
                reader = cmd.ExecuteReader();
                reader.Read();
                if (reader[0] != DBNull.Value)
                    hours = reader.GetInt32(0);
                else
                    hours = 0;
                reader.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving OT hours worked\n\n" + ex);
            }

            String q2 = "SELECT p.OTRate FROM Employee e, Position p " +
                        "WHERE e.EmployeeID = " + sal.empid + " AND e.Position = p.PositionID";
            try
            {
                cmd = new SqlCommand(q2, con);
                reader = cmd.ExecuteReader();
                reader.Read();
                OTRate = Convert.ToDouble(reader.GetValue(0));
                sal.ot = (OTRate * hours);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving OT rate\n\n" + ex);
            }


            con.Close();
            return sal;
        }
        //DELETE AdditionalPayments
        public bool DeleteAdditionalPayment(int id)
        {
            bool status = false;
            String q = "DELETE FROM EmployeeAdditionalPayments WHERE id = " + id;
            SqlCommand cmd = new SqlCommand(q, con);
            con.Open();
            try
            {
                cmd.ExecuteNonQuery();
                status = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured when deleing.\n\n" + ex);
                status = false;
            }
            con.Close();
            return status;
        }
        public bool AddAdditionalPayment(int eid, String date, String r, Double a)
        {
            bool status = false;
            String q = "INSERT INTO EmployeeAdditionalPayments VALUES(@empid,@date,@reason,@amount)";
            SqlCommand cmd = new SqlCommand(q, con);
            cmd.Parameters.AddWithValue("@empid", eid);
            cmd.Parameters.AddWithValue("@date", date);
            cmd.Parameters.AddWithValue("@reason", r);
            cmd.Parameters.AddWithValue("@amount", a);

            con.Open();
            try
            {
                cmd.ExecuteNonQuery();
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
                MessageBox.Show("Error adding payment.\n\n" + ex);
            }
            con.Close();
            return status;
        }
        public Double getTotAdditionalPayment(int eid)
        {
            double tot = 0;
            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;
            String q = "SELECT SUM(Amount) FROM EmployeeAdditionalPayments " +
                        "WHERE EmployeeID = " + eid + " AND MONTH(Date) = " + month + " AND YEAR(Date) = " + year;
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataReader reader;
            con.Open();
            try
            {
                reader = cmd.ExecuteReader();
                reader.Read();
                if (reader[0] != DBNull.Value)
                    tot = reader.GetDouble(0);
                else
                    tot = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting the total of the additional payments.\n\n" + ex);
            }
            con.Close();
            return tot;
        }
        //Save salary details
        public void SaveSalaryDetails(Salary sal)
        {
            String date = DateTime.Today.Date.ToString("yyyy-MM-28");
            String q1 = "INSERT INTO Paid_Salary VALUES (@eid,@dt,@sal,@etf,@epfemp,@epfcom)";
            SqlCommand cmd = new SqlCommand(q1, con);
            cmd.Parameters.AddWithValue("@eid", sal.empid);
            cmd.Parameters.AddWithValue("@dt", date);
            cmd.Parameters.AddWithValue("@sal", sal.netsalary);
            cmd.Parameters.AddWithValue("@etf", sal.etf);
            cmd.Parameters.AddWithValue("@epfemp", sal.epfEmployeeAmount);
            cmd.Parameters.AddWithValue("@epfcom", sal.epfEmployerAmount);
            con.Open();
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("You have successfully saved the salary details of " + sal.name);
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    MessageBox.Show("You have already saved this employees salary details");
                }
                else
                {
                    MessageBox.Show("Error saving the salary details.\n\n" + ex);
                }
            }
            con.Close();
        }
        //RETRIEVE LEAVE DETAILS FOR NOTIFICATION CLICK
        public Leave GetLeaveDetails(int empid)
        {
            Leave le = new Leave();
            String q = "SELECT * FROM Leave WHERE StartDate IN ( SELECT MIN(StartDate) as 'minDate' " +
                        "FROM Leave where EmployeeID = " + empid + " AND ApproveStatus = 0 GROUP BY  EmployeeID )";
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataReader reader;
            con.Open();
            try
            {
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    le.empid = reader.GetInt32(0);
                    le.start = Convert.ToDateTime(reader.GetValue(1));
                    le.end = Convert.ToDateTime(reader.GetValue(2));
                    le.reason = reader.GetString(3);
                    le.type = reader.GetString(4);
                    if (reader[5] != DBNull.Value)
                        le.session = reader.GetString(5);
                    else
                        le.session = "";
                    le.duration = Convert.ToDouble(reader.GetValue(11));
                }
            }
            catch (Exception ex)
            {
                le.reason = "error";
                MessageBox.Show("Error retrieving leave details.\n\n" + ex);
            }
            con.Close();
            return le;
        }

        public bool ApproveLeave(int eid, DateTime dt)
        {
            bool status = false;
            String date = dt.ToString("yyyy-MM-dd");
            String q = "UPDATE Leave SET ApproveStatus = 1 WHERE EmployeeID = " + eid + " AND StartDate = '" + date + "'";
            SqlCommand cmd = new SqlCommand(q, con);
            con.Open();
            try
            {
                cmd.ExecuteNonQuery();
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
                MessageBox.Show("Error in approving\n\n" + ex);
            }
            con.Close();
            return status;
        }

        public void DeleteNotification(int notiID)
        {
            String q = "DELETE FROM Notification WHERE ID = " + notiID;
            SqlCommand cmd = new SqlCommand(q, con);
            con.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting the notification\n\n" + ex);
            }
            con.Close();
        }

        public bool deleteLeave(int eid, DateTime dt)
        {
            bool status = false;
            String date = dt.ToString("yyyy-MM-dd");
            String q = "DELETE FROM Leave WHERE EmployeeID = " + eid + " AND StartDate = '" + date + "'";
            SqlCommand cmd = new SqlCommand(q, con);
            con.Open();
            try
            {
                cmd.ExecuteNonQuery();
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
                MessageBox.Show("Error in rejecting\n\n" + ex);
            }
            con.Close();
            return status;
        }
//SHASHI PRABHA
        //Add New Expenditure
        public bool AddNewExpenditure(AccountObject objAccountObjects)
        {
            bool status = false;

            SqlConnection con = ConnectionManager.GetConnection();

            if (con.State.ToString() == "Closed")
            {
                con.Open();
            }
            try
            {
                SqlCommand newCmd = con.CreateCommand();

                newCmd.Connection = con;
                newCmd.CommandType = CommandType.Text;
                newCmd.CommandText = "insert into dbo.Expenditure(Description,Date,Amount,Category) values ('" + objAccountObjects.Description + "','" + objAccountObjects.Date + "','" + objAccountObjects.Amount + "','" + objAccountObjects.Expenditure + "')";
                newCmd.ExecuteNonQuery();
                status = true;

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return status;
        }


        //AddBudgetAllocation

        public bool AddBudgetAllocation(BudgetObject objBudgetObjects)
        {
            bool status = false;

            SqlConnection con = ConnectionManager.GetConnection();

            if (con.State.ToString() == "Closed")
            {
                con.Open();
            }
            try
            {
                SqlCommand newCmd = con.CreateCommand();

                newCmd.Connection = con;
                newCmd.CommandType = CommandType.Text;
                newCmd.CommandText = "insert into dbo.budget(Year,Month,Total_Budget,Payroll_Amn,Marketing_Amn,Insurance_Amn,Travel_Amn,Miselenius_Amn,Other_Amn,Payroll_Pres,Marketing_pres,Insurance_pres,Travel_pres ,Miselenius_pres,Other_pres) values ('" + objBudgetObjects.Year + "','" + objBudgetObjects.Month + "','" + objBudgetObjects.TotalBudget + "','" + objBudgetObjects.Payroll + "','" + objBudgetObjects.Marketing + "','" + objBudgetObjects.Insurance + "','" + objBudgetObjects.Travel + "','" + objBudgetObjects.Miselenius + "','" + objBudgetObjects.Other + "','" + objBudgetObjects.Payroll_Pres + "','" + objBudgetObjects.Marketing_pres + "','" + objBudgetObjects.Insurance_pres + "','" + objBudgetObjects.Travel_pres + "' ,'" + objBudgetObjects.Miselenius_pres + "','" + objBudgetObjects.Other_pres + "')";


                newCmd.ExecuteNonQuery();
                status = true;

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return status;
        }


        //AddTax

        public bool AddTax(TaxObject objTaxObjects)
        {
            bool status = false;

            SqlConnection con = ConnectionManager.GetConnection();

            if (con.State.ToString() == "Closed")
            {
                con.Open();
            }
            try
            {
                String q = "insert into dbo.Taxes(TaxFileNo,Date,Description,Amount) values (" + objTaxObjects.TaxFileNo + ",@dt,'" + objTaxObjects.Description + "','" + objTaxObjects.Amount + "')";
                SqlCommand cmd = new SqlCommand(q, con);
                SqlCommand newCmd = con.CreateCommand();

                //    newCmd.Connection = con;
                //  newCmd.CommandType = CommandType.Text;
                //  newCmd.CommandText = "insert into dbo.Taxes1(TaxFileNo,Date,Description,Amount) values (@dt,'"+objTaxObjects.Description +"','"+objTaxObjects.TaxFileNo+"','"+ objTaxObjects.Amount+"')";
                cmd.Parameters.AddWithValue("@dt", objTaxObjects.Date);
                cmd.ExecuteNonQuery();
                status = true;

            }
            catch (SqlException ex)
            {
                status = false;

                throw ex;
            }
            return status;
        }



        //Delete Expenditure
        public bool DeleteExpenditure(int ExpenditureID)
        {
            bool status = false;

            SqlConnection con = ConnectionManager.GetConnection();

            if (con.State.ToString() == "Closed")
            {
                con.Open();
            }

            try
            {
                SqlCommand newCmd = con.CreateCommand();
                newCmd.Connection = con;
                newCmd.CommandType = CommandType.Text;
                newCmd.CommandText = "DELETE FROM dbo.Expenditure WHERE ExpenditureID='" + ExpenditureID + "'";
                newCmd.ExecuteNonQuery();
                status = true;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return status;
        }

        //Delete Tax
        public bool DeleteTax(int TaxFileNo)
        {
            bool status = false;

            SqlConnection con = ConnectionManager.GetConnection();

            if (con.State.ToString() == "Closed")
            {
                con.Open();
            }

            try
            {
                SqlCommand newCmd = con.CreateCommand();
                newCmd.Connection = con;
                newCmd.CommandType = CommandType.Text;
                newCmd.CommandText = "DELETE FROM dbo.Taxes WHERE TaxFileNo='" + TaxFileNo + "'";
                newCmd.ExecuteNonQuery();
                status = true;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return status;
        }

        //saveNetProfit
        public bool SaveNetProfit(ProfitObject objProfitObjects)
        {
            bool status = false;

            SqlConnection con = ConnectionManager.GetConnection();

            if (con.State.ToString() == "Closed")
            {
                con.Open();
            }
            try
            {
                SqlCommand newCmd = con.CreateCommand();

                newCmd.Connection = con;
                newCmd.CommandType = CommandType.Text;
                newCmd.CommandText = "insert into NetProfit (Month,Payroll,Marketing,Insurance,Travel,Misallaneous,Bill,Tax,Other,Net_profit,Total_Expes,Year,Date) values ('" + objProfitObjects.Month + "','" + objProfitObjects.Payroll + "','" + objProfitObjects.Marketing + "','" + objProfitObjects.Insurance + "','" + objProfitObjects.Travel + "','" + objProfitObjects.Miselenius + "','" + objProfitObjects.Bill + "','" + objProfitObjects.Tax + "','" + objProfitObjects.Other + "','" + objProfitObjects.Net_Profit + "','" + objProfitObjects.Tot_Ex + "','" + objProfitObjects.YearNet + "','" + objProfitObjects.DateN + "')";
                newCmd.ExecuteNonQuery();
                status = true;

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return status;
        }

        //saveGrossProfit
        public bool SaveGrossProfit(ProfitObject objProfitObjects)
        {
            bool status = false;

            SqlConnection con = ConnectionManager.GetConnection();

            if (con.State.ToString() == "Closed")
            {
                con.Open();
            }
            try
            {
                SqlCommand newCmd = con.CreateCommand();

                newCmd.Connection = con;
                newCmd.CommandType = CommandType.Text;
                newCmd.CommandText = "insert into GrossProfit (Month,Product_Sales,Order_cost,Repair_Service,Offsite_Service,Total_Revenu,Gross_Profit,Delivery_Servises,Year,Date) values ('" + objProfitObjects.MonthGross + "','" + objProfitObjects.ProductSales + "','" + objProfitObjects.OrderCost + "','" + objProfitObjects.RepairServices + "','" + objProfitObjects.OffsiteServices + "','" + objProfitObjects.TotalIncome + "','" + objProfitObjects.GrossProfit + "','" + objProfitObjects.DeliveryServices + "','" + objProfitObjects.YearGross + "','" + objProfitObjects.DateG + "')";
                newCmd.ExecuteNonQuery();
                status = true;

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return status;
        }

        //saveAnnualProfit
        public bool SaveAnnualProfit(ProfitObject objProfitObjects)
        {
            bool status = false;

            SqlConnection con = ConnectionManager.GetConnection();

            if (con.State.ToString() == "Closed")
            {
                con.Open();
            }
            try
            {
                SqlCommand newCmd = con.CreateCommand();

                newCmd.Connection = con;
                newCmd.CommandType = CommandType.Text;
                newCmd.CommandText = "insert into AnnualProfit (Year,TotalProduct,TotalService,TotalIncome,TotalExpences,AnnualGrossProfit,AnnualNetProfit) values ('" + objProfitObjects.Year + "','" + objProfitObjects.TotalProduct + "','" + objProfitObjects.TotalService + "','" + objProfitObjects.TotalIncome1 + "','" + objProfitObjects.TotalExpences + "','" + objProfitObjects.AnnualGrossProfit + "','" + objProfitObjects.AnnualNetProfit + "')";
                newCmd.ExecuteNonQuery();
                status = true;

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return status;
        }



        //SHASHI PRABHA END
//SHASHI PRABHA END

//NIPUN 
		        // Add a new Repair Job to the system


        public bool AddNewRepairJob(RepairObject objRepairObjects, CustomerObject objCustomerObjects, EmployeeObject objEmployeeObjects)
        {
            bool status = false;

            SqlConnection con = ConnectionManager.GetConnection();

            if (con.State.ToString() == "Closed")
            {
                con.Open();
            }
            try
            {
                 SqlCommand newcmd2 = con.CreateCommand();

                 string q = "select NIC FROM Customer WHERE NIC = '" + objCustomerObjects.Nic + "'";
                
                newcmd2.CommandText = q;
                SqlDataReader reader = newcmd2.ExecuteReader();
                reader.Read();
                bool result = reader.HasRows;
                if (!result)
                {
                    MessageBox.Show("This NIC is not in the Database !");
                }



                else
                {
                    con.Close();

                    con.Open();


                    SqlCommand newCmd1 = con.CreateCommand();


                    newCmd1.Connection = con;
                    newCmd1.CommandType = CommandType.Text;
                    newCmd1.CommandText = "insert into dbo.Repair_Job(Type, JobStartDate, JobEndDate, Details, CustomerNIC, Supervisor ) values ('" + objRepairObjects.rType + "', '" + objRepairObjects.JobStartDate + "','" + objRepairObjects.JobEndDate + "' , '" + objRepairObjects.Details + "','" + objCustomerObjects.Nic + "', '" + objEmployeeObjects.empid + "')";


                    newCmd1.ExecuteNonQuery();



                    status = true;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return status;
        }

        // Add Inventory Items to the on going repair Job

        public bool RepairInventory(RepairObject objRepairObjects, StockObject objStockObjects)
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

                newCmd1.Connection = con;
                newCmd1.CommandType = CommandType.Text;
                newCmd1.CommandText = "insert into dbo.Repair_Inventory(InventoryID, JobID, ItemNo, SellingPrice) values ('" + objStockObjects.inventoryID + "', '" + objRepairObjects.JobID + "','" + objRepairObjects.ItemNo + "' , '" + objStockObjects.sellingPrice + "')";

                newCmd1.ExecuteNonQuery();

                newCmd3.Connection = con;
         
                string newQuan = "select Quantity from Inventory where InventoryID = '" + objStockObjects.inventoryID + "'";

                newCmd3.CommandText = newQuan;

                SqlDataReader reader = newCmd3.ExecuteReader();

                reader.Read();
                int x = reader.GetInt32(0);
                reader.Close();
              

                x = x - 1;
      
                newCmd2.Connection = con;
                newCmd2.CommandType = CommandType.Text;
                newCmd2.CommandText = "update Inventory set Quantity = " + x + " where InventoryID = '" + objStockObjects.inventoryID +"' ";

                newCmd2.ExecuteNonQuery(); 
             
                status = true;

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return status;
        }

        // Update Job details when it needed

        public bool UpdateRepairJob(EmployeeObject objEmployeeObjects, RepairObject objRepairObjects)
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


                newCmd1.Connection = con;
                newCmd1.CommandType = CommandType.Text;
                newCmd1.CommandText = " update Repair_Job set Type = '"+ objRepairObjects.rType +"', JobEndDate = '"+ objRepairObjects.JobEndDate +"', Details = '"+ objRepairObjects.Details +"', Supervisor = '" + objEmployeeObjects.empid + "' where JobID = '" + objRepairObjects.JobID + "' ";

            
                newCmd1.ExecuteNonQuery();


                status = true;

            }
            catch (Exception ex)
            {
               
                MessageBox.Show("" + ex);
            }
            return status;
        } 

        // Assign Employees to Repair Job 

        public bool EmpRepair(RepairObject objRepairObjects, EmployeeObject objEmployeeObjects)
        {
           bool status = false;

            SqlConnection con = ConnectionManager.GetConnection();

            if (con.State.ToString() == "Closed")
            {
                con.Open();
            }
            try
            {
                SqlCommand newcmd2 = con.CreateCommand();   
             
                string q = "select EmployeeID, JobID FROM Employee_Repair_Job WHERE EmployeeID = '"+ objEmployeeObjects.empid + "' AND JobID = '" + objRepairObjects.JobID +"'";
                
                newcmd2.CommandText = q;
                SqlDataReader reader = newcmd2.ExecuteReader();
                reader.Read();
                bool result = reader.HasRows;
                if (result)
                {
                    MessageBox.Show("This Employee already in this Job !");
                }

                

                else
                {
                    con.Close();

                    con.Open();

                    SqlCommand newCmd1 = con.CreateCommand();

                    newCmd1.Connection = con;
                    newCmd1.CommandType = CommandType.Text;

                    newCmd1.CommandText = "insert into dbo.Employee_Repair_Job(EmployeeID, JobID) values ('" + objEmployeeObjects.empid + "', '" + objRepairObjects.JobID + "')";

                    newCmd1.ExecuteNonQuery();


                    status = true;
                }

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return status;

        }

        //  Release Employees from Repair job

        public bool ReleaseEmployee(RepairObject objRepairObjects, EmployeeObject objEmployeeObjects)
        {
            bool status = false;

            SqlConnection con = ConnectionManager.GetConnection();

            if (con.State.ToString() == "Closed")
            {
                con.Open();
            }
            try
            {
               
                SqlCommand newcmd2 = con.CreateCommand();   
             
                string q = "select EmployeeID, JobID FROM Employee_Repair_Job WHERE EmployeeID = '"+ objEmployeeObjects.empid + "' AND JobID = '" + objRepairObjects.JobID +"'";
                
                newcmd2.CommandText = q;
                SqlDataReader reader = newcmd2.ExecuteReader();
                reader.Read();
                bool result = reader.HasRows;
                if (!result)
                {
                    MessageBox.Show("This Employee is not workig in this Job !");
                } 



                else 
                {
                    con.Close();

                    con.Open();

                    SqlCommand newCmd1 = con.CreateCommand();

                    newCmd1.Connection = con;

                    newCmd1.CommandType = CommandType.Text;

                    newCmd1.CommandText = "delete from Employee_Repair_Job where EmployeeID = '" + objEmployeeObjects.empid + "' AND JobID = '" + objRepairObjects.JobID + "'";

                    newCmd1.ExecuteNonQuery();


                    status = true;
                }        
        
            } 
            catch (SqlException ex)
            {
                MessageBox.Show("" + ex);
            }
            return status;

        } 
       

        internal bool UpdateRepairJob(RepairObject objRepair, EmployeeObject objEmployee)
        {
            throw new NotImplementedException();
        }

        internal bool ReleaseEmployee(EmployeeObject objEmployee, RepairObject objRepair)
        {
            throw new NotImplementedException();
        }



        //Load InventoryID into combo boxes
        public DataTable LoadInventoryIDComboBox()
        {
            SqlConnection con = ConnectionManager.GetConnection();

            con.Open();
            String q = "select InventoryID, ProductType  from Inventory";
            SqlDataReader reader;
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(q, con);
            try
            {
                reader = cmd.ExecuteReader();
                dt.Load(reader);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading the positions\n\n" + ex);
            }
            con.Close();
            return dt;
        }

        //Load Supervisor into combo boxes
        public DataTable LoadSupervisorComboBox()
        {
            SqlConnection con = ConnectionManager.GetConnection();

            con.Open();
            String q = "select EmployeeID, Name from Employee where Position = 6";
            SqlDataReader reader;
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(q, con);
            try
            {
                reader = cmd.ExecuteReader();
                dt.Load(reader);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading the positions\n\n" + ex);
            }
            con.Close();
            return dt;
        }
//NIPUN END

//THARAKA
        //Customer

        //Add New Customer
        public bool AddNewCustomer(CustomerObject objCustomerObjects)
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

                newCmd1.Connection = con;
                newCmd1.CommandType = CommandType.Text;
                newCmd1.CommandText = "insert into dbo.Customer(NIC,Name,Email,Address,Rate,CustomerType) values ('" + objCustomerObjects.Nic + "', '" + objCustomerObjects.CustomrName + "','" + objCustomerObjects.Email + "' , '" + objCustomerObjects.Address + "',0, '" + objCustomerObjects.CustomerType + "')";

                newCmd2.Connection = con;
                newCmd2.CommandType = CommandType.Text;
                newCmd2.CommandText = "insert into dbo.CustomerContact(NIC,ContactNo) values ('" + objCustomerObjects.Nic + "' , '" + objCustomerObjects.Phone + "')";


                newCmd1.ExecuteNonQuery();
                newCmd2.ExecuteNonQuery();

                status = true;

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return status;
        }

        //update Customer
        public bool EditCustomer(CustomerObject objCustomerObjects)
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

                newCmd1.Connection = con;
                newCmd1.CommandType = CommandType.Text;
                newCmd1.CommandText = "UPDATE dbo.Customer SET Name = '" + objCustomerObjects.CustomrName + "',Email='" + objCustomerObjects.Email + "',Address='" + objCustomerObjects.Address + "',Rate=" + objCustomerObjects.Rate + ",CustomerType='" + objCustomerObjects.CustomerType + "' where NIC = '" + objCustomerObjects.Nic + "'";

                newCmd2.Connection = con;
                newCmd2.CommandType = CommandType.Text;
                newCmd2.CommandText = "UPDATE dbo.CustomerContact SET ContactNo = '" + objCustomerObjects.Phone + "' where NIC = '" + objCustomerObjects.Nic + "'";


                newCmd1.ExecuteNonQuery();
                newCmd2.ExecuteNonQuery();

                status = true;

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return status;
        }


        //Delete Customer
        public bool DeleteCustomer(string nic)
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

                newCmd1.Connection = con;
                newCmd1.CommandType = CommandType.Text;
                newCmd1.CommandText = "DELETE FROM dbo.Customer WHERE NIC='" + nic + "'";

                newCmd2.Connection = con;
                newCmd2.CommandType = CommandType.Text;
                newCmd2.CommandText = "DELETE FROM dbo.CustomerContact WHERE NIC='" + nic + "'";


                newCmd2.ExecuteNonQuery();
                newCmd1.ExecuteNonQuery();


                status = true;

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return status;
        }


        //LOYALTY CARD

        //AddloyaltyCard
        public bool AddLoyaltyCustomer(CustomerObject objCustomerObjects)
        {
            bool status = false;

            SqlConnection con = ConnectionManager.GetConnection();

            if (con.State.ToString() == "Closed")
            {
                con.Open();
            }
            try
            {
                string nic = objCustomerObjects.Nic;
                SqlCommand newCmd1 = con.CreateCommand();
                SqlCommand newCmd2 = con.CreateCommand();

                newCmd1.Connection = con;
                newCmd1.CommandType = CommandType.Text;
                newCmd1.CommandText = "insert into dbo.CustomerLoyalatyCard(Card_No,NIC,Card_Points,CardType) values ('" + objCustomerObjects.CardNo + "','" + objCustomerObjects.Nic + "', " + objCustomerObjects.CardPoints + ",'" + objCustomerObjects.CardType + "' )";

                newCmd2.Connection = con;
                newCmd2.CommandType = CommandType.Text;
                newCmd2.CommandText = "UPDATE Customer set CustomerType = 'Loyalty' where NIC = '" + nic + "'";


                newCmd1.ExecuteNonQuery();
                newCmd2.ExecuteNonQuery();

                status = true;

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return status;
        }





        //update loyalty card
        public bool EditLoyaltyCard(CustomerObject objCustomerObjects)
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

                newCmd1.Connection = con;
                newCmd1.CommandType = CommandType.Text;
                newCmd1.CommandText = "UPDATE dbo.CustomerLoyalatyCard SET Card_No = '" + objCustomerObjects.CardNo + "' ,NIC = '" + objCustomerObjects.Nic + "', Card_Points = " + objCustomerObjects.CardPoints + ", CardType = '" + objCustomerObjects.CardType + "' where NIC = '" + objCustomerObjects.Nic + "'";

                newCmd1.ExecuteNonQuery();


                status = true;

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return status;
        }

        //Delete loyalty card
        public bool DeleteLoyaltyCard(string nic)
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

                newCmd1.Connection = con;
                newCmd1.CommandType = CommandType.Text;
                // newCmd1.CommandText = "DELETE FROM dbo.CustomerLoyalatyCard WHERE Card_No='" + cardno + "' and NIC = '"+nic+"'";
                newCmd1.CommandText = "DELETE FROM dbo.CustomerLoyalatyCard WHERE NIC = '" + nic + "'";
                newCmd1.ExecuteNonQuery();

                status = true;

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return status;
        }


        //rating
        public void rating()
        {
            SqlConnection con = ConnectionManager.GetConnection();

            SqlDataAdapter sda1 = new SqlDataAdapter("select NIC, sum(Amount) as total_amount from Invoice group by NIC order by sum(Amount) desc", con);

            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);


            foreach (DataRow dtRow in dt1.Rows)
            {
                int index = dt1.Rows.IndexOf(dtRow);
                int index1 = index + 1;
                string nic = dtRow.Field<string>("NIC");


                try
                {

                    if (con.State.ToString() == "Closed")
                    {
                        con.Open();
                    }
                    SqlCommand newCmd = con.CreateCommand();

                    newCmd.Connection = con;
                    newCmd.CommandType = CommandType.Text;
                    newCmd.CommandText = "UPDATE dbo.Customer SET Rate = " + index1 + "where NIC = '" + nic + "'";

                    newCmd.ExecuteNonQuery();


                }
                catch (SqlException ex)
                {
                    throw ex;
                }
                con.Close();
            }
        }

        //set cardtype according to rating
        public string setCardType(string nic)
        {


            SqlConnection con = ConnectionManager.GetConnection();
            if (con.State.ToString() == "Closed")
            {
                con.Open();
            }

            SqlDataAdapter sda1 = new SqlDataAdapter("select sum(Amount) as total_amount from Invoice where NIC = '" + nic + "' group by NIC ", con);

            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);

            string cardType = "";

            foreach (DataRow dtRow in dt1.Rows)
            {
                double totAmt = dtRow.Field<double>("total_amount");

                if (totAmt > 100000.00)
                {
                    cardType = "GOLD";

                }
                else if (totAmt > 50000.00)
                {
                    cardType = "SILVER";

                }
                else
                {
                    cardType = "BRONZE";

                }


            }
            return cardType;

        }


        //show messagge when customer reach to change the loyalty card type
        public void changeCardType(string nic)
        {
            string ct = "";
            SqlConnection con = ConnectionManager.GetConnection();
            if (con.State.ToString() == "Closed")
            {
                con.Open();
            }

            SqlDataAdapter sda1 = new SqlDataAdapter("select sum(Amount) as total_amount from Invoice where NIC = '" + nic + "' group by NIC  ", con);
            SqlDataAdapter sda2 = new SqlDataAdapter("select CardType from dbo.CustomerLoyalatyCard where NIC = '" + nic + "'", con);


            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);

            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);


            foreach (DataRow dt2Row in dt2.Rows)
            {
                ct = dt2Row.Field<string>("CardType");

            }



            foreach (DataRow dtRow in dt1.Rows)
            {
                double totAmt = dtRow.Field<double>("total_amount");
                DialogResult dr;

                if (totAmt >= 100000.00 && ct == "SILVER")
                {

                    dr = MessageBox.Show("Congratulations!!! You can be a GOLD card loyalty member now... Do you want to change the card type", "Confirm", MessageBoxButtons.YesNo);
                    if (dr.ToString() == "Yes")
                    {

                        customer cus = new customer(); //make customer form object
                        cus.Show(); //show customer form
                        cus.tb_cus_tabcontroller.SelectedTab = cus.tab_loyalitycard; //redirect to the customer form loyalty card tab
                        cus.txt_loy_nic.Text = nic; //get the nic of billing customer and put in cutomer form loyalty tab cus nic feild
                    }


                }
                else if (totAmt >= 100000.00 && ct == "BRONZE")
                {

                    dr = MessageBox.Show("Congratulations!!! You can be a GOLD card loyalty member now... Do you want to change the card type", "Confirm", MessageBoxButtons.YesNo);
                    if (dr.ToString() == "Yes")
                    {

                        customer cus = new customer();
                        cus.Show();
                        cus.tb_cus_tabcontroller.SelectedTab = cus.tab_loyalitycard;
                        cus.txt_loy_nic.Text = nic;
                    }


                }
                else if (totAmt >= 50000.00 && ct == "BRONZE")
                {
                    dr = MessageBox.Show("Congratulations!!! You can be a SILVER card loyalty member now...Do you want to change the card type", "Confirm", MessageBoxButtons.YesNo);
                    if (dr.ToString() == "Yes")
                    {

                        customer cus = new customer();
                        cus.Show();
                        cus.tb_cus_tabcontroller.SelectedTab = cus.tab_loyalitycard;
                        cus.txt_loy_nic.Text = nic;
                    }

                }

            }

        }


        //add points to loyalty card when invoice generate
        public void LoyaltyCardAddPoints(double Invoice_Amount, string nic)
        {

            double amount = Invoice_Amount;
            int tot_points = 0;
            int current_points = 0;

            SqlConnection con = ConnectionManager.GetConnection();

            if (con.State.ToString() == "Closed")
            {
                con.Open();
            }
            try
            {

                SqlCommand cmd1 = con.CreateCommand();
                SqlCommand cmd2 = con.CreateCommand();

                cmd1.Connection = con;
                cmd1.CommandType = CommandType.Text;

                cmd1.CommandText = "select Card_Points from dbo.CustomerLoyalatyCard where NIC ='" + nic + "'";


                SqlDataReader dr = cmd1.ExecuteReader();


                while (dr.Read())
                {
                    current_points = Convert.ToInt32(dr[0]);

                    if (amount >= 5000)
                        tot_points = current_points + 10;
                    else if (amount >= 4000)
                        tot_points = current_points + 8;
                    else if (amount >= 4000)
                        tot_points = current_points + 6;
                    else if (amount >= 3000)
                        tot_points = current_points + 4;
                    else if (amount >= 2000)
                        tot_points = current_points + 3;
                    else if (amount >= 1000)
                        tot_points = current_points + 2;
                    else if (amount >= 500)
                        tot_points = current_points + 1;
                    else
                        tot_points = current_points;

                }
                cmd2.Connection = con;
                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = "update 	dbo.CustomerLoyalatyCard set Card_Points = '" + tot_points + "' where NIC ='" + nic + "'";
                dr.Close();
                cmd2.ExecuteNonQuery();


            }
            catch (SqlException ex)
            {
                throw ex;
            }

        }

		
//THARAKA END

//POOJA
        // STOCK

        //Add Inventory
        public bool addInventory(StockObject objStock, SupplierObject objSupplier)
        {

            bool status = false;

            SqlConnection con = ConnectionManager.GetConnection();

            if (con.State.ToString() == "Closed")
            {
                con.Open();
            }

            try
            {

                SqlCommand cmd1 = con.CreateCommand();
                SqlCommand cmd2 = con.CreateCommand();

                cmd1.Connection = con;
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "insert into dbo.Inventory(InventoryID,ProductType,Make,Model,BuyingPrice,SellingPrice,Quantity) values('" + objStock.inventoryID + "','" + objStock.productType + "','" + objStock.make + "','" + objStock.model + "','" + objStock.buyingPrice + "','" + objStock.sellingPrice + "','" + objStock.quantity + "')";

                cmd2.Connection = con;
                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = "insert into dbo.Supplies(SupplierID,InventoryID) values('" + objSupplier.supplierID + "','" + objStock.inventoryID + "')";

                cmd1.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();

                status = true;

            }
            catch (SqlException ex)
            {

                if (ex.Number == 2627)
                {
                    MessageBox.Show("Inventory ID already exists.");
                }
                if (ex.Number == 547)
                {
                    MessageBox.Show("Supplier ID does not exist");
                }

            }
            con.Close();
            return status;

        }

        //Edit Inventory
        public bool editInventory(StockObject objStock, SupplierObject objSupplier)
        {
            bool status = false;

            SqlConnection con = ConnectionManager.GetConnection();

            if (con.State.ToString() == "Closed")
            {
                con.Open();
            }
            try
            {

                SqlCommand cmd1 = con.CreateCommand();
                SqlCommand cmd2 = con.CreateCommand();

                cmd1.Connection = con;
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "update dbo.Inventory set BuyingPrice='" + objStock.buyingPrice + "',SellingPrice='" + objStock.sellingPrice + "',Quantity='" + objStock.quantity + "' where InventoryID='" + objStock.inventoryID + "' ";

                cmd2.Connection = con;
                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = "update dbo.Supplies set SupplierID='" + objSupplier.supplierID + "'where InventoryID='" + objStock.inventoryID + "'";

                cmd1.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();

                status = true;

            }
            catch (SqlException ex)
            {
                if (ex.Number == 547)
                {
                    MessageBox.Show("Supplier ID does not exist");
                }
            }
            con.Close();
            return status;

        }

        //Delete Inventory
        public bool deleteInventory(string inventoryID, string supplierID)
        {
            bool status = false;

            SqlConnection con = ConnectionManager.GetConnection();

            if (con.State.ToString() == "Closed")
            {
                con.Open();
            }

            try
            {
                SqlCommand cmd1 = con.CreateCommand();
                SqlCommand cmd2 = con.CreateCommand();

                cmd1.Connection = con;
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "DELETE FROM dbo.Supplies WHERE SupplierID='" + supplierID + "'and InventoryID='" + inventoryID + "' ";

                cmd2.Connection = con;
                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = "DELETE FROM dbo.Inventory WHERE InventoryID='" + inventoryID + "'";

                cmd1.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();

                status = true;

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            con.Close();
            return status;
        }

        //Add Supplier
        public bool addSupplier(SupplierObject objSupplier)
        {

            bool status = false;

            SqlConnection con = ConnectionManager.GetConnection();

            if (con.State.ToString() == "Closed")
            {
                con.Open();
            }
            try
            {

                SqlCommand cmd1 = con.CreateCommand();
                SqlCommand cmd2 = con.CreateCommand();

                cmd1.Connection = con;
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "insert into dbo.Supplier(SupplierID,Name,Address,email) values('" + objSupplier.supplierID + "','" + objSupplier.name + "','" + objSupplier.address + "','" + objSupplier.Email + "')";

                cmd2.Connection = con;
                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = "insert into dbo.SupplierContact(SupplierID,ContactNo) values('" + objSupplier.supplierID + "','" + objSupplier.contactNo + "')";

                cmd1.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();

                status = true;

            }
            catch (SqlException ex)
            {

                if (ex.Number == 2627)
                {
                    MessageBox.Show("Supplier ID already exists.");
                }

            }
            con.Close();
            return status;
        }

        //Edit Supplier
        public bool editSupplier(SupplierObject objSupplier)
        {
            bool status = false;

            SqlConnection con = ConnectionManager.GetConnection();

            if (con.State.ToString() == "Closed")
            {
                con.Open();
            }
            try
            {

                SqlCommand cmd1 = con.CreateCommand();
                SqlCommand cmd2 = con.CreateCommand();

                cmd1.Connection = con;
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "update dbo.Supplier set Name='" + objSupplier.name + "',Address='" + objSupplier.address + "',email='" + objSupplier.Email + "' where SupplierID='" + objSupplier.supplierID + "' ";

                cmd2.Connection = con;
                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = "update dbo.SupplierContact set ContactNo='" + objSupplier.contactNo + "' where SupplierID='" + objSupplier.supplierID + "' ";


                cmd1.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();

                status = true;

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            con.Close();
            return status;

        }

        //Delete Supplier
        public bool deleteSupplier(string supplierID)
        {
            bool status = false;

            SqlConnection con = ConnectionManager.GetConnection();

            if (con.State.ToString() == "Closed")
            {
                con.Open();
            }

            try
            {
                SqlCommand cmd1 = con.CreateCommand();
                SqlCommand cmd2 = con.CreateCommand();
                SqlCommand cmd3 = con.CreateCommand();

                cmd1.Connection = con;
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = " DELETE FROM dbo.Supplies WHERE SupplierID='" + supplierID + "' ";

                cmd2.Connection = con;
                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = "DELETE FROM dbo.SupplierContact WHERE SupplierID='" + supplierID + "' ";


                cmd3.Connection = con;
                cmd3.CommandType = CommandType.Text;
                cmd3.CommandText = "DELETE FROM dbo.Supplier WHERE SupplierID='" + supplierID + "' ";


                cmd1.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                cmd3.ExecuteNonQuery();

                status = true;

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            con.Close();
            return status;
        }

        //Add Reorder Inventory
        public bool addReorderInventory(StockObject objStock)
        {

            bool status = false;

            SqlConnection con = ConnectionManager.GetConnection();

            if (con.State.ToString() == "Closed")
            {
                con.Open();
            }

            try
            {
                SqlCommand cmd1 = con.CreateCommand();
                SqlCommand cmd2 = con.CreateCommand();

                cmd2.Connection = con;
                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = "select sum(Quantity) from Inventory where ProductType='" + objStock.productType + "' and Make='" + objStock.make + "' and Model='" + objStock.model + "' ";

                string str = Convert.ToString(cmd2.ExecuteScalar());

                cmd1.Connection = con;
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "insert into dbo.InventoryReorder(ProductType,Make,Model,Re_orderLevel,TotalQuantity) values('" + objStock.productType + "','" + objStock.make + "','" + objStock.model + "','" + objStock.reorderLevel + "','" + str + "')";

                cmd1.ExecuteNonQuery();

                status = true;

            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    MessageBox.Show("Re-order levels are already set for this Inventory ID.");
                }

            }
            con.Close();
            return status;
        }

        //Edit Inventory Reorder Level
        public bool editReorderInventory(StockObject objStock)
        {
            bool status = false;

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
                cmd1.CommandText = "update dbo.InventoryReorder set Re_orderLevel='" + objStock.reorderLevel + "' where ProductType='" + objStock.productType + "' and Make='" + objStock.make + "' and Model='" + objStock.model + "' ";

                cmd1.ExecuteNonQuery();

                status = true;

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            con.Close();
            return status;



        }

        //Increase Stock
        public bool increaseStock(StockObject objStock, int num)
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
                SqlCommand cmd1 = con.CreateCommand();
                SqlCommand cmd2 = con.CreateCommand();
                SqlCommand cmd3 = con.CreateCommand();

                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select Quantity from dbo.Inventory where InventoryID='" + objStock.inventoryID + "' ";

                string q = Convert.ToString(cmd.ExecuteScalar());
                int i = Convert.ToInt16(q) + num;

                cmd1.Connection = con;
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "update dbo.Inventory set Quantity='" + i + "' where InventoryID='" + objStock.inventoryID + "' ";
                cmd1.ExecuteNonQuery();

                cmd2.Connection = con;
                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = "select sum(Quantity) from dbo.Inventory where ProductType='" + objStock.productType + "' and Make='" + objStock.make + "' and Model='" + objStock.model + "' ";

                int str = Convert.ToInt16(cmd2.ExecuteScalar());

                cmd3.Connection = con;
                cmd3.CommandType = CommandType.Text;
                cmd3.CommandText = "update dbo.InventoryReorder set TotalQuantity='" + str + "' where ProductType='" + objStock.productType + "' and Make='" + objStock.make + "' and Model='" + objStock.model + "' ";

                cmd3.ExecuteNonQuery();

                status = true;

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            con.Close();
            return status;

        }

        //Decrease Stock
        public bool decreaseStock(StockObject objStock, int num)
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
                SqlCommand cmd1 = con.CreateCommand();
                SqlCommand cmd2 = con.CreateCommand();
                SqlCommand cmd3 = con.CreateCommand();

                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select Quantity from dbo.Inventory where InventoryID='" + objStock.inventoryID + "' ";

                string q = Convert.ToString(cmd.ExecuteScalar());
                int i = Convert.ToInt16(q) - num;

                cmd1.Connection = con;
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "update dbo.Inventory set Quantity='" + i + "' where InventoryID='" + objStock.inventoryID + "' ";
                cmd1.ExecuteNonQuery();

                cmd2.Connection = con;
                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = "select sum(Quantity) from dbo.Inventory where ProductType='" + objStock.productType + "' and Make='" + objStock.make + "' and Model='" + objStock.model + "' ";

                int str = Convert.ToInt16(cmd2.ExecuteScalar());

                cmd3.Connection = con;
                cmd3.CommandType = CommandType.Text;
                cmd3.CommandText = "update dbo.InventoryReorder set TotalQuantity='" + str + "' where ProductType='" + objStock.productType + "' and Make='" + objStock.make + "' and Model='" + objStock.model + "' ";

                cmd3.ExecuteNonQuery();

                status = true;

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            con.Close();
            return status;

        }


        //Add Supplier Payment
        public bool addSupplierPayment(SupplierObject objSupplier, StockObject objStock)
        {
            bool status = false;

            SqlConnection con = ConnectionManager.GetConnection();

            if (con.State.ToString() == "Closed")
            {
                con.Open();
            }
            try
            {
                SqlCommand cmd1 = con.CreateCommand();
                SqlCommand cmd2 = con.CreateCommand();
                SqlCommand cmd3 = con.CreateCommand();

                cmd1.Connection = con;
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "insert into dbo.SupplierPayment(SupplierID,InventoryID,Date,PaidAmount) values('" + objSupplier.supplierID + "','" + objStock.inventoryID + "','" + objSupplier.paidDate + "'," + objSupplier.paidAmt + ")";
                cmd1.ExecuteNonQuery();

                cmd2.Connection = con;
                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = "select sum(PaidAmount) from dbo.SupplierPayment where SupplierID='" + objSupplier.supplierID + "' and InventoryID='" + objStock.inventoryID + "' ";

                float str = float.Parse(cmd2.ExecuteScalar().ToString());

                cmd3.Connection = con;
                cmd3.CommandType = CommandType.Text;
                cmd3.CommandText = "update dbo.Supplies set TotallyPaidAmount=" + str + " where  SupplierID='" + objSupplier.supplierID + "' and InventoryID='" + objStock.inventoryID + "' ";

                cmd3.ExecuteNonQuery();

                status = true;

            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    MessageBox.Show("This entry already exists.");
                }

            }
            con.Close();
            return status;
        }


        //Edit Supplier Payment
        public bool editSupplierPayment(StockObject objStock, SupplierObject objSupplier)
        {
            bool status = false;

            SqlConnection con = ConnectionManager.GetConnection();

            if (con.State.ToString() == "Closed")
            {
                con.Open();
            }
            try
            {
                SqlCommand cmd1 = con.CreateCommand();
                SqlCommand cmd2 = con.CreateCommand();
                SqlCommand cmd3 = con.CreateCommand();

                cmd1.Connection = con;
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "update dbo.SupplierPayment set PaidAmount='" + objSupplier.paidAmt + "' where SupplierID='" + objSupplier.supplierID + "' and InventoryID='" + objStock.inventoryID + "' and Date='" + objSupplier.paidDate + "' ";

                cmd1.ExecuteNonQuery();

                cmd2.Connection = con;
                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = "select sum(PaidAmount) from dbo.SupplierPayment where SupplierID='" + objSupplier.supplierID + "' and InventoryID='" + objStock.inventoryID + "' ";

                float str = float.Parse(cmd2.ExecuteScalar().ToString());

                cmd3.Connection = con;
                cmd3.CommandType = CommandType.Text;
                cmd3.CommandText = "update dbo.Supplies set TotallyPaidAmount='" + str + "' where  SupplierID='" + objSupplier.supplierID + "' and InventoryID='" + objStock.inventoryID + "' ";

                cmd3.ExecuteNonQuery();

                status = true;

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            con.Close();
            return status;



        }

        //Delete Supplier Payment
        public bool deleteSupplierPayment(string supID, string invID, DateTime date)
        {
            bool status = false;

            SqlConnection con = ConnectionManager.GetConnection();

            if (con.State.ToString() == "Closed")
            {
                con.Open();
            }
            try
            {
                SqlCommand cmd1 = con.CreateCommand();
                SqlCommand cmd2 = con.CreateCommand();
                SqlCommand cmd3 = con.CreateCommand();

                cmd1.Connection = con;
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "delete from dbo.SupplierPayment where SupplierID='" + supID + "' and InventoryID='" + invID + "' and Date='" + date + "' ";

                cmd1.ExecuteNonQuery();

                cmd2.Connection = con;
                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = "select sum(PaidAmount) from dbo.SupplierPayment where SupplierID='" + supID + "' and InventoryID='" + invID + "' ";

                float str = float.Parse(cmd2.ExecuteScalar().ToString());

                cmd3.Connection = con;
                cmd3.CommandType = CommandType.Text;
                cmd3.CommandText = "update dbo.Supplies set TotallyPaidAmount='" + str + "' where  SupplierID='" + supID + "' and InventoryID='" + invID + "' ";

                cmd3.ExecuteNonQuery();

                status = true;

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            con.Close();
            return status;



        }

//Pooja END
//NADITHA


        //Delivery
        //Add New Vehical
        public bool AddNewvehical(VehicalObject objvehicalObjects)
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

                newCmd1.Connection = con;
                newCmd1.CommandType = CommandType.Text;
                newCmd1.CommandText = "insert into dbo.Vehicles(VehicleNo,Vehicle_Type,Capacity,Make,Model,Status,Description) values ('" + objvehicalObjects.VehicalNo + "', '" + objvehicalObjects.Type1 + "','" + objvehicalObjects.Capacity + "' , '" + objvehicalObjects.Make + "','" + objvehicalObjects.Model + "', '" + objvehicalObjects.Status + "','" + objvehicalObjects.Description + "')";



                newCmd1.ExecuteNonQuery();


                status = true;

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            con.Close();
            return status;
        }

        //Add service
        public bool AddNewservice(VehicalObject objvehi)
        {
            bool status = false;

            SqlConnection con = ConnectionManager.GetConnection();

            if (con.State.ToString() == "Closed")
            {
                con.Open();
            }

            SqlDataAdapter sda = new SqlDataAdapter("select * from Vehicles where VehicleNo = '" + objvehi.VehicalNo + "'", con);

            DataTable dt = new DataTable();
            sda.Fill(dt);

            SqlDataAdapter sda1 = new SqlDataAdapter("select * from Vehicle_Service where VehicleNo = '" + objvehi.VehicalNo + "'", con);

            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);


            if (dt.Rows.Count > 0)
            {
                if (dt1.Rows.Count == 0)
                {
                    try
                    {
                        SqlCommand newCmd1 = con.CreateCommand();

                        newCmd1.Connection = con;
                        newCmd1.CommandType = CommandType.Text;
                        newCmd1.CommandText = "insert into dbo.Vehicle_Service(VehicleNo,Servise_Des,Last_Service_Date,Last_Service_Millage,Next_Service_Date,Next_Service_Millage) Values ('" + objvehi.VehicalNo + "','" + objvehi.Ser_description + "','" + objvehi.Last_ser_date + "'," + objvehi.Last_ser_milage + ",'" + objvehi.Next_ser_date1 + "'," + objvehi.Next_ser_milage + ")";

                        newCmd1.ExecuteNonQuery();


                        status = true;

                    }
                    catch (SqlException ex)
                    {
                        throw ex;
                    }
                }
                else
                    MessageBox.Show("service record for this vehical is already in system...");

            }
            else
            {
                MessageBox.Show("This vehical is not in the system... Check Vehicle Number");

            }

            con.Close();
            return status;
        }

        //Add delivery
        public bool AddNewdelivery(DeliveryObject objdel, CustomerObject objcus, SalesObject objInv, EmployeeObject objemp, VehicalObject objvehi)
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





                newCmd1.Connection = con;
                newCmd1.CommandType = CommandType.Text;
                newCmd1.CommandText = "insert into Delivery (DeliveryNo,Description,Status,VehicleNo,EmpID,NIC,From1,To1,distance,rate,Cost,InvoiceID,DiliveryDate) values ('" + objdel.DeliveryNo1 + "','" + objdel.Description1 + "','" + objdel.Status1 + "' , '" + objvehi.VehicalNo + "'," + objemp.empid + ", '" + objcus.Nic + "','" + objdel.From1 + "','" + objdel.To1 + "'," + objdel.Distance1 + "," + objdel.Rate1 + "," + objdel.Cost1 + "," + objInv.InvoiceNo + ",'" + objdel.Date + "')";
                newCmd1.ExecuteNonQuery();




                SqlCommand newCmd2 = con.CreateCommand();
                SqlCommand newCmd3 = con.CreateCommand();
                SqlCommand newCmd4 = con.CreateCommand();
                SqlCommand newCmd5 = con.CreateCommand();

                newCmd2.Connection = con;
                newCmd2.CommandType = CommandType.Text;
                newCmd2.CommandText = "UPDATE dbo.EmpDriver SET Status ='NA' where driverNo = " + objemp.empid;

                newCmd3.Connection = con;
                newCmd3.CommandType = CommandType.Text;
                newCmd3.CommandText = "UPDATE dbo.Vehicles SET Status ='NA' where VehicleNo = '" + objvehi.VehicalNo + "'";

                newCmd4.Connection = con;
                newCmd4.CommandType = CommandType.Text;
                newCmd4.CommandText = "UPDATE dbo.Invoice SET Amount = Amount + " + objdel.Cost1 + " where InvoiceID = " + objInv.InvoiceNo;

                newCmd5.Connection = con;
                newCmd5.CommandType = CommandType.Text;
                newCmd5.CommandText = "UPDATE dbo.Invoice SET deliveryStatus ='Processing' where InvoiceID = " + objInv.InvoiceNo;

                newCmd2.ExecuteNonQuery();
                newCmd3.ExecuteNonQuery();
                newCmd4.ExecuteNonQuery();
                newCmd5.ExecuteNonQuery();



                status = true;

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            con.Close();
            return status;
        }

        //update availability of drivers
        public void setAvailability(DeliveryObject objdel, EmployeeObject objem, VehicalObject objvehi)
        {

            if (System.DateTime.Today == objdel.Date)
            {

                SqlConnection con = ConnectionManager.GetConnection();

                if (con.State.ToString() == "Closed")
                {
                    con.Open();
                }

                SqlCommand newCmd2 = con.CreateCommand();
                SqlCommand newCmd3 = con.CreateCommand();

                newCmd2.Connection = con;
                newCmd2.CommandType = CommandType.Text;
                newCmd2.CommandText = "update EmpDriver set status = 'NotAvailable' where driverNo = " + objem.empid;

                newCmd3.Connection = con;
                newCmd3.CommandType = CommandType.Text;
                newCmd3.CommandText = "UPDATE dbo.Vehicles SET Status ='NotAvailable' where VehicleNo = '" + objvehi.VehicalNo + "'";

                newCmd2.ExecuteNonQuery();
                newCmd3.ExecuteNonQuery();
            }




        }


        //updeate vehical
        public bool Editvehical(VehicalObject objvehiObjects)
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

                newCmd1.Connection = con;
                newCmd1.CommandType = CommandType.Text;
                newCmd1.CommandText = "UPDATE dbo.Vehicles SET Vehicle_Type = '" + objvehiObjects.Type1 + "',Capacity='" + objvehiObjects.Capacity + "',Make='" + objvehiObjects.Make + "',Model='" + objvehiObjects.Model + "',Status='" + objvehiObjects.Status + "',Description ='" + objvehiObjects.Description + "' where VehicleNo = '" + objvehiObjects.VehicalNo + "'";


                newCmd1.ExecuteNonQuery();


                status = true;

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            con.Close();
            return status;
        }


        //update service
        public bool updateService(VehicalObject objvehiObjects)
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

                newCmd1.Connection = con;
                newCmd1.CommandType = CommandType.Text;
                newCmd1.CommandText = "UPDATE dbo.Vehicle_Service SET Servise_Des = '" + objvehiObjects.Ser_description + "',Last_Service_Date='" + objvehiObjects.Last_ser_date + "',Last_Service_Millage=" + objvehiObjects.Last_ser_milage + ",Next_Service_Date='" + objvehiObjects.Next_ser_date1 + "',Next_Service_Millage=" + objvehiObjects.Next_ser_milage + " where VehicleNo = '" + objvehiObjects.VehicalNo + "'";


                newCmd1.ExecuteNonQuery();


                status = true;

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            con.Close();
            return status;
        }


        //update delivery

        public bool EditDelivery(DeliveryObject objdel, CustomerObject objcus, SalesObject objInv, EmployeeObject objem, VehicalObject objvehi)
        {
            bool status = false;
            SqlConnection con = ConnectionManager.GetConnection();

            if (con.State.ToString() == "Closed")
            {
                con.Open();
            }


            try
            {

                SqlDataAdapter adapter = new SqlDataAdapter();
                string sql = "UPDATE dbo.Delivery SET Description ='" + objdel.Description1 + "',From1 = '" + objdel.From1 + "',To1 = '" + objdel.To1 + "',distance = " + objdel.Distance1 + ",rate = " + objdel.Rate1 + ",cost = " + objdel.Cost1 + ",DiliveryDate = '" + objdel.Date + "' where DeliveryNo = '" + objdel.DeliveryNo1 + "'";


                adapter.UpdateCommand = con.CreateCommand();
                adapter.UpdateCommand.CommandText = sql;
                adapter.UpdateCommand.ExecuteNonQuery();

                status = true;

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            con.Close();
            return status;
        }






        //Delete vehical
        public bool DeleteVehical(string vehino)
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


                newCmd1.Connection = con;
                newCmd1.CommandType = CommandType.Text;
                newCmd1.CommandText = "DELETE FROM dbo.Vehicles WHERE VehicleNo='" + vehino + "'";


                newCmd2.Connection = con;
                newCmd2.CommandType = CommandType.Text;
                newCmd2.CommandText = "DELETE FROM dbo.Delivery WHERE VehicleNo='" + vehino + "'";


                newCmd3.Connection = con;
                newCmd3.CommandType = CommandType.Text;
                newCmd3.CommandText = "DELETE FROM dbo.Vehicle_Service WHERE VehicleNo='" + vehino + "'";

                newCmd3.ExecuteNonQuery();
                newCmd2.ExecuteNonQuery();
                newCmd1.ExecuteNonQuery();


                status = true;

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            con.Close();
            return status;
        }

        //delete service
        public bool DeleteService(string vehino)
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


                newCmd1.Connection = con;
                newCmd1.CommandType = CommandType.Text;
                newCmd1.CommandText = "DELETE FROM dbo.Vehicle_Service WHERE VehicleNo='" + vehino + "'";



                newCmd1.ExecuteNonQuery();


                status = true;

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            con.Close();
            return status;
        }

        //delete delivery
        public bool DeleteDelivery(string delno)
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


                newCmd1.Connection = con;
                newCmd1.CommandType = CommandType.Text;
                newCmd1.CommandText = "DELETE FROM dbo.Delivery WHERE DeliveryNo='" + delno + "'";



                newCmd1.ExecuteNonQuery();


                status = true;

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            con.Close();
            return status;
        }

        //delivery cost calculation

        public double calcCost(DeliveryObject delobj)
        {
            double destance = delobj.Distance1;
            double rate = delobj.Rate1;

            double cost = destance * rate;

            return cost;

        }


       


      
       



//NADITHA END

//CHATHU


        //sales------------------------------------------------------------------

        public double getPurchaseTotal(DataGridView dg)
        {
            double sum = 0;
            for (int i = 0; i < dg.Rows.Count; ++i)
            {
                sum += Convert.ToDouble(dg.Rows[i].Cells["Column4"].Value);
            }

            return sum;
        }


        public string getCardType(CustomerObject co, SalesObject so)
        {

            SqlConnection con = ConnectionManager.GetConnection();
            string q = "select * from CustomerLoyalatyCard where NIC='" + so.NIC + "'";
            SqlCommand cmd = new SqlCommand(q, con);

            if (con.State.ToString() == "Closed")
            {
                con.Open();
            }
            try
            {
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    rd.Read();
                    co.CardType = rd[3].ToString();
                    return co.CardType;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;

            }
            con.Close();

        }

        public string getCardCardPoints(SalesObject so)
        {

            SqlConnection con = ConnectionManager.GetConnection();

            string q = "select * from CustomerLoyalatyCard where NIC='" + so.NIC + "'";
            SqlCommand cmd = new SqlCommand(q, con);

            if (con.State.ToString() == "Closed")
            {
                con.Open();
            }

            try
            {
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    rd.Read();
                    so.CardPoints = rd[2].ToString();
                    return so.CardPoints;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            con.Close();

        }



        public string getNIC(SalesObject so, string jobID)
        {
            SqlConnection con = ConnectionManager.GetConnection();
            //string CardType;
            string q = "select * " +
                        "from Customer c, Repair_Job r " +
                        "where c.NIC = r.CustomerNIC and r.JobID = '" + jobID + "'";
            SqlCommand cmd = new SqlCommand(q, con);

            if (con.State.ToString() == "Closed")
            {
                con.Open();
            }
            try
            {
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    rd.Read();
                    so.NIC = rd[0].ToString();
                    return so.NIC;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;

            }

            con.Close();

        }

        public double getServiceTotal(DataGridView gd)
        {
            double sum = 0;
            for (int i = 0; i < gd.Rows.Count; i++)
            {
                sum += Convert.ToDouble(gd.Rows[i].Cells["Column9"].Value);
            }
            return sum;
        }

        public double calcDiscount(string cardType, double total)
        {
            double discount = 0;
            if (cardType == "GOLD")
                discount = total / 100 * 25;
            else if (cardType == "SILVER")
                discount = total / 100 * 10;
            else if (cardType == "BRONZE")
                discount = total / 100 * 5;

            return discount;
        }
            
        public bool deletePurchaseItem(string idx)
        {
            bool status = false;
            string q = "DELETE FROM PurchaseItems" +
                        " WHERE idx='" + idx + "'";
            SqlCommand cmd = new SqlCommand(q, con);

            con.Open();
            try
            {
                cmd.ExecuteNonQuery();
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
                throw ex;
            }
            con.Close();
            return status;
        }


        
        public void DeductPoints(CustomerObject co, SalesObject so)
        {
            int pointsToDeduct;

            pointsToDeduct = Convert.ToInt32(co.CardPoints - so.PurchaseGrand - so.ServiceGrand);
            if (pointsToDeduct < 0)
            {
                pointsToDeduct = 0;
                co.CardPoints = pointsToDeduct;
            }

            string q = "update CustomerLoyalatyCard set Card_Points= '" + pointsToDeduct + "' where NIC= '" + so.NIC + "'";
            SqlConnection con = ConnectionManager.GetConnection();
            SqlCommand cmd = new SqlCommand(q, con);
            if (con.State.ToString() == "Closed")
            {
                con.Open();
            }

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public void DeductInventory(string inID)
        {
            int qty = 0;
            int newQty = 0;


            string q = "select Quantity from Inventory where InventoryID = '" + inID + "'";
            //string q1 = "update Inventory set Quantity='"+qty+"' where InventoryID='"+inID+"' ";
            SqlCommand cmd = new SqlCommand(q, con);

            con.Open();
            try
            {
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    rd.Read();
                    qty = Convert.ToInt16(rd[0]);
                    newQty = qty - 1;

                }
                rd.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            con.Close();


            string q1 = "update Inventory set Quantity='" + newQty + "' where InventoryID='" + inID + "' ";
            SqlCommand cmd1 = new SqlCommand(q1, con);
            con.Open();
            try
            {
                cmd1.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            con.Close();
        }


        public void ResetInventory(string inID)
        {
            int qty = 0;
            int newQty = 0;


            string q = "select Quantity from Inventory where InventoryID = '" + inID + "'";
            //string q1 = "update Inventory set Quantity='"+qty+"' where InventoryID='"+inID+"' ";
            SqlCommand cmd = new SqlCommand(q, con);

            con.Open();
            try
            {
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    rd.Read();
                    qty = Convert.ToInt16(rd[0]);
                    newQty = qty + 1;

                }
                rd.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            con.Close();


            string q1 = "update Inventory set Quantity='" + newQty + "' where InventoryID='" + inID + "' ";
            SqlCommand cmd1 = new SqlCommand(q1, con);
            con.Open();
            try
            {
                cmd1.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            con.Close();
        }




        //-------------------------------------------------------------------------------



		

    }
}
