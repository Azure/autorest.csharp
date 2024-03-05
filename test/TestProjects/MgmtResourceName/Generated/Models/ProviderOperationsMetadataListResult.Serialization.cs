// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using MgmtResourceName;

namespace MgmtResourceName.Models
{
    internal partial class ProviderOperationsMetadataListResult
    {
        internal static ProviderOperationsMetadataListResult DeserializeProviderOperationsMetadataListResult(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IReadOnlyList<ProviderOperationData> value = default;
            string nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<ProviderOperationData> array = new List<ProviderOperationData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(ProviderOperationData.DeserializeProviderOperationData(item));
                    }
                    value = array;
                    continue;
                }
                if (property.NameEquals("nextLink"u8))
                {
                    nextLink = property.Value.GetString();
                    continue;
                }
            }
            return new ProviderOperationsMetadataListResult(value ?? new ChangeTrackingList<ProviderOperationData>(), nextLink);
        }
    }
}
