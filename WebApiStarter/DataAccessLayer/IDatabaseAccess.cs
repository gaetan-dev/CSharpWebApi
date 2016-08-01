using System;
using System.Collections.Generic;
using WebApiStarter.Components;

namespace WebApiStarter.DataAccessLayer
{
    public interface IDatabaseAccess
    {
        List<T> ExecuteStoredProcedure<T>(String storedProcedureName, Dictionary<string, object> parameters = null) where T : IModel , new();
    }
}