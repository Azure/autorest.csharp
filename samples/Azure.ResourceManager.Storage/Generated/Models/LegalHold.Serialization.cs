// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Storage.Models
{
    public partial class LegalHold : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("tags"u8);
            writer.WriteStartArray();
            foreach (var item in Tags)
            {
                writer.WriteStringValue(item);
            }
            writer.WriteEndArray();
            if (Optional.IsDefined(AllowProtectedAppendWritesAll))
            {
                writer.WritePropertyName("allowProtectedAppendWritesAll"u8);
                writer.WriteBooleanValue(AllowProtectedAppendWritesAll.Value);
            }
            writer.WriteEndObject();
        }

        internal static LegalHold DeserializeLegalHold(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<bool> hasLegalHold = default;
            IList<string> tags = default;
            Optional<bool> allowProtectedAppendWritesAll = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("hasLegalHold"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    hasLegalHold = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("tags"u8))
                {
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    tags = array;
                    continue;
                }
                if (property.NameEquals("allowProtectedAppendWritesAll"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    allowProtectedAppendWritesAll = property.Value.GetBoolean();
                    continue;
                }
            }
            return new LegalHold(Optional.ToNullable(hasLegalHold), tags, Optional.ToNullable(allowProtectedAppendWritesAll));
        }
    }
}
