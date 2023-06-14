// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Storage.Models
{
    public partial class StorageAccountMicrosoftEndpoints
    {
        internal static StorageAccountMicrosoftEndpoints DeserializeStorageAccountMicrosoftEndpoints(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> blob = default;
            Optional<string> queue = default;
            Optional<string> table = default;
            Optional<string> file = default;
            Optional<string> web = default;
            Optional<string> dfs = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("blob"u8))
                {
                    blob = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("queue"u8))
                {
                    queue = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("table"u8))
                {
                    table = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("file"u8))
                {
                    file = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("web"u8))
                {
                    web = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("dfs"u8))
                {
                    dfs = property.Value.GetString();
                    continue;
                }
            }
            return new StorageAccountMicrosoftEndpoints(blob.Value, queue.Value, table.Value, file.Value, web.Value, dfs.Value);
        }
    }
}
