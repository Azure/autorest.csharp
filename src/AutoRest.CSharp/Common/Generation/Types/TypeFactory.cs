// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Models.Types;
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

        private Type AzureResponseErrorType => typeof(ResponseError);

        /// <summary>
        /// This method will attempt to retrieve the <see cref="CSharpType"/> of the input type.
        /// </summary>
        /// <param name="inputType">The input type to convert.</param>
        /// <returns>The <see cref="CSharpType"/> of the input type.</returns>
        public CSharpType CreateType(InputType inputType) => inputType switch
        {
            InputLiteralType literalType => CSharpType.FromLiteral(CreateType(literalType.LiteralValueType), literalType.Value),
            InputUnionType unionType => CSharpType.FromUnion(unionType.UnionItemTypes.Select(CreateType).ToArray(), unionType.IsNullable),
            InputListType listType => new CSharpType(typeof(IList<>), listType.IsNullable, CreateType(listType.ElementType)),
            InputDictionaryType dictionaryType => new CSharpType(typeof(IDictionary<,>), inputType.IsNullable, typeof(string), CreateType(dictionaryType.ValueType)),
            InputEnumType enumType => _library.ResolveEnum(enumType).WithNullable(inputType.IsNullable),
            // TODO -- this is a temporary solution until we refactored the type replacement to use input types instead of code model schemas
            InputModelType { Namespace: "Azure.Core.Foundations", Name: "Error" } => SystemObjectType.Create(AzureResponseErrorType, AzureResponseErrorType.Namespace!, null).Type,
            InputModelType model => _library.ResolveModel(model).WithNullable(inputType.IsNullable),
            InputPrimitiveType primitiveType => primitiveType.Kind switch
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
                InputTypeKind.Decimal => new CSharpType(typeof(decimal), inputType.IsNullable),
                InputTypeKind.Decimal128 => new CSharpType(typeof(decimal), inputType.IsNullable),
                InputTypeKind.DurationISO8601 => new CSharpType(typeof(TimeSpan), inputType.IsNullable),
                InputTypeKind.DurationSeconds => new CSharpType(typeof(TimeSpan), inputType.IsNullable),
                InputTypeKind.DurationSecondsFloat => new CSharpType(typeof(TimeSpan), inputType.IsNullable),
                InputTypeKind.DurationConstant => new CSharpType(typeof(TimeSpan), inputType.IsNullable),
                InputTypeKind.ETag => new CSharpType(typeof(ETag), inputType.IsNullable),
                InputTypeKind.Float32 => new CSharpType(typeof(float), inputType.IsNullable),
                InputTypeKind.Float64 => new CSharpType(typeof(double), inputType.IsNullable),
                InputTypeKind.Float128 => new CSharpType(typeof(decimal), inputType.IsNullable),
                InputTypeKind.Guid => new CSharpType(typeof(Guid), inputType.IsNullable),
                InputTypeKind.SByte => new CSharpType(typeof(sbyte), inputType.IsNullable),
                InputTypeKind.Byte => new CSharpType(typeof(byte), inputType.IsNullable),
                InputTypeKind.Int32 => new CSharpType(typeof(int), inputType.IsNullable),
                InputTypeKind.Int64 => new CSharpType(typeof(long), inputType.IsNullable),
                InputTypeKind.SafeInt => new CSharpType(typeof(long), inputType.IsNullable),
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
            ArraySchema array => new CSharpType(GetListType(schema), isNullable, CreateType(array.ElementType, array.NullableItems ?? false)),
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

        private Type GetListType(Schema schema)
        {
            return schema.Extensions is not null && schema.Extensions.IsEmbeddingsVector ? typeof(ReadOnlyMemory<>) : typeof(IList<>);
        }

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
            XMsFormat.DataFactoryElementOfKeyObjectValuePairs => typeof(DataFactoryElement<IDictionary<string, BinaryData>>),
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
            return symbol switch
            {
                IArrayTypeSymbol arrayTypeSymbol => TryCreateTypeForIArrayTypeSymbol(arrayTypeSymbol, validator, out type),
                INamedTypeSymbol namedTypeSymbol => TryCreateTypeForINamedTypeSymbol(namedTypeSymbol, validator, out type),

                // We can only handle IArrayTypeSymbol of framework type and INamedTypeSymbol for now since CSharpType can't represent other types such as IArrayTypeSymbol of user types
                // Instead of throwing an exception, wihch causes more side effects, we just return false and let the caller handle it.
                _ => false
            };
        }

        private bool TryCreateTypeForINamedTypeSymbol(INamedTypeSymbol namedTypeSymbol, Func<Type, bool> validator, [NotNullWhen(true)] out CSharpType? type)
        {
            type = null;
            if (namedTypeSymbol.ConstructedFrom.SpecialType == SpecialType.System_Nullable_T)
            {
                if (!TryCreateType(namedTypeSymbol.TypeArguments[0], validator, out type))
                {
                    return false;
                }
                type = type.WithNullable(true);
                return true;
            }

            Type? existingType = TryGetFrameworkType(namedTypeSymbol);

            if (existingType is not null && validator(existingType))
            {
                if (!TryPopulateArguments(namedTypeSymbol.TypeArguments, validator, out var arguments))
                {
                    return false;
                }
                type = new CSharpType(existingType, false, arguments);
            }
            else
            {
                type = _library.FindTypeByName(namedTypeSymbol.Name);
            }

            if (type is null)
            {
                return false;
            }

            if (!type.IsValueType &&
                namedTypeSymbol.NullableAnnotation != NullableAnnotation.NotAnnotated)
            {
                type = type.WithNullable(true);
            }

            return true;
        }

        private bool TryCreateTypeForIArrayTypeSymbol(IArrayTypeSymbol symbol, Func<Type, bool> validator, [NotNullWhen(true)] out CSharpType? type)
        {
            type = null;
            if (symbol is not IArrayTypeSymbol arrayTypeSymbol)
            {
                return false;
            }

            // For IArrayTypeSymbol, we can only handle it when the element type is a framework type.
            var arrayType = TryGetFrameworkType(arrayTypeSymbol);
            if (arrayType is not null && validator(arrayType))
            {
                type = new CSharpType(arrayType, arrayType.IsValueType && symbol.NullableAnnotation != NullableAnnotation.NotAnnotated);
                return true;
            }
            return false;
        }

        private Type? TryGetFrameworkType(ISymbol namedTypeSymbol)
        {
            var fullMetadataName = GetFullMetadataName(namedTypeSymbol);
            var fullyQualifiedName = $"{fullMetadataName}, {namedTypeSymbol.ContainingAssembly?.Name}";
            return Type.GetType(fullMetadataName) ?? Type.GetType(fullyQualifiedName);
        }

        // There can be argument type missing
        private bool TryPopulateArguments(ImmutableArray<ITypeSymbol> typeArguments, Func<Type, bool> validator, [NotNullWhen(true)] out IReadOnlyList<CSharpType>? arguments)
        {
            arguments = null;
            var result = new List<CSharpType>();
            foreach (var typeArgtment in typeArguments)
            {
                if (!TryCreateType(typeArgtment, validator, out CSharpType? type))
                {
                    return false;
                }
                result.Add(type);
            }
            arguments = result;
            return true;
        }

        private string GetFullMetadataName(ISymbol namedTypeSymbol)
        {
            StringBuilder builder = new StringBuilder();

            BuildFullMetadataName(builder, namedTypeSymbol);

            return builder.ToString();
        }

        private void BuildFullMetadataName(StringBuilder builder, ISymbol symbol)
        {
            if (symbol is IArrayTypeSymbol arrayTypeSymbol)
            {
                BuildFullMetadataName(builder, arrayTypeSymbol.ElementType);
                builder.Append("[]");
                return;
            }

            if (symbol.ContainingNamespace != null &&
                !symbol.ContainingNamespace.IsGlobalNamespace)
            {
                BuildFullMetadataName(builder, symbol.ContainingNamespace);
                builder.Append(".");
            }

            builder.Append(symbol.MetadataName);
        }
    }
}
