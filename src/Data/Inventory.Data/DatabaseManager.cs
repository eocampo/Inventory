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
            RunLocalStoredCommands("Inventory.Data.SqlClient.Scripts.CreateProductSchema.sql");
        }

        public static void DropSchema() {
            RunLocalStoredCommands("Inventory.Data.SqlClient.Scripts.DropSchema.sql");


        }


        public static void RunLocalStoredCommands(string resourceName) {
            System.Data.SqlClient.SqlConnection connection = CreateConnection();
            System.Data.SqlClient.SqlCommand command = new SqlCommand();

            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            System.IO.TextReader textReader = new System.IO.StreamReader(assembly.GetManifestResourceStream(resourceName));

            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = textReader.ReadToEnd();

            System.Data.SqlClient.SqlTransaction transaction = null;
            try {
                connection.Open();
                transaction = connection.BeginTransaction();
                command.Transaction = transaction;
                // command.Transaction.IsolationLevel = IsolationLevel.ReadUncommitted;
                command.Connection = transaction.Connection;
                connection = transaction.Connection;
                //command.Connection.Open();
                command.ExecuteNonQuery();
                transaction.Commit();
                //command.Connection.Close();
            }
            catch (Exception ex) {
                ex.ToString();
                transaction.Rollback();
                throw ex;
            }
            finally {
                if (transaction.Connection != null)
                    transaction.Connection.Close();

                // when trasaction is commited (transaction.Commit()) the .Net Framework set the connection property to null
                // we need to get the connection from the command
                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
            }

        }
    }
}
