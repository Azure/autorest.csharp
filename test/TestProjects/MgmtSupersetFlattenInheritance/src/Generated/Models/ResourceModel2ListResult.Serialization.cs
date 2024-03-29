// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;

namespace MgmtSupersetFlattenInheritance.Models
{
    internal partial class ResourceModel2ListResult
    {
        internal static ResourceModel2ListResult DeserializeResourceModel2ListResult(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IReadOnlyList<ResourceModel2> value = default;
            string nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<ResourceModel2> array = new List<ResourceModel2>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(ResourceModel2.DeserializeResourceModel2(item));
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
            return new ResourceModel2ListResult(value ?? new ChangeTrackingList<ResourceModel2>(), nextLink);
        }
    }
}
