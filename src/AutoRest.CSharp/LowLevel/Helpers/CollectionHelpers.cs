// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;

namespace AutoRest.CSharp.LowLevel.Helpers
{
    internal static class CollectionHelpers
    {
        /// <summary>
        /// This method get all possible combinations from a given list of arrays, by getting one element from each array
        /// For instance, if we have two arrays [1, 2] and [3, 4, 5], we should get the result of
        /// [1, 3], [1, 4], [1, 5], [2, 3], [2, 4], [2, 5] total 2x3=6 combinations
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IEnumerable<IEnumerable<T>> GetCombinations<T>(IEnumerable<IEnumerable<T>> source) where T : notnull
        {
            var queue = new Queue<List<T>>();
            queue.Enqueue(new List<T>());
            foreach (var level in source)
            {
                // get every element in queue out, and push the new results back
                int count = queue.Count;
                for (int i = 0; i < count; i++)
                {
                    var list = queue.Dequeue();
                    foreach (var item in level)
                    {
                        // push the results back with a new element on it
                        queue.Enqueue(new List<T>(list) { item });
                    }
                }
            }

            return queue;
        }
    }
}
