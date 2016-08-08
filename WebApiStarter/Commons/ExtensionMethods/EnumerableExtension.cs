using System.Collections.Generic;
using System.Linq;

namespace WebApiStarter.Commons.ExtensionMethods
{
    public static class EnumerableExtension
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable)
        {
            if (enumerable == null)
                return true;

            return !enumerable.Any();
        }
    }
}