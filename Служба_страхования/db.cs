using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Служба_страхования
{
    public class db
    {
        public string login = "";
        public string pass = "";
        static string serverName = @"DESKTOP-IG7NGDO\SQLEXPRESS";
        static string dbName = "Служба_страхования";

        public SqlConnection con = new SqlConnection($@"Data Source={serverName}; Initial Catalog={dbName};Integrated Security = True");
    }
}
