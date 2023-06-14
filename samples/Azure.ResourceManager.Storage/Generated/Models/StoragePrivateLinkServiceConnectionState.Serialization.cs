// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Storage.Models
{
    public partial class StoragePrivateLinkServiceConnectionState : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Status))
            {
                writer.WritePropertyName("status"u8);
                writer.WriteStringValue(Status.Value.ToString());
            }
            if (Optional.IsDefined(Description))
            {
                writer.WritePropertyName("description"u8);
                writer.WriteStringValue(Description);
            }
            if (Optional.IsDefined(ActionRequired))
            {
                writer.WritePropertyName("actionRequired"u8);
                writer.WriteStringValue(ActionRequired);
            }
            writer.WriteEndObject();
        }

        internal static StoragePrivateLinkServiceConnectionState DeserializeStoragePrivateLinkServiceConnectionState(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<StoragePrivateEndpointServiceConnectionStatus> status = default;
            Optional<string> description = default;
            Optional<string> actionRequired = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("status"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    status = new StoragePrivateEndpointServiceConnectionStatus(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("description"u8))
                {
                    description = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("actionRequired"u8))
                {
                    actionRequired = property.Value.GetString();
                    continue;
                }
            }
            return new StoragePrivateLinkServiceConnectionState(Optional.ToNullable(status), description.Value, actionRequired.Value);
        }
    }
}
