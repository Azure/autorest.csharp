﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.IO;
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

        public CSharpType CreateType(Schema schema, bool isNullable, TypeFlags typeFlags = TypeFlags.Normal) => schema switch
        {
            ConstantSchema constantSchema => CreateType(constantSchema.ValueType, isNullable, typeFlags),
            BinarySchema _ => new CSharpType(typeof(Stream), isNullable),
            ByteArraySchema _ => new CSharpType(typeof(byte[]), isNullable),
            ArraySchema array => new CSharpType(
                GetListType(typeFlags),
                isNullable,
                CreateType(array.ElementType, false, typeFlags)),
            DictionarySchema dictionary => new CSharpType(
                GetDictionaryType(typeFlags),
                isNullable,
                new CSharpType(typeof(string)), CreateType(dictionary.ElementType, false, typeFlags)),
            NumberSchema number => new CSharpType(ToFrameworkNumericType(number), isNullable),
            _ when ToFrameworkType(schema.Type) is Type type => new CSharpType(type, isNullable),
            _ => _library.FindTypeForSchema(schema).Type.WithNullable(isNullable)
        };

        public CSharpType GetImplementationType(CSharpType type)
        {
            if (type.IsFrameworkType)
            {
                if (type.FrameworkType == typeof(IEnumerable<>) ||
                    type.FrameworkType == typeof(IReadOnlyList<>) ||
                    type.FrameworkType == typeof(IList<>))
                {
                    return new CSharpType(typeof(List<>), type.Arguments);
                }

                if (type.FrameworkType == typeof(IDictionary<,>) ||
                    type.FrameworkType == typeof(IReadOnlyDictionary<,>))
                {
                    return new CSharpType(typeof(Dictionary<,>), type.Arguments);
                }
            }

            return type;
        }

        public CSharpType GetElementType(CSharpType type)
        {
            if (type.IsFrameworkType)
            {
                if (type.FrameworkType == typeof(IEnumerable<>) ||
                    type.FrameworkType == typeof(IReadOnlyList<>) ||
                    type.FrameworkType == typeof(IList<>))
                {
                    return type.Arguments[0];
                }

                if (type.FrameworkType == typeof(IDictionary<,>) ||
                    type.FrameworkType == typeof(IReadOnlyDictionary<,>))
                {
                    return type.Arguments[1];
                }
            }

            throw new NotSupportedException(type.Name);
        }

        private static Type GetListType(TypeFlags typeFlags)
        {
            return typeFlags switch
            {
                TypeFlags.Normal => typeof(IList<>),
                TypeFlags.Input => typeof(IEnumerable<>),
                TypeFlags.Output => typeof(IReadOnlyList<>),
                _ => throw new NotSupportedException(typeFlags.ToString())
            };
        }

        private static Type GetDictionaryType(TypeFlags typeFlags)
        {
            return typeFlags switch
            {
                TypeFlags.Normal => typeof(IDictionary<,>),
                TypeFlags.Input => typeof(IDictionary<,>),
                TypeFlags.Output => typeof(IReadOnlyDictionary<,>),
                _ => throw new NotSupportedException(typeFlags.ToString())
            };
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
