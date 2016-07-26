using System;
using System.Collections.Generic;

namespace WebApiStarter.Components.Example
{
    public class MockExampleService : IExampleService
    {
        public List<Example> GetAll()
        {
            return new List<Example>
            {
                new Example()
                {
                    Id = -1,
                    Prop1 = "Mock01",
                    Prop2 = "Mock02",
                },
                 new Example()
                {
                    Id = -2,
                    Prop1 = "Mock11",
                    Prop2 = "Mock12",
                }
            };
        }

        public Example Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Set(Example model)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Example> CallDb(string storedProcedure, Dictionary<string, object> parameters)
        {
            throw new NotImplementedException();
        }
    }
}