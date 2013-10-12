using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Data
{
    public class ProductDAC
    {
        private string ConnectionString {
            get {
                return System.Configuration.ConfigurationManager.ConnectionStrings["DefaultDatabase"].ConnectionString;
            }
        }

        private SqlConnection CreateConnection() {
            return new SqlConnection(ConnectionString);
        }

        private SqlCommand CreateCommand(string commandString) {
            return new SqlCommand(commandString, CreateConnection());
        }

        public IDataReader Select() {
            SqlCommand command = CreateCommand("SELECT * FROM [inventory_product]");
            command.Connection.Open();
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }


        public bool Insert(Guid productId, string name) {
            SqlCommand command = CreateCommand(string.Format("INSERT INTO inventory_product ([product_id], [display_name]) VALUES ('{0}','{1}')"
                , productId, name));
            command.Connection.Open();
            bool result = command.ExecuteNonQuery() >= 0;
            command.Connection.Close();
            return result;
        }
    }
}
