// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure;
using Azure.Core;
using Azure.Core.Serialization;

namespace CognitiveSearch.Models
{
    public partial class IndexerExecutionResult : IUtf8JsonSerializable, IModelJsonSerializable<IndexerExecutionResult>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<IndexerExecutionResult>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<IndexerExecutionResult>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            writer.WriteStartObject();
            if (_rawData is not null && options.Format == ModelSerializerFormat.Json)
            {
                foreach (var property in _rawData)
                {
                    writer.WritePropertyName(property.Key);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(property.Value);
#else
                    JsonSerializer.Serialize(writer, JsonDocument.Parse(property.Value.ToString()).RootElement);
#endif
                }
            }
            writer.WriteEndObject();
        }

        internal static IndexerExecutionResult DeserializeIndexerExecutionResult(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IndexerExecutionStatus status = default;
            Optional<string> errorMessage = default;
            Optional<DateTimeOffset> startTime = default;
            Optional<DateTimeOffset> endTime = default;
            IReadOnlyList<ItemError> errors = default;
            IReadOnlyList<ItemWarning> warnings = default;
            int itemsProcessed = default;
            int itemsFailed = default;
            Optional<string> initialTrackingState = default;
            Optional<string> finalTrackingState = default;
            Dictionary<string, BinaryData> rawData = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("status"u8))
                {
                    status = property.Value.GetString().ToIndexerExecutionStatus();
                    continue;
                }
                if (property.NameEquals("errorMessage"u8))
                {
                    errorMessage = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("startTime"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    startTime = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("endTime"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    endTime = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("errors"u8))
                {
                    List<ItemError> array = new List<ItemError>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(ItemError.DeserializeItemError(item));
                    }
                    errors = array;
                    continue;
                }
                if (property.NameEquals("warnings"u8))
                {
                    List<ItemWarning> array = new List<ItemWarning>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(ItemWarning.DeserializeItemWarning(item));
                    }
                    warnings = array;
                    continue;
                }
                if (property.NameEquals("itemsProcessed"u8))
                {
                    itemsProcessed = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("itemsFailed"u8))
                {
                    itemsFailed = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("initialTrackingState"u8))
                {
                    initialTrackingState = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("finalTrackingState"u8))
                {
                    finalTrackingState = property.Value.GetString();
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    rawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                    continue;
                }
            }
            return new IndexerExecutionResult(status, errorMessage.Value, Optional.ToNullable(startTime), Optional.ToNullable(endTime), errors, warnings, itemsProcessed, itemsFailed, initialTrackingState.Value, finalTrackingState.Value, rawData);
        }

        IndexerExecutionResult IModelJsonSerializable<IndexerExecutionResult>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeIndexerExecutionResult(doc.RootElement, options);
        }

        BinaryData IModelSerializable<IndexerExecutionResult>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        IndexerExecutionResult IModelSerializable<IndexerExecutionResult>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeIndexerExecutionResult(doc.RootElement, options);
        }

        /// <summary> Converts a <see cref="IndexerExecutionResult"/> into a <see cref="RequestContent"/>. </summary>
        /// <param name="model"> The <see cref="IndexerExecutionResult"/> to convert. </param>
        public static implicit operator RequestContent(IndexerExecutionResult model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        /// <summary> Converts a <see cref="Response"/> into a <see cref="IndexerExecutionResult"/>. </summary>
        /// <param name="response"> The <see cref="Response"/> to convert. </param>
        public static explicit operator IndexerExecutionResult(Response response)
        {
            if (response is null)
            {
                return null;
            }

            using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
            return DeserializeIndexerExecutionResult(doc.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
