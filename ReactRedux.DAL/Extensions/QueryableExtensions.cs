using System;
using System.Collections.Generic;
using System.Linq;

namespace ReactRedux.DAL.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> OrderBy<T>(this IQueryable<T> source, IEnumerable<ISorter<T>> sorters)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            if (sorters == null)
            {
                return source;
            }
            using (var enumerator = sorters.GetEnumerator())
            {
                if (!enumerator.MoveNext())
                {
                    return source;
                }
                var orderedSource = enumerator.Current.ApplyOrderBy(source);
                while (enumerator.MoveNext())
                {
                    orderedSource = enumerator.Current.ApplyThenBy(orderedSource);
                }
                return orderedSource;
            }
        }
    }
}