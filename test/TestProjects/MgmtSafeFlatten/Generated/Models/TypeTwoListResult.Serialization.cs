// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using MgmtSafeFlatten;

namespace MgmtSafeFlatten.Models
{
    internal partial class TypeTwoListResult
    {
        internal static TypeTwoListResult DeserializeTypeTwoListResult(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IReadOnlyList<TypeTwoData> value = default;
            Optional<string> nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    List<TypeTwoData> array = new List<TypeTwoData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(TypeTwoData.DeserializeTypeTwoData(item));
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
            return new TypeTwoListResult(value, nextLink.Value);
        }
    }
}
