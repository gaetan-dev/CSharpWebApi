using System;
using System.Data;
using WebApiStarter.Commons.ExceptionLayer;

namespace WebApiStarter.Commons.ExtensionMethods
{
    public static class DataReaderExtension
    {
        public static T ParseField<T>(this IDataReader reader, string column) where T : IConvertible
        {
            try
            {
                int columnIndex = reader.GetOrdinal(column);
                string columnValue = reader.GetValue(columnIndex).ToString();
                return Tools.GenericTryParse<T>(columnValue);
            }
            catch (IndexOutOfRangeException)
            {
                CustomExceptionService.ThrowMappingNotValidException(column);
            }

            return default(T);
        }
    }
}