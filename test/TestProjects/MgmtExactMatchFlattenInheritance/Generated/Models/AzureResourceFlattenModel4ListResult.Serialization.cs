// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace MgmtExactMatchFlattenInheritance.Models
{
    internal partial class AzureResourceFlattenModel4ListResult
    {
        internal static AzureResourceFlattenModel4ListResult DeserializeAzureResourceFlattenModel4ListResult(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IReadOnlyList<AzureResourceFlattenModel4>> value = default;
            Optional<string> nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<AzureResourceFlattenModel4> array = new List<AzureResourceFlattenModel4>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(AzureResourceFlattenModel4.DeserializeAzureResourceFlattenModel4(item));
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
            return new AzureResourceFlattenModel4ListResult(Optional.ToList(value), nextLink.Value);
        }
    }
}
