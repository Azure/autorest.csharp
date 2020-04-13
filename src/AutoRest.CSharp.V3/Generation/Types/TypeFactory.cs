﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AutoRest.CSharp.V3.Input;
using AutoRest.CSharp.V3.Output.Models.Types;
using Microsoft.CodeAnalysis;

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
            BinarySchema _ => new CSharpType(typeof(Stream), isNullable),
            ByteArraySchema _ => new CSharpType(typeof(byte[]), isNullable),
            ArraySchema array => new CSharpType(
                typeof(IList<>),
                isNullable,
                CreateType(array.ElementType, false)),
            DictionarySchema dictionary => new CSharpType(
                typeof(IDictionary<,>),
                isNullable,
                new CSharpType(typeof(string)), CreateType(dictionary.ElementType, false)),
            NumberSchema number => new CSharpType(ToFrameworkNumericType(number), isNullable),
            _ when ToFrameworkType(schema.Type) is Type type => new CSharpType(type, isNullable),
            _ => _library.FindTypeForSchema(schema).Type.WithNullable(isNullable)
        };

        public static CSharpType GetImplementationType(CSharpType type)
        {
            if (type.IsFrameworkType)
            {
                if (IsList(type))
                {
                    return new CSharpType(typeof(List<>), type.Arguments);
                }

                if (IsDictionary(type))
                {
                    return new CSharpType(typeof(Dictionary<,>), type.Arguments);
                }
            }

            return type;
        }

        public static CSharpType GetElementType(CSharpType type)
        {
            if (type.IsFrameworkType)
            {
                if (IsList(type))
                {
                    return type.Arguments[0];
                }

                if (IsDictionary(type))
                {
                    return type.Arguments[1];
                }
            }

            throw new NotSupportedException(type.Name);
        }

        private static bool IsDictionary(CSharpType type)
        {
            return type.FrameworkType == typeof(IDictionary<,>) ||
                   type.FrameworkType == typeof(IReadOnlyDictionary<,>);
        }

        private static bool IsList(CSharpType type)
        {
            return type.FrameworkType == typeof(IEnumerable<>) ||
                   type.FrameworkType == typeof(IReadOnlyList<>) ||
                   type.FrameworkType == typeof(IList<>) ||
                   type.FrameworkType == typeof(ICollection<>);
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
            AllSchemaTypes.Time => typeof(TimeSpan),
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

        public static CSharpType GetInputType(CSharpType type)
        {
            if (type.IsFrameworkType)
            {
                if (IsList(type))
                {
                    return new CSharpType(
                        typeof(IEnumerable<>),
                        isNullable: type.IsNullable,
                        type.Arguments);
                }
            }

            return type;
        }

        public static CSharpType GetOutputType(CSharpType type)
        {
            if (type.IsFrameworkType)
            {
                if (IsList(type))
                {
                    return new CSharpType(
                        typeof(IReadOnlyList<>),
                        isNullable: type.IsNullable,
                        type.Arguments);
                }

                if (IsDictionary(type))
                {
                    return new CSharpType(
                        typeof(IReadOnlyDictionary<,>),
                        isNullable: type.IsNullable,
                        type.Arguments);
                }
            }

            return type;
        }

        public CSharpType CreateType(ITypeSymbol symbol)
        {
            INamedTypeSymbol? namedTypeSymbol = symbol as INamedTypeSymbol;
            if (namedTypeSymbol == null)
            {
                throw new InvalidCastException($"Unexpected type {symbol}");
            }

            bool nullable;
            if (namedTypeSymbol.ConstructedFrom.SpecialType == SpecialType.System_Nullable_T)
            {
                nullable = true;
                namedTypeSymbol = (INamedTypeSymbol)namedTypeSymbol.TypeArguments[0];
            }
            else
            {
                nullable = symbol.NullableAnnotation != NullableAnnotation.NotAnnotated;
            }

            var existingType = Type.GetType(GetFullMetadataName(namedTypeSymbol));
            if (existingType != null)
            {
                var arguments = namedTypeSymbol.TypeArguments.Select(a => CreateType(a)).ToArray();
                return new CSharpType(existingType, nullable, arguments);
            }

            foreach (var model in _library.Models)
            {
                if (namedTypeSymbol.Name == model.Type.Name)
                {
                    return model.Type.WithNullable(nullable);
                }
            }

            throw new InvalidOperationException($"Unable to find a model or framework type that corresponds to {symbol}");
        }

        private string GetFullMetadataName(ISymbol namedTypeSymbol)
        {
            StringBuilder builder = new StringBuilder();

            GetFullMetadataName(builder, namedTypeSymbol);

            return builder.ToString();
        }

        private void GetFullMetadataName(StringBuilder builder, ISymbol symbol)
        {
            if (symbol.ContainingNamespace != null &&
                !symbol.ContainingNamespace.IsGlobalNamespace)
            {
                GetFullMetadataName(builder, symbol.ContainingNamespace);
                builder.Append(".");
            }

            builder.Append(symbol.MetadataName);
        }
    }
}
