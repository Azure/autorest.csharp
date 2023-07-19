// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace Azure.ResourceManager.Storage.Models
{
    public partial class AccountSasContent : IUtf8JsonSerializable, IJsonModelSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModelSerializable)this).Serialize(writer, ModelSerializerOptions.AzureServiceDefault);

        void IJsonModelSerializable.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
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
            writer.WriteEndObject();
        }

        object IModelSerializable.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            using var doc = JsonDocument.Parse(data);
            return DeserializeAccountSasContent(doc.RootElement, options);
        }

        internal static AccountSasContent DeserializeAccountSasContent(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.AzureServiceDefault;
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
            }
            return new AccountSasContent(signedServices, signedResourceTypes, signedPermission, signedIp.Value, Optional.ToNullable(signedProtocol), Optional.ToNullable(signedStart), signedExpiry, keyToSign.Value);
        }

        object IJsonModelSerializable.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeAccountSasContent(doc.RootElement, options);
        }
    }
}
