using System.Collections.Generic;
using System.Linq;

namespace bengogogadget.core.Extensions
{
    public static class IEnumerableExtensions
    {
        public static string ToBase64Hash(this IEnumerable<string> collection)
        {
            if (collection == null)
            {
                return null;
            }
            
            return string.Join(",", collection.OrderByDescending(x => x)).ToBase64String();
        }
    }
}
