// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.V3.ClientModel;
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

        public CSharpType CreateType(ISchemaTypeProvider clientTypeProvider)
        {
            return DefaultTypeInfo(clientTypeProvider.Schema);
        }

        public CSharpType CreateType(Schema schema)
        {
            schema = schema ?? throw new ArgumentNullException(nameof(schema));

            return CreateTypeInfo(schema);
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
            return new CSharpType(
                new CSharpNamespace(_namespace.NullIfEmpty(), "Operations", apiVersion != null ? $"V{apiVersion}" : operationGroup.Language.Default.Namespace),
                operationGroup.CSharpName() ?? operationGroup.Language.Default.Name);
        }

        // TODO: Clean this type selection mechanism up
        private CSharpType? CreateTypeInfo(Schema schema, bool useConcrete = false, bool useInput = false) =>
            schema switch
            {
                Schema s when s.Type.ToFrameworkCSharpType() is Type t => new CSharpType(t),
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
            new CSharpType(useConcrete ? ListType : (useInput ? IEnumerableType : ICollectionType),
                CreateTypeInfo(schema.ElementType));

        private CSharpType DictionaryTypeInfo(DictionarySchema schema,
            bool useConcrete = false) =>
            new CSharpType(useConcrete ? DictionaryType : IDictionaryType, new CSharpType(typeof(string)), CreateTypeInfo(schema.ElementType));

        private CSharpType ConstantTypeInfo(ConstantSchema schema) => CreateTypeInfo(schema.ValueType) ?? new CSharpType(typeof(string));

        private CSharpType DefaultTypeInfo(Schema schema)
        {
            var apiVersion = schema.ApiVersions?.FirstOrDefault()?.Version.RemoveNonWordCharacters();
            return new CSharpType(
                new CSharpNamespace(_namespace.NullIfEmpty(), "Models", apiVersion != null ? $"V{apiVersion}" : schema.Language.Default.Namespace),
                schema.CSharpName() ?? schema.Language.Default.Name);
        }

        public CSharpType? CreateType(ClientTypeReference clientTypeProvider)
        {
            return CreateTypeInfo(clientTypeProvider);
        }

        public CSharpType? CreateConcreteType(ClientTypeReference clientTypeProvider)
        {
            return CreateTypeInfo(clientTypeProvider, useConcrete: true);
        }

        private CSharpType? CreateTypeInfo(ClientTypeReference schema, bool useConcrete = false, bool useInput = false) =>
            schema switch
            {
                CollectionTypeReference arraySchema => ArrayTypeInfo(arraySchema, useConcrete, useInput),
                DictionaryTypeReference dictionarySchema => DictionaryTypeInfo(dictionarySchema, useConcrete),
                SchemaTypeReference schemaTypeReference => DefaultTypeInfo(schemaTypeReference),
                FrameworkTypeReference frameworkTypeReference => new CSharpType(frameworkTypeReference.Type, isNullable: frameworkTypeReference.IsNullable),
                _ => throw new NotImplementedException()
            };

        private CSharpType ArrayTypeInfo(CollectionTypeReference schema, bool useConcrete = false, bool useInput = false) =>
            new CSharpType(useConcrete ? ListType : (useInput ? IEnumerableType : ICollectionType),
                CreateTypeInfo(schema.ItemType));

        private CSharpType DictionaryTypeInfo(DictionaryTypeReference schema,
            bool useConcrete = false) =>
            new CSharpType(useConcrete ? DictionaryType : IDictionaryType, CreateTypeInfo(schema.KeyType), CreateTypeInfo(schema.ValueType));

        private CSharpType DefaultTypeInfo(SchemaTypeReference schemaReference)
        {
            var schema = schemaReference.Schema;
            var apiVersion = schema.ApiVersions?.FirstOrDefault()?.Version.RemoveNonWordCharacters();
            return new CSharpType(
                new CSharpNamespace(_namespace.NullIfEmpty(), "Models", apiVersion != null ? $"V{apiVersion}" : schema.Language.Default.Namespace),
                schema.CSharpName() ?? schema.Language.Default.Name,
                isNullable: schemaReference.IsNullable);
        }

    }
}
