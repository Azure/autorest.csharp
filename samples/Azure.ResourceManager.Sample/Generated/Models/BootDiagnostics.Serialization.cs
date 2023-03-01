// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Sample.Models
{
    public partial class BootDiagnostics : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Enabled))
            {
                writer.WritePropertyName("enabled"u8);
                writer.WriteBooleanValue(Enabled.Value);
            }
            if (Optional.IsDefined(StorageUri))
            {
                writer.WritePropertyName("storageUri"u8);
                writer.WriteStringValue(StorageUri.AbsoluteUri);
            }
            writer.WriteEndObject();
        }

        internal static BootDiagnostics DeserializeBootDiagnostics(JsonElement element)
        {
            Optional<bool> enabled = default;
            Optional<Uri> storageUri = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("enabled"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    enabled = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("storageUri"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    storageUri = new Uri(property.Value.GetString());
                    continue;
                }
            }
            return new BootDiagnostics(Optional.ToNullable(enabled), storageUri.Value);
        }
    }
}
