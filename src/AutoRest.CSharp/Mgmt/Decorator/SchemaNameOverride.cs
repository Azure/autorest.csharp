// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using AutoRest.CSharp.AutoRest.Plugins;
using AutoRest.CSharp.Input;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal static class SchemaNameOverride
    {
        private static ConcurrentDictionary<Schema, string> _valueCache = new ConcurrentDictionary<Schema, string>();

        public static string MgmtName(this Schema schema, MgmtConfiguration config)
        {
            string? result;
            if (_valueCache.TryGetValue(schema, out result))
                return result;

            result = GetName(schema, config);
            _valueCache.TryAdd(schema, result);
            return result;
        }

        private static string GetName(Schema schema, MgmtConfiguration config)
        {
            string? name;
            if (config.ModelToResource.TryGetValue(schema.Name, out name))
            {
                return name;
            }
            else if (config.ModelRename.TryGetValue(schema.Name, out name))
            {
                return name;
            }
            else
            {
                return schema.Name;
            }
        }
    }
}
