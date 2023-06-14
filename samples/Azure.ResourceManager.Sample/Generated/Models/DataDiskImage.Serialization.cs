// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Sample.Models
{
    public partial class DataDiskImage : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WriteEndObject();
        }

        internal static DataDiskImage DeserializeDataDiskImage(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<int> lun = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("lun"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    lun = property.Value.GetInt32();
                    continue;
                }
            }
            return new DataDiskImage(Optional.ToNullable(lun));
        }
    }
}
