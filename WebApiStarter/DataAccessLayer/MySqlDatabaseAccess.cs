using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace WebApiStarter.DataAccessLayer
{
    public class MySqlDatabaseAccess<T> where T : Model, new()
    {
        public static List<T> ExecuteStoredProcedure(String storedProcedureName, Dictionary<string, object> parameters = null)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["mysqlConnection"].ConnectionString;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(storedProcedureName, connection)
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

        private static List<T> ExecuteReader(MySqlCommand command)
        {
            List<T> results = new List<T>();

            MySqlDataReader reader = command.ExecuteReader();

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