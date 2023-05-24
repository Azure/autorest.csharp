// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace MgmtSupersetFlattenInheritance.Models
{
    internal partial class TrackedResourceModel2ListResult
    {
        internal static TrackedResourceModel2ListResult DeserializeTrackedResourceModel2ListResult(JsonElement element, SerializableOptions options = default)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IReadOnlyList<TrackedResourceModel2>> value = default;
            Optional<string> nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<TrackedResourceModel2> array = new List<TrackedResourceModel2>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(TrackedResourceModel2.DeserializeTrackedResourceModel2(item));
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
            return new TrackedResourceModel2ListResult(Optional.ToList(value), nextLink.Value);
        }
    }
}
