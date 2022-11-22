// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;

namespace AutoRest.CSharp.Mgmt.Decorator.Transformer
{
    internal static class JsonConverterResolver
    {
        public static void ResolveConverter(CodeModel codeModel)
        {
            Dictionary<string, Property> map = new();

            foreach (var schema in codeModel.AllSchemas.OfType<ObjectSchema>())
            {
                foreach (var property in schema.Properties)
                {
                    if (property.Extensions?.TryGetValue("x-ms-format-element-type", out var value) == true)
                    {
                        map.Add((string)value, property);
                    }
                }
            }

            foreach (var schema in codeModel.AllSchemas.OfType<ObjectSchema>())
            {
                if (map.TryGetValue(schema.Name, out var property))
                {
                    property.Extensions!["x-ms-format-element-type"] = schema;
                    schema.Extensions ??= new RecordOfStringAndAny();
                    if (!schema.Extensions!.TryGetValue("x-csharp-usage", out var usages))
                    {
                        schema.Extensions.Add("x-csharp-usage", "converter");
                    }
                    else
                    {
                        if (usages is string usage && !string.IsNullOrEmpty(usage))
                        {
                            schema.Extensions!["x-csharp-usage"] += ",converter";
                        }
                        else
                        {
                            schema.Extensions!["x-csharp-usage"] = "converter";
                        }
                    }
                }
            }
        }
    }
}
