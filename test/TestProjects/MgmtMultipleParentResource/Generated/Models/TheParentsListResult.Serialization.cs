// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using MgmtMultipleParentResource;

namespace MgmtMultipleParentResource.Models
{
    internal partial class TheParentsListResult
    {
        internal static TheParentsListResult DeserializeTheParentsListResult(JsonElement element)
        {
            IReadOnlyList<TheParentResourceData> value = default;
            Optional<string> nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"))
                {
                    List<TheParentResourceData> array = new List<TheParentResourceData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(TheParentResourceData.DeserializeTheParentResourceData(item));
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
            return new TheParentsListResult(value, nextLink.Value);
        }
    }
}
