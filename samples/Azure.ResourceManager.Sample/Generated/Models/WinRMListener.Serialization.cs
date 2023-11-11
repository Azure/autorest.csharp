// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Net.ClientModel;
using System.Net.ClientModel.Core;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Sample.Models
{
    public partial class WinRMListener : IUtf8JsonSerializable, IJsonModel<WinRMListener>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<WinRMListener>)this).Write(writer, ModelReaderWriterOptions.DefaultWireOptions);

        void IJsonModel<WinRMListener>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if ((options.Format != ModelReaderWriterFormat.Wire || ((IModel<WinRMListener>)this).GetWireFormat(options) != ModelReaderWriterFormat.Json) && options.Format != ModelReaderWriterFormat.Json)
            {
                throw new InvalidOperationException($"Must use 'J' format when calling the {nameof(IJsonModel<WinRMListener>)} interface");
            }

            writer.WriteStartObject();
            if (Optional.IsDefined(Protocol))
            {
                writer.WritePropertyName("protocol"u8);
                writer.WriteStringValue(Protocol.Value.ToSerialString());
            }
            if (Optional.IsDefined(CertificateUri))
            {
                writer.WritePropertyName("certificateUrl"u8);
                writer.WriteStringValue(CertificateUri.AbsoluteUri);
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

        WinRMListener IJsonModel<WinRMListener>.Read(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(WinRMListener)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeWinRMListener(document.RootElement, options);
        }

        internal static WinRMListener DeserializeWinRMListener(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelReaderWriterOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<ProtocolType> protocol = default;
            Optional<Uri> certificateUrl = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("protocol"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    protocol = property.Value.GetString().ToProtocolType();
                    continue;
                }
                if (property.NameEquals("certificateUrl"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    certificateUrl = new Uri(property.Value.GetString());
                    continue;
                }
                if (options.Format == ModelReaderWriterFormat.Json)
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new WinRMListener(Optional.ToNullable(protocol), certificateUrl.Value, serializedAdditionalRawData);
        }

        BinaryData IModel<WinRMListener>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(WinRMListener)} does not support '{options.Format}' format.");
            }

            return ModelReaderWriter.Write(this, options);
        }

        WinRMListener IModel<WinRMListener>.Read(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(WinRMListener)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeWinRMListener(document.RootElement, options);
        }

        ModelReaderWriterFormat IModel<WinRMListener>.GetWireFormat(ModelReaderWriterOptions options) => ModelReaderWriterFormat.Json;
    }
}
