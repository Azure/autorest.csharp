// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;

namespace AzureSample.ResourceManager.Storage.Models
{
    public partial class StorageAccountInternetEndpoints
    {
        internal static StorageAccountInternetEndpoints DeserializeStorageAccountInternetEndpoints(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string blob = default;
            string file = default;
            string web = default;
            string dfs = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("blob"u8))
                {
                    blob = property.Value.GetString();
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
            return new StorageAccountInternetEndpoints(blob, file, web, dfs);
        }
    }
}
