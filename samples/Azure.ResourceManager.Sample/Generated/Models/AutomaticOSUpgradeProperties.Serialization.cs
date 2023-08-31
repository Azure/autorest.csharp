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
    internal partial class AutomaticOSUpgradeProperties : IUtf8JsonSerializable, IModelJsonSerializable<AutomaticOSUpgradeProperties>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<AutomaticOSUpgradeProperties>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<AutomaticOSUpgradeProperties>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            writer.WriteStartObject();
            writer.WritePropertyName("automaticOSUpgradeSupported"u8);
            writer.WriteBooleanValue(AutomaticOSUpgradeSupported);
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

        internal static AutomaticOSUpgradeProperties DeserializeAutomaticOSUpgradeProperties(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            bool automaticOSUpgradeSupported = default;
            Dictionary<string, BinaryData> rawData = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("automaticOSUpgradeSupported"u8))
                {
                    automaticOSUpgradeSupported = property.Value.GetBoolean();
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    rawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                    continue;
                }
            }
            return new AutomaticOSUpgradeProperties(automaticOSUpgradeSupported, rawData);
        }

        AutomaticOSUpgradeProperties IModelJsonSerializable<AutomaticOSUpgradeProperties>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeAutomaticOSUpgradeProperties(doc.RootElement, options);
        }

        BinaryData IModelSerializable<AutomaticOSUpgradeProperties>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        AutomaticOSUpgradeProperties IModelSerializable<AutomaticOSUpgradeProperties>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeAutomaticOSUpgradeProperties(doc.RootElement, options);
        }

        /// <summary> Converts a <see cref="AutomaticOSUpgradeProperties"/> into a <see cref="RequestContent"/>. </summary>
        /// <param name="model"> The <see cref="AutomaticOSUpgradeProperties"/> to convert. </param>
        public static implicit operator RequestContent(AutomaticOSUpgradeProperties model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        /// <summary> Converts a <see cref="Response"/> into a <see cref="AutomaticOSUpgradeProperties"/>. </summary>
        /// <param name="response"> The <see cref="Response"/> to convert. </param>
        public static explicit operator AutomaticOSUpgradeProperties(Response response)
        {
            if (response is null)
            {
                return null;
            }

            using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
            return DeserializeAutomaticOSUpgradeProperties(doc.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
