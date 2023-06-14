// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Sample.Models
{
    public partial class OrchestrationServiceSummary
    {
        internal static OrchestrationServiceSummary DeserializeOrchestrationServiceSummary(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<OrchestrationServiceName> serviceName = default;
            Optional<OrchestrationServiceState> serviceState = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("serviceName"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    serviceName = new OrchestrationServiceName(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("serviceState"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    serviceState = new OrchestrationServiceState(property.Value.GetString());
                    continue;
                }
            }
            return new OrchestrationServiceSummary(Optional.ToNullable(serviceName), Optional.ToNullable(serviceState));
        }
    }
}
