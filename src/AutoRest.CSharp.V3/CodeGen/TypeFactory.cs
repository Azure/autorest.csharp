// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.V3.ClientModels;
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

        public CSharpType CreateType(ISchemaTypeProvider typeProvider) => CreateTypeInfo(new SchemaTypeReference(typeProvider.Schema, false));
        public CSharpType CreateType(ClientTypeReference clientTypeProvider) => CreateTypeInfo(clientTypeProvider);
        public CSharpType CreateConcreteType(ClientTypeReference clientTypeProvider) => CreateTypeInfo(clientTypeProvider, useConcrete: true);
        public CSharpType CreateInputType(ClientTypeReference clientTypeProvider) => CreateTypeInfo(clientTypeProvider, useInput: true);

        public ISchemaTypeProvider ResolveReference(SchemaTypeReference reference) => _schemaTypes.Single(s => s.Schema == reference.Schema);

        private CSharpType CreateTypeInfo(ClientTypeReference schema, bool useConcrete = false, bool useInput = false) => schema switch
        {
            CollectionTypeReference arraySchema => ArrayTypeInfo(arraySchema, useConcrete, useInput),
            DictionaryTypeReference dictionarySchema => DictionaryTypeInfo(dictionarySchema, useConcrete),
            SchemaTypeReference schemaTypeReference => DefaultTypeInfo(schemaTypeReference),
            BinaryTypeReference binary => new CSharpType(typeof(byte[]), isNullable: binary.IsNullable),
            FrameworkTypeReference frameworkTypeReference => new CSharpType(frameworkTypeReference.Type, isNullable: frameworkTypeReference.IsNullable),
            _ => throw new NotImplementedException()
        };

        private CSharpType ArrayTypeInfo(CollectionTypeReference schema, bool useConcrete = false, bool useInput = false) =>
            new CSharpType(useConcrete ? typeof(List<>) : (useInput ? typeof(IEnumerable<>) : typeof(ICollection<>)),CreateTypeInfo(schema.ItemType));

        private CSharpType DictionaryTypeInfo(DictionaryTypeReference schema, bool useConcrete = false) =>
            new CSharpType(useConcrete ? typeof(Dictionary<string, object>) : typeof(IDictionary<string, object>), CreateTypeInfo(schema.KeyType), CreateTypeInfo(schema.ValueType));

        private CSharpType DefaultTypeInfo(SchemaTypeReference schemaReference)
        {
            var type = ResolveReference(schemaReference);
            var schema = type.Schema;
            var apiVersion = schema.ApiVersions?.FirstOrDefault()?.Version.RemoveNonWordCharacters();
            return new CSharpType(
                new CSharpNamespace(_namespace.NullIfEmpty(), "Models", apiVersion != null ? $"V{apiVersion}" : schema.Language.Default.Namespace),
                type.Name,
                isNullable: schemaReference.IsNullable,
                isValueType: type is ClientEnum);
        }

        public CSharpType CreateType(string name) =>
            new CSharpType(new CSharpNamespace(_namespace.NullIfEmpty()), name, isNullable: false);
    }
}
