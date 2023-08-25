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
            var isFirstProperty = id == null && name == null;
            bool isNullable = false;
            InputConstant? value = null;

            while (reader.TokenType != JsonTokenType.EndObject)
            {
                var isKnownProperty = reader.TryReadReferenceId(ref isFirstProperty, ref id)
                    || reader.TryReadString(nameof(InputLiteralType.Name), ref name)
                    || reader.TryReadBoolean(nameof(InputLiteralType.IsNullable), ref isNullable)
                    || reader.TryReadWithConverter(nameof(InputLiteralType.Value), options, ref value);

                if (!isKnownProperty)
                {
                    reader.SkipProperty();
                }
            }

            name = name ?? throw new JsonException($"{nameof(InputLiteralType)} must have a name.");

            value = value ?? throw new JsonException($"{nameof(InputLiteralType)} must have value");

            var literalType = new InputLiteralType(value, isNullable);

            if (id != null)
            {
                resolver.AddReference(id, literalType);
            }
            return literalType;
        }
    }
}
