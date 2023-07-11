// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace MgmtListMethods.Models
{
    internal partial class TenantTestListResult
    {
        internal static TenantTestListResult DeserializeTenantTestListResult(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IReadOnlyList<TenantTestData> value = default;
            Optional<string> nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    List<TenantTestData> array = new List<TenantTestData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(TenantTestData.DeserializeTenantTestData(item));
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
            return new TenantTestListResult(value, nextLink.Value);
        }
    }
}
