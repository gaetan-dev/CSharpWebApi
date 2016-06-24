using System.Collections.Generic;

namespace WebApiStarter
{
    internal interface IRepoDb<T>
    {
        List<T> GetAll();
        T Get(int id);
        void Set(T model);
        void Delete(int id);
        List<T> CallDb(string storedProcedure, Dictionary<string, object> parameters);
    }
}