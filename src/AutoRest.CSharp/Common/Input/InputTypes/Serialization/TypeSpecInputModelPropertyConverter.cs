﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AutoRest.CSharp.Common.Input
{
    internal sealed class TypeSpecInputModelPropertyConverter : JsonConverter<InputModelProperty>
    {
        private readonly TypeSpecReferenceHandler _referenceHandler;

        public TypeSpecInputModelPropertyConverter(TypeSpecReferenceHandler referenceHandler)
        {
            _referenceHandler = referenceHandler;
        }

        public override InputModelProperty Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => reader.ReadReferenceAndResolve<InputModelProperty>(_referenceHandler.CurrentResolver) ?? ReadInputModelProperty(ref reader, null, null, options, _referenceHandler.CurrentResolver);

        public override void Write(Utf8JsonWriter writer, InputModelProperty value, JsonSerializerOptions options)
            => throw new NotSupportedException("Writing not supported");

        private static InputModelProperty ReadInputModelProperty(ref Utf8JsonReader reader, string? id, string? name, JsonSerializerOptions options, ReferenceResolver resolver)
        {
            string? serializedName = null;
            string? kind = null;
            string? summary = null;
            string? doc = null;
            InputType? propertyType = null;
            InputConstant? defaultValue = null;
            bool isReadOnly = false;
            bool isOptional = false;
            bool isDiscriminator = false;
            IReadOnlyList<InputDecoratorInfo>? decorators = null;
            bool isFlattened = false;

            while (reader.TokenType != JsonTokenType.EndObject)
            {
                var isKnownProperty = reader.TryReadReferenceId(ref id)
                    || reader.TryReadString("name", ref name)
                    || reader.TryReadString("kind", ref kind)
                    || reader.TryReadString("serializedName", ref serializedName)
                    || reader.TryReadString("summary", ref summary)
                    || reader.TryReadString("doc", ref doc)
                    || reader.TryReadComplexType("type", options, ref propertyType)
                    || reader.TryReadBoolean("readOnly", ref isReadOnly)
                    || reader.TryReadBoolean("optional", ref isOptional)
                    || reader.TryReadBoolean("discriminator", ref isDiscriminator)
                    || reader.TryReadComplexType("decorators", options, ref decorators)
                    || reader.TryReadBoolean("flatten", ref isFlattened);

                if (!isKnownProperty)
                {
                    reader.SkipProperty();
                }
            }

            name = name ?? throw new JsonException($"{nameof(InputModelProperty)} must have a name.");
            if (kind == null)
            {
                throw new JsonException("Property must have kind");
            }
            Enum.TryParse(kind, ignoreCase: true, out InputModelPropertyKind propertyKind);
            propertyType = propertyType ?? throw new JsonException($"{nameof(InputModelProperty)} must have a property type.");

            if (propertyType is InputLiteralType lt)
            {
                defaultValue = new InputConstant(lt.Value, lt.ValueType);
                propertyType = lt.ValueType;
            }

            if (propertyType is InputEnumTypeValue enumTypeValue)
            {
                defaultValue = new InputConstant(enumTypeValue.Value, enumTypeValue.ValueType);
                propertyType = enumTypeValue.EnumType;
            }

            var property = new InputModelProperty(name, serializedName ?? name, summary, doc, propertyType, defaultValue, !isOptional, isReadOnly, isDiscriminator, propertyKind)
            {
                Decorators = decorators ?? [],
                IsFlattened = isFlattened
            };
            if (id != null)
            {
                resolver.AddReference(id, property);
            }

            return property;
        }
    }
}
