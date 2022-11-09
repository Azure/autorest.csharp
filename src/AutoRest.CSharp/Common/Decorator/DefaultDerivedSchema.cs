﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Common.Decorator
{
    internal static class DefaultDerivedSchema
    {
        public const string DefaultDerivedExtension = "x-ms-autorest-defaultDerivedSchema";

        public static void AddDefaultDerivedSchemas(CodeModel codeModel)
        {
            Dictionary<string, ObjectSchema> defaultDerivedSchemas = new Dictionary<string, ObjectSchema>();
            foreach (var schema in codeModel.Schemas.Objects)
            {
                BuildInternalDefaultDerivedType(schema, defaultDerivedSchemas);
            }

            foreach (var defaultDerivedSchema in defaultDerivedSchemas.Values.Distinct())
            {
                codeModel.Schemas.Objects.Add(defaultDerivedSchema);
            }
        }

        public static ObjectSchema? GetDefaultDerivedSchema(this ObjectSchema schema)
        {
            object? result = null;
            schema.Extensions?.TryGetValue(DefaultDerivedExtension, out result);
            return result as ObjectSchema;
        }

        private static void BuildInternalDefaultDerivedType(ObjectSchema schema, Dictionary<string, ObjectSchema> defaultDerivedSchemas)
        {
            // TODO: Avoid potential duplicated schema name and discriminator value.
            // Note: When this Todo is done, the method IsDescendantOf also needs to be updated.
            // Reason:
            // Here we just hard coded the name and discriminator value for the internal backing schema.
            // This could work now, but there are also potential duplicate conflict issue.
            bool isChildPoly = schema.DiscriminatorValue is not null;
            bool isBasePoly = schema.IsBasePolySchema();
            if (!isChildPoly && !isBasePoly)
                return;

            var actualBaseSchema = isBasePoly ? schema : schema.Parents?.All.FirstOrDefault(parent => parent is ObjectSchema objectParent && objectParent.IsBasePolySchema()) as ObjectSchema;
            if (actualBaseSchema is null)
                throw new InvalidOperationException($"Found a child poly {schema.Language.Default.Name} that we weren't able to determine its base poly from {string.Join(',', schema.Parents?.Immediate.Select(p => p.Name) ?? Array.Empty<string>())}");

            //Since the unknown type is used for deserialization only we don't need to create if its an input only model
            var hasXCsharpUsageOutput = !actualBaseSchema.Extensions?.Usage?.Contains("output", StringComparison.OrdinalIgnoreCase);
            if (!actualBaseSchema.Usage.Contains(SchemaContext.Output) &&
                !actualBaseSchema.Usage.Contains(SchemaContext.Exception) &&
                (!hasXCsharpUsageOutput.HasValue ||
                hasXCsharpUsageOutput.Value))
                return;

            ObjectSchema? defaultDerivedSchema = null;

            //if I have children and parents then I am my own defaultDerivedType
            if (actualBaseSchema.HasParentsWithDiscriminator())
                defaultDerivedSchema = actualBaseSchema;

            if (defaultDerivedSchema is null)
            {
                string defaultDerivedSchemaName = "Unknown" + actualBaseSchema.Language.Default.Name;
                if (!defaultDerivedSchemas.TryGetValue(defaultDerivedSchemaName, out defaultDerivedSchema))
                {
                    //TODO: Not sure if we want to do this or have a linter rule to block fixed enums from discriminators
                    //if (actualBaseSchema.Discriminator?.Property.Schema is SealedChoiceSchema sealedChoiceSchema)
                    //{
                    //    if (!sealedChoiceSchema.Choices.Any(v => v.Value == "Unknown" || v.Value == "None"))
                    //    {
                    //        var unknownChoice = new ChoiceValue();
                    //        unknownChoice.Value = "Unknown";
                    //        sealedChoiceSchema.Choices.Add(unknownChoice);
                    //    }
                    //}
                    defaultDerivedSchema = new ObjectSchema
                    {
                        Language = new Languages
                        {
                            Default = new Language
                            {
                                Name = defaultDerivedSchemaName
                            }
                        },
                        Parents = new Relations
                        {
                            All = { actualBaseSchema },
                            Immediate = { actualBaseSchema }
                        },
                        DiscriminatorValue = "Unknown",
                        SerializationFormats = { KnownMediaType.Json },
                    };

                    if (actualBaseSchema.Parents is not null)
                    {
                        foreach (var p in actualBaseSchema.Parents.All)
                        {
                            defaultDerivedSchema.Parents.All.Add(p);
                        };
                    }

                    defaultDerivedSchema.Extensions = new RecordOfStringAndAny { { "x-ms-skip-init-ctor", true } };
                    HashSet<string> usages = new HashSet<string>();
                    usages.Add("Model");
                    if (actualBaseSchema.Usage.Contains(SchemaContext.Input))
                        usages.Add("Input");
                    if (actualBaseSchema.Usage.Contains(SchemaContext.Output) || actualBaseSchema.Usage.Contains(SchemaContext.Exception))
                        usages.Add("Output");
                    if (actualBaseSchema.Extensions?.Usage?.Contains("output", StringComparison.OrdinalIgnoreCase) ?? false)
                        usages.Add("Output");
                    if (actualBaseSchema.Extensions?.Usage?.Contains("input", StringComparison.OrdinalIgnoreCase) ?? false)
                        usages.Add("Input");

                    defaultDerivedSchema.Extensions.Add("x-csharp-usage", string.Join(',', usages));
                    defaultDerivedSchema.Extensions.Add(DefaultDerivedExtension, defaultDerivedSchema);
                    defaultDerivedSchemas.Add(defaultDerivedSchema.Name, defaultDerivedSchema);
                }
            }

            if (defaultDerivedSchema is not null)
            {
                if (schema.Extensions is null)
                    schema.Extensions = new RecordOfStringAndAny();
                schema.Extensions.Add(DefaultDerivedExtension, defaultDerivedSchema);
            }
        }

        private static bool IsBasePolySchema(this ObjectSchema schema)
        {
            return schema.Discriminator?.All is not null ||
                (schema.Discriminator is not null && !schema.HasParentsWithDiscriminator()); //this is the case where I am a solo placeholder but might have derived types later
        }

        private static bool HasParentsWithDiscriminator(this ObjectSchema schema)
        {
            return schema.Parents?.All.Count > 0 && schema.Parents.All.Any(parent => parent is ObjectSchema objectSchema && objectSchema.Discriminator is not null);
        }
    }
}
