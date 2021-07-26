// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using MgmtListMethods;

namespace MgmtListMethods.Models
{
    internal partial class SubFakeListResult
    {
        internal static SubFakeListResult DeserializeSubFakeListResult(JsonElement element)
        {
            IReadOnlyList<SubFakeData> value = default;
            Optional<string> nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"))
                {
                    List<SubFakeData> array = new List<SubFakeData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(SubFakeData.DeserializeSubFakeData(item));
                    }
                    value = array;
                    continue;
                }
                if (property.NameEquals("nextLink"))
                {
                    nextLink = property.Value.GetString();
                    continue;
                }
            }
            return new SubFakeListResult(value, nextLink.Value);
        }
    }
}
