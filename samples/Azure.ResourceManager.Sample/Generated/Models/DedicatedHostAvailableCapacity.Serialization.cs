// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Sample.Models
{
    internal partial class DedicatedHostAvailableCapacity
    {
        internal static DedicatedHostAvailableCapacity DeserializeDedicatedHostAvailableCapacity(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IReadOnlyList<DedicatedHostAllocatableVM>> allocatableVMs = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("allocatableVMs"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<DedicatedHostAllocatableVM> array = new List<DedicatedHostAllocatableVM>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(DedicatedHostAllocatableVM.DeserializeDedicatedHostAllocatableVM(item));
                    }
                    allocatableVMs = array;
                    continue;
                }
            }
            return new DedicatedHostAvailableCapacity(Optional.ToList(allocatableVMs));
        }
    }
}
