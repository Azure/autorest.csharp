// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;

namespace Azure.ResourceManager.Storage.Models
{
    public partial class LeaseContainerResponse
    {
        internal static LeaseContainerResponse DeserializeLeaseContainerResponse(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string leaseId = default;
            string leaseTimeSeconds = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("leaseId"u8))
                {
                    leaseId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("leaseTimeSeconds"u8))
                {
                    leaseTimeSeconds = property.Value.GetString();
                    continue;
                }
            }
            return new LeaseContainerResponse(leaseId, leaseTimeSeconds);
        }
    }
}
