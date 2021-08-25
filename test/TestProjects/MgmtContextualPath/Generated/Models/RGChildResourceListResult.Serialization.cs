// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using MgmtContextualPath;

namespace MgmtContextualPath.Models
{
    internal partial class RGChildResourceListResult
    {
        internal static RGChildResourceListResult DeserializeRGChildResourceListResult(JsonElement element)
        {
            IReadOnlyList<RGChildResourceData> value = default;
            Optional<string> nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"))
                {
                    List<RGChildResourceData> array = new List<RGChildResourceData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(RGChildResourceData.DeserializeRGChildResourceData(item));
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
            return new RGChildResourceListResult(value, nextLink.Value);
        }
    }
}
