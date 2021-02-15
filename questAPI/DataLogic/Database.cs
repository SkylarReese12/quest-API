using System;
using System.Data.SqlClient;
using System.Text;

namespace questAPI.DataLogic
{
    public class Database : IDatabase
    {
        private DatabaseProperties _connectionProperties;

        public Database(DatabaseProperties connectionProperties)       
        {
            this._connectionProperties = connectionProperties;
        }

        public SqlConnection GetConnection()

        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

                builder.DataSource = _connectionProperties.DataSource;
                builder.UserID = _connectionProperties.UserID;
                builder.Password = _connectionProperties.Password;
                builder.InitialCatalog = _connectionProperties.InitialCatalog;

                return new SqlConnection(builder.ConnectionString);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
        }
    }
}
