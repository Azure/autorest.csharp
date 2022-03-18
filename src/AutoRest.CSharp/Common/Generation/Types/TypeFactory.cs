﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using Azure;
using Azure.Core;
using Microsoft.CodeAnalysis;
using Operation = AutoRest.CSharp.Input.Operation;

namespace AutoRest.CSharp.Generation.Types
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
                CreateType(array.ElementType, array.NullableItems ?? false)),
            DictionarySchema dictionary => new CSharpType(
                typeof(IDictionary<,>),
                isNullable,
                new CSharpType(typeof(string)), CreateType(dictionary.ElementType, dictionary.NullableItems ?? false)),
            CredentialSchema credentialSchema => new CSharpType(typeof(string), isNullable),
            NumberSchema number => new CSharpType(ToFrameworkNumericType(number), isNullable),
            _ when ToFrameworkType(schema) is Type type => new CSharpType(type, isNullable),
            _ => _library.FindTypeForSchema(schema).WithNullable(isNullable)
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

        public static CSharpType GetPropertyImplementationType(CSharpType type)
        {
            if (type.IsFrameworkType)
            {
                if (IsList(type))
                {
                    return new CSharpType(typeof(ChangeTrackingList<>), type.Arguments);
                }

                if (IsDictionary(type))
                {
                    return new CSharpType(typeof(ChangeTrackingDictionary<,>), type.Arguments);
                }
            }

            return type;
        }

        public static bool CanBeInitializedInline(CSharpType type, Constant? defaultValue)
        {
             Debug.Assert(defaultValue.HasValue);

            if (type.Equals(typeof(string)))
            {
                return true;
            }

            if (IsExtendableEnum(type) && defaultValue.Value.Value != null)
            {
                return defaultValue.Value.IsNewInstanceSentinel;
            }

            return type.IsValueType || defaultValue.Value.Value == null;
        }

        public static bool IsExtendableEnum(CSharpType type)
        {
            return !type.IsFrameworkType && type.IsValueType &&
                type.Implementation is EnumType enumType &&
                enumType.IsExtendable;
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


        /// <summary>
        /// Is the type a string or an Enum that is modeled as string.
        /// </summary>
        /// <param name="type">Type to check.</param>
        /// <returns>Is the type a string or an Enum that is modeled as string.</returns>
        public static bool IsStringLike(CSharpType type) =>
            type.IsFrameworkType
                ? type.Equals(typeof(string))
                : type.Implementation is EnumType enumType && enumType.BaseType.Equals(typeof(string)) && enumType.IsExtendable;

        internal static bool IsDictionary(CSharpType type)
            => IsReadOnlyDictionary(type) || IsReadWriteDictionary(type);

        internal static bool IsReadOnlyDictionary(CSharpType type)
            => type.IsFrameworkType && type.FrameworkType == typeof(IReadOnlyDictionary<,>);

        internal static bool IsReadWriteDictionary(CSharpType type)
            => type.IsFrameworkType && type.FrameworkType == typeof(IDictionary<,>);

        internal static bool IsList(CSharpType type)
            => IsReadOnlyList(type) || IsReadWriteList(type);

        internal static bool IsReadOnlyList(CSharpType type)
            => type.IsFrameworkType &&
               (type.FrameworkType == typeof(IEnumerable<>) ||
               type.FrameworkType == typeof(IReadOnlyList<>));

        internal static bool IsReadWriteList(CSharpType type)
            => type.IsFrameworkType &&
               (type.FrameworkType == typeof(IList<>) ||
               type.FrameworkType == typeof(ICollection<>));

        internal static bool IsIEnumerableType(CSharpType type)
            => type.IsFrameworkType &&
            (type.FrameworkType == typeof(IEnumerable) ||
            type.FrameworkType.IsGenericType && type.FrameworkType.GetGenericTypeDefinition() == typeof(IEnumerable<>));

        internal static bool IsIEnumerableOfT(CSharpType type) => type.IsFrameworkType && type.FrameworkType == typeof(IEnumerable<>);

        internal static bool IsIAsyncEnumerableOfT(CSharpType type) => type.IsFrameworkType && type.FrameworkType == typeof(IAsyncEnumerable<>);

        internal static bool IsAsyncPageable(CSharpType type) => type.IsFrameworkType && type.FrameworkType == typeof(AsyncPageable<>);

        internal static bool IsOperationOfAsyncPageable(CSharpType type)
            => type.IsFrameworkType && type.FrameworkType == typeof(Operation<>) && type.Arguments.Length == 1 && IsAsyncPageable(type.Arguments[0]);

        internal static bool IsPageable(CSharpType type) => type.IsFrameworkType && type.FrameworkType == typeof(Pageable<>);

        internal static bool IsOperationOfPageable(CSharpType type)
            => type.IsFrameworkType && type.FrameworkType == typeof(Operation<>) && type.Arguments.Length == 1 && IsPageable(type.Arguments[0]);

        private static Type? ToFrameworkType(Schema schema) => schema.Type switch
        {
            AllSchemaTypes.Boolean => typeof(bool),
            AllSchemaTypes.ByteArray => null,
            AllSchemaTypes.Char => typeof(char),
            AllSchemaTypes.Date => typeof(DateTimeOffset),
            AllSchemaTypes.DateTime => typeof(DateTimeOffset),
            AllSchemaTypes.Duration => typeof(TimeSpan),
            AllSchemaTypes.OdataQuery => typeof(string),
            AllSchemaTypes.String => schema.Extensions?.Format switch
            {
                XMsFormat.ArmId => typeof(ResourceIdentifier),
                XMsFormat.ResourceType => typeof(ResourceType),
                XMsFormat.DurationConstant => typeof(TimeSpan),
                _ => typeof(string)
            },
            AllSchemaTypes.Time => typeof(TimeSpan),
            AllSchemaTypes.Unixtime => typeof(DateTimeOffset),
            AllSchemaTypes.Uri => typeof(Uri),
            AllSchemaTypes.Uuid => typeof(Guid),
            AllSchemaTypes.Any => Configuration.AzureArm ? typeof(BinaryData) : typeof(object),
            AllSchemaTypes.AnyObject => Configuration.AzureArm ? typeof(BinaryData) : typeof(object),
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
            if (!TryCreateType(symbol, out var type))
            {
                throw new InvalidOperationException($"Unable to find a model or framework type that corresponds to {symbol}");
            }

            return type;
        }

        public bool TryCreateType(ITypeSymbol symbol, [NotNullWhen(true)] out CSharpType? type)
        {
            type = null;
            INamedTypeSymbol? namedTypeSymbol = symbol as INamedTypeSymbol;
            if (namedTypeSymbol == null)
            {
                throw new InvalidCastException($"Unexpected type {symbol}");
            }

            if (namedTypeSymbol.ConstructedFrom.SpecialType == SpecialType.System_Nullable_T)
            {
                type = CreateType(namedTypeSymbol.TypeArguments[0]).WithNullable(true);
                return true;
            }

            var fullMetadataName = GetFullMetadataName(namedTypeSymbol);
            var fullyQualifiedName = $"{fullMetadataName}, {namedTypeSymbol.ContainingAssembly.Name}";
            var existingType = Type.GetType(fullMetadataName) ?? Type.GetType(fullyQualifiedName);

            if (existingType != null)
            {
                var arguments = namedTypeSymbol.TypeArguments.Select(a => CreateType(a)).ToArray();
                type = new CSharpType(existingType, false, arguments);
            }
            else
            {
                type = _library.FindTypeByName(namedTypeSymbol.Name);
            }

            if (type == null)
            {
                return false;
            }

            if (!type.IsValueType &&
                symbol.NullableAnnotation != NullableAnnotation.NotAnnotated)
            {
                type = type.WithNullable(true);
            }

            return true;
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

        public static bool IsCollectionType(CSharpType type)
        {
            return type.IsFrameworkType && (IsDictionary(type) || IsList(type));
        }
    }
}
