using System;
using System.Collections.Generic;

namespace AutoRest.CSharp.V3.Utilities
{
    internal static class EnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> collection, Action<T>? actionExceptLast = null, Action<T>? actionOnLast = null)
        {
            using var enumerator = collection.GetEnumerator();
            var isNotLast = enumerator.MoveNext();
            while (isNotLast)
            {
                var current = enumerator.Current;
                isNotLast = enumerator.MoveNext();
                var action = isNotLast ? actionExceptLast : actionOnLast;
                action?.Invoke(current);
            }
        }
    }
}
