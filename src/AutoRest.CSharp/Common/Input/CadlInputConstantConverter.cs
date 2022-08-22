// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Types;
using static AutoRest.CSharp.Input.Configuration;

namespace AutoRest.CSharp.Common.Input
{
    internal class CadlInputConstantConverter: JsonConverter<InputConstant>
    {
        private readonly CadlReferenceHandler _referenceHandler;

        public CadlInputConstantConverter(CadlReferenceHandler referenceHandler)
        {
            _referenceHandler = referenceHandler;
        }

        public override InputConstant Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => reader.ReadReferenceAndResolve<InputConstant>(_referenceHandler.CurrentResolver) ?? CreateInputConstant(ref reader, null, null, options, _referenceHandler.CurrentResolver);

        public override void Write(Utf8JsonWriter writer, InputConstant value, JsonSerializerOptions options)
            => throw new NotSupportedException("Writing not supported");

        public static InputConstant CreateInputConstant(ref Utf8JsonReader reader, string? id, string? name, JsonSerializerOptions options, ReferenceResolver resolver)
        {
            var isFirstProperty = id == null;
            Object? value = null;
            InputType? type = null;
            while (reader.TokenType != JsonTokenType.EndObject)
            {
                var isKnownProperty = reader.TryReadReferenceId(ref isFirstProperty, ref id)
                    || reader.TryReadWithConverter(nameof(InputConstant.Type), options, ref type)
                    || TryReadConstantValue(ref reader, nameof(InputConstant.Value), options, type, ref value);

                if (!isKnownProperty)
                {
                    reader.SkipProperty();
                }
            }

            type = type ?? throw new JsonException("InputConstant must have type");

            value = value ?? throw new JsonException("InputConstant must have value");

            var constant = new InputConstant(value, type);
            if (id != null)
            {
                resolver.AddReference(id, constant);
            }
            return constant;
        }

        public static bool TryReadConstantValue(ref Utf8JsonReader reader, string propertyName, JsonSerializerOptions options, InputType? type, ref Object? value)
        {
            if (type == null)
            {
                throw new JsonException("Must place type ahead of value.");
            }
            if (reader.TokenType != JsonTokenType.PropertyName)
            {
                throw new JsonException();
            }

            if (reader.GetString() != propertyName)
            {
                return false;
            }

            reader.Read();
            switch (type) {
                case InputPrimitiveType primitype:
                    switch (primitype.Kind)
                    {
                        case InputTypeKind.String:
                            value = reader.GetString() ?? throw new JsonException();
                            break;
                        case InputTypeKind.Uri:
                            var stringvalue = reader.GetString() ?? throw new JsonException();
                            value = new Uri(stringvalue);
                            break;
                        case InputTypeKind.Int32:
                            value = reader.GetInt32();
                            break;
                        case InputTypeKind.Int64:
                            value = reader.GetInt64();
                            break;
                        case InputTypeKind.Boolean:
                            value = reader.GetBoolean();
                            break;
                        default:
                            value = reader.GetString() ?? throw new JsonException();
                            break;

                    }
                    break;
                case InputModelType model:
                    /*TODO: serialize it as Byte array, and will convert to the actually type in autorest.csharp code generator. */
                    var converter = (JsonConverter<ObjectType>)options.GetConverter(typeof(Byte[]));
                    if (converter != null)
                    {
                        Type typeToConvert = typeof(Byte[]);
                        value = converter.Read(ref reader, typeToConvert: typeToConvert, options) ?? throw new JsonException();
                    }
                    break;
                default:
                    break;
            }
            reader.Read();
            return true;
        }
    }
}
