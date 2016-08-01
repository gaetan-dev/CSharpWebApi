using System.Collections.Generic;

namespace WebApiStarter.Components
{
    public interface IService<T>
    {
        List<T> ReadAll();

        T Read(string id);

        T Create(T model);

        T Update(T model);

        void Delete(string id);

        List<T> CallDb(string storedProcedure, Dictionary<string, object> parameters);
    }
}