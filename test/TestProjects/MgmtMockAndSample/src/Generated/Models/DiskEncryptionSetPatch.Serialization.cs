// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace MgmtMockAndSample.Models
{
    public partial class DiskEncryptionSetPatch : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsCollectionDefined(Tags))
            {
                writer.WritePropertyName("tags"u8);
                writer.WriteStartObject();
                foreach (var item in Tags)
                {
                    writer.WritePropertyName(item.Key);
                    writer.WriteStringValue(item.Value);
                }
                writer.WriteEndObject();
            }
            if (Optional.IsDefined(Identity))
            {
                writer.WritePropertyName("identity"u8);
                var serializeOptions = new JsonSerializerOptions { Converters = { new ManagedServiceIdentityTypeV3Converter() } };
                JsonSerializer.Serialize(writer, Identity, serializeOptions);
            }
            writer.WritePropertyName("properties"u8);
            writer.WriteStartObject();
            if (Optional.IsDefined(EncryptionType))
            {
                writer.WritePropertyName("encryptionType"u8);
                writer.WriteStringValue(EncryptionType.Value.ToString());
            }
            if (Optional.IsDefined(ActiveKey))
            {
                writer.WritePropertyName("activeKey"u8);
                writer.WriteObjectValue(ActiveKey);
            }
            if (Optional.IsDefined(RotationToLatestKeyVersionEnabled))
            {
                writer.WritePropertyName("rotationToLatestKeyVersionEnabled"u8);
                writer.WriteBooleanValue(RotationToLatestKeyVersionEnabled.Value);
            }
            if (Optional.IsDefined(FederatedClientId))
            {
                writer.WritePropertyName("federatedClientId"u8);
                writer.WriteStringValue(FederatedClientId);
            }
            writer.WriteEndObject();
            writer.WriteEndObject();
        }
    }
}
