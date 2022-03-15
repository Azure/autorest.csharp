// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using SupersetFlattenInheritance;

namespace SupersetFlattenInheritance.Models
{
    internal partial class ResourceModel1ListResult
    {
        internal static ResourceModel1ListResult DeserializeResourceModel1ListResult(JsonElement element)
        {
            Optional<IReadOnlyList<ResourceModel1ResourceData>> value = default;
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
                    List<ResourceModel1ResourceData> array = new List<ResourceModel1ResourceData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(ResourceModel1ResourceData.DeserializeResourceModel1ResourceData(item));
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
            return new ResourceModel1ListResult(Optional.ToList(value), nextLink.Value);
        }
    }
}
