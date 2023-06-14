// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using MgmtMultipleParentResource;

namespace MgmtMultipleParentResource.Models
{
    internal partial class SubParentsListResult
    {
        internal static SubParentsListResult DeserializeSubParentsListResult(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IReadOnlyList<SubParentData> value = default;
            Optional<string> nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    List<SubParentData> array = new List<SubParentData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(SubParentData.DeserializeSubParentData(item));
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
            return new SubParentsListResult(value, nextLink.Value);
        }
    }
}
