// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace CognitiveSearch.Models
{
    public partial class ServiceStatistics
    {
        internal static ServiceStatistics DeserializeServiceStatistics(JsonElement element)
        {
            ServiceCounters counters = default;
            ServiceLimits limits = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("counters"))
                {
                    counters = ServiceCounters.DeserializeServiceCounters(property.Value);
                    continue;
                }
                if (property.NameEquals("limits"))
                {
                    limits = ServiceLimits.DeserializeServiceLimits(property.Value);
                    continue;
                }
            }
            return new ServiceStatistics(counters, limits);
        }
    }
}
