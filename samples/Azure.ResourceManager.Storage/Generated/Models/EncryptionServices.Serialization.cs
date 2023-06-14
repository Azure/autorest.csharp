// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Storage.Models
{
    public partial class EncryptionServices : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Blob))
            {
                writer.WritePropertyName("blob"u8);
                writer.WriteObjectValue(Blob);
            }
            if (Optional.IsDefined(File))
            {
                writer.WritePropertyName("file"u8);
                writer.WriteObjectValue(File);
            }
            if (Optional.IsDefined(Table))
            {
                writer.WritePropertyName("table"u8);
                writer.WriteObjectValue(Table);
            }
            if (Optional.IsDefined(Queue))
            {
                writer.WritePropertyName("queue"u8);
                writer.WriteObjectValue(Queue);
            }
            writer.WriteEndObject();
        }

        internal static EncryptionServices DeserializeEncryptionServices(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<EncryptionService> blob = default;
            Optional<EncryptionService> file = default;
            Optional<EncryptionService> table = default;
            Optional<EncryptionService> queue = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("blob"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    blob = EncryptionService.DeserializeEncryptionService(property.Value);
                    continue;
                }
                if (property.NameEquals("file"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    file = EncryptionService.DeserializeEncryptionService(property.Value);
                    continue;
                }
                if (property.NameEquals("table"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    table = EncryptionService.DeserializeEncryptionService(property.Value);
                    continue;
                }
                if (property.NameEquals("queue"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    queue = EncryptionService.DeserializeEncryptionService(property.Value);
                    continue;
                }
            }
            return new EncryptionServices(blob.Value, file.Value, table.Value, queue.Value);
        }
    }
}
