// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Storage.Models
{
    public partial class StorageAccountKey
    {
        internal static StorageAccountKey DeserializeStorageAccountKey(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> keyName = default;
            Optional<string> value = default;
            Optional<KeyPermission> permissions = default;
            Optional<DateTimeOffset> creationTime = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("keyName"u8))
                {
                    keyName = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("value"u8))
                {
                    value = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("permissions"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    permissions = property.Value.GetString().ToKeyPermission();
                    continue;
                }
                if (property.NameEquals("creationTime"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    creationTime = property.Value.GetDateTimeOffset("O");
                    continue;
                }
            }
            return new StorageAccountKey(keyName.Value, value.Value, Optional.ToNullable(permissions), Optional.ToNullable(creationTime));
        }
    }
}
