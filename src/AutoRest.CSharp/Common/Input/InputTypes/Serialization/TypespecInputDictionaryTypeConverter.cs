// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AutoRest.CSharp.Common.Input
{
    internal sealed class TypespecInputDictionaryTypeConverter : JsonConverter<InputDictionaryType>
    {
        private readonly TypespecReferenceHandler _referenceHandler;

        public TypespecInputDictionaryTypeConverter(TypespecReferenceHandler referenceHandler)
        {
            _referenceHandler = referenceHandler;
        }

        public override InputDictionaryType? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => reader.ReadReferenceAndResolve<InputDictionaryType>(_referenceHandler.CurrentResolver) ?? CreateDictionaryType(ref reader, null, null, options);

        public override void Write(Utf8JsonWriter writer, InputDictionaryType value, JsonSerializerOptions options)
            => throw new NotSupportedException("Writing not supported");

        public static InputDictionaryType CreateDictionaryType(ref Utf8JsonReader reader, string? id, string? name, JsonSerializerOptions options)
        {
            var isFirstProperty = id == null && name == null;
            InputType? keyType = null;
            InputType? valueType = null;
            while (reader.TokenType != JsonTokenType.EndObject)
            {
                var isKnownProperty = reader.TryReadReferenceId(ref isFirstProperty, ref id)
                    || reader.TryReadString(nameof(InputListType.Name), ref name)
                    || reader.TryReadWithConverter(nameof(InputDictionaryType.KeyType), options, ref keyType)
                    || reader.TryReadWithConverter(nameof(InputDictionaryType.ValueType), options, ref valueType);

                if (!isKnownProperty)
                {
                    reader.SkipProperty();
                }
            }

            keyType = keyType ?? throw new JsonException("Dictionary must have key type");
            valueType = valueType ?? throw new JsonException("Dictionary must have value type");

            return new InputDictionaryType(name ?? "Dictionary", keyType, valueType);
        }
    }
}
