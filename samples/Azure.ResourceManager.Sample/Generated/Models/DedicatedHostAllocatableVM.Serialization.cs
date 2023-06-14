// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Sample.Models
{
    public partial class DedicatedHostAllocatableVM
    {
        internal static DedicatedHostAllocatableVM DeserializeDedicatedHostAllocatableVM(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> vmSize = default;
            Optional<double> count = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("vmSize"u8))
                {
                    vmSize = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("count"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    count = property.Value.GetDouble();
                    continue;
                }
            }
            return new DedicatedHostAllocatableVM(vmSize.Value, Optional.ToNullable(count));
        }
    }
}
