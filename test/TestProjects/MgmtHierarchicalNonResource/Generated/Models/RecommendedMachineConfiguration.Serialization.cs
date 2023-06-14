// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace MgmtHierarchicalNonResource.Models
{
    public partial class RecommendedMachineConfiguration
    {
        internal static RecommendedMachineConfiguration DeserializeRecommendedMachineConfiguration(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<ResourceRange> vCpus = default;
            Optional<ResourceRange> memory = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("vCPUs"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    vCpus = ResourceRange.DeserializeResourceRange(property.Value);
                    continue;
                }
                if (property.NameEquals("memory"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    memory = ResourceRange.DeserializeResourceRange(property.Value);
                    continue;
                }
            }
            return new RecommendedMachineConfiguration(vCpus.Value, memory.Value);
        }
    }
}
