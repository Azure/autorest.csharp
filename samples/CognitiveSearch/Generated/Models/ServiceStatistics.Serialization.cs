// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace CognitiveSearch.Models
{
    public partial class ServiceStatistics
    {
        internal static ServiceStatistics DeserializeServiceStatistics(JsonElement element, SerializableOptions options = default)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            ServiceCounters counters = default;
            ServiceLimits limits = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("counters"u8))
                {
                    counters = ServiceCounters.DeserializeServiceCounters(property.Value);
                    continue;
                }
                if (property.NameEquals("limits"u8))
                {
                    limits = ServiceLimits.DeserializeServiceLimits(property.Value);
                    continue;
                }
            }
            return new ServiceStatistics(counters, limits);
        }
    }
}
