using System;
using System.Collections.Generic;
using System.Linq;
using WebApiStarter.Commons.ExceptionLayer;
using WebApiStarter.DataAccessLayer;

namespace WebApiStarter.Components.Example
{
    public class ExampleService : IExampleService
    {
        private readonly IDatabaseAccess _databaseAccess;

        // Required for Acceptance Tests
        public ExampleService()
        {
            _databaseAccess = new MySqlDatabaseAccess();
        }

        // Required for Ninject
        public ExampleService(IDatabaseAccess databaseAccess)
        {
            _databaseAccess = databaseAccess;
        }

        public List<ExampleModel> ReadAll()
        {
            List<ExampleModel> result = CallDb("PS_ReadAllExamples", null);
            return result;
        }

        public ExampleModel Read(string id)
        {
            var parameters = new Dictionary<string, object> { { "P_Id", id } };

            List<ExampleModel> results = CallDb("PS_ReadExampleById ", parameters);

            if (results == null || results.Count == 0 || results[0].Id == null)
                CustomExceptionService.ThrowItemNotFoundException();

            // ReSharper disable once AssignNullToNotNullAttribute
            return results.First();
        }

        public ExampleModel Create(ExampleModel model)
        {
            var parameters = new Dictionary<string, object>
            {
                { "P_Prop1", model.Prop1    },
                { "P_Prop2", model.Prop2    }
            };

            string id = model.Id ?? Guid.NewGuid().ToString();
            parameters.Add("P_Id", id);

            return CallDb("PS_CreateExample", parameters).First();
        }

        public ExampleModel Update(ExampleModel model)
        {
            var parameters = new Dictionary<string, object>
            {
                { "P_Id"   , model.Id    },
                { "P_Prop1", model.Prop1 },
                { "P_Prop2", model.Prop2 }
            };

            return CallDb("PS_UpdateExample", parameters).First();
        }

        public void Delete(string id)
        {
            var parameters = new Dictionary<string, object> { { "P_Id", id } };

            CallDb("PS_DeleteExample", parameters);
        }

        public List<ExampleModel> CallDb(string storedProcedure, Dictionary<string, object> parameters)
        {
            return _databaseAccess.ExecuteStoredProcedure<ExampleModel>(storedProcedure, parameters);
        }
    }
}