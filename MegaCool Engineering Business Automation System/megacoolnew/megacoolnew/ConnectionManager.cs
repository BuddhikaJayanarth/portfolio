using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace megacoolnew
{
    class ConnectionManager
    {

        public static SqlConnection NewCon;
        public static string ConStr = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;

        public static SqlConnection GetConnection()
        {
            NewCon = new SqlConnection(ConStr);
            return NewCon;
        }

    }
}
