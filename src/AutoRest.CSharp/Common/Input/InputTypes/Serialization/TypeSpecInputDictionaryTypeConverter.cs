// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AutoRest.CSharp.Common.Input
{
    internal sealed class TypeSpecInputDictionaryTypeConverter : JsonConverter<IDictionaryType>
    {
        private readonly TypeSpecReferenceHandler _referenceHandler;

        public TypeSpecInputDictionaryTypeConverter(TypeSpecReferenceHandler referenceHandler)
        {
            _referenceHandler = referenceHandler;
        }

        public override IDictionaryType? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => reader.ReadReferenceAndResolve<IDictionaryType>(_referenceHandler.CurrentResolver) ?? CreateDictionaryType(ref reader, null, options, _referenceHandler.CurrentResolver);

        public override void Write(Utf8JsonWriter writer, IDictionaryType value, JsonSerializerOptions options)
            => throw new NotSupportedException("Writing not supported");

        public static IDictionaryType CreateDictionaryType(ref Utf8JsonReader reader, string? id, JsonSerializerOptions options, ReferenceResolver resolver)
        {
            var isFirstProperty = id == null;
            bool isNullable = false;
            IType? keyType = null;
            IType? valueType = null;
            while (reader.TokenType != JsonTokenType.EndObject)
            {
                var isKnownProperty = reader.TryReadReferenceId(ref isFirstProperty, ref id)
                    || reader.TryReadBoolean(nameof(IDictionaryType.IsNullable), ref isNullable)
                    || reader.TryReadWithConverter(nameof(IDictionaryType.KeyType), options, ref keyType)
                    || reader.TryReadWithConverter(nameof(IDictionaryType.ValueType), options, ref valueType);

                if (!isKnownProperty)
                {
                    reader.SkipProperty();
                }
            }

            keyType = keyType ?? throw new JsonException("Dictionary must have key type");
            valueType = valueType ?? throw new JsonException("Dictionary must have value type");

            var dictType = new InputDictionaryType(keyType, valueType, isNullable);
            if (id != null)
            {
                resolver.AddReference(id, dictType);
            }
            return dictType;
        }
    }
}
