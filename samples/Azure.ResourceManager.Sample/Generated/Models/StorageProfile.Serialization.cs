// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Sample.Models
{
    public partial class StorageProfile : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(ImageReference))
            {
                writer.WritePropertyName("imageReference"u8);
                writer.WriteObjectValue(ImageReference);
            }
            if (Optional.IsDefined(OsDisk))
            {
                writer.WritePropertyName("osDisk"u8);
                writer.WriteObjectValue(OsDisk);
            }
            if (Optional.IsCollectionDefined(DataDisks))
            {
                writer.WritePropertyName("dataDisks"u8);
                writer.WriteStartArray();
                foreach (var item in DataDisks)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
        }

        internal static StorageProfile DeserializeStorageProfile(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<ImageReference> imageReference = default;
            Optional<OSDisk> osDisk = default;
            Optional<IList<DataDisk>> dataDisks = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("imageReference"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    imageReference = ImageReference.DeserializeImageReference(property.Value);
                    continue;
                }
                if (property.NameEquals("osDisk"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    osDisk = OSDisk.DeserializeOSDisk(property.Value);
                    continue;
                }
                if (property.NameEquals("dataDisks"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<DataDisk> array = new List<DataDisk>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(DataDisk.DeserializeDataDisk(item));
                    }
                    dataDisks = array;
                    continue;
                }
            }
            return new StorageProfile(imageReference.Value, osDisk.Value, Optional.ToList(dataDisks));
        }
    }
}
