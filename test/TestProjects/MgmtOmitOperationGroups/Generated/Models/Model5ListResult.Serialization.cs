// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using MgmtOmitOperationGroups;

namespace MgmtOmitOperationGroups.Models
{
    internal partial class Model5ListResult
    {
        internal static Model5ListResult DeserializeModel5ListResult(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IReadOnlyList<Model5> value = default;
            string nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<Model5> array = new List<Model5>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(Model5.DeserializeModel5(item));
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
            return new Model5ListResult(value ?? new ChangeTrackingList<Model5>(), nextLink);
        }
    }
}
