// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Storage.Models
{
    public partial class ProtectedAppendWritesHistory
    {
        internal static ProtectedAppendWritesHistory DeserializeProtectedAppendWritesHistory(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<bool> allowProtectedAppendWritesAll = default;
            Optional<DateTimeOffset> timestamp = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("allowProtectedAppendWritesAll"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    allowProtectedAppendWritesAll = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("timestamp"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    timestamp = property.Value.GetDateTimeOffset("O");
                    continue;
                }
            }
            return new ProtectedAppendWritesHistory(Optional.ToNullable(allowProtectedAppendWritesAll), Optional.ToNullable(timestamp));
        }
    }
}
