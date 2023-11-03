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

namespace Azure.ResourceManager.Storage.Models
{
    public partial class ServiceSasContent : IUtf8JsonSerializable, IJsonModel<ServiceSasContent>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<ServiceSasContent>)this).Write(writer, ModelReaderWriterOptions.DefaultWireOptions);

        void IJsonModel<ServiceSasContent>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("canonicalizedResource"u8);
            writer.WriteStringValue(CanonicalizedResource);
            if (Optional.IsDefined(Resource))
            {
                writer.WritePropertyName("signedResource"u8);
                writer.WriteStringValue(Resource.Value.ToString());
            }
            if (Optional.IsDefined(Permissions))
            {
                writer.WritePropertyName("signedPermission"u8);
                writer.WriteStringValue(Permissions.Value.ToString());
            }
            if (Optional.IsDefined(IPAddressOrRange))
            {
                writer.WritePropertyName("signedIp"u8);
                writer.WriteStringValue(IPAddressOrRange);
            }
            if (Optional.IsDefined(Protocols))
            {
                writer.WritePropertyName("signedProtocol"u8);
                writer.WriteStringValue(Protocols.Value.ToSerialString());
            }
            if (Optional.IsDefined(SharedAccessStartOn))
            {
                writer.WritePropertyName("signedStart"u8);
                writer.WriteStringValue(SharedAccessStartOn.Value, "O");
            }
            if (Optional.IsDefined(SharedAccessExpiryOn))
            {
                writer.WritePropertyName("signedExpiry"u8);
                writer.WriteStringValue(SharedAccessExpiryOn.Value, "O");
            }
            if (Optional.IsDefined(Identifier))
            {
                writer.WritePropertyName("signedIdentifier"u8);
                writer.WriteStringValue(Identifier);
            }
            if (Optional.IsDefined(PartitionKeyStart))
            {
                writer.WritePropertyName("startPk"u8);
                writer.WriteStringValue(PartitionKeyStart);
            }
            if (Optional.IsDefined(PartitionKeyEnd))
            {
                writer.WritePropertyName("endPk"u8);
                writer.WriteStringValue(PartitionKeyEnd);
            }
            if (Optional.IsDefined(RowKeyStart))
            {
                writer.WritePropertyName("startRk"u8);
                writer.WriteStringValue(RowKeyStart);
            }
            if (Optional.IsDefined(RowKeyEnd))
            {
                writer.WritePropertyName("endRk"u8);
                writer.WriteStringValue(RowKeyEnd);
            }
            if (Optional.IsDefined(KeyToSign))
            {
                writer.WritePropertyName("keyToSign"u8);
                writer.WriteStringValue(KeyToSign);
            }
            if (Optional.IsDefined(CacheControl))
            {
                writer.WritePropertyName("rscc"u8);
                writer.WriteStringValue(CacheControl);
            }
            if (Optional.IsDefined(ContentDisposition))
            {
                writer.WritePropertyName("rscd"u8);
                writer.WriteStringValue(ContentDisposition);
            }
            if (Optional.IsDefined(ContentEncoding))
            {
                writer.WritePropertyName("rsce"u8);
                writer.WriteStringValue(ContentEncoding);
            }
            if (Optional.IsDefined(ContentLanguage))
            {
                writer.WritePropertyName("rscl"u8);
                writer.WriteStringValue(ContentLanguage);
            }
            if (Optional.IsDefined(ContentType))
            {
                writer.WritePropertyName("rsct"u8);
                writer.WriteStringValue(ContentType);
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

        ServiceSasContent IJsonModel<ServiceSasContent>.Read(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException(string.Format("The model {0} does not support '{1}' format.", GetType().Name, options.Format));
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeServiceSasContent(document.RootElement, options);
        }

        internal static ServiceSasContent DeserializeServiceSasContent(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelReaderWriterOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string canonicalizedResource = default;
            Optional<SignedResource> signedResource = default;
            Optional<Permission> signedPermission = default;
            Optional<string> signedIp = default;
            Optional<HttpProtocol> signedProtocol = default;
            Optional<DateTimeOffset> signedStart = default;
            Optional<DateTimeOffset> signedExpiry = default;
            Optional<string> signedIdentifier = default;
            Optional<string> startPk = default;
            Optional<string> endPk = default;
            Optional<string> startRk = default;
            Optional<string> endRk = default;
            Optional<string> keyToSign = default;
            Optional<string> rscc = default;
            Optional<string> rscd = default;
            Optional<string> rsce = default;
            Optional<string> rscl = default;
            Optional<string> rsct = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("canonicalizedResource"u8))
                {
                    canonicalizedResource = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("signedResource"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    signedResource = new SignedResource(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("signedPermission"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    signedPermission = new Permission(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("signedIp"u8))
                {
                    signedIp = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("signedProtocol"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    signedProtocol = property.Value.GetString().ToHttpProtocol();
                    continue;
                }
                if (property.NameEquals("signedStart"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    signedStart = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("signedExpiry"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    signedExpiry = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("signedIdentifier"u8))
                {
                    signedIdentifier = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("startPk"u8))
                {
                    startPk = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("endPk"u8))
                {
                    endPk = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("startRk"u8))
                {
                    startRk = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("endRk"u8))
                {
                    endRk = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("keyToSign"u8))
                {
                    keyToSign = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("rscc"u8))
                {
                    rscc = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("rscd"u8))
                {
                    rscd = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("rsce"u8))
                {
                    rsce = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("rscl"u8))
                {
                    rscl = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("rsct"u8))
                {
                    rsct = property.Value.GetString();
                    continue;
                }
                if (options.Format == ModelReaderWriterFormat.Json)
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new ServiceSasContent(canonicalizedResource, Optional.ToNullable(signedResource), Optional.ToNullable(signedPermission), signedIp.Value, Optional.ToNullable(signedProtocol), Optional.ToNullable(signedStart), Optional.ToNullable(signedExpiry), signedIdentifier.Value, startPk.Value, endPk.Value, startRk.Value, endRk.Value, keyToSign.Value, rscc.Value, rscd.Value, rsce.Value, rscl.Value, rsct.Value, serializedAdditionalRawData);
        }

        BinaryData IModel<ServiceSasContent>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException(string.Format("The model {0} does not support '{1}' format.", GetType().Name, options.Format));
            }

            return ModelReaderWriter.Write(this, options);
        }

        ServiceSasContent IModel<ServiceSasContent>.Read(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException(string.Format("The model {0} does not support '{1}' format.", GetType().Name, options.Format));
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeServiceSasContent(document.RootElement, options);
        }

        ModelReaderWriterFormat IModel<ServiceSasContent>.GetWireFormat(ModelReaderWriterOptions options) => ModelReaderWriterFormat.Json;
    }
}
