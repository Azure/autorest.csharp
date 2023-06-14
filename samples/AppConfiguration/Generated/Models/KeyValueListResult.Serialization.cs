// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace AppConfiguration.Models
{
    internal partial class KeyValueListResult
    {
        internal static KeyValueListResult DeserializeKeyValueListResult(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IReadOnlyList<KeyValue>> items = default;
            Optional<string> nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("items"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<KeyValue> array = new List<KeyValue>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(KeyValue.DeserializeKeyValue(item));
                    }
                    items = array;
                    continue;
                }
                if (property.NameEquals("@nextLink"u8))
                {
                    nextLink = property.Value.GetString();
                    continue;
                }
            }
            return new KeyValueListResult(Optional.ToList(items), nextLink.Value);
        }
    }
}
