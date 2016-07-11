using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using MySql.Data.MySqlClient;

namespace WebApiStarter.DataAccessLayer
{
    public class MySqlDatabaseAccess : DatabaseAccess
    {
        private static DatabaseAccess _instance;
        public static DatabaseAccess GetInstance()
        {
            return _instance ?? (_instance = new MySqlDatabaseAccess());
        }

        public override List<T> ExecuteStoredProcedure<T>(String storedProcedureName, Dictionary<string, object> parameters = null)
        {
            using (MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["mysqlConnection"].ConnectionString))
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

                return ExecuteReader<T>(command);
            }
        }

        protected override List<T> ExecuteReader<T>(DbCommand command)
        {
            List<T> results = new List<T>();

            MySqlDataReader reader = ((MySqlCommand)command).ExecuteReader();

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