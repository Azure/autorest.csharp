// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using MgmtListMethods;

namespace MgmtListMethods.Models
{
    internal partial class ResGrpParentListResult
    {
        internal static ResGrpParentListResult DeserializeResGrpParentListResult(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IReadOnlyList<ResGrpParentData> value = default;
            Optional<string> nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    List<ResGrpParentData> array = new List<ResGrpParentData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(ResGrpParentData.DeserializeResGrpParentData(item));
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
            return new ResGrpParentListResult(value, nextLink.Value);
        }
    }
}
