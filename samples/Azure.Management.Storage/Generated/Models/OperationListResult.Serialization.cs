// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.Management.Storage.Models
{
    public partial class OperationListResult
    {
        internal static OperationListResult DeserializeOperationListResult(JsonElement element)
        {
            Optional<IReadOnlyList<OperationData>> value = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<OperationData> array = new List<OperationData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(OperationData.DeserializeOperationData(item));
                    }
                    value = array;
                    continue;
                }
            }
            return new OperationListResult(Optional.ToList(value));
        }
    }
}
