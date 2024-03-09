// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using MgmtSupersetFlattenInheritance;

namespace MgmtSupersetFlattenInheritance.Models
{
    internal partial class TrackedResourceModel1ListResult
    {
        internal static TrackedResourceModel1ListResult DeserializeTrackedResourceModel1ListResult(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IReadOnlyList<TrackedResourceModel1Data> value = default;
            string nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<TrackedResourceModel1Data> array = new List<TrackedResourceModel1Data>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(TrackedResourceModel1Data.DeserializeTrackedResourceModel1Data(item));
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
            return new TrackedResourceModel1ListResult(value ?? new ChangeTrackingList<TrackedResourceModel1Data>(), nextLink);
        }
    }
}
