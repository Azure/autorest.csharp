// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

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
            object? value = null;
            InputType? type = null;
            while (reader.TokenType != JsonTokenType.EndObject)
            {
                var isKnownProperty = reader.TryReadReferenceId(ref isFirstProperty, ref id)
                    || reader.TryReadWithConverter(nameof(InputConstant.Value), options, ref value)
                    || reader.TryReadWithConverter(nameof(InputConstant.Type), options, ref type);

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
    }
}
