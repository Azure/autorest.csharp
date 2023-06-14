// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace MgmtRenameRules.Models
{
    public partial class DataDisk : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("lun"u8);
            writer.WriteNumberValue(Lun);
            if (Optional.IsDefined(Name))
            {
                writer.WritePropertyName("name"u8);
                writer.WriteStringValue(Name);
            }
            if (Optional.IsDefined(Vhd))
            {
                writer.WritePropertyName("vhd"u8);
                writer.WriteObjectValue(Vhd);
            }
            if (Optional.IsDefined(Image))
            {
                writer.WritePropertyName("image"u8);
                writer.WriteObjectValue(Image);
            }
            if (Optional.IsDefined(Caching))
            {
                writer.WritePropertyName("caching"u8);
                writer.WriteStringValue(Caching.Value.ToSerialString());
            }
            if (Optional.IsDefined(WriteAcceleratorEnabled))
            {
                writer.WritePropertyName("writeAcceleratorEnabled"u8);
                writer.WriteBooleanValue(WriteAcceleratorEnabled.Value);
            }
            writer.WritePropertyName("createOption"u8);
            writer.WriteStringValue(CreateOption.ToString());
            if (Optional.IsDefined(DiskSizeGB))
            {
                writer.WritePropertyName("diskSizeGB"u8);
                writer.WriteNumberValue(DiskSizeGB.Value);
            }
            if (Optional.IsDefined(ManagedDisk))
            {
                writer.WritePropertyName("managedDisk"u8);
                writer.WriteObjectValue(ManagedDisk);
            }
            if (Optional.IsDefined(ToBeDetached))
            {
                writer.WritePropertyName("toBeDetached"u8);
                writer.WriteBooleanValue(ToBeDetached.Value);
            }
            writer.WriteEndObject();
        }

        internal static DataDisk DeserializeDataDisk(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            int lun = default;
            Optional<string> name = default;
            Optional<VirtualHardDisk> vhd = default;
            Optional<VirtualHardDisk> image = default;
            Optional<CachingType> caching = default;
            Optional<bool> writeAcceleratorEnabled = default;
            DiskCreateOptionType createOption = default;
            Optional<int> diskSizeGB = default;
            Optional<ManagedDiskParameters> managedDisk = default;
            Optional<bool> toBeDetached = default;
            Optional<long> diskIOPSReadWrite = default;
            Optional<long> diskMBpsReadWrite = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("lun"u8))
                {
                    lun = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("vhd"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    vhd = VirtualHardDisk.DeserializeVirtualHardDisk(property.Value);
                    continue;
                }
                if (property.NameEquals("image"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    image = VirtualHardDisk.DeserializeVirtualHardDisk(property.Value);
                    continue;
                }
                if (property.NameEquals("caching"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    caching = property.Value.GetString().ToCachingType();
                    continue;
                }
                if (property.NameEquals("writeAcceleratorEnabled"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    writeAcceleratorEnabled = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("createOption"u8))
                {
                    createOption = new DiskCreateOptionType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("diskSizeGB"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    diskSizeGB = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("managedDisk"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    managedDisk = ManagedDiskParameters.DeserializeManagedDiskParameters(property.Value);
                    continue;
                }
                if (property.NameEquals("toBeDetached"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    toBeDetached = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("diskIOPSReadWrite"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    diskIOPSReadWrite = property.Value.GetInt64();
                    continue;
                }
                if (property.NameEquals("diskMBpsReadWrite"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    diskMBpsReadWrite = property.Value.GetInt64();
                    continue;
                }
            }
            return new DataDisk(lun, name.Value, vhd.Value, image.Value, Optional.ToNullable(caching), Optional.ToNullable(writeAcceleratorEnabled), createOption, Optional.ToNullable(diskSizeGB), managedDisk.Value, Optional.ToNullable(toBeDetached), Optional.ToNullable(diskIOPSReadWrite), Optional.ToNullable(diskMBpsReadWrite));
        }
    }
}
