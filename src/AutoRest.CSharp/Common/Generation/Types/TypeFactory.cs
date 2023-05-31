// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using Azure;
using Azure.Core;
using Azure.Core.Expressions.DataFactory;
using Microsoft.CodeAnalysis;

namespace AutoRest.CSharp.Generation.Types
{
    internal class TypeFactory
    {
        private readonly OutputLibrary _library;

        public TypeFactory(OutputLibrary library)
        {
            _library = library;
        }

        private Type AzureResponseErrorType => typeof(Azure.ResponseError);

        public CSharpType CreateType(InputType inputType) => inputType switch
        {
            InputLiteralType literalType       => CreateType(literalType.LiteralValueType), //TODO -- need to support literal type with the value.
            InputUnionType unionType           => CreateType(unionType.UnionItemTypes[0]), //TODO -- need to support multiple union types.
            InputListType listType             => new CSharpType(typeof(IList<>), listType.IsNullable, CreateType(listType.ElementType)),
            InputDictionaryType dictionaryType => new CSharpType(typeof(IDictionary<,>), inputType.IsNullable, typeof(string), CreateType(dictionaryType.ValueType)),
            InputEnumType enumType             => _library.ResolveEnum(enumType).WithNullable(inputType.IsNullable),
            // TODO -- this is a temporary solution until we refactored the type replacement to use input types instead of code model schemas
            InputModelType { Namespace: "Azure.Core.Foundations", Name: "Error" } => SystemObjectType.Create(AzureResponseErrorType, AzureResponseErrorType.Namespace!, null).Type,
            InputModelType { Namespace: "Azure.Core", Name: "RequestContent" } => KnownParameters.RequestContent.Type,
            InputModelType { Namespace: "Azure.Core", Name: "RequestContentNullable" } => KnownParameters.RequestContentNullable.Type,
            InputModelType model               => _library.ResolveModel(model).WithNullable(inputType.IsNullable),
            InputPrimitiveType primitiveType   => primitiveType.Kind switch
            {
                InputTypeKind.AzureLocation => new CSharpType(typeof(AzureLocation), inputType.IsNullable),
                InputTypeKind.BinaryData => new CSharpType(typeof(BinaryData), inputType.IsNullable),
                InputTypeKind.Boolean => new CSharpType(typeof(bool), inputType.IsNullable),
                InputTypeKind.BytesBase64Url => Configuration.ShouldTreatBase64AsBinaryData ? new CSharpType(typeof(BinaryData), inputType.IsNullable) : new CSharpType(typeof(byte[]), inputType.IsNullable),
                InputTypeKind.Bytes => Configuration.ShouldTreatBase64AsBinaryData ? new CSharpType(typeof(BinaryData), inputType.IsNullable) : new CSharpType(typeof(byte[]), inputType.IsNullable),
                InputTypeKind.ContentType => new CSharpType(typeof(ContentType), inputType.IsNullable),
                InputTypeKind.Date => new CSharpType(typeof(DateTimeOffset), inputType.IsNullable),
                InputTypeKind.DateTime => new CSharpType(typeof(DateTimeOffset), inputType.IsNullable),
                InputTypeKind.DateTimeISO8601 => new CSharpType(typeof(DateTimeOffset), inputType.IsNullable),
                InputTypeKind.DateTimeRFC1123 => new CSharpType(typeof(DateTimeOffset), inputType.IsNullable),
                InputTypeKind.DateTimeRFC3339 => new CSharpType(typeof(DateTimeOffset), inputType.IsNullable),
                InputTypeKind.DateTimeRFC7231 => new CSharpType(typeof(DateTimeOffset), inputType.IsNullable),
                InputTypeKind.DateTimeUnix => new CSharpType(typeof(DateTimeOffset), inputType.IsNullable),
                InputTypeKind.DurationISO8601 => new CSharpType(typeof(TimeSpan), inputType.IsNullable),
                InputTypeKind.DurationSeconds => new CSharpType(typeof(TimeSpan), inputType.IsNullable),
                InputTypeKind.DurationSecondsFloat => new CSharpType(typeof(TimeSpan), inputType.IsNullable),
                InputTypeKind.DurationConstant => new CSharpType(typeof(TimeSpan), inputType.IsNullable),
                InputTypeKind.ETag => new CSharpType(typeof(ETag), inputType.IsNullable),
                InputTypeKind.Float32 => new CSharpType(typeof(float), inputType.IsNullable),
                InputTypeKind.Float64 => new CSharpType(typeof(double), inputType.IsNullable),
                InputTypeKind.Float128 => new CSharpType(typeof(decimal), inputType.IsNullable),
                InputTypeKind.Guid => new CSharpType(typeof(Guid), inputType.IsNullable),
                InputTypeKind.Int32 => new CSharpType(typeof(int), inputType.IsNullable),
                InputTypeKind.Int64 => new CSharpType(typeof(long), inputType.IsNullable),
                InputTypeKind.IPAddress => new CSharpType(typeof(IPAddress), inputType.IsNullable),
                InputTypeKind.RequestMethod => new CSharpType(typeof(RequestMethod), inputType.IsNullable),
                InputTypeKind.ResourceIdentifier => new CSharpType(typeof(ResourceIdentifier), inputType.IsNullable),
                InputTypeKind.ResourceType => new CSharpType(typeof(ResourceType), inputType.IsNullable),
                InputTypeKind.Stream => new CSharpType(typeof(Stream), inputType.IsNullable),
                InputTypeKind.String => new CSharpType(typeof(string), inputType.IsNullable),
                InputTypeKind.Time => new CSharpType(typeof(TimeSpan), inputType.IsNullable),
                InputTypeKind.Uri => new CSharpType(typeof(Uri), inputType.IsNullable),
                _ => new CSharpType(typeof(object), inputType.IsNullable),
            },
            InputIntrinsicType { Kind: InputIntrinsicTypeKind.Unknown } => typeof(BinaryData),
            CodeModelType cmt => CreateType(cmt.Schema, cmt.IsNullable),
            _ => throw new Exception("Unknown type")
        };

