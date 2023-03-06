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
    internal partial class SupersetModel7ListResult
    {
        internal static SupersetModel7ListResult DeserializeSupersetModel7ListResult(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IReadOnlyList<SupersetModel7Data>> value = default;
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
                    List<SupersetModel7Data> array = new List<SupersetModel7Data>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(SupersetModel7Data.DeserializeSupersetModel7Data(item));
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
            return new SupersetModel7ListResult(Optional.ToList(value), nextLink.Value);
        }
    }
}
