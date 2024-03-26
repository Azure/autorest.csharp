// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;

namespace AzureSample.ResourceManager.Storage.Models
{
    internal partial class AzureSampleResourceManagerStoragePrivateEndpointConnectionListResult
    {
        internal static AzureSampleResourceManagerStoragePrivateEndpointConnectionListResult DeserializeAzureSampleResourceManagerStoragePrivateEndpointConnectionListResult(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IReadOnlyList<AzureSampleResourceManagerStoragePrivateEndpointConnectionData> value = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<AzureSampleResourceManagerStoragePrivateEndpointConnectionData> array = new List<AzureSampleResourceManagerStoragePrivateEndpointConnectionData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(AzureSampleResourceManagerStoragePrivateEndpointConnectionData.DeserializeAzureSampleResourceManagerStoragePrivateEndpointConnectionData(item));
                    }
                    value = array;
                    continue;
                }
            }
            return new AzureSampleResourceManagerStoragePrivateEndpointConnectionListResult(value ?? new ChangeTrackingList<AzureSampleResourceManagerStoragePrivateEndpointConnectionData>());
        }
    }
}
