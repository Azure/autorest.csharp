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

namespace Azure.ResourceManager.Sample.Models
{
    public partial class LogAnalyticsInputBase : IUtf8JsonSerializable, IModelJsonSerializable<LogAnalyticsInputBase>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<LogAnalyticsInputBase>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<LogAnalyticsInputBase>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            writer.WriteStartObject();
            writer.WritePropertyName("blobContainerSasUri"u8);
            writer.WriteStringValue(BlobContainerSasUri.AbsoluteUri);
            writer.WritePropertyName("fromTime"u8);
            writer.WriteStringValue(FromTime, "O");
            writer.WritePropertyName("toTime"u8);
            writer.WriteStringValue(ToTime, "O");
            if (Optional.IsDefined(GroupByThrottlePolicy))
            {
                writer.WritePropertyName("groupByThrottlePolicy"u8);
                writer.WriteBooleanValue(GroupByThrottlePolicy.Value);
            }
            if (Optional.IsDefined(GroupByOperationName))
            {
                writer.WritePropertyName("groupByOperationName"u8);
                writer.WriteBooleanValue(GroupByOperationName.Value);
            }
            if (Optional.IsDefined(GroupByResourceName))
            {
                writer.WritePropertyName("groupByResourceName"u8);
                writer.WriteBooleanValue(GroupByResourceName.Value);
            }
            if (_serializedAdditionalRawData is not null && options.Format == ModelSerializerFormat.Json)
            {
                foreach (var property in _serializedAdditionalRawData)
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

        internal static LogAnalyticsInputBase DeserializeLogAnalyticsInputBase(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Uri blobContainerSasUri = default;
            DateTimeOffset fromTime = default;
            DateTimeOffset toTime = default;
            Optional<bool> groupByThrottlePolicy = default;
            Optional<bool> groupByOperationName = default;
            Optional<bool> groupByResourceName = default;
            Dictionary<string, BinaryData> serializedAdditionalRawData = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("blobContainerSasUri"u8))
                {
                    blobContainerSasUri = new Uri(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("fromTime"u8))
                {
                    fromTime = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("toTime"u8))
                {
                    toTime = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("groupByThrottlePolicy"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    groupByThrottlePolicy = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("groupByOperationName"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    groupByOperationName = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("groupByResourceName"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    groupByResourceName = property.Value.GetBoolean();
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    serializedAdditionalRawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                    continue;
                }
            }
            return new LogAnalyticsInputBase(blobContainerSasUri, fromTime, toTime, Optional.ToNullable(groupByThrottlePolicy), Optional.ToNullable(groupByOperationName), Optional.ToNullable(groupByResourceName), serializedAdditionalRawData);
        }

        LogAnalyticsInputBase IModelJsonSerializable<LogAnalyticsInputBase>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeLogAnalyticsInputBase(doc.RootElement, options);
        }

        BinaryData IModelSerializable<LogAnalyticsInputBase>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        LogAnalyticsInputBase IModelSerializable<LogAnalyticsInputBase>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeLogAnalyticsInputBase(doc.RootElement, options);
        }

        /// <summary> Converts a <see cref="LogAnalyticsInputBase"/> into a <see cref="RequestContent"/>. </summary>
        /// <param name="model"> The <see cref="LogAnalyticsInputBase"/> to convert. </param>
        public static implicit operator RequestContent(LogAnalyticsInputBase model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        /// <summary> Converts a <see cref="Response"/> into a <see cref="LogAnalyticsInputBase"/>. </summary>
        /// <param name="response"> The <see cref="Response"/> to convert. </param>
        public static explicit operator LogAnalyticsInputBase(Response response)
        {
            if (response is null)
            {
                return null;
            }

            using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
            return DeserializeLogAnalyticsInputBase(doc.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
