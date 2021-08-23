// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal static class SchemaMatchTracker
    {
        private static readonly ConcurrentDictionary<Schema, CSharpType?> _exactMatchCache = new ConcurrentDictionary<Schema, CSharpType?>();

        public static bool TryGetExactMatch(this Schema schema, out CSharpType? result)
        {
            return _exactMatchCache.TryGetValue(schema, out result);
        }

        private static bool ShouldSkipTemp(Schema schema)
        {
            //TODO: we need to add logic to replace SubResource with ResourceIdentifier where appropriate until then we won't remove these types
            return schema.Name.StartsWith("SubResource");
        }

        public static void SetExactMatch(this Schema schema, CSharpType? replacementType)
        {
            if (ShouldSkipTemp(schema))
                return;

            _exactMatchCache.TryAdd(schema, replacementType);
        }
    }
}
