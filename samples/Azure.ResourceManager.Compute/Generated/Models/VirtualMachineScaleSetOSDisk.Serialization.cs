// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Compute
{
    public partial class VirtualMachineScaleSetOSDisk : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Name))
            {
                writer.WritePropertyName("name");
                writer.WriteStringValue(Name);
            }
            if (Optional.IsDefined(Caching))
            {
                writer.WritePropertyName("caching");
                writer.WriteStringValue(Caching.Value.ToSerialString());
            }
            if (Optional.IsDefined(WriteAcceleratorEnabled))
            {
                writer.WritePropertyName("writeAcceleratorEnabled");
                writer.WriteBooleanValue(WriteAcceleratorEnabled.Value);
            }
            writer.WritePropertyName("createOption");
            writer.WriteStringValue(CreateOption.ToString());
            if (Optional.IsDefined(DiffDiskSettings))
            {
                writer.WritePropertyName("diffDiskSettings");
                writer.WriteObjectValue(DiffDiskSettings);
            }
            if (Optional.IsDefined(DiskSizeGB))
            {
                writer.WritePropertyName("diskSizeGB");
                writer.WriteNumberValue(DiskSizeGB.Value);
            }
            if (Optional.IsDefined(OsType))
            {
                writer.WritePropertyName("osType");
                writer.WriteStringValue(OsType.Value.ToSerialString());
            }
            if (Optional.IsDefined(Image))
            {
                writer.WritePropertyName("image");
                writer.WriteObjectValue(Image);
            }
            if (Optional.IsCollectionDefined(VhdContainers))
            {
                writer.WritePropertyName("vhdContainers");
                writer.WriteStartArray();
                foreach (var item in VhdContainers)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(ManagedDisk))
            {
                writer.WritePropertyName("managedDisk");
                writer.WriteObjectValue(ManagedDisk);
            }
            writer.WriteEndObject();
        }

        internal static VirtualMachineScaleSetOSDisk DeserializeVirtualMachineScaleSetOSDisk(JsonElement element)
        {
            Optional<string> name = default;
            Optional<CachingTypes> caching = default;
            Optional<bool> writeAcceleratorEnabled = default;
            DiskCreateOptionTypes createOption = default;
            Optional<DiffDiskSettings> diffDiskSettings = default;
            Optional<int> diskSizeGB = default;
            Optional<OperatingSystemTypes> osType = default;
            Optional<VirtualHardDisk> image = default;
            Optional<IList<string>> vhdContainers = default;
            Optional<VirtualMachineScaleSetManagedDiskParameters> managedDisk = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name"))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("caching"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    caching = property.Value.GetString().ToCachingTypes();
                    continue;
                }
                if (property.NameEquals("writeAcceleratorEnabled"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    writeAcceleratorEnabled = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("createOption"))
                {
                    createOption = new DiskCreateOptionTypes(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("diffDiskSettings"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    diffDiskSettings = DiffDiskSettings.DeserializeDiffDiskSettings(property.Value);
                    continue;
                }
                if (property.NameEquals("diskSizeGB"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    diskSizeGB = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("osType"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    osType = property.Value.GetString().ToOperatingSystemTypes();
                    continue;
                }
                if (property.NameEquals("image"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    image = VirtualHardDisk.DeserializeVirtualHardDisk(property.Value);
                    continue;
                }
                if (property.NameEquals("vhdContainers"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    vhdContainers = array;
                    continue;
                }
                if (property.NameEquals("managedDisk"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    managedDisk = VirtualMachineScaleSetManagedDiskParameters.DeserializeVirtualMachineScaleSetManagedDiskParameters(property.Value);
                    continue;
                }
            }
            return new VirtualMachineScaleSetOSDisk(name.Value, Optional.ToNullable(caching), Optional.ToNullable(writeAcceleratorEnabled), createOption, diffDiskSettings.Value, Optional.ToNullable(diskSizeGB), Optional.ToNullable(osType), image.Value, Optional.ToList(vhdContainers), managedDisk.Value);
        }
    }
}
