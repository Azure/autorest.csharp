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

namespace Azure.ResourceManager.Storage.Models
{
    public partial class RestorePolicyProperties : IUtf8JsonSerializable, IModelJsonSerializable<RestorePolicyProperties>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<RestorePolicyProperties>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<RestorePolicyProperties>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            writer.WriteStartObject();
            writer.WritePropertyName("enabled"u8);
            writer.WriteBooleanValue(Enabled);
            if (Optional.IsDefined(Days))
            {
                writer.WritePropertyName("days"u8);
                writer.WriteNumberValue(Days.Value);
            }
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

        internal static RestorePolicyProperties DeserializeRestorePolicyProperties(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            bool enabled = default;
            Optional<int> days = default;
            Optional<DateTimeOffset> lastEnabledTime = default;
            Optional<DateTimeOffset> minRestoreTime = default;
            Dictionary<string, BinaryData> rawData = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("enabled"u8))
                {
                    enabled = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("days"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    days = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("lastEnabledTime"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    lastEnabledTime = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("minRestoreTime"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    minRestoreTime = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    rawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                    continue;
                }
            }
            return new RestorePolicyProperties(enabled, Optional.ToNullable(days), Optional.ToNullable(lastEnabledTime), Optional.ToNullable(minRestoreTime), rawData);
        }

        RestorePolicyProperties IModelJsonSerializable<RestorePolicyProperties>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeRestorePolicyProperties(doc.RootElement, options);
        }

        BinaryData IModelSerializable<RestorePolicyProperties>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        RestorePolicyProperties IModelSerializable<RestorePolicyProperties>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeRestorePolicyProperties(doc.RootElement, options);
        }

        /// <summary> Converts a <see cref="RestorePolicyProperties"/> into a <see cref="RequestContent"/>. </summary>
        /// <param name="model"> The <see cref="RestorePolicyProperties"/> to convert. </param>
        public static implicit operator RequestContent(RestorePolicyProperties model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        /// <summary> Converts a <see cref="Response"/> into a <see cref="RestorePolicyProperties"/>. </summary>
        /// <param name="response"> The <see cref="Response"/> to convert. </param>
        public static explicit operator RestorePolicyProperties(Response response)
        {
            if (response is null)
            {
                return null;
            }

            using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
            return DeserializeRestorePolicyProperties(doc.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
