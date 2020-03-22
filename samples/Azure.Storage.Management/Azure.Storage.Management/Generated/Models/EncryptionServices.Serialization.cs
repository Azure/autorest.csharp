// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.Storage.Management.Models
{
    public partial class EncryptionServices : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Blob != null)
            {
                writer.WritePropertyName("blob");
                writer.WriteObjectValue(Blob);
            }
            if (File != null)
            {
                writer.WritePropertyName("file");
                writer.WriteObjectValue(File);
            }
            if (Table != null)
            {
                writer.WritePropertyName("table");
                writer.WriteObjectValue(Table);
            }
            if (Queue != null)
            {
                writer.WritePropertyName("queue");
                writer.WriteObjectValue(Queue);
            }
            writer.WriteEndObject();
        }

        internal static EncryptionServices DeserializeEncryptionServices(JsonElement element)
        {
            EncryptionService blob = default;
            EncryptionService file = default;
            EncryptionService table = default;
            EncryptionService queue = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("blob"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    blob = EncryptionService.DeserializeEncryptionService(property.Value);
                    continue;
                }
                if (property.NameEquals("file"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    file = EncryptionService.DeserializeEncryptionService(property.Value);
                    continue;
                }
                if (property.NameEquals("table"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    table = EncryptionService.DeserializeEncryptionService(property.Value);
                    continue;
                }
                if (property.NameEquals("queue"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    queue = EncryptionService.DeserializeEncryptionService(property.Value);
                    continue;
                }
            }
            return new EncryptionServices(blob, file, table, queue);
        }
    }
}
