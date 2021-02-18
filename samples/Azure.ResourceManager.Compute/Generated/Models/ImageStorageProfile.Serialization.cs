// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Compute
{
    public partial class ImageStorageProfile : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(OsDisk))
            {
                writer.WritePropertyName("osDisk");
                writer.WriteObjectValue(OsDisk);
            }
            if (Optional.IsCollectionDefined(DataDisks))
            {
                writer.WritePropertyName("dataDisks");
                writer.WriteStartArray();
                foreach (var item in DataDisks)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(ZoneResilient))
            {
                writer.WritePropertyName("zoneResilient");
                writer.WriteBooleanValue(ZoneResilient.Value);
            }
            writer.WriteEndObject();
        }

        internal static ImageStorageProfile DeserializeImageStorageProfile(JsonElement element)
        {
            Optional<ImageOSDisk> osDisk = default;
            Optional<IList<ImageDataDisk>> dataDisks = default;
            Optional<bool> zoneResilient = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("osDisk"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    osDisk = ImageOSDisk.DeserializeImageOSDisk(property.Value);
                    continue;
                }
                if (property.NameEquals("dataDisks"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<ImageDataDisk> array = new List<ImageDataDisk>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(ImageDataDisk.DeserializeImageDataDisk(item));
                    }
                    dataDisks = array;
                    continue;
                }
                if (property.NameEquals("zoneResilient"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    zoneResilient = property.Value.GetBoolean();
                    continue;
                }
            }
            return new ImageStorageProfile(osDisk.Value, Optional.ToList(dataDisks), Optional.ToNullable(zoneResilient));
        }
    }
}
