using System.ComponentModel;

namespace WebApiStarter.Commons
{
    public class Tools
    {
        public static T GenericTryParse<T>(string str)
        {
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));
            return (T)converter.ConvertFromString(str);
        }
    }
}