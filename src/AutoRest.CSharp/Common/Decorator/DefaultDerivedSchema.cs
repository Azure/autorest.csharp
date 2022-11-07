// Copyright (c) Microsoft Corporation. All rights reserved.
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

            string defaultDerivedSchemaName = "Unknown" + actualBaseSchema.Language.Default.Name;
            ObjectSchema? defaultDerivedSchema = null;
            if (!defaultDerivedSchemas.TryGetValue(defaultDerivedSchemaName, out defaultDerivedSchema))
            {
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
                    //Discriminator = actualBaseSchema.Discriminator,
                    DiscriminatorValue = "Unknown", //TODO: do we need to handle int / fixed enums?
                    SerializationFormats = { KnownMediaType.Json },
                };
                defaultDerivedSchema.Extensions = new RecordOfStringAndAny { { "x-ms-skip-init-ctor", true } };
                List<string> usages = new List<string>();
                usages.Add("Model");
                if (actualBaseSchema.Usage.Contains(SchemaContext.Input))
                    usages.Add("Input");
                if (actualBaseSchema.Usage.Contains(SchemaContext.Output) || actualBaseSchema.Usage.Contains(SchemaContext.Exception))
                    usages.Add("Output");
                defaultDerivedSchema.Extensions.Add("x-csharp-usage", string.Join(',', usages));
                defaultDerivedSchema.Extensions.Add(DefaultDerivedExtension, defaultDerivedSchema);
                defaultDerivedSchemas.Add(defaultDerivedSchema.Name, defaultDerivedSchema);
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
            return schema.Discriminator?.All is not null;
        }
    }
}
