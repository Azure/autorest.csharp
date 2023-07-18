// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core;

namespace AutoRest.CSharp.Common.Input
{
    internal sealed class TypeSpecInputTypeConverter : JsonConverter<InputType>
    {
        private const string InputTypeName = nameof(InputType.Name);
        private const string PrimitiveTypeKind = nameof(InputPrimitiveType.Kind);
        private const string LiteralValueType = nameof(InputLiteralType.LiteralValueType);
        private const string ListElementType = nameof(InputListType.ElementType);
        private const string DictionaryKeyType = nameof(InputDictionaryType.KeyType);
        private const string DictionaryValueType = nameof(InputDictionaryType.ValueType);
        private const string EnumValueType = nameof(InputEnumType.EnumValueType);
        private const string EnumAllowedValues = nameof(InputEnumType.AllowedValues);
        private const string IsLowConfidentField = nameof(InputType.IsConfident);
        private const string IsNullableField = nameof(InputType.IsNullable);
        private const string UnionItemTypes = nameof(InputUnionType.UnionItemTypes);

        private readonly TypeSpecReferenceHandler _referenceHandler;

        public TypeSpecInputTypeConverter(TypeSpecReferenceHandler referenceHandler)
        {
            _referenceHandler = referenceHandler;
        }

        public override InputType? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String)
            {
                return CreatePrimitiveType(reader.GetString(), false, false);
            }

            return reader.ReadReferenceAndResolve<InputType>(_referenceHandler.CurrentResolver) ?? CreateObject(ref reader, options);
        }

        public override void Write(Utf8JsonWriter writer, InputType value, JsonSerializerOptions options)
            => throw new NotSupportedException("Writing not supported");

        private InputType CreateObject(ref Utf8JsonReader reader, JsonSerializerOptions options)
        {
            string? id = null;
            string? name = null;
            InputType? result = null;
            var isFirstProperty = true;
            while (reader.TokenType != JsonTokenType.EndObject)
            {
                var isIdOrName = reader.TryReadReferenceId(ref isFirstProperty, ref id)
                    || reader.TryReadString(nameof(InputModelProperty.Name), ref name);

                if (isIdOrName)
                {
                    continue;
                }

                var propertyName = reader.GetString();
                result = CreateDerivedType(ref reader, propertyName, name, id, options);
            }

            return result ?? TypeSpecInputModelTypeConverter.CreateModelType(ref reader, id, name, options, _referenceHandler.CurrentResolver);
        }

        private InputType CreateDerivedType(ref Utf8JsonReader reader, string? propertyName, string? name, string? id, JsonSerializerOptions options) => propertyName switch
        {
            PrimitiveTypeKind when name == InputIntrinsicType.InputIntrinsicTypeName  => ReadIntrinsicType(ref reader, id, _referenceHandler.CurrentResolver),
            PrimitiveTypeKind => ReadPrimitiveType(ref reader, id, _referenceHandler.CurrentResolver),
            ListElementType     => TypeSpecInputListTypeConverter.CreateListType(ref reader, id, name, options),
            DictionaryKeyType   => TypeSpecInputDictionaryTypeConverter.CreateDictionaryType(ref reader, id, name, options),
            DictionaryValueType => TypeSpecInputDictionaryTypeConverter.CreateDictionaryType(ref reader, id, name, options),
            EnumValueType       => TypeSpecInputEnumTypeConverter.CreateEnumType(ref reader, id, name, options, _referenceHandler.CurrentResolver),
            EnumAllowedValues   => TypeSpecInputEnumTypeConverter.CreateEnumType(ref reader, id, name, options, _referenceHandler.CurrentResolver),
            LiteralValueType    => TypeSpecInputLiteralTypeConverter.CreateInputLiteralType(ref reader, id, name, options, _referenceHandler.CurrentResolver),
            UnionItemTypes      => TypeSpecInputUnionTypeConverter.CreateInputUnionType(ref reader, id, name, options, _referenceHandler.CurrentResolver),
            "" or null          => throw new JsonException("Property name can't be null or empty"),
            _                   => TypeSpecInputModelTypeConverter.CreateModelType(ref reader, id, name, options, _referenceHandler.CurrentResolver)
        };

        public static InputPrimitiveType ReadPrimitiveType(ref Utf8JsonReader reader, string? id, ReferenceResolver resolver)
        {
            var isFirstProperty = id == null;
            var isConfident = true;
            var isNullable = false;
            string? inputTypeKindString = null;
            while (reader.TokenType != JsonTokenType.EndObject)
            {
                var isKnownProperty = reader.TryReadReferenceId(ref isFirstProperty, ref id)
                    || reader.TryReadBoolean(nameof(InputPrimitiveType.IsConfident), ref isConfident)
                    || reader.TryReadBoolean(nameof(InputPrimitiveType.IsNullable), ref isNullable)
                    || reader.TryReadString(nameof(InputPrimitiveType.Kind), ref inputTypeKindString);

                if (!isKnownProperty)
                {
                    reader.SkipProperty();
                }
            }

            var primitiveType = CreatePrimitiveType(inputTypeKindString, isConfident, isNullable);
            if (id != null)
            {
                resolver.AddReference(id, primitiveType);
            }

            return primitiveType;
        }

        public static InputPrimitiveType CreatePrimitiveType(string? inputTypeKindString, bool isLowConfident, bool isNullable)
        {
            Argument.AssertNotNull(inputTypeKindString, nameof(inputTypeKindString));
            return Enum.TryParse<InputTypeKind>(inputTypeKindString, ignoreCase: true, out var kind)
                ? new InputPrimitiveType(kind, isLowConfident, IsNullable: isNullable)
                : throw new InvalidOperationException($"{inputTypeKindString} type is unknown.");
        }

        private static InputIntrinsicType ReadIntrinsicType(ref Utf8JsonReader reader, string? id, ReferenceResolver resolver)
        {
            var isFirstProperty = id == null;
            string? inputTypeKindString = null;
            while (reader.TokenType != JsonTokenType.EndObject)
            {
                var isKnownProperty = reader.TryReadReferenceId(ref isFirstProperty, ref id)
                    || reader.TryReadString(nameof(InputIntrinsicType.Kind), ref inputTypeKindString);

                if (!isKnownProperty)
                {
                    reader.SkipProperty();
                }
            }

            var intrinsicType = CreateIntrinsicType(inputTypeKindString);
            if (id != null)
            {
                resolver.AddReference(id, intrinsicType);
            }

            return intrinsicType;
        }

        private static InputIntrinsicType CreateIntrinsicType(string? inputTypeKindString)
        {
            Argument.AssertNotNull(inputTypeKindString, nameof(inputTypeKindString));
            return Enum.TryParse<InputIntrinsicTypeKind>(inputTypeKindString, ignoreCase: true, out var kind)
                ? new InputIntrinsicType(kind)
                : throw new InvalidOperationException($"{inputTypeKindString} type is unknown for InputIntrinsicType.");
        }
    }
}
