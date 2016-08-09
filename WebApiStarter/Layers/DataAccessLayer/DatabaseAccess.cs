using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using WebApiStarter.Components;
using WebApiStarter.Components.Example.Model;

namespace WebApiStarter.Layers.DataAccessLayer
{
    public abstract class DatabaseAccess : IDatabaseAccess
    {
        protected DbConnection Connection;
        protected DbCommand    Command;

        public abstract List<T> ExecuteStoredProcedure<T>(string storedProcedureName,
            Dictionary<string, object> parameters = null) where T : IModel, new();

        protected List<T> ExecuteReader<T>() where T : IModel, new()
        {
            List<T> results = new List<T>();

            IDataReader reader = Command.ExecuteReader();

            ComponentFactory factory = new ExampleModelFactory();

            while (reader.Read())
            {
                T model = (T)factory.CreateModel(reader);
                if (!model.IsEmpty())
                    results.Add(model);
            }

            reader.Close();
            return results;
        }

        protected abstract void SetupCommand(string storedProcedureName, Dictionary<string, object> parameters = null);
    }
}