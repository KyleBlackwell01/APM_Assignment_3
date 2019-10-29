using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace WebApiG1N2
{
    public class DBConnection
    {

        public static SqlConnection GetConnection()
        {
            string ConnString = @"Server=102472889.database.windows.net;Database=Database_Sem2;User Id=dbadmin;Password=G1N2!@#$;";
            return new SqlConnection(ConnString);
        }


    }
}