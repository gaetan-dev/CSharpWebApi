using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using WebApiStarter.Components;

namespace WebApiStarter.Layers.DataAccessLayer
{
    public class SqlServerDatabaseAccess : IDatabaseAccess
    {
        private static IDatabaseAccess _instance;
        public static IDatabaseAccess GetInstance()
        {
            return _instance ?? (_instance = new SqlServerDatabaseAccess());
        }

        public List<T> ExecuteStoredProcedure<T>(String storedProcedureName, Dictionary<string, object> parameters = null) where T : IModel, new()
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlserverConnection"].ConnectionString))
            {
                SqlCommand command = new SqlCommand(storedProcedureName, connection)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandText = storedProcedureName,
                    Connection = connection
                };

                if (parameters != null)
                {
                    foreach (var key in parameters.Keys)
                    {
                        command.Parameters.AddWithValue(key, parameters[key]);
                    }
                }

                connection.Open();

                return ExecuteReader<T>(command);
            }
        }

        public List<T> ExecuteReader<T>(DbCommand command) where T : IModel, new()
        {
            List<T> results = new List<T>();

            SqlDataReader reader = ((SqlCommand)command).ExecuteReader();

            while (reader.Read())
            {
                T model = new T();
                model.Map(reader);
                results.Add(model);
            }

            reader.Close();
            return results;
        }
    }
}