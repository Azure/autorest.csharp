// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using AutoRest.CSharp.Input;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal static class SchemaMatchTracker
    {
        private static readonly ConcurrentDictionary<Schema, bool> _exactMatchCache = new ConcurrentDictionary<Schema, bool>();

        public static bool GetExactMatch(this Schema schema)
        {
            return _exactMatchCache.TryGetValue(schema, out bool result) && result;
        }

        private static bool ShouldSkipTemp(Schema schema)
        {
            return schema.Name.StartsWith("SubResource");
        }

        public static void SetExactMatch(this Schema schema)
        {
            if (ShouldSkipTemp(schema))
                return;

            _exactMatchCache.TryAdd(schema, true);
        }
    }
}
