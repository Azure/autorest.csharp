// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace Azure.ResourceManager.Sample.Models
{
    internal partial class WinRMConfiguration : IUtf8JsonSerializable, IModelJsonSerializable<WinRMConfiguration>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<WinRMConfiguration>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<WinRMConfiguration>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            if (Optional.IsCollectionDefined(Listeners))
            {
                writer.WritePropertyName("listeners"u8);
                writer.WriteStartArray();
                foreach (var item in Listeners)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (_serializedAdditionalRawData != null && options.Format == ModelSerializerFormat.Json)
            {
                foreach (var item in _serializedAdditionalRawData)
                {
                    writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(item.Value);
#else
                    JsonSerializer.Serialize(writer, JsonDocument.Parse(item.Value.ToString()).RootElement);
#endif
                }
            }
            writer.WriteEndObject();
        }

        WinRMConfiguration IModelJsonSerializable<WinRMConfiguration>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeWinRMConfiguration(document.RootElement, options);
        }

        internal static WinRMConfiguration DeserializeWinRMConfiguration(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IList<WinRMListener>> listeners = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("listeners"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<WinRMListener> array = new List<WinRMListener>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(WinRMListener.DeserializeWinRMListener(item));
                    }
                    listeners = array;
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new WinRMConfiguration(Optional.ToList(listeners), serializedAdditionalRawData);
        }

        BinaryData IModelSerializable<WinRMConfiguration>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        WinRMConfiguration IModelSerializable<WinRMConfiguration>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeWinRMConfiguration(document.RootElement, options);
        }
    }
}
