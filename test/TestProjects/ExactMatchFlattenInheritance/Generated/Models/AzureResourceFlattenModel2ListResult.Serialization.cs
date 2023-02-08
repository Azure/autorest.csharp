// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace ExactMatchFlattenInheritance.Models
{
    internal partial class AzureResourceFlattenModel2ListResult
    {
        internal static AzureResourceFlattenModel2ListResult DeserializeAzureResourceFlattenModel2ListResult(JsonElement element)
        {
            Optional<IReadOnlyList<AzureResourceFlattenModel2>> value = default;
            Optional<string> nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<AzureResourceFlattenModel2> array = new List<AzureResourceFlattenModel2>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(AzureResourceFlattenModel2.DeserializeAzureResourceFlattenModel2(item));
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
            return new AzureResourceFlattenModel2ListResult(Optional.ToList(value), nextLink.Value);
        }
    }
}
