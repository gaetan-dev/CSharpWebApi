using System.Collections.Generic;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;

namespace WebApiStarter.Layers.DataAccessLayer
{
    public sealed class MySqlDatabaseAccess : DatabaseAccess
    {
      public override List<T> ExecuteStoredProcedure<T>(string storedProcedureName, Dictionary<string, object> parameters = null)
        {
            using (Connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["mysqlConnection"].ConnectionString))
            {
                SetupCommand(storedProcedureName, parameters);

                Connection.Open();

                return ExecuteReader<T>();
            }
        }

        protected override void SetupCommand(string storedProcedureName, Dictionary<string, object> parameters = null)
        {
            Command = new MySqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = storedProcedureName,
                Connection  = (MySqlConnection) Connection
            };

            if (parameters != null)
            {
                foreach (var key in parameters.Keys)
                {
                    ((MySqlCommand) Command).Parameters.AddWithValue(key, parameters[key]);
                }
            }
        }
    }
}