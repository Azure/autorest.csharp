// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;

namespace MgmtSupersetFlattenInheritance.Models
{
    internal partial class SubResourceModel2ListResult
    {
        internal static SubResourceModel2ListResult DeserializeSubResourceModel2ListResult(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IReadOnlyList<SubResourceModel2> value = default;
            string nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<SubResourceModel2> array = new List<SubResourceModel2>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(SubResourceModel2.DeserializeSubResourceModel2(item));
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
            return new SubResourceModel2ListResult(value ?? new ChangeTrackingList<SubResourceModel2>(), nextLink);
        }
    }
}
