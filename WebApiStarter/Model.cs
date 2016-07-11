using System.Data;

namespace WebApiStarter
{
    public abstract class Model
    {
        public int Id { get; set; }

        public abstract void Map(IDataReader reader);
    }
}