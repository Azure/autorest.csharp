// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace AutoRest.CSharp.Mgmt.Report
{
    internal static class TransformStoreExtension
    {
        public static T AddToTransformerStore<T>(this T items, string transformerType) where T : IEnumerable<string>
        {
            foreach (var item in items)
                TransformStore.Instance.AddTransformer(transformerType, item);
            return items;
        }

        public static IReadOnlyDictionary<string, string> AddToTransformerStore(this IReadOnlyDictionary<string, string> dict, string transformerType)
        {
            return AddToTransformerStore<string>(dict, transformerType, (arg) => new TransformItem[] { new TransformItem(arg.Type, arg.Key, arg.Value) });
        }

        public static IReadOnlyDictionary<string, T> AddToTransformerStore<T>(this IReadOnlyDictionary<string, T> dict, string transformerType, Func<(string Type, string Key, T Value), IEnumerable<TransformItem>> toTransformerArguments)
        {
            foreach (var kv in dict)
            {
                var items = toTransformerArguments((transformerType, kv.Key, kv.Value));
                TransformStore.Instance.AddTransformers(items);
            }
            return dict;
        }
    }
}
