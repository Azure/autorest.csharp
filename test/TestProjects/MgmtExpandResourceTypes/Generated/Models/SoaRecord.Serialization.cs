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

namespace MgmtExpandResourceTypes.Models
{
    public partial class SoaRecord : IUtf8JsonSerializable, IJsonModel<SoaRecord>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<SoaRecord>)this).Write(writer, ModelReaderWriterOptions.Wire);

        void IJsonModel<SoaRecord>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if ((options.Format != "W" || ((IPersistableModel<SoaRecord>)this).GetWireFormat(options) != "J") && options.Format != "J")
            {
                throw new InvalidOperationException($"Must use 'J' format when calling the {nameof(IJsonModel<SoaRecord>)} interface");
            }

            writer.WriteStartObject();
            if (Optional.IsDefined(Host))
            {
                writer.WritePropertyName("host"u8);
                writer.WriteStringValue(Host);
            }
            if (Optional.IsDefined(Email))
            {
                writer.WritePropertyName("email"u8);
                writer.WriteStringValue(Email);
            }
            if (Optional.IsDefined(SerialNumber))
            {
                writer.WritePropertyName("serialNumber"u8);
                writer.WriteNumberValue(SerialNumber.Value);
            }
            if (Optional.IsDefined(RefreshTime))
            {
                writer.WritePropertyName("refreshTime"u8);
                writer.WriteNumberValue(RefreshTime.Value);
            }
            if (Optional.IsDefined(RetryTime))
            {
                writer.WritePropertyName("retryTime"u8);
                writer.WriteNumberValue(RetryTime.Value);
            }
            if (Optional.IsDefined(ExpireTime))
            {
                writer.WritePropertyName("expireTime"u8);
                writer.WriteNumberValue(ExpireTime.Value);
            }
            if (Optional.IsDefined(MinimumTtl))
            {
                writer.WritePropertyName("minimumTTL"u8);
                writer.WriteNumberValue(MinimumTtl.Value);
            }
            if (_serializedAdditionalRawData != null && options.Format == "J")
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

        SoaRecord IJsonModel<SoaRecord>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(SoaRecord)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeSoaRecord(document.RootElement, options);
        }

        internal static SoaRecord DeserializeSoaRecord(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelReaderWriterOptions.Wire;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> host = default;
            Optional<string> email = default;
            Optional<long> serialNumber = default;
            Optional<long> refreshTime = default;
            Optional<long> retryTime = default;
            Optional<long> expireTime = default;
            Optional<long> minimumTTL = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("host"u8))
                {
                    host = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("email"u8))
                {
                    email = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("serialNumber"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    serialNumber = property.Value.GetInt64();
                    continue;
                }
                if (property.NameEquals("refreshTime"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    refreshTime = property.Value.GetInt64();
                    continue;
                }
                if (property.NameEquals("retryTime"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    retryTime = property.Value.GetInt64();
                    continue;
                }
                if (property.NameEquals("expireTime"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    expireTime = property.Value.GetInt64();
                    continue;
                }
                if (property.NameEquals("minimumTTL"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    minimumTTL = property.Value.GetInt64();
                    continue;
                }
                if (options.Format == "J")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new SoaRecord(host.Value, email.Value, Optional.ToNullable(serialNumber), Optional.ToNullable(refreshTime), Optional.ToNullable(retryTime), Optional.ToNullable(expireTime), Optional.ToNullable(minimumTTL), serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<SoaRecord>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(SoaRecord)} does not support '{options.Format}' format.");
            }

            return ModelReaderWriter.Write(this, options);
        }

        SoaRecord IPersistableModel<SoaRecord>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(SoaRecord)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeSoaRecord(document.RootElement, options);
        }

        string IPersistableModel<SoaRecord>.GetWireFormat(ModelReaderWriterOptions options) => "J";
    }
}
