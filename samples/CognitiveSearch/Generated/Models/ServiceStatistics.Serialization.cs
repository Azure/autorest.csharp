// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace CognitiveSearch.Models
{
    public partial class ServiceStatistics
    {
        internal static ServiceStatistics DeserializeServiceStatistics(JsonElement element)
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
