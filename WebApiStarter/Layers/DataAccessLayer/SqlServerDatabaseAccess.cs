using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WebApiStarter.Layers.DataAccessLayer
{
    public class SqlServerDatabaseAccess : DatabaseAccess
    {
        public override List<T> ExecuteStoredProcedure<T>(String storedProcedureName, Dictionary<string, object> parameters = null)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlserverConnection"].ConnectionString))
            {
                SetupCommand(storedProcedureName, parameters);

                connection.Open();

                return ExecuteReader<T>();
            }
        }

        protected override void SetupCommand(string storedProcedureName, Dictionary<string, object> parameters = null)
        {
            Command = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = storedProcedureName,
                Connection = (SqlConnection) Connection,
            };


            if (parameters != null)
            {
                foreach (var key in parameters.Keys)
                {
                    ((SqlCommand) Command).Parameters.AddWithValue(key, parameters[key]);
                }
            }
        }
    }
}