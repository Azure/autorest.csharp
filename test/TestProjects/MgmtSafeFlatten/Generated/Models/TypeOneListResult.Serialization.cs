// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using MgmtSafeFlatten;

namespace MgmtSafeFlatten.Models
{
    internal partial class TypeOneListResult
    {
        internal static TypeOneListResult DeserializeTypeOneListResult(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IReadOnlyList<TypeOneData> value = default;
            Optional<string> nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    List<TypeOneData> array = new List<TypeOneData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(TypeOneData.DeserializeTypeOneData(item));
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
            return new TypeOneListResult(value, nextLink.Value);
        }
    }
}
