using System.Data;

namespace WebApiStarter.Components
{
    public interface IModel
    {
        int Id { get; set; }

        void Map(IDataReader reader);
    }
}