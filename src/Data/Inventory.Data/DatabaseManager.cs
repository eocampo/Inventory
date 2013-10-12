using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Data
{
    public class DatabaseManager
    {
        private static string ConnectionString {
            get { return System.Configuration.ConfigurationManager.ConnectionStrings["DefaultDatabase"].ConnectionString; }
        }
        private static SqlConnection CreateConnection() {
            return new SqlConnection(DatabaseManager.ConnectionString);
        }

        public static void CreateSchema() {



        }

        public static void DropSchema() {



        }
    }
}
