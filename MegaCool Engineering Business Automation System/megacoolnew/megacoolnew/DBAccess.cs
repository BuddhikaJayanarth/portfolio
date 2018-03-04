using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using megacoolnew.userObjects;


namespace megacoolnew
{
    public class DBAccess
    {

        SqlConnection con = ConnectionManager.GetConnection();

        public LoginObj ValidateLogin(String uname, String pwd)
        {
            LoginObj lg = new LoginObj();
            lg.Name = "";
            
            String q = "SELECT Name,Clearancelevel FROM Login WHERE Username = '" + uname + "'"
                        + " AND Password = '" + pwd + "'";
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataReader reader;
            con.Open();
            try
            {
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    lg.Name = reader.GetString(0);
                    lg.Clearancelevel1 = reader.GetInt32(1);
                }
                else
                {
                    lg.Name = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error\n\n"+ex);
            }
            con.Close();
            return lg;
        }
              
    }
}
