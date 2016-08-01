using System.Collections.Generic;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;
using WebApiStarter.Components;

namespace WebApiStarter.Layers.DataAccessLayer
{
    public class MySqlDatabaseAccess : IDatabaseAccess
    {
        private MySqlConnection _connection;
        private MySqlCommand    _command;

        public List<T> ExecuteStoredProcedure<T>(string storedProcedureName, Dictionary<string, object> parameters = null) where T : IModel, new()
        {
            using (_connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["mysqlConnection"].ConnectionString))
            {
                SetupCommand(storedProcedureName, parameters);

                _connection.Open();

                return ExecuteReader<T>();
            }
        }

        private List<T> ExecuteReader<T>() where T : IModel, new()
        {
            List<T> results = new List<T>();

            MySqlDataReader reader = _command.ExecuteReader();

            while (reader.Read())
            {
                T model = new T();
                model.Map(reader);
                results.Add(model);
            }

            reader.Close();
            return results;
        }

        private void SetupCommand(string storedProcedureName, Dictionary<string, object> parameters = null)
        {
            _command = new MySqlCommand(storedProcedureName, _connection)
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = storedProcedureName,
                Connection = _connection
            };

            if (parameters != null)
            {
                foreach (var key in parameters.Keys)
                {
                    _command.Parameters.AddWithValue(key, parameters[key]);
                }
            }
        }
    }
}