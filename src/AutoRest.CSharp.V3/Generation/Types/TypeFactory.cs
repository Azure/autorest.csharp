// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using AutoRest.CSharp.V3.Input;
using AutoRest.CSharp.V3.Output.Models.Types;

namespace AutoRest.CSharp.V3.Generation.Types
{
    internal class TypeFactory
    {
        private readonly OutputLibrary _library;

        public TypeFactory(OutputLibrary library)
        {
            _library = library;
        }

        public CSharpType CreateType(Schema schema, bool isNullable) => schema switch
        {
            ConstantSchema constantSchema => CreateType(constantSchema.ValueType, isNullable),
            BinarySchema _ => new CSharpType(typeof(byte[]), isNullable),
            ByteArraySchema _ => new CSharpType(typeof(byte[]), isNullable),
            ArraySchema array => new CSharpType(typeof(ICollection<>), isNullable, CreateType(array.ElementType, false)),
            DictionarySchema dictionary => new CSharpType(typeof(IDictionary<,>), isNullable, new CSharpType(typeof(string)), CreateType(dictionary.ElementType, false)),
            NumberSchema number => new CSharpType(ToFrameworkNumericType(number), isNullable),
            _ when ToFrameworkType(schema.Type) is Type type => new CSharpType(type, isNullable),
            _ => _library.FindTypeForSchema(schema).Type.WithNullable(isNullable)
        };

        public CSharpType CreateImplementationType(Schema schema, bool isNullable)
        {
            var definitionType = CreateType(schema, isNullable);

            if (!definitionType.IsFrameworkType)
            {
                return definitionType;
            }

            if (definitionType.FrameworkType == typeof(ICollection<>))
            {
                return new CSharpType(typeof(List<>), definitionType.IsNullable, definitionType.Arguments);
            }

            if (definitionType.FrameworkType == typeof(IDictionary<,>))
            {
                return new CSharpType(typeof(Dictionary<,>), definitionType.IsNullable, definitionType.Arguments);
            }

            return definitionType;
        }

        public CSharpType CreateInputType(Schema schema, bool isNullable)
        {
            var definitionType = CreateType(schema, isNullable);

            if (!definitionType.IsFrameworkType)
            {
                return definitionType;
            }

            if (definitionType.FrameworkType == typeof(ICollection<>))
            {
                return new CSharpType(typeof(IEnumerable<>), definitionType.IsNullable, definitionType.Arguments);
            }

            return definitionType;
        }

        private static Type? ToFrameworkType(AllSchemaTypes schemaType) => schemaType switch
        {
            AllSchemaTypes.Boolean => typeof(bool),
            AllSchemaTypes.ByteArray => null,
            AllSchemaTypes.Char => typeof(char),
            AllSchemaTypes.Date => typeof(DateTimeOffset),
            AllSchemaTypes.DateTime => typeof(DateTimeOffset),
            AllSchemaTypes.Duration => typeof(TimeSpan),
            AllSchemaTypes.OdataQuery => typeof(string),
            AllSchemaTypes.String => typeof(string),
            AllSchemaTypes.Unixtime => typeof(DateTimeOffset),
            AllSchemaTypes.Uri => typeof(Uri),
            AllSchemaTypes.Uuid => typeof(Guid),
            AllSchemaTypes.Any => typeof(object),
            AllSchemaTypes.Binary => typeof(byte[]),
            _ => null
        };

        private static Type ToFrameworkNumericType(NumberSchema schema) => schema.Type switch
        {
            AllSchemaTypes.Number => schema.Precision switch
            {
                32 => typeof(float),
                128 => typeof(decimal),
                _ => typeof(double)
            },
            // Assumes AllSchemaTypes.Integer
            _ => schema.Precision switch
            {
                16 => typeof(short),
                64 => typeof(long),
                _ => typeof(int)
            }
        };
    }
}
