using System.Collections.Generic;

namespace WebApiStarter
{
    public interface IService<T>
    {
        List<T> GetAll();

        T Get(int id);

        void Set(T model);

        void Delete(int id);

        List<T> CallDb(string storedProcedure, Dictionary<string, object> parameters);
    }
}