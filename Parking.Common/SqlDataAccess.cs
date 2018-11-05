using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Parking.Common;
using Parking.Common.Enums;

namespace Parking.Common
{
    /// <summary>
    /// SqlDataAccess is being used for accessing MSSQL database quickly and easily. 
    /// Requires a connection string that is named MsSql defined on web.config file. This connection string is used as default. 
    /// For using different connection strings you should pass the name of the connection string as a parameter with methods.
    /// </summary>
    public class SqlDataAccess : ISqlDataAccess
    {
        // Default connection string. a connection named MsSql should be defined in web.config file.
        public const string ConnectionStringName = "MsSql";
        //This returns the connection string  
        private static string DefaultConnectionString;

        public SqlDataAccess(Application application)
        {
            DefaultConnectionString = ConstructConnectionStringWithServerDetails(application);
        }
        public SqlCommand GetCommand(string sql)
        {
            var conn = new SqlConnection(DefaultConnectionString);
            var sqlCmd = new SqlCommand(sql, conn);
            return sqlCmd;
        }
        public DataTable Execute(string sql)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlCommand cmd = GetCommand(sql);
                cmd.Connection.Open();
                dt.Load(cmd.ExecuteReader());
                cmd.Connection.Close();
                return dt;
            }
            catch (System.Exception e)
            {
                FileLogger.Log($"Sql Data Access error (Unable to execute Sql) : {e.Message}");
                throw;
            }           
        }
        public DataTable Execute(SqlCommand command)
        {
            try
            {
                DataTable dt = new DataTable();
                command.Connection.Open();
                //command.ExecuteNonQuery();
                dt.Load(command.ExecuteReader());
                command.Connection.Close();
                return dt;
            }
            catch (System.Exception e)
            {
                FileLogger.Log($"Sql Data Access error (Unable to execute Sql Command) : {e.Message}");
                throw;
            }
        }
        public int ExecuteNonQuery(string sql)
        {
            try
            {
                SqlCommand cmd = GetCommand(sql);
                cmd.Connection.Open();
                int result = cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                return result;
            }
            catch (System.Exception e)
            {
                FileLogger.Log($"Sql Data Access error (Unable to execute Sql NonQuery) : {e.Message}");
                throw;
            }
        }
        public object ExecuteNonQueryReturnsIdentity(string sql)
        {
            try
            {
                SqlCommand cmd = GetCommand(sql);
                cmd.Connection.Open();
                var result = cmd.ExecuteScalar();
                cmd.Connection.Close();
                return result;
            }
            catch (System.Exception e)
            {
                FileLogger.Log($"Sql Data Access error (Unable to execute Sql ExecuteNonQueryReturnsIdentity) : {e.Message}");
                throw;
            }
        }
        public int ExecuteNonQuery(SqlCommand command)
        {
            try
            {
                command.Connection.Open();
                int result = command.ExecuteNonQuery();
                command.Connection.Close();
                return result;
            }
            catch (System.Exception e)
            {
                FileLogger.Log($"Sql Data Access error (Unable to execute SqlCommand NonQuery) : {e.Message}");
                throw;
            }
        }
        public int ExecuteStoredProcedure(string spName)
        {
            try
            {

                SqlCommand cmd = GetCommand(spName);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection.Open();
                int result = cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                return result;
            }
            catch (System.Exception e)
            {
                FileLogger.Log($"Sql Data Access error (Unable to execute Stored Proceddure) : {e.Message}");
                throw;
            }
        }      
        public int ExecuteStoredProcedure(SqlCommand command)
        {
            try
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Connection.Open();
                int result = command.ExecuteNonQuery();
                command.Connection.Close();
                return result;
            }
            catch (System.Exception e)
            {
                FileLogger.Log($"Sql Data Access error (Unable to execute SqlCommand Stored Procedure) : {e.Message}");
                throw;
            }
        }
        public DataTable ExecuteDataReturningStoredProcedure(SqlCommand command)
        {
            try
            {
                var result = new DataTable();
                command.Connection = new SqlConnection(DefaultConnectionString);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                command.Connection.Open();
                dataAdapter.Fill(result);
                command.Connection.Close();
                return result;
            }
            catch (System.Exception e)
            {
                FileLogger.Log($"Sql Data Access error (Unable to execute Data Returning SqlCommand Stored Procedure) : {e.Message}");
                throw;
            }
        }
        private static string ConstructConnectionStringWithServerDetails(Application application)
        {
            try
            {
                string connectionString = null;
                switch (application)
                {
                    case Application.TicketDispenserClient:
                        var settings = (TickerDispenserClientSettings)ConfigurationReader.GetConfigurationSettings(application);
                        connectionString = $"Data Source = {settings.TdServerIPAddress},{settings.TdServerPort}; Network Library = DBMSSOCN; Initial Catalog = db_Parking; User ID = {settings.TdServerUsername}; Password = {settings.TdServerPassword};";
                    break;
                    case Application.TickerDispenserServer:
                        var tdServerSettings = (TicketDispenserServerSettings)ConfigurationReader.GetConfigurationSettings(application);
                        connectionString = $"Data Source = {tdServerSettings.IPAddress},{tdServerSettings.Port}; Network Library = DBMSSOCN; Initial Catalog = db_Parking; User ID = {tdServerSettings.Username}; Password = {tdServerSettings.Password};";
                    break;
                    case Application.ManualPayStation:
                        var mpsSettings = (ManualPayStationSettings)ConfigurationReader.GetConfigurationSettings(application);
                        connectionString = $"Data Source = {mpsSettings.TdServerIPAddress},{mpsSettings.TdServerPort}; Network Library = DBMSSOCN; Initial Catalog = db_Parking; User ID = {mpsSettings.TdServerUsername}; Password = {mpsSettings.TdServerPassword};";
                        break;
                }

                return connectionString;
            }
            catch (System.Exception exception)
            {
                FileLogger.Log($"Connection String could not be built as Configuration settings could not be loaded successfully as : {exception.Message}");
                return string.Empty;
            }            
        }
    }
}