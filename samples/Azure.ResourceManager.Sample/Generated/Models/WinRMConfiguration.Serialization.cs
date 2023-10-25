// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Net.ClientModel;
using System.Net.ClientModel.Core;
using System.Net.ClientModel.Internal;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Sample.Models
{
    internal partial class WinRMConfiguration : IUtf8JsonSerializable, IJsonModel<WinRMConfiguration>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<WinRMConfiguration>)this).Write(writer, ModelReaderWriterOptions.DefaultWireOptions);

        void IJsonModel<WinRMConfiguration>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
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
            if (_serializedAdditionalRawData != null && options.Format == ModelReaderWriterFormat.Json)
            {
                foreach (var item in _serializedAdditionalRawData)
                {
                    writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(item.Value);
#else
                    using (JsonDocument document = JsonDocument.Parse(item.Value))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
            }
            writer.WriteEndObject();
        }

        WinRMConfiguration IJsonModel<WinRMConfiguration>.Read(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeWinRMConfiguration(document.RootElement, options);
        }

        internal static WinRMConfiguration DeserializeWinRMConfiguration(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelReaderWriterOptions.DefaultWireOptions;

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
                if (options.Format == ModelReaderWriterFormat.Json)
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new WinRMConfiguration(Optional.ToList(listeners), serializedAdditionalRawData);
        }

        BinaryData IModel<WinRMConfiguration>.Write(ModelReaderWriterOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return ModelReaderWriter.WriteCore(this, options);
        }

        WinRMConfiguration IModel<WinRMConfiguration>.Read(BinaryData data, ModelReaderWriterOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeWinRMConfiguration(document.RootElement, options);
        }
    }
}
