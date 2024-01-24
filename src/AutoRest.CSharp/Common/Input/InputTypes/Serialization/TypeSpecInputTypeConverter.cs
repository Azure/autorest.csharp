// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using AutoRest.CSharp.Output.Models.Serialization;
using Azure.Core;

namespace AutoRest.CSharp.Common.Input
{
    internal sealed class TypeSpecInputTypeConverter : JsonConverter<InputType>
    {
        private const string KindPropertyName = "Kind";

        private readonly TypeSpecReferenceHandler _referenceHandler;

        public TypeSpecInputTypeConverter(TypeSpecReferenceHandler referenceHandler)
        {
            _referenceHandler = referenceHandler;
        }

        public override InputType? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            // TODO -- figure out why we need this
            if (reader.TokenType == JsonTokenType.String)
            {
                return CreatePrimitiveType(reader.GetString(), false);
            }

            return reader.ReadReferenceAndResolve<InputType>(_referenceHandler.CurrentResolver) ?? CreateObject(ref reader, options);
        }

        public override void Write(Utf8JsonWriter writer, InputType value, JsonSerializerOptions options)
            => throw new NotSupportedException("Writing not supported");

        private InputType CreateObject(ref Utf8JsonReader reader, JsonSerializerOptions options)
        {
            string? id = null;
            string? kind = null;
            string? name = null;
            InputType? result = null;
            var isFirstProperty = true;
            while (reader.TokenType != JsonTokenType.EndObject)
            {
                var isIdOrNameOrKind = reader.TryReadReferenceId(ref isFirstProperty, ref id)
                    || reader.TryReadString(KindPropertyName, ref kind)
                    || reader.TryReadString(nameof(InputType.Name), ref name);

                if (isIdOrNameOrKind)
                {
                    continue;
                }
                result = CreateDerivedType(ref reader, id, kind, name, options);
            }

            return result ?? throw new JsonException("cannot deserialize InputType");
        }

        private const string PrimitiveKind = "Primitive";
        private const string LiteralKind = "Literal";
        private const string UnionKind = "Union";
        private const string ModelKind = "Model";
        private const string EnumKind = "Enum";
        private const string ArrayKind = "Array";
        private const string DictionaryKind = "Dictionary";
        private const string IntrinsicKind = "Intrinsic";

        private InputType CreateDerivedType(ref Utf8JsonReader reader, string? id, string? kind, string? name, JsonSerializerOptions options) => kind switch
        {
            PrimitiveKind => ReadPrimitiveType(ref reader, id, name, _referenceHandler.CurrentResolver),
            LiteralKind => TypeSpecInputLiteralTypeConverter.CreateInputLiteralType(ref reader, id, name, options, _referenceHandler.CurrentResolver),
            UnionKind => TypeSpecInputUnionTypeConverter.CreateInputUnionType(ref reader, id, name, options, _referenceHandler.CurrentResolver),
            ModelKind => TypeSpecInputModelTypeConverter.CreateModelType(ref reader, id, name, options, _referenceHandler.CurrentResolver),
            EnumKind => TypeSpecInputEnumTypeConverter.CreateEnumType(ref reader, id, name, options, _referenceHandler.CurrentResolver),
            ArrayKind => TypeSpecInputListTypeConverter.CreateListType(ref reader, id, name, options, _referenceHandler.CurrentResolver),
            DictionaryKind => TypeSpecInputDictionaryTypeConverter.CreateDictionaryType(ref reader, id, name, options, _referenceHandler.CurrentResolver),
            IntrinsicKind => ReadIntrinsicType(ref reader, id, name, _referenceHandler.CurrentResolver),
            null => throw new JsonException("InputType must have a 'Kind' property"),
            _ => throw new JsonException($"unknown kind {kind}")
        };

        public static InputPrimitiveType ReadPrimitiveType(ref Utf8JsonReader reader, string? id, string? name, ReferenceResolver resolver)
        {
            var isFirstProperty = id == null;
            string? encode = null;
            var isNullable = false;
            while (reader.TokenType != JsonTokenType.EndObject)
            {
                var isKnownProperty = reader.TryReadReferenceId(ref isFirstProperty, ref id)
                    || reader.TryReadBoolean(nameof(InputPrimitiveType.IsNullable), ref isNullable)
                    || reader.TryReadString(nameof(InputPrimitiveType.Name), ref name) // the primitive kind in the json is represented by the property `Name`.
                    || reader.TryReadString("Encode", ref encode);

                if (!isKnownProperty)
                {
                    reader.SkipProperty();
                }
            }

            var primitiveType = CreatePrimitiveType(name, isNullable);
            if (id != null)
            {
                resolver.AddReference(id, primitiveType);
            }

            return primitiveType;
        }

        public static InputPrimitiveType CreatePrimitiveType(string? inputTypeKindString, bool isNullable)
        {
            Argument.AssertNotNull(inputTypeKindString, nameof(inputTypeKindString));
            return Enum.TryParse<InputTypePrimitiveKind>(inputTypeKindString, ignoreCase: true, out var kind)
                ? new InputPrimitiveType(kind, GetSerializationFormat(kind), isNullable)
                : throw new JsonException($"{inputTypeKindString} type is unknown.");
        }

        private static SerializationFormat GetSerializationFormat(InputTypePrimitiveKind kind) => kind switch
        {
            InputTypePrimitiveKind.BytesBase64Url => SerializationFormat.Bytes_Base64Url,
            InputTypePrimitiveKind.Bytes => SerializationFormat.Bytes_Base64,
            InputTypePrimitiveKind.Date => SerializationFormat.Date_ISO8601,
            InputTypePrimitiveKind.DateTime => SerializationFormat.DateTime_ISO8601,
            InputTypePrimitiveKind.DateTimeISO8601 => SerializationFormat.DateTime_ISO8601,
            InputTypePrimitiveKind.DateTimeRFC1123 => SerializationFormat.DateTime_RFC1123,
            InputTypePrimitiveKind.DateTimeRFC3339 => SerializationFormat.DateTime_RFC3339,
            InputTypePrimitiveKind.DateTimeRFC7231 => SerializationFormat.DateTime_RFC7231,
            InputTypePrimitiveKind.DateTimeUnix => SerializationFormat.DateTime_Unix,
            InputTypePrimitiveKind.DurationISO8601 => SerializationFormat.Duration_ISO8601,
            InputTypePrimitiveKind.DurationConstant => SerializationFormat.Duration_Constant,
            InputTypePrimitiveKind.DurationSeconds => SerializationFormat.Duration_Seconds,
            InputTypePrimitiveKind.DurationSecondsFloat => SerializationFormat.Duration_Seconds_Float,
            InputTypePrimitiveKind.Time => SerializationFormat.Time_ISO8601,
            _ => SerializationFormat.Default,
        };

        private static InputIntrinsicType ReadIntrinsicType(ref Utf8JsonReader reader, string? id, string? name, ReferenceResolver resolver)
        {
            var isFirstProperty = id == null;
            while (reader.TokenType != JsonTokenType.EndObject)
            {
                var isKnownProperty = reader.TryReadReferenceId(ref isFirstProperty, ref id)
                    || reader.TryReadString(nameof(InputIntrinsicType.Kind), ref name); // the InputIntrinsicType kind in the json is represented by the property `Name`.

                if (!isKnownProperty)
                {
                    reader.SkipProperty();
                }
            }

            var intrinsicType = CreateIntrinsicType(name);
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
