﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace AutoRest.CSharp.Common.Input
{
    internal class TypeSpecInputLiteralTypeConverter : JsonConverter<InputLiteralType>
    {
        private readonly TypeSpecReferenceHandler _referenceHandler;
        public TypeSpecInputLiteralTypeConverter(TypeSpecReferenceHandler referenceHandler)
        {
            _referenceHandler = referenceHandler;
        }

        public override InputLiteralType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
           => reader.ReadReferenceAndResolve<InputLiteralType>(_referenceHandler.CurrentResolver) ?? CreateInputLiteralType(ref reader, null, null, options, _referenceHandler.CurrentResolver);

        public override void Write(Utf8JsonWriter writer, InputLiteralType value, JsonSerializerOptions options)
            => throw new NotSupportedException("Writing not supported");

        public static InputLiteralType CreateInputLiteralType(ref Utf8JsonReader reader, string? id, string? name, JsonSerializerOptions options, ReferenceResolver resolver)
        {
            JsonElement? rawValue = null;
            InputType? valueType = null;
            IReadOnlyList<InputDecoratorInfo>? decorators = null;

            while (reader.TokenType != JsonTokenType.EndObject)
            {
                var isKnownProperty = reader.TryReadReferenceId(ref id)
                    || reader.TryReadComplexType("value", options, ref rawValue)
                    || reader.TryReadComplexType("valueType", options, ref valueType)
                    || reader.TryReadComplexType("decorators", options, ref decorators);

                if (!isKnownProperty)
                {
                    reader.SkipProperty();
                }
            }

            valueType = valueType ?? throw new JsonException("InputLiteralType must have type");

            if (rawValue == null)
            {
                throw new JsonException("InputLiteralType must have value");
            }

            var valueKind = valueType switch
            {
                InputPrimitiveType primitiveType => primitiveType.Kind,
                InputEnumType enumType => enumType.ValueType.Kind,
                _ => throw new JsonException($"InputLiteralType does not support type {valueType.GetType()}")
            };
            object value = valueKind switch
            {
                InputPrimitiveTypeKind.String => rawValue.Value.GetString() ?? throw new JsonException(),
                InputPrimitiveTypeKind.Int32 => rawValue.Value.GetInt32(),
                InputPrimitiveTypeKind.Float32 => rawValue.Value.GetSingle(),
                InputPrimitiveTypeKind.Float64 => rawValue.Value.GetDouble(),
                InputPrimitiveTypeKind.Boolean => rawValue.Value.GetBoolean(),
                _ => throw new JsonException($"InputLiteralType does not support type {valueKind}")
            };

            var literalType = new InputLiteralType(valueType, value)
            {
                Decorators = decorators ?? []
            };

            if (id != null)
            {
                resolver.AddReference(id, literalType);
            }
            return literalType;
        }
    }
}
