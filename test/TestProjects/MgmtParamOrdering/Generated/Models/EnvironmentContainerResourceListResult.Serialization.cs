// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using MgmtParamOrdering;

namespace MgmtParamOrdering.Models
{
    internal partial class EnvironmentContainerResourceListResult
    {
        internal static EnvironmentContainerResourceListResult DeserializeEnvironmentContainerResourceListResult(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IReadOnlyList<EnvironmentContainerResourceData> value = default;
            Optional<string> nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    List<EnvironmentContainerResourceData> array = new List<EnvironmentContainerResourceData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(EnvironmentContainerResourceData.DeserializeEnvironmentContainerResourceData(item));
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
            return new EnvironmentContainerResourceListResult(value, nextLink.Value);
        }
    }
}
