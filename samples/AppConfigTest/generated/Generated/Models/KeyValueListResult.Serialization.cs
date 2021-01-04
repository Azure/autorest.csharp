// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.AppConfiguration.Models
{
    public partial class KeyValueListResult
    {
        internal static KeyValueListResult DeserializeKeyValueListResult(JsonElement element)
        {
            Optional<IReadOnlyList<KeyValue>> items = default;
            Optional<string> nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("items"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
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
                if (property.NameEquals("@nextLink"))
                {
                    nextLink = property.Value.GetString();
                    continue;
                }
            }
            return new KeyValueListResult(Optional.ToList(items), nextLink.Value);
        }
    }
}
