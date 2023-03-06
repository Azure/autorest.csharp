// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.Management.Storage.Models
{
    public partial class LeaseContainerResponse
    {
        internal static LeaseContainerResponse DeserializeLeaseContainerResponse(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> leaseId = default;
            Optional<string> leaseTimeSeconds = default;
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
            return new LeaseContainerResponse(leaseId.Value, leaseTimeSeconds.Value);
        }
    }
}
