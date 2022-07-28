// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using MgmtResourceName;

namespace MgmtResourceName.Models
{
    internal partial class ProviderOperationsMetadataListResult
    {
        internal static ProviderOperationsMetadataListResult DeserializeProviderOperationsMetadataListResult(JsonElement element)
        {
            Optional<IReadOnlyList<ProviderOperationData>> value = default;
            Optional<string> nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
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
                if (property.NameEquals("nextLink"))
                {
                    nextLink = property.Value.GetString();
                    continue;
                }
            }
            return new ProviderOperationsMetadataListResult(Optional.ToList(value), nextLink.Value);
        }
    }
}
