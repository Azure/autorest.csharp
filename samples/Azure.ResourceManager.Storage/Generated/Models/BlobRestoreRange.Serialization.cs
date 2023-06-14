// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Storage.Models
{
    public partial class BlobRestoreRange : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("startRange"u8);
            writer.WriteStringValue(StartRange);
            writer.WritePropertyName("endRange"u8);
            writer.WriteStringValue(EndRange);
            writer.WriteEndObject();
        }

        internal static BlobRestoreRange DeserializeBlobRestoreRange(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string startRange = default;
            string endRange = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("startRange"u8))
                {
                    startRange = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("endRange"u8))
                {
                    endRange = property.Value.GetString();
                    continue;
                }
            }
            return new BlobRestoreRange(startRange, endRange);
        }
    }
}
