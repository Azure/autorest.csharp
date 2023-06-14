// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Sample.Models
{
    internal partial class ListUsagesResult
    {
        internal static ListUsagesResult DeserializeListUsagesResult(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IReadOnlyList<SampleUsage> value = default;
            Optional<string> nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    List<SampleUsage> array = new List<SampleUsage>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(SampleUsage.DeserializeSampleUsage(item));
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
            return new ListUsagesResult(value, nextLink.Value);
        }
    }
}
