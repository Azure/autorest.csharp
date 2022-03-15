// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using MgmtListMethods;

namespace MgmtListMethods.Models
{
    internal partial class TenantParentWithLocListResult
    {
        internal static TenantParentWithLocListResult DeserializeTenantParentWithLocListResult(JsonElement element)
        {
            IReadOnlyList<TenantParentWithLocResourceData> value = default;
            Optional<string> nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"))
                {
                    List<TenantParentWithLocResourceData> array = new List<TenantParentWithLocResourceData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(TenantParentWithLocResourceData.DeserializeTenantParentWithLocResourceData(item));
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
            return new TenantParentWithLocListResult(value, nextLink.Value);
        }
    }
}
