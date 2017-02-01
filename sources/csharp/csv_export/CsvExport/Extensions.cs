using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsvExport
{
    public static class Extensions
    {
        public static IEnumerable<TResult> Map<TSource, TResult>(
            this IEnumerable<TSource> source,
            Func<TSource, TResult> mapper
        )
        {
            foreach (var item in source)
                yield return mapper(item);
        }
    }
}