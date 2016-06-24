using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace WebApiStarter.DataAccessLayer
{
    public class SqlServerDatabaseAccess<T> where T : Model, new()
    {
        public static List<T> ExecuteStoredProcedure(String storedProcedureName, Dictionary<string, object> parameters = null)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["sqlserverConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
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

                return ExecuteReader(command);
            }
        }

        private static List<T> ExecuteReader(SqlCommand command)
        {
            List<T> results = new List<T>();

            SqlDataReader reader = command.ExecuteReader();

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