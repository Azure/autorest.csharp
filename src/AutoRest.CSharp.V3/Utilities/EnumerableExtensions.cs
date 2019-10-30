using System;
using System.Collections.Generic;

namespace AutoRest.CSharp.V3.Utilities
{
    internal static class EnumerableExtensions
    {
        public static void ForEachLast<T>(this IEnumerable<T> collection, Action<T>? actionExceptLast = null, Action<T>? actionOnLast = null) =>
            // ReSharper disable once IteratorMethodResultIsIgnored
            collection.SelectLast(i => { actionExceptLast?.Invoke(i); return true; }, i => { actionOnLast?.Invoke(i); return true; });

        public static IEnumerable<TResult> SelectLast<T, TResult>(this IEnumerable<T> collection, Func<T, TResult>? selectorExceptLast = null, Func<T, TResult>? selectorOnLast = null)
        {
            using var enumerator = collection.GetEnumerator();
            var isNotLast = enumerator.MoveNext();
            while (isNotLast)
            {
                var current = enumerator.Current;
                isNotLast = enumerator.MoveNext();
                var selector = isNotLast ? selectorExceptLast : selectorOnLast;
                //https://stackoverflow.com/a/32580613/294804
                if (selector != null)
                {
                    yield return selector.Invoke(current);
                }
            }
        }
    }
}
