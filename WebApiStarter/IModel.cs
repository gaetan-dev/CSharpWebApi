using System.Data;

namespace WebApiStarter
{
    public interface IModel
    {
        int Id { get; set; }

        void Map(IDataReader reader);
    }
}