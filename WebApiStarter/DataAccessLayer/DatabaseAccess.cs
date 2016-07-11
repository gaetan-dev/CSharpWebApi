using System;
using System.Collections.Generic;
using System.Data.Common;

namespace WebApiStarter.DataAccessLayer
{
    public abstract class DatabaseAccess
    {
        public abstract List<T> ExecuteStoredProcedure<T>(String storedProcedureName, Dictionary<string, object> parameters = null) where T : IModel , new();

        protected abstract List<T> ExecuteReader<T>(DbCommand command) where T : IModel, new();
    }
}