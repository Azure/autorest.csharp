// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace AppConfiguration.Models
{
    internal partial class KeyListResult
    {
        internal static KeyListResult DeserializeKeyListResult(JsonElement element)
        {
            Optional<IReadOnlyList<Key>> items = default;
            Optional<string> nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("items"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<Key> array = new List<Key>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(Key.DeserializeKey(item));
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
            return new KeyListResult(Optional.ToList(items), nextLink.Value);
        }
    }
}
