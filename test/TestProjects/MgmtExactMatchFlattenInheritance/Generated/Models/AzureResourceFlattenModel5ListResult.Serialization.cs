// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using MgmtExactMatchFlattenInheritance;

namespace MgmtExactMatchFlattenInheritance.Models
{
    internal partial class AzureResourceFlattenModel5ListResult
    {
        internal static AzureResourceFlattenModel5ListResult DeserializeAzureResourceFlattenModel5ListResult(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IReadOnlyList<AzureResourceFlattenModel5> value = default;
            string nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<AzureResourceFlattenModel5> array = new List<AzureResourceFlattenModel5>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(AzureResourceFlattenModel5.DeserializeAzureResourceFlattenModel5(item));
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
            return new AzureResourceFlattenModel5ListResult(value ?? new ChangeTrackingList<AzureResourceFlattenModel5>(), nextLink);
        }
    }
}
