// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace MgmtListMethods.Models
{
    internal partial class ResGrpParentWithAncestorWithLocListResult
    {
        internal static ResGrpParentWithAncestorWithLocListResult DeserializeResGrpParentWithAncestorWithLocListResult(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IReadOnlyList<ResGrpParentWithAncestorWithLocData> value = default;
            Optional<string> nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    List<ResGrpParentWithAncestorWithLocData> array = new List<ResGrpParentWithAncestorWithLocData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(ResGrpParentWithAncestorWithLocData.DeserializeResGrpParentWithAncestorWithLocData(item));
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
            return new ResGrpParentWithAncestorWithLocListResult(value, nextLink.Value);
        }
    }
}
