// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Storage.Models
{
    public partial class BlobInventoryPolicyRule : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("enabled"u8);
            writer.WriteBooleanValue(Enabled);
            writer.WritePropertyName("name"u8);
            writer.WriteStringValue(Name);
            writer.WritePropertyName("destination"u8);
            writer.WriteStringValue(Destination);
            writer.WritePropertyName("definition"u8);
            writer.WriteObjectValue(Definition);
            writer.WriteEndObject();
        }

        internal static BlobInventoryPolicyRule DeserializeBlobInventoryPolicyRule(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            bool enabled = default;
            string name = default;
            string destination = default;
            BlobInventoryPolicyDefinition definition = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("enabled"u8))
                {
                    enabled = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("destination"u8))
                {
                    destination = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("definition"u8))
                {
                    definition = BlobInventoryPolicyDefinition.DeserializeBlobInventoryPolicyDefinition(property.Value);
                    continue;
                }
            }
            return new BlobInventoryPolicyRule(enabled, name, destination, definition);
        }
    }
}
