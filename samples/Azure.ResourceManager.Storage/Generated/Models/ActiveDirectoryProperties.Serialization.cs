// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Storage.Models
{
    public partial class ActiveDirectoryProperties : IUtf8JsonSerializable, IJsonModel<ActiveDirectoryProperties>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<ActiveDirectoryProperties>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<ActiveDirectoryProperties>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ActiveDirectoryProperties>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new InvalidOperationException($"The model {nameof(ActiveDirectoryProperties)} does not support '{format}' format.");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("domainName"u8);
            writer.WriteStringValue(DomainName);
            writer.WritePropertyName("netBiosDomainName"u8);
            writer.WriteStringValue(NetBiosDomainName);
            writer.WritePropertyName("forestName"u8);
            writer.WriteStringValue(ForestName);
            writer.WritePropertyName("domainGuid"u8);
            writer.WriteStringValue(DomainGuid);
            writer.WritePropertyName("domainSid"u8);
            writer.WriteStringValue(DomainSid);
            writer.WritePropertyName("azureStorageSid"u8);
            writer.WriteStringValue(AzureStorageSid);
            if (_serializedAdditionalRawData != null && options.Format != "W")
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

        ActiveDirectoryProperties IJsonModel<ActiveDirectoryProperties>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ActiveDirectoryProperties>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new InvalidOperationException($"The model {nameof(ActiveDirectoryProperties)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeActiveDirectoryProperties(document.RootElement, options);
        }

        internal static ActiveDirectoryProperties DeserializeActiveDirectoryProperties(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string domainName = default;
            string netBiosDomainName = default;
            string forestName = default;
            string domainGuid = default;
            string domainSid = default;
            string azureStorageSid = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("domainName"u8))
                {
                    domainName = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("netBiosDomainName"u8))
                {
                    netBiosDomainName = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("forestName"u8))
                {
                    forestName = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("domainGuid"u8))
                {
                    domainGuid = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("domainSid"u8))
                {
                    domainSid = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("azureStorageSid"u8))
                {
                    azureStorageSid = property.Value.GetString();
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new ActiveDirectoryProperties(domainName, netBiosDomainName, forestName, domainGuid, domainSid, azureStorageSid, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<ActiveDirectoryProperties>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ActiveDirectoryProperties>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new InvalidOperationException($"The model {nameof(ActiveDirectoryProperties)} does not support '{options.Format}' format.");
            }
        }

        ActiveDirectoryProperties IPersistableModel<ActiveDirectoryProperties>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ActiveDirectoryProperties>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeActiveDirectoryProperties(document.RootElement, options);
                    }
                default:
                    throw new InvalidOperationException($"The model {nameof(ActiveDirectoryProperties)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<ActiveDirectoryProperties>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
