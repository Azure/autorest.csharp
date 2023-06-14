// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using MgmtListMethods;

namespace MgmtListMethods.Models
{
    internal partial class FakeParentWithAncestorWithNonResChListResult
    {
        internal static FakeParentWithAncestorWithNonResChListResult DeserializeFakeParentWithAncestorWithNonResChListResult(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IReadOnlyList<FakeParentWithAncestorWithNonResChData> value = default;
            Optional<string> nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    List<FakeParentWithAncestorWithNonResChData> array = new List<FakeParentWithAncestorWithNonResChData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(FakeParentWithAncestorWithNonResChData.DeserializeFakeParentWithAncestorWithNonResChData(item));
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
            return new FakeParentWithAncestorWithNonResChListResult(value, nextLink.Value);
        }
    }
}
