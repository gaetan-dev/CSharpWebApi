using System;
using System.Collections.Generic;

namespace WebApiStarter.Components.Example
{
    public class MockExampleService : IExampleService
    {
        public List<ExampleModel> ReadAll()
        {
            return new List<ExampleModel>
            {
                new ExampleModel
                {
                    Id = "-1",
                    Prop1 = "Mock01",
                    Prop2 = "Mock02",
                },
                 new ExampleModel
                {
                    Id = "-2",
                    Prop1 = "Mock11",
                    Prop2 = "Mock12",
                }
            };
        }

        public ExampleModel Read(string id)
        {
            throw new NotImplementedException();
        }

        public ExampleModel Create(ExampleModel model)
        {
            throw new NotImplementedException();
        }

        public ExampleModel Update(ExampleModel model)
        {
            throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public List<ExampleModel> CallDb(string storedProcedure, Dictionary<string, object> parameters)
        {
            throw new NotImplementedException();
        }
    }
}