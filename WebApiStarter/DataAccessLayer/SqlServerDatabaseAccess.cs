using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace WebApiStarter.DataAccessLayer
{
    public class SqlServerDatabaseAccess : DatabaseAccess
    {
        private static DatabaseAccess _instance;
        public static DatabaseAccess GetInstance()
        {
            return _instance ?? (_instance = new SqlServerDatabaseAccess());
        }

        public override List<T> ExecuteStoredProcedure<T>(String storedProcedureName, Dictionary<string, object> parameters = null)
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

        protected override List<T> ExecuteReader<T>(DbCommand command)
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