using System.Collections.Generic;

namespace Auth.Infrastructure.Extension
{
    public static class CollectionExt
    {
        public static bool IsNullOrEmpty<T>(this ICollection<T> source)
        {
            if (source != null)
            {
                return source.Count <= 0;
            }
            return true;
        }
    }
}