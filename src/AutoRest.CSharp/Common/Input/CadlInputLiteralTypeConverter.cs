// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis;

namespace AutoRest.CSharp.Common.Input
{
    internal class CadlInputLiteralTypeConverter : JsonConverter<InputLiteralType>
    {
        private readonly CadlReferenceHandler _referenceHandler;
        public CadlInputLiteralTypeConverter(CadlReferenceHandler referenceHandler)
        {
            _referenceHandler = referenceHandler;
        }

        public override InputLiteralType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
           => reader.ReadReferenceAndResolve<InputLiteralType>(_referenceHandler.CurrentResolver) ?? CreateInputLiteralType(ref reader, null, null, options, _referenceHandler.CurrentResolver);

        public override void Write(Utf8JsonWriter writer, InputLiteralType value, JsonSerializerOptions options)
            => throw new NotSupportedException("Writing not supported");
        public static InputLiteralType CreateInputLiteralType(ref Utf8JsonReader reader, string? id, string? name, JsonSerializerOptions options, ReferenceResolver resolver)
        {
            var isFirstProperty = id == null && name == null;
            Object? value = null;
            InputType? type = null;

            while (reader.TokenType != JsonTokenType.EndObject)
            {
                var isKnownProperty = reader.TryReadReferenceId(ref isFirstProperty, ref id)
                    || reader.TryReadString(nameof(InputListType.Name), ref name)
                    || reader.TryReadWithConverter(nameof(InputLiteralType.LiteralValueType), options, ref type);

                if (isKnownProperty)
                {
                    continue;
                }

                if (reader.GetString() == nameof(InputLiteralType.Value))
                {
                    value = ReadLiteralValue(ref reader, nameof(InputLiteralType.Value), options, type);
                }
                else
                {
                    reader.SkipProperty();
                }
            }

            name = name ?? throw new JsonException($"{nameof(InputLiteralType)} must have a name.");

            type = type ?? throw new JsonException("InputConstant must have type");

            value = value ?? throw new JsonException("InputConstant must have value");

            var literalType = new InputLiteralType(name, type, value);

            if (id != null)
            {
                resolver.AddReference(id, literalType);
            }
            return literalType;
        }

        public static object ReadLiteralValue(ref Utf8JsonReader reader, string propertyName, JsonSerializerOptions options, InputType? type)
        {
            if (type == null)
            {
                throw new JsonException("Must place ValueType ahead of value.");
            }
            if (reader.TokenType != JsonTokenType.PropertyName)
            {
                throw new JsonException();
            }

            if (reader.GetString() != propertyName)
            {
                throw new JsonException("This is not for json field " + propertyName);
            }

            reader.Read();
            Object? value = null;
            var kind = type switch
            {
                InputPrimitiveType primitiveType => primitiveType.Kind,
                InputEnumType enumType => enumType.EnumValueType.Kind,
                _ => throw new JsonException($"Not supported literal type {type.Name}.")
            };
            switch (kind)
            {
                case InputTypeKind.String:
                    value = reader.GetString() ?? throw new JsonException();
                    break;
                case InputTypeKind.Int32:
                    value = reader.GetInt32();
                    break;
                case InputTypeKind.Float32:
                    value = reader.GetSingle();
                    break;
                case InputTypeKind.Float64:
                    value = reader.GetDouble();
                    break;
                case InputTypeKind.Boolean:
                    value = reader.GetBoolean();
                    break;
                default:
                    throw new JsonException($"Not supported literal type {kind}.");
            }
            reader.Read();
            return value;
        }
    }
}
