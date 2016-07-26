using System.Collections.Generic;
using WebApiStarter.Commons.ExceptionLayer;
using WebApiStarter.DataAccessLayer;

namespace WebApiStarter.Components.Example
{
    public class ExampleService : IService<Example>
    {
        public List<Example> GetAll()
        {
            List<Example> result = CallDb("PS_GetAllExamples", null);
            return result;
        }

        public Example Get(int id)
        {
            var parameters = new Dictionary<string, object> { { "P_Id", id } };

            List<Example> results = CallDb("PS_GetExampleById ", parameters);

            if (results == null || results.Count == 0 || results[0].Id == -1)
                CustomExceptionService.ThrowItemNotFoundException();

            // ReSharper disable once PossibleNullReferenceException
            return results[0];
        }

        public void Set(Example model)
        {
            var parameters = new Dictionary<string, object>
            {
                { "P_Id"   , model.Id    },
                { "P_Prop1", model.Prop1 },
                { "P_Prop2", model.Prop2 }
            };

            CallDb("PS_SetExample", parameters);
        }

        public void Delete(int id)
        {
            var parameters = new Dictionary<string, object> { { "P_Id", id } };

            CallDb("PS_DeleteExample", parameters);
        }

        public List<Example> CallDb(string storedProcedure, Dictionary<string, object> parameters)
        {
            return MySqlDatabaseAccess.GetInstance().ExecuteStoredProcedure<Example>(storedProcedure, parameters);
        }
    }
}