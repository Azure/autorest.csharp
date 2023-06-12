// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace Azure.ResourceManager.Sample.Models
{
    public partial class DataDiskImage : IUtf8JsonSerializable, IModelSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelSerializable)this).Serialize(writer, new SerializableOptions());

        void IModelSerializable.Serialize(Utf8JsonWriter writer, SerializableOptions options)
        {
            writer.WriteStartObject();
            writer.WriteEndObject();
        }

        internal static DataDiskImage DeserializeDataDiskImage(JsonElement element, SerializableOptions options = default)
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
