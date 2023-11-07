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
    public partial class AccountSasContent : IUtf8JsonSerializable, IJsonModel<AccountSasContent>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<AccountSasContent>)this).Write(writer, ModelReaderWriterOptions.DefaultWireOptions);

        void IJsonModel<AccountSasContent>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("signedServices"u8);
            writer.WriteStringValue(Services.ToString());
            writer.WritePropertyName("signedResourceTypes"u8);
            writer.WriteStringValue(ResourceTypes.ToString());
            writer.WritePropertyName("signedPermission"u8);
            writer.WriteStringValue(Permissions.ToString());
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
            writer.WritePropertyName("signedExpiry"u8);
            writer.WriteStringValue(SharedAccessExpiryOn, "O");
            if (Optional.IsDefined(KeyToSign))
            {
                writer.WritePropertyName("keyToSign"u8);
                writer.WriteStringValue(KeyToSign);
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

        AccountSasContent IJsonModel<AccountSasContent>.Read(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(AccountSasContent)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeAccountSasContent(document.RootElement, options);
        }

        internal static AccountSasContent DeserializeAccountSasContent(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelReaderWriterOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Service signedServices = default;
            SignedResourceType signedResourceTypes = default;
            Permission signedPermission = default;
            Optional<string> signedIp = default;
            Optional<HttpProtocol> signedProtocol = default;
            Optional<DateTimeOffset> signedStart = default;
            DateTimeOffset signedExpiry = default;
            Optional<string> keyToSign = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("signedServices"u8))
                {
                    signedServices = new Service(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("signedResourceTypes"u8))
                {
                    signedResourceTypes = new SignedResourceType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("signedPermission"u8))
                {
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
                    signedExpiry = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("keyToSign"u8))
                {
                    keyToSign = property.Value.GetString();
                    continue;
                }
                if (options.Format == ModelReaderWriterFormat.Json)
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new AccountSasContent(signedServices, signedResourceTypes, signedPermission, signedIp.Value, Optional.ToNullable(signedProtocol), Optional.ToNullable(signedStart), signedExpiry, keyToSign.Value, serializedAdditionalRawData);
        }

        BinaryData IModel<AccountSasContent>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(AccountSasContent)} does not support '{options.Format}' format.");
            }

            return ModelReaderWriter.Write(this, options);
        }

        AccountSasContent IModel<AccountSasContent>.Read(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(AccountSasContent)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeAccountSasContent(document.RootElement, options);
        }

        ModelReaderWriterFormat IModel<AccountSasContent>.GetWireFormat(ModelReaderWriterOptions options) => ModelReaderWriterFormat.Json;
    }
}
