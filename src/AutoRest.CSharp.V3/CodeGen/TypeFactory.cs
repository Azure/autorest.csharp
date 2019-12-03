// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.V3.ClientModel;
using AutoRest.CSharp.V3.Utilities;

namespace AutoRest.CSharp.V3.CodeGen
{
    internal class TypeFactory
    {
        private readonly string _namespace;
        private readonly ISchemaTypeProvider[] _schemaTypes;

        public TypeFactory(string @namespace, ISchemaTypeProvider[] schemaTypes)
        {
            _namespace = @namespace;
            _schemaTypes = schemaTypes;
        }

        // Need types to be cached for YAML references to work properly (needs same instance)
        private readonly Type ListType = typeof(List<>);
        private readonly Type IEnumerableType = typeof(IEnumerable<>);
        private readonly Type ICollectionType = typeof(ICollection<>);
        private readonly Type DictionaryType = typeof(Dictionary<string, object>);
        private readonly Type IDictionaryType = typeof(IDictionary<string, object>);

        public CSharpType CreateType(ISchemaTypeProvider typeProvider)
        {
            return CreateTypeInfo(new SchemaTypeReference(typeProvider.Schema, false));
        }

        public CSharpType CreateType(ClientTypeReference clientTypeProvider)
        {
            return CreateTypeInfo(clientTypeProvider);
        }

        public CSharpType CreateConcreteType(ClientTypeReference clientTypeProvider)
        {
            return CreateTypeInfo(clientTypeProvider, useConcrete: true);
        }

        public CSharpType CreateInputType(ClientTypeReference clientTypeProvider)
        {
            return CreateTypeInfo(clientTypeProvider, useInput: true);
        }

        public ISchemaTypeProvider ResolveReference(SchemaTypeReference reference)
        {
            return _schemaTypes.Single(s => s.Schema == reference.Schema);
        }

        private CSharpType CreateTypeInfo(ClientTypeReference schema, bool useConcrete = false, bool useInput = false) =>
            schema switch
            {
                CollectionTypeReference arraySchema => ArrayTypeInfo(arraySchema, useConcrete, useInput),
                DictionaryTypeReference dictionarySchema => DictionaryTypeInfo(dictionarySchema, useConcrete),
                SchemaTypeReference schemaTypeReference => DefaultTypeInfo(schemaTypeReference),
                BinaryTypeReference binary => new CSharpType(typeof(byte[]), isNullable: binary.IsNullable),
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
            var type = ResolveReference(schemaReference);
            var schema = type.Schema;
            var apiVersion = schema.ApiVersions?.FirstOrDefault()?.Version.RemoveNonWordCharacters();
            return new CSharpType(
                new CSharpNamespace(_namespace.NullIfEmpty(), "Models", apiVersion != null ? $"V{apiVersion}" : schema.Language.Default.Namespace),
                type.Name,
                isNullable: schemaReference.IsNullable);
        }

        public CSharpType CreateType(ServiceClient clientTypeProvider)
        {
            return new CSharpType(
                new CSharpNamespace(_namespace.NullIfEmpty()),
                clientTypeProvider.Name,
                isNullable: false);
        }
    }
}
