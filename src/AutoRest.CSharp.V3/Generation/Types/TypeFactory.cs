// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.V3.Output.Models.TypeReferences;
using AutoRest.CSharp.V3.Output.Models.Types;
using AutoRest.CSharp.V3.Utilities;

namespace AutoRest.CSharp.V3.Generation.Types
{
    internal class TypeFactory
    {
        private readonly ISchemaType[] _schemaTypes;

        public TypeFactory(ISchemaType[] schemaTypes)
        {
            _schemaTypes = schemaTypes;
        }

        public CSharpType CreateType(TypeReference typeProvider) => CreateTypeInfo(typeProvider);
        public CSharpType CreateConcreteType(TypeReference typeProvider) => CreateTypeInfo(typeProvider, useConcrete: true);
        public CSharpType CreateInputType(TypeReference typeProvider) => CreateTypeInfo(typeProvider, useInput: true);
        public ISchemaType ResolveReference(SchemaTypeReference reference) => _schemaTypes.Single(s => s.Schema == reference.Schema);

        private CSharpType CreateTypeInfo(TypeReference schema, bool useConcrete = false, bool useInput = false) => schema switch
        {
            CollectionTypeReference arraySchema => ArrayTypeInfo(arraySchema, useConcrete, useInput),
            DictionaryTypeReference dictionarySchema => DictionaryTypeInfo(dictionarySchema, useConcrete),
            SchemaTypeReference schemaTypeReference => DefaultTypeInfo(schemaTypeReference),
            FrameworkTypeReference frameworkTypeReference => new CSharpType(frameworkTypeReference.Type, isNullable: frameworkTypeReference.IsNullable),
            _ => throw new NotImplementedException()
        };

        private CSharpType ArrayTypeInfo(CollectionTypeReference schema, bool useConcrete = false, bool useInput = false)
        {
            bool isNullable = schema.IsNullable;
            Type type;
            if (useConcrete)
            {
                type = typeof(List<>);
                isNullable = false;
            }
            else if (useInput)
            {
                type = typeof(IEnumerable<>);
            }
            else
            {
                type = typeof(ICollection<>);
            }

            return new CSharpType(type, isNullable, CreateTypeInfo(schema.ItemType));
        }

        private CSharpType DictionaryTypeInfo(DictionaryTypeReference schema, bool useConcrete = false)
        {
            Type type;
            bool isNullable = schema.IsNullable;
            if (useConcrete)
            {
                type = typeof(Dictionary<,>);
                isNullable = false;
            }
            else
            {
                type = typeof(IDictionary<,>);
            }

            return new CSharpType(type, isNullable, CreateTypeInfo(schema.KeyType), CreateTypeInfo(schema.ValueType));
        }

        private CSharpType DefaultTypeInfo(SchemaTypeReference schemaReference)
        {
            return ResolveReference(schemaReference).Type.WithNullable(schemaReference.IsNullable);
        }
    }
}
