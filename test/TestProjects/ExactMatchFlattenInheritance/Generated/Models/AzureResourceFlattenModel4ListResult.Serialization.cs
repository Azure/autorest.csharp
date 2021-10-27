// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using ExactMatchFlattenInheritance;

namespace ExactMatchFlattenInheritance.Models
{
    public partial class AzureResourceFlattenModel4ListResult
    {
        internal static AzureResourceFlattenModel4ListResult DeserializeAzureResourceFlattenModel4ListResult(JsonElement element)
        {
            Optional<IReadOnlyList<AzureResourceFlattenModel4Data>> value = default;
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
                    List<AzureResourceFlattenModel4Data> array = new List<AzureResourceFlattenModel4Data>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(AzureResourceFlattenModel4Data.DeserializeAzureResourceFlattenModel4Data(item));
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
            return new AzureResourceFlattenModel4ListResult(Optional.ToList(value), nextLink.Value);
        }
    }
}
