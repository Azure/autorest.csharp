// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace CognitiveSearch.Models
{
    public partial class IndexingResult
    {
        internal static IndexingResult DeserializeIndexingResult(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string key = default;
            Optional<string> errorMessage = default;
            bool status = default;
            int statusCode = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("key"u8))
                {
                    key = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("errorMessage"u8))
                {
                    errorMessage = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("status"u8))
                {
                    status = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("statusCode"u8))
                {
                    statusCode = property.Value.GetInt32();
                    continue;
                }
            }
            return new IndexingResult(key, errorMessage.Value, status, statusCode);
        }
    }
}
