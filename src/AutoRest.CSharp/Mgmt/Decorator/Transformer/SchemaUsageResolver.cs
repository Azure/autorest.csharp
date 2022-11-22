// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Input;

namespace AutoRest.CSharp.Mgmt.Decorator.Transformer
{
    internal static class SchemaUsageResolver
    {
        public static void ResolveConverter(CodeModel codeModel)
        {
            Dictionary<string, List<Property>> schemaToPropertyMap = new();
            Dictionary<string, List<Schema>> schemaToEnclosingSchemasMap = new();

            foreach (var schema in codeModel.AllSchemas.OfType<ObjectSchema>())
            {
                foreach (var property in schema.Properties)
                {
                    if (property.Extensions?.TryGetValue("x-ms-format-element-type", out var value) == true)
                    {
                        string valueString = (string)value;

                        if (!schemaToPropertyMap.ContainsKey(valueString))
                        {
                            schemaToPropertyMap.Add(valueString, new List<Property>());
                        }

                        if (!schemaToEnclosingSchemasMap.ContainsKey(valueString))
                        {
                            schemaToEnclosingSchemasMap.Add(valueString, new List<Schema>());
                        }

                        schemaToPropertyMap[valueString].Add(property);
                        schemaToEnclosingSchemasMap[valueString].Add(schema);
                    }
                }
            }

            foreach (var schema in codeModel.AllSchemas.OfType<ObjectSchema>())
            {
                if (!schemaToPropertyMap.TryGetValue(schema.Name, out var propertyList)) continue;

                foreach (var property in propertyList)
                {
                    property.Extensions!["x-ms-format-element-type"] = schema;
                }

                schema.Extensions ??= new RecordOfStringAndAny();

                // apply converter usage to any schemas that are referenced with "x-ms-format-element-type" in a property

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

                // apply input/output usages based on the enclosing schemas for the properties that reference
                // the "x-ms-format-element-type" schema

                HashSet<string> additionalUsages = new();
                foreach (var enclosingSchema in schemaToEnclosingSchemasMap[schema.Name])
                {
                    if (enclosingSchema is ObjectSchema objectSchema)
                    {
                        foreach (SchemaContext schemaUsage in objectSchema.Usage)
                        {
                            if (schemaUsage == SchemaContext.Exception) continue;
                            additionalUsages.Add(schemaUsage == SchemaContext.Input ? "input" : "output");
                        }
                    }
                }
                if (additionalUsages.Count > 0)
                {
                    additionalUsages.Add("model");
                    schema.Extensions!["x-csharp-usage"] += "," + string.Join(",", additionalUsages);
                }
            }
        }
    }
}
