using System.Data;
using System.Data.SqlClient;

namespace Parking.Common
{
    public interface ISqlDataAccess
    {
        /// <summary>
        /// Brings a SqlCommand object to be able to add some parameters in it. After you send this to Execute method.
        /// </summary>
        /// <param name="sql">SQL Query string</param>
        /// <returns></returns>
        SqlCommand GetCommand(string sql);

        /// <summary>
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        DataTable Execute(string sql);

        /// <summary>
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        DataTable Execute(SqlCommand command);

        /// <summary>
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        int ExecuteNonQuery(string sql);

        /// <summary>
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        int ExecuteNonQuery(SqlCommand command);

        /// <summary>
        /// </summary>
        /// <param name="spName"></param>
        /// <returns></returns>
        int ExecuteStoredProcedure(string spName);

        /// <summary>
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        int ExecuteStoredProcedure(SqlCommand command);

        /// <summary>
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        DataTable ExecuteDataReturningStoredProcedure(SqlCommand command);

        /// <summary>
        /// </summary>
        object ExecuteNonQueryReturnsIdentity(string sql);
    }
}
