using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;


namespace megacoolnew
{
    class ConnectionManagerOffsite
    {
        public static SqlConnection conn = null;

        public void OpenCon()
        {
            conn = new SqlConnection(@"Data Source=HP;Initial Catalog=MegaCoolEngineering;Integrated Security=True");
            conn.Open();
        }
        
    }
}
