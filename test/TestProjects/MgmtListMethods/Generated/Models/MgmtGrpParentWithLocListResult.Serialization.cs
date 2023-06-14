// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using MgmtListMethods;

namespace MgmtListMethods.Models
{
    internal partial class MgmtGrpParentWithLocListResult
    {
        internal static MgmtGrpParentWithLocListResult DeserializeMgmtGrpParentWithLocListResult(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IReadOnlyList<MgmtGrpParentWithLocData> value = default;
            Optional<string> nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    List<MgmtGrpParentWithLocData> array = new List<MgmtGrpParentWithLocData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(MgmtGrpParentWithLocData.DeserializeMgmtGrpParentWithLocData(item));
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
            return new MgmtGrpParentWithLocListResult(value, nextLink.Value);
        }
    }
}
