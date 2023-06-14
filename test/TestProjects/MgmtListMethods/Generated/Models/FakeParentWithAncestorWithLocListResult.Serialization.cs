// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using MgmtListMethods;

namespace MgmtListMethods.Models
{
    internal partial class FakeParentWithAncestorWithLocListResult
    {
        internal static FakeParentWithAncestorWithLocListResult DeserializeFakeParentWithAncestorWithLocListResult(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IReadOnlyList<FakeParentWithAncestorWithLocData> value = default;
            Optional<string> nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    List<FakeParentWithAncestorWithLocData> array = new List<FakeParentWithAncestorWithLocData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(FakeParentWithAncestorWithLocData.DeserializeFakeParentWithAncestorWithLocData(item));
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
            return new FakeParentWithAncestorWithLocListResult(value, nextLink.Value);
        }
    }
}
