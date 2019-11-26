// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.V3.Pipeline;
using AutoRest.CSharp.V3.Pipeline.Generated;
using AutoRest.CSharp.V3.Utilities;

namespace AutoRest.CSharp.V3.Plugins
{
    internal class TypeFactory
    {
        private readonly string _namespace;

        public TypeFactory(string @namespace)
        {
            _namespace = @namespace;
        }

        public CSharpType CreateType(Schema schema)
        {
            schema = schema ?? throw new ArgumentNullException(nameof(schema));

            return CreateTypeInfo(schema);
        }

        public CSharpType? CreateConcreteType(Schema schema)
        {
            if (!(schema is ArraySchema || schema is DictionarySchema))
            {
                return CreateType(schema);
            }

            return CreateTypeInfo(schema, true);
        }

        public CSharpType? CreateInputType(Schema schema)
        {
            if (!(schema is ArraySchema || schema is DictionarySchema))
            {
                return CreateType(schema);
            }

            return CreateTypeInfo(schema, false, true);
        }

        public CSharpType CreateType(OperationGroup operationGroup)
        {
            var apiVersion = operationGroup.Operations.Where(o => o.ApiVersions != null).SelectMany(o => o.ApiVersions).FirstOrDefault()?.Version.RemoveNonWordCharacters();
            return new CSharpType
            {
                Name = operationGroup.CSharpName() ?? operationGroup.Language.Default.Name,
                Namespace = new CSharpNamespace
                {
                    Base = _namespace.NullIfEmpty(),
                    Category = "Operations",
                    ApiVersion = apiVersion != null ? $"V{apiVersion}" : null
                }
            };
        }

        // TODO: Clean this type selection mechanism up
        private CSharpType? CreateTypeInfo(Schema schema, bool useConcrete = false, bool useInput = false) =>
            schema switch
            {
                { } s when s.Type.ToFrameworkCSharpType() is { } t => t,
                ArraySchema arraySchema => ArrayTypeInfo(arraySchema, useConcrete, useInput),
                DictionarySchema dictionarySchema => DictionaryTypeInfo(dictionarySchema, useConcrete),
                ConstantSchema constantSchema => ConstantTypeInfo(constantSchema),
                _ => DefaultTypeInfo(schema)
            };

        // Need types to be cached for YAML references to work properly (needs same instance)
        private readonly Type ListType = typeof(List<>);
        private readonly Type IEnumerableType = typeof(IEnumerable<>);
        private readonly Type ICollectionType = typeof(ICollection<>);
        private readonly Type DictionaryType = typeof(Dictionary<string, object>);
        private readonly Type IDictionaryType = typeof(IDictionary<string, object>);

        private CSharpType ArrayTypeInfo(ArraySchema schema, bool useConcrete = false, bool useInput = false) =>
            new CSharpType
            {
                FrameworkType = useConcrete ? ListType : (useInput ? IEnumerableType : ICollectionType),
                SubType1 = CreateTypeInfo(schema.ElementType)
            };

        private CSharpType DictionaryTypeInfo(DictionarySchema schema,
            bool useConcrete = false) =>
            new CSharpType
            {
                // The generic type arguments are not used when assigning them via FrameworkType.
                FrameworkType = useConcrete ? DictionaryType : IDictionaryType,
                SubType1 = AllSchemaTypes.String.ToFrameworkCSharpType(),
                SubType2 = CreateTypeInfo(schema.ElementType)
            };

        private CSharpType ConstantTypeInfo(ConstantSchema schema) => CreateTypeInfo(schema.ValueType) ?? AllSchemaTypes.String.ToFrameworkCSharpType()!;

        private CSharpType DefaultTypeInfo(Schema schema)
        {
            var apiVersion = schema.ApiVersions?.FirstOrDefault()?.Version.RemoveNonWordCharacters();
            return new CSharpType
            {
                Name = schema.CSharpName() ?? schema.Language.Default.Name,
                Namespace = new CSharpNamespace
                {
                    Base = _namespace.NullIfEmpty(),
                    Category = "Models",
                    ApiVersion = apiVersion != null ? $"V{apiVersion}" : schema.Language.Default.Namespace
                }
            };
        }
    }
}
