// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using SingletonResource;

namespace SingletonResource.Models
{
    internal partial class ParentResourceListResult
    {
        internal static ParentResourceListResult DeserializeParentResourceListResult(JsonElement element)
        {
            IReadOnlyList<ParentResourceData> value = default;
            Optional<string> nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    List<ParentResourceData> array = new List<ParentResourceData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(ParentResourceData.DeserializeParentResourceData(item));
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
            return new ParentResourceListResult(value, nextLink.Value);
        }
    }
}
