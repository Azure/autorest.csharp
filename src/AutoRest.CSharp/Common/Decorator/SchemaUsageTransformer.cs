// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Input;

namespace AutoRest.CSharp.Common.Decorator
{
    /// <summary>
    /// This class is used to transform usages for definitions listed in the "x-ms-format-element-type" property attribute.
    /// It must be run before the <see cref="DefaultDerivedSchema"/> transform (or any transforms that depend on the usages)
    /// so that the default derived schema logic is working with the correct usages.
    /// </summary>
    internal static class SchemaUsageTransformer
    {
        public static void Transform(CodeModel codeModel)
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

                // apply usages and media types based on the enclosing schemas for the properties that reference
                // the "x-ms-format-element-type" schema

                HashSet<string> additionalUsages = new();
                HashSet<KnownMediaType> additionalMediaTypes = new();
                foreach (var enclosingSchema in schemaToEnclosingSchemasMap[schema.Name])
                {
                    if (enclosingSchema is ObjectSchema objectSchema)
                    {
                        foreach (SchemaContext schemaUsage in objectSchema.Usage)
                        {
                            if (schemaUsage == SchemaContext.Exception) continue;
                            additionalUsages.Add(schemaUsage == SchemaContext.Input ? "input" : "output");
                        }

                        foreach (KnownMediaType mediaType in objectSchema.SerializationFormats)
                        {
                            additionalMediaTypes.Add(mediaType);
                        }
                    }
                }

                if (additionalUsages.Count > 0)
                {
                    // This is a hack to avoid needing to update the SchemaUsageProvider logic to look up the property schema using "x-ms-format-element-type"
                    // The problem with doing this here is that we don't know for sure if this should be a public model, but if we don't mark is as a model
                    // here then it will be generated as internal, since it will not necessarily be included in the SchemaUsageProvider logic that
                    // loops through model properties.
                    additionalUsages.Add("model");
                }

                // apply converter usage to any schemas that are referenced with "x-ms-format-element-type" in a property
                additionalUsages.Add("converter");

                // recursively apply the usages and media types to the schema and all property schemas on the schema
                Apply(schema, additionalUsages, additionalMediaTypes, new HashSet<ObjectSchema>());
            }
        }

        private static void Apply(ObjectSchema schema, HashSet<string> usages, HashSet<KnownMediaType> mediaTypes, HashSet<ObjectSchema> appliedSchemas)
        {
            if (appliedSchemas.Contains(schema))
                return;

            appliedSchemas.Add(schema);

            if (usages.Count > 0)
            {
                schema.Extensions ??= new RecordOfStringAndAny();
                if (!schema.Extensions!.TryGetValue("x-csharp-usage", out var existingUsages))
                {
                    schema.Extensions.Add("x-csharp-usage", string.Join(",", usages));
                }
                else
                {
                    if (existingUsages is string usage && !string.IsNullOrEmpty(usage))
                    {
                        schema.Extensions!["x-csharp-usage"] = usage + "," + string.Join(",", usages);
                    }
                    else
                    {
                        schema.Extensions!["x-csharp-usage"] = string.Join(",", usages);
                    }
                }
            }
            foreach (var mediaType in mediaTypes)
            {
                schema.SerializationFormats.Add(mediaType);
            }

            foreach (var property in schema.Properties)
            {
                if (property.Schema is ObjectSchema propertySchema)
                {
                    Apply(propertySchema, usages, mediaTypes, appliedSchemas);
                }
            }

            if (schema.Children != null)
            {
                foreach (var child in schema.Children!.Immediate)
                {
                    if (child is ObjectSchema propertySchema)
                    {
                        Apply(propertySchema, usages, mediaTypes, appliedSchemas);
                    }
                }
            }

            if (schema.Parents != null)
            {
                foreach (var parent in schema.Parents!.Immediate)
                {
                    if (parent is ObjectSchema propertySchema)
                    {
                        Apply(propertySchema, usages, mediaTypes, appliedSchemas);
                    }
                }
            }
        }
    }
}
