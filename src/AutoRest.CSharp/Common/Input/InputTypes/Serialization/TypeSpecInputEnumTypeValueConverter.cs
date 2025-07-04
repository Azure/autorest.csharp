﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AutoRest.CSharp.Common.Input
{
    internal sealed class TypeSpecInputEnumTypeValueConverter : JsonConverter<InputEnumTypeValue>
    {
        private readonly TypeSpecReferenceHandler _referenceHandler;

        public TypeSpecInputEnumTypeValueConverter(TypeSpecReferenceHandler referenceHandler)
        {
            _referenceHandler = referenceHandler;
        }

        public override InputEnumTypeValue Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => reader.ReadReferenceAndResolve<InputEnumTypeValue>(_referenceHandler.CurrentResolver) ?? CreateEnumTypeValue(ref reader, null, null, options, _referenceHandler.CurrentResolver);

        public override void Write(Utf8JsonWriter writer, InputEnumTypeValue value, JsonSerializerOptions options)
            => throw new NotSupportedException("Writing not supported");

        public static InputEnumTypeValue CreateEnumTypeValue(ref Utf8JsonReader reader, string? id, string? name, JsonSerializerOptions options, ReferenceResolver resolver)
        {
            JsonElement? rawValue = null;
            InputPrimitiveType? valueType = null;
            InputEnumType? enumType = null;
            string? summary = null;
            string? doc = null;
            IReadOnlyList<InputDecoratorInfo>? decorators = null;
            while (reader.TokenType != JsonTokenType.EndObject)
            {
                var isKnownProperty = reader.TryReadReferenceId(ref id)
                    || reader.TryReadString("name", ref name)
                    || reader.TryReadComplexType("value", options, ref rawValue)
                    || reader.TryReadComplexType("valueType", options, ref valueType)
                    || reader.TryReadComplexType("enumType", options, ref enumType)
                    || reader.TryReadString("summary", ref summary)
                    || reader.TryReadString("doc", ref doc)
                    || reader.TryReadComplexType("decorators", options, ref decorators);

                if (!isKnownProperty)
                {
                    reader.SkipProperty();
                }
            }

            name = name ?? throw new JsonException("EnumValue must have name");

            if (rawValue == null)
            {
                throw new JsonException("EnumValue must have value");
            }

            valueType = valueType ?? throw new JsonException("EnumValue must have valueType");
            enumType = enumType ?? throw new JsonException("EnumValue must have enumType");

            InputEnumTypeValue enumValue = valueType.Kind switch
            {
                InputPrimitiveTypeKind.String => new InputEnumTypeStringValue(name, rawValue.Value.GetString() ?? throw new JsonException(), valueType, enumType, summary, doc) { Decorators = decorators ?? [] },
                InputPrimitiveTypeKind.Int32 => new InputEnumTypeIntegerValue(name, rawValue.Value.GetInt32(), valueType, enumType, summary, doc) { Decorators = decorators ?? [] },
                InputPrimitiveTypeKind.Float32 => new InputEnumTypeFloatValue(name, rawValue.Value.GetSingle(), valueType, enumType, summary, doc) { Decorators = decorators ?? [] },
                _ => throw new JsonException()
            };
            if (id != null)
            {
                resolver.AddReference(id, enumValue);
            }
            return enumValue;
        }
    }
}
