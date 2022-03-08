// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using SupersetInheritance;

namespace SupersetInheritance.Models
{
    internal partial class SupersetModel4ListResult
    {
        internal static SupersetModel4ListResult DeserializeSupersetModel4ListResult(JsonElement element)
        {
            Optional<IReadOnlyList<SupersetModel4Data>> value = default;
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
                    List<SupersetModel4Data> array = new List<SupersetModel4Data>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(SupersetModel4Data.DeserializeSupersetModel4Data(item));
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
            return new SupersetModel4ListResult(Optional.ToList(value), nextLink.Value);
        }
    }
}
