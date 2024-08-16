// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AutoRest.CSharp.Common.Input.Examples
{
    internal sealed class TypeSpecInputTypeExampleConverter : JsonConverter<InputExampleValue>
    {
        private const string KindPropertyName = "kind";

        private readonly TypeSpecReferenceHandler _referenceHandler;

        public TypeSpecInputTypeExampleConverter(TypeSpecReferenceHandler referenceHandler)
        {
            _referenceHandler = referenceHandler;
        }

        public override InputExampleValue? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return reader.ReadReferenceAndResolve<InputExampleValue>(_referenceHandler.CurrentResolver) ?? CreateObject(ref reader, options);
        }

        public override void Write(Utf8JsonWriter writer, InputExampleValue value, JsonSerializerOptions options)
            => throw new NotSupportedException("Writing not supported");

        private InputExampleValue CreateObject(ref Utf8JsonReader reader, JsonSerializerOptions options)
        {
            string? id = null;
            string? kind = null;
            InputExampleValue? result = null;
            var isFirstProperty = true;
            while (reader.TokenType != JsonTokenType.EndObject)
            {
                var isIdOrKind = reader.TryReadReferenceId(ref isFirstProperty, ref id)
                    || reader.TryReadString(KindPropertyName, ref kind);

                if (isIdOrKind)
                {
                    continue;
                }
                result = CreateDerivedType(ref reader, id, kind, options);
            }

            return result ?? CreateDerivedType(ref reader, id, kind, options);
        }

        private const string ModelKind = "model";
        private const string ArrayKind = "array";
        private const string DictionaryKind = "dict";

        private InputExampleValue CreateDerivedType(ref Utf8JsonReader reader, string? id, string? kind, JsonSerializerOptions options) => kind switch
        {
            null => throw new JsonException($"InputTypeExample (id: '{id}') must have a 'kind' property"),
            ArrayKind => CreateArrayExample(ref reader, id, options, _referenceHandler.CurrentResolver),
            DictionaryKind or ModelKind => CreateObjectExample(ref reader, id, options, _referenceHandler.CurrentResolver),
            _ => CreateOtherExample(ref reader, id, options, _referenceHandler.CurrentResolver),
        };

        private InputExampleValue CreateArrayExample(ref Utf8JsonReader reader, string? id, JsonSerializerOptions options, ReferenceResolver referenceResolver)
        {
            bool isFirstProperty = id == null;
            InputType? type = null;
            IReadOnlyList<InputExampleValue>? value = null;
            while (reader.TokenType != JsonTokenType.EndObject)
            {
                var isKnownProperty = reader.TryReadReferenceId(ref isFirstProperty, ref id)
                    || reader.TryReadWithConverter("type", options, ref type)
                    || reader.TryReadWithConverter("value", options, ref value);

                if (!isKnownProperty)
                {
                    reader.SkipProperty();
                }
            }

            var result = new InputExampleListValue(type ?? throw new JsonException(), value ?? throw new JsonException());

            if (id != null)
            {
                referenceResolver.AddReference(id, result);
            }

            return result;
        }

        private InputExampleValue CreateObjectExample(ref Utf8JsonReader reader, string? id, JsonSerializerOptions options, ReferenceResolver referenceResolver)
        {
            bool isFirstProperty = id == null;
            InputType? type = null;
            IReadOnlyDictionary<string, InputExampleValue>? value = null;
            while (reader.TokenType != JsonTokenType.EndObject)
            {
                var isKnownProperty = reader.TryReadReferenceId(ref isFirstProperty, ref id)
                    || reader.TryReadWithConverter("type", options, ref type)
                    || reader.TryReadWithConverter("value", options, ref value);

                if (!isKnownProperty)
                {
                    reader.SkipProperty();
                }
            }

            var result = new InputExampleObjectValue(type ?? throw new JsonException(), value ?? throw new JsonException());

            if (id != null)
            {
                referenceResolver.AddReference(id, result);
            }

            return result;
        }

        private InputExampleValue CreateOtherExample(ref Utf8JsonReader reader, string? id, JsonSerializerOptions options, ReferenceResolver referenceResolver)
        {
            bool isFirstProperty = id == null;
            InputType? type = null;
            JsonElement? rawValue = null;
            while (reader.TokenType != JsonTokenType.EndObject)
            {
                var isKnownProperty = reader.TryReadReferenceId(ref isFirstProperty, ref id)
                    || reader.TryReadWithConverter("type", options, ref type)
                    || reader.TryReadWithConverter("value", options, ref rawValue);

                if (!isKnownProperty)
                {
                    reader.SkipProperty();
                }
            }

            object? value = rawValue?.ValueKind switch
            {
                null => throw new JsonException(),
                JsonValueKind.Null => null,
                JsonValueKind.String => rawValue.Value.GetString(),
                JsonValueKind.False => false,
                JsonValueKind.True => true,
                JsonValueKind.Number => rawValue.Value.GetDouble(),
                _ => throw new JsonException($"kind {rawValue?.ValueKind} is not expected here")
            };

            var result = new InputExampleRawValue(type ?? throw new JsonException(), value);

            if (id != null)
            {
                referenceResolver.AddReference(id, result);
            }

            return result;
        }
    }
}
