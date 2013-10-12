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

        public IDataReader Select(Guid productId) {
            SqlCommand command = CreateCommand(string.Format(
                "SELECT * FROM [inventory_product] WHERE [product_id] = '{0}'"
                , productId));
            command.Connection.Open();
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public IDataReader FindByCode(string code) {
            SqlCommand command = CreateCommand(string.Format(
                "SELECT * FROM [inventory_product] WHERE [code] = '{0}'"
                , code));
            command.Connection.Open();
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public bool Insert(Guid productId, string code, string name, string description) {
            SqlCommand command = CreateCommand(string.Format(
                "INSERT INTO inventory_product ([product_id], [display_name], [code], [description]) VALUES ('{0}','{1}','{2}','{3}')"
                , productId, name, code, description));
            command.Connection.Open();
            bool result = command.ExecuteNonQuery() >= 0;
            command.Connection.Close();
            return result;
        }
    }
}
