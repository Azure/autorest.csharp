// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace MgmtRenameRules.Models
{
    public partial class VirtualMachineSize
    {
        internal static VirtualMachineSize DeserializeVirtualMachineSize(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> name = default;
            Optional<int> numberOfCores = default;
            Optional<int> osDiskSizeInMB = default;
            Optional<int> resourceDiskSizeInMB = default;
            Optional<int> memoryInMB = default;
            Optional<int> maxDataDiskCount = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("numberOfCores"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    numberOfCores = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("osDiskSizeInMB"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    osDiskSizeInMB = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("resourceDiskSizeInMB"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    resourceDiskSizeInMB = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("memoryInMB"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    memoryInMB = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("maxDataDiskCount"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    maxDataDiskCount = property.Value.GetInt32();
                    continue;
                }
            }
            return new VirtualMachineSize(name.Value, Optional.ToNullable(numberOfCores), Optional.ToNullable(osDiskSizeInMB), Optional.ToNullable(resourceDiskSizeInMB), Optional.ToNullable(memoryInMB), Optional.ToNullable(maxDataDiskCount));
        }
    }
}
