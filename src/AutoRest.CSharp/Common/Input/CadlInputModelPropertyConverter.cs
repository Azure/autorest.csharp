﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models.Serialization;

namespace AutoRest.CSharp.Common.Input
{
    internal sealed class CadlInputModelPropertyConverter : JsonConverter<InputModelProperty>
    {
        private readonly CadlReferenceHandler _referenceHandler;

        public CadlInputModelPropertyConverter(CadlReferenceHandler referenceHandler)
        {
            _referenceHandler = referenceHandler;
        }

        public override InputModelProperty Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => reader.ReadReferenceAndResolve<InputModelProperty>(_referenceHandler.CurrentResolver) ?? ReadInputModelProperty(ref reader, null, null, options, _referenceHandler.CurrentResolver);

        public override void Write(Utf8JsonWriter writer, InputModelProperty value, JsonSerializerOptions options)
            => throw new NotSupportedException("Writing not supported");

        private static InputModelProperty ReadInputModelProperty(ref Utf8JsonReader reader, string? id, string? name, JsonSerializerOptions options, ReferenceResolver resolver)
        {
            var isFirstProperty = true;
            string? serializedName = null;
            string? description = null;
            InputType? propertyType = null;
            bool isReadOnly = false;
            bool isRequired = false;
            bool isDiscriminator = false;

            while (reader.TokenType != JsonTokenType.EndObject)
            {
                var isKnownProperty = reader.TryReadReferenceId(ref isFirstProperty, ref id)
                    || reader.TryReadString(nameof(InputModelProperty.Name), ref name)
                    || reader.TryReadString(nameof(InputModelProperty.SerializedName), ref serializedName)
                    || reader.TryReadString(nameof(InputModelProperty.Description), ref description)
                    || reader.TryReadWithConverter(nameof(InputModelProperty.Type), options, ref propertyType)
                    || reader.TryReadBoolean(nameof(InputModelProperty.IsReadOnly), ref isReadOnly)
                    || reader.TryReadBoolean(nameof(InputModelProperty.IsRequired), ref isRequired)
                    || reader.TryReadBoolean(nameof(InputModelProperty.IsDiscriminator), ref isDiscriminator);

                if (!isKnownProperty)
                {
                    reader.SkipProperty();
                }
            }

            name = name ?? throw new JsonException($"{nameof(InputModelProperty)} must have a name.");
            description = description ?? throw new JsonException($"{nameof(InputModelProperty)} must have a description.");
            description = BuilderHelpers.EscapeXmlDocDescription(description);
            propertyType = propertyType ?? throw new JsonException($"{nameof(InputModelProperty)} must have a property type.");

            var property = new InputModelProperty(name, serializedName ?? name, description, propertyType, isRequired, isReadOnly, isDiscriminator, GetDefaultValue(propertyType), GetSerializationFormat(propertyType));
            if (id != null)
            {
                resolver.AddReference(id, property);
            }

            return property;
        }

        private static SerializationFormat GetSerializationFormat(InputType propertyType)
        {
            InputTypeKind? typeKind = propertyType switch
            {
                InputPrimitiveType primitiveType => primitiveType.Kind,
                _ => null
            };

            if (typeKind is null)
                return SerializationFormat.Default;

            return typeKind switch
            {
                InputTypeKind.BytesBase64Url => SerializationFormat.Bytes_Base64Url,
                InputTypeKind.Bytes => SerializationFormat.Bytes_Base64,
                _ => SerializationFormat.Default
            };
        }

        private static FormattableString? GetDefaultValue(InputType propertyType)
        {
            if (propertyType is not InputLiteralType literalType)
            {
                return null;
            }

            return literalType.LiteralValueType switch
            {
                InputPrimitiveType primitiveType => primitiveType.Kind switch
                {
                    InputTypeKind.Boolean => $"{literalType.Value.ToString()!.ToLower()}",
                    InputTypeKind.Float32 or InputTypeKind.Float64 or InputTypeKind.Float128
                        or InputTypeKind.Int32 or InputTypeKind.Int64 => $"{literalType.Value.ToString()}",
                    InputTypeKind.String => $"\"{(literalType.Value).ToString()}\"",
                    _ => throw new Exception($"Unsupported literal value type: {primitiveType}"),

                },
                _ => throw new Exception($"Unsupported literal value type: {literalType.LiteralValueType}"),
            };
        }
    }
}
