using System.Data;

namespace WebApiStarter.Components
{
    public interface IModel
    {
        string Id { get; set; }

        void Map(IDataReader reader);

        bool IsEmpty();
    }
}