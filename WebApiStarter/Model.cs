using System;
using System.Data;

namespace WebApiStarter
{
    public abstract class Model
    {
        public abstract void Mapping(IDataReader reader);

        protected static bool HasColumn(IDataReader dr, string columnName)
        {
            for (int i = 0; i < dr.FieldCount; i++)
            {
                if (dr.GetName(i).Equals(columnName, StringComparison.InvariantCultureIgnoreCase))
                    if (dr[columnName].ToString().Length > 0)
                        return true;
            }
            return false;
        }
    }
}