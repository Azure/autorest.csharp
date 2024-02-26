// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace MgmtAcronymMapping.Models
{
    public partial class OSDisk : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (OSType.HasValue)
            {
                writer.WritePropertyName("osType"u8);
                writer.WriteStringValue(OSType.Value.ToSerialString());
            }
            if (EncryptionSettings != null)
            {
                writer.WritePropertyName("encryptionSettings"u8);
                writer.WriteObjectValue(EncryptionSettings);
            }
            if (Name != null)
            {
                writer.WritePropertyName("name"u8);
                writer.WriteStringValue(Name);
            }
            if (Vhd != null)
            {
                writer.WritePropertyName("vhd"u8);
                writer.WriteObjectValue(Vhd);
            }
            if (Image != null)
            {
                writer.WritePropertyName("image"u8);
                writer.WriteObjectValue(Image);
            }
            if (Caching.HasValue)
            {
                writer.WritePropertyName("caching"u8);
                writer.WriteStringValue(Caching.Value.ToSerialString());
            }
            if (WriteAcceleratorEnabled.HasValue)
            {
                writer.WritePropertyName("writeAcceleratorEnabled"u8);
                writer.WriteBooleanValue(WriteAcceleratorEnabled.Value);
            }
            if (DiffDiskSettings != null)
            {
                writer.WritePropertyName("diffDiskSettings"u8);
                writer.WriteObjectValue(DiffDiskSettings);
            }
            writer.WritePropertyName("createOption"u8);
            writer.WriteStringValue(CreateOption.ToString());
            if (DiskSizeGB.HasValue)
            {
                writer.WritePropertyName("diskSizeGB"u8);
                writer.WriteNumberValue(DiskSizeGB.Value);
            }
            if (ManagedDisk != null)
            {
                writer.WritePropertyName("managedDisk"u8);
                writer.WriteObjectValue(ManagedDisk);
            }
            writer.WriteEndObject();
        }

        internal static OSDisk DeserializeOSDisk(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            OperatingSystemType osType = default;
            DiskEncryptionSettings encryptionSettings = default;
            string name = default;
            VirtualHardDisk vhd = default;
            VirtualHardDisk image = default;
            CachingType caching = default;
            bool writeAcceleratorEnabled = default;
            DiffDiskSettings diffDiskSettings = default;
            DiskCreateOptionType createOption = default;
            int diskSizeGB = default;
            ManagedDiskParameters managedDisk = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("osType"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    osType = property.Value.GetString().ToOperatingSystemType();
                    continue;
                }
                if (property.NameEquals("encryptionSettings"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    encryptionSettings = DiskEncryptionSettings.DeserializeDiskEncryptionSettings(property.Value);
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
                if (property.NameEquals("diffDiskSettings"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    diffDiskSettings = DiffDiskSettings.DeserializeDiffDiskSettings(property.Value);
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
            }
            return new OSDisk(
                osType,
                encryptionSettings,
                name,
                vhd,
                image,
                caching,
                writeAcceleratorEnabled,
                diffDiskSettings,
                createOption,
                diskSizeGB,
                managedDisk);
        }
    }
}
