// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace MgmtListMethods.Models
{
    internal partial class ResGrpParentWithAncestorWithNonResChListResult
    {
        internal static ResGrpParentWithAncestorWithNonResChListResult DeserializeResGrpParentWithAncestorWithNonResChListResult(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IReadOnlyList<ResGrpParentWithAncestorWithNonResChData> value = default;
            Optional<string> nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    List<ResGrpParentWithAncestorWithNonResChData> array = new List<ResGrpParentWithAncestorWithNonResChData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(ResGrpParentWithAncestorWithNonResChData.DeserializeResGrpParentWithAncestorWithNonResChData(item));
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
            return new ResGrpParentWithAncestorWithNonResChListResult(value, nextLink.Value);
        }
    }
}
