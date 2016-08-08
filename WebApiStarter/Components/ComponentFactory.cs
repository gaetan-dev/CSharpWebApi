using System.Data;

namespace WebApiStarter.Components
{
    public abstract class ComponentFactory
    {
        protected IModel Model;

        public virtual IModel CreateModel(IDataReader reader)
        {
            Model.Map(reader);

            return Model;
        }
    }
}