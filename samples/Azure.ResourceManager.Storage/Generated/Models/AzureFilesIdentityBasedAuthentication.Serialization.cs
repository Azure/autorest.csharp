// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Storage.Models
{
    public partial class AzureFilesIdentityBasedAuthentication : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("directoryServiceOptions"u8);
            writer.WriteStringValue(DirectoryServiceOptions.ToString());
            if (Optional.IsDefined(ActiveDirectoryProperties))
            {
                writer.WritePropertyName("activeDirectoryProperties"u8);
                writer.WriteObjectValue(ActiveDirectoryProperties);
            }
            if (Optional.IsDefined(DefaultSharePermission))
            {
                writer.WritePropertyName("defaultSharePermission"u8);
                writer.WriteStringValue(DefaultSharePermission.Value.ToString());
            }
            writer.WriteEndObject();
        }

        internal static AzureFilesIdentityBasedAuthentication DeserializeAzureFilesIdentityBasedAuthentication(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            DirectoryServiceOption directoryServiceOptions = default;
            Optional<ActiveDirectoryProperties> activeDirectoryProperties = default;
            Optional<DefaultSharePermission> defaultSharePermission = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("directoryServiceOptions"u8))
                {
                    directoryServiceOptions = new DirectoryServiceOption(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("activeDirectoryProperties"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    activeDirectoryProperties = ActiveDirectoryProperties.DeserializeActiveDirectoryProperties(property.Value);
                    continue;
                }
                if (property.NameEquals("defaultSharePermission"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    defaultSharePermission = new DefaultSharePermission(property.Value.GetString());
                    continue;
                }
            }
            return new AzureFilesIdentityBasedAuthentication(directoryServiceOptions, activeDirectoryProperties.Value, Optional.ToNullable(defaultSharePermission));
        }
    }
}
