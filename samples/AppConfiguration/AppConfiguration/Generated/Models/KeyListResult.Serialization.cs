// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace AppConfiguration.Models
{
    public partial class KeyListResult : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Items != null)
            {
                writer.WritePropertyName("items");
                writer.WriteStartArray();
                foreach (var item in Items)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (NextLink != null)
            {
                writer.WritePropertyName("@nextLink");
                writer.WriteStringValue(NextLink);
            }
            writer.WriteEndObject();
        }
        internal static KeyListResult DeserializeKeyListResult(JsonElement element)
        {
            KeyListResult result = new KeyListResult();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("items"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Items = new List<Key>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        result.Items.Add(Key.DeserializeKey(item));
                    }
                    continue;
                }
                if (property.NameEquals("@nextLink"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.NextLink = property.Value.GetString();
                    continue;
                }
            }
            return result;
        }
    }
}
