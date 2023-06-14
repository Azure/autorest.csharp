// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using MgmtListMethods;

namespace MgmtListMethods.Models
{
    internal partial class MgmtGrpParentWithNonResChWithLocListResult
    {
        internal static MgmtGrpParentWithNonResChWithLocListResult DeserializeMgmtGrpParentWithNonResChWithLocListResult(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IReadOnlyList<MgmtGrpParentWithNonResChWithLocData> value = default;
            Optional<string> nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    List<MgmtGrpParentWithNonResChWithLocData> array = new List<MgmtGrpParentWithNonResChWithLocData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(MgmtGrpParentWithNonResChWithLocData.DeserializeMgmtGrpParentWithNonResChWithLocData(item));
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
            return new MgmtGrpParentWithNonResChWithLocListResult(value, nextLink.Value);
        }
    }
}