        public CSharpType CreateType(Schema schema, bool isNullable, string? formatOverride = default, Property? property = default) => CreateType(schema, formatOverride ?? schema.Extensions?.Format, isNullable, property);

        // This function provide the capability to support the extensions is coming from outside, like parameter.
        public CSharpType CreateType(Schema schema, string? format, bool isNullable, Property? property = default) => schema switch
        {
            ConstantSchema constantSchema => constantSchema.ValueType is not ChoiceSchema && ToXMsFormatType(format) is Type type ? new CSharpType(type, isNullable) : CreateType(constantSchema.ValueType, isNullable),
            BinarySchema _ => new CSharpType(typeof(Stream), isNullable),
            ByteArraySchema _ => new CSharpType(typeof(byte[]), isNullable),
            ArraySchema array => new CSharpType(typeof(IList<>), isNullable, CreateType(array.ElementType, array.NullableItems ?? false)),
            DictionarySchema dictionary => new CSharpType(typeof(IDictionary<,>), isNullable, new CSharpType(typeof(string)), CreateType(dictionary.ElementType, dictionary.NullableItems ?? false)),
            CredentialSchema credentialSchema => new CSharpType(typeof(string), isNullable),
            NumberSchema number => new CSharpType(ToFrameworkNumericType(number), isNullable),
            AnyObjectSchema _ when format == XMsFormat.DataFactoryElementOfListOfT => new CSharpType(
                typeof(DataFactoryElement<>),
                isNullable: isNullable,
                new CSharpType(typeof(IList<>), _library.FindTypeForSchema((ObjectSchema)property!.Extensions!["x-ms-format-element-type"]))),
            _ when ToFrameworkType(schema, format) is Type type => new CSharpType(type, isNullable),
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

            if (!type.Equals(defaultValue.Value.Type) && !CanBeInitializedInline(defaultValue.Value.Type, defaultValue))
            {
                return false;
            }

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
                enumType.IsExtensible;
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
                : type.Implementation is EnumType enumType && enumType.ValueType.Equals(typeof(string)) && enumType.IsExtensible;

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

        internal static Type? ToFrameworkType(Schema schema) => ToFrameworkType(schema, schema.Extensions?.Format);

        internal static Type? ToFrameworkType(Schema schema, string? format) => schema.Type switch
        {
            AllSchemaTypes.Integer => typeof(int),
            AllSchemaTypes.Boolean => typeof(bool),
            AllSchemaTypes.ByteArray => null,
            AllSchemaTypes.Char => typeof(char),
            AllSchemaTypes.Date => typeof(DateTimeOffset),
            AllSchemaTypes.DateTime => typeof(DateTimeOffset),
            AllSchemaTypes.Duration => typeof(TimeSpan),
            AllSchemaTypes.OdataQuery => typeof(string),
            AllSchemaTypes.ArmId => typeof(ResourceIdentifier),
            AllSchemaTypes.String => ToXMsFormatType(format) ?? typeof(string),
            AllSchemaTypes.Time => typeof(TimeSpan),
            AllSchemaTypes.Unixtime => typeof(DateTimeOffset),
            AllSchemaTypes.Uri => typeof(Uri),
            AllSchemaTypes.Uuid => typeof(Guid),
            AllSchemaTypes.Any => Configuration.AzureArm ? typeof(BinaryData) : typeof(object),
            AllSchemaTypes.AnyObject => ToXMsFormatType(format) ?? (Configuration.AzureArm ? typeof(BinaryData) : typeof(object)),
            AllSchemaTypes.Binary => typeof(byte[]),
            _ => null
        };

        internal static Type? ToXMsFormatType(string? format) => format switch
        {
            XMsFormat.ArmId => typeof(ResourceIdentifier),
            XMsFormat.AzureLocation => typeof(AzureLocation),
            XMsFormat.DateTime => typeof(DateTimeOffset),
            XMsFormat.DateTimeRFC1123 => typeof(DateTimeOffset),
            XMsFormat.DateTimeUnix => typeof(DateTimeOffset),
            XMsFormat.DurationConstant => typeof(TimeSpan),
            XMsFormat.ETag => typeof(ETag),
            XMsFormat.ResourceType => typeof(ResourceType),
            XMsFormat.Object => typeof(object),
            XMsFormat.IPAddress => typeof(IPAddress),
            XMsFormat.ContentType => typeof(ContentType),
            XMsFormat.RequestMethod => typeof(RequestMethod),
            XMsFormat.DataFactoryElementOfString => typeof(DataFactoryElement<string>),
            XMsFormat.DataFactoryElementOfInt => typeof(DataFactoryElement<int>),
            XMsFormat.DataFactoryElementOfDouble => typeof(DataFactoryElement<double>),
            XMsFormat.DataFactoryElementOfBool => typeof(DataFactoryElement<bool>),
            XMsFormat.DataFactoryElementOfDateTime => typeof(DataFactoryElement<DateTimeOffset>),
            XMsFormat.DataFactoryElementOfDuration => typeof(DataFactoryElement<TimeSpan>),
            XMsFormat.DataFactoryElementOfUri => typeof(DataFactoryElement<Uri>),
            XMsFormat.DataFactoryElementOfObject => typeof(DataFactoryElement<BinaryData>),
            XMsFormat.DataFactoryElementOfListOfString => typeof(DataFactoryElement<IList<string>>),
            XMsFormat.DataFactoryElementOfKeyValuePairs => typeof(DataFactoryElement<IDictionary<string, string>>),
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

        private static bool NoTypeValidator(System.Type type) => true;

        public bool TryCreateType(ITypeSymbol symbol, [NotNullWhen(true)] out CSharpType? type)
            => TryCreateType(symbol, NoTypeValidator, out type);

        public CSharpType? GetLibraryTypeByName(string name) => _library.FindTypeByName(name);

        public bool TryCreateType(ITypeSymbol symbol, Func<System.Type, bool> validator, [NotNullWhen(true)] out CSharpType? type)
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

            if (existingType != null && validator(existingType))
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

        /// <summary>
        /// Method checks if object of "<c>from</c>" type can be converted to "<c>to</c>" type by calling `ToList` extension method.
        /// It returns true if "<c>from</c>" is <see cref="IEnumerable{T}"/> and "<c>to</c>" is <see cref="IReadOnlyList{T}"/> or <see cref="IList{T}"/>.
        /// </summary>
        public static bool RequiresToList(CSharpType from, CSharpType to)
        {
            if (!to.IsFrameworkType || !from.IsFrameworkType || from.FrameworkType != typeof(IEnumerable<>))
            {
                return false;
            }

            return to.FrameworkType == typeof(IReadOnlyList<>) || to.FrameworkType == typeof(IList<>);
        }
    }
}
