// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// 

using System.Collections.Generic;
using System.Linq;

namespace AutoRest.Core.Utilities.Collections
{
    public static class LinqExtensions
    {
        public static TValue AddOrSet<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue value)
        {
            lock (dictionary)
            {
                if (dictionary.ContainsKey(key))
                {
                    dictionary[key] = value;
                }
                else
                {
                    dictionary.Add(key, value);
                }
            }
            return value;
        }

        /// <summary>
        ///     Concatenates a single item to an IEnumerable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public static IEnumerable<T> ConcatSingleItem<T>(this IEnumerable<T> enumerable, T item) => (enumerable ?? Enumerable.Empty<T>()).Concat(item.SingleItemAsEnumerable());

        public static IEnumerable<T> SingleItemAsEnumerable<T>(this T item) => new[] { item };
    }
}