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
    public partial class TerminateNotificationProfile : IUtf8JsonSerializable, IModelJsonSerializable<TerminateNotificationProfile>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<TerminateNotificationProfile>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<TerminateNotificationProfile>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            writer.WriteStartObject();
            if (Optional.IsDefined(NotBeforeTimeout))
            {
                writer.WritePropertyName("notBeforeTimeout"u8);
                writer.WriteStringValue(NotBeforeTimeout);
            }
            if (Optional.IsDefined(Enable))
            {
                writer.WritePropertyName("enable"u8);
                writer.WriteBooleanValue(Enable.Value);
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

        internal static TerminateNotificationProfile DeserializeTerminateNotificationProfile(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> notBeforeTimeout = default;
            Optional<bool> enable = default;
            Dictionary<string, BinaryData> rawData = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("notBeforeTimeout"u8))
                {
                    notBeforeTimeout = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("enable"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    enable = property.Value.GetBoolean();
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    rawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                    continue;
                }
            }
            return new TerminateNotificationProfile(notBeforeTimeout.Value, Optional.ToNullable(enable), rawData);
        }

        TerminateNotificationProfile IModelJsonSerializable<TerminateNotificationProfile>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeTerminateNotificationProfile(doc.RootElement, options);
        }

        BinaryData IModelSerializable<TerminateNotificationProfile>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        TerminateNotificationProfile IModelSerializable<TerminateNotificationProfile>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeTerminateNotificationProfile(doc.RootElement, options);
        }

        /// <summary> Converts a <see cref="TerminateNotificationProfile"/> into a <see cref="RequestContent"/>. </summary>
        /// <param name="model"> The <see cref="TerminateNotificationProfile"/> to convert. </param>
        public static implicit operator RequestContent(TerminateNotificationProfile model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        /// <summary> Converts a <see cref="Response"/> into a <see cref="TerminateNotificationProfile"/>. </summary>
        /// <param name="response"> The <see cref="Response"/> to convert. </param>
        public static explicit operator TerminateNotificationProfile(Response response)
        {
            if (response is null)
            {
                return null;
            }

            using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
            return DeserializeTerminateNotificationProfile(doc.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
