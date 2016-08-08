using System.Data;

namespace WebApiStarter.Components.Example.Model
{
    public class ExampleModelFactory : ComponentFactory
    {
        public override IModel CreateModel(IDataReader reader)
        {
            Model = new ExampleModel();

            return base.CreateModel(reader);
        }
    }
}