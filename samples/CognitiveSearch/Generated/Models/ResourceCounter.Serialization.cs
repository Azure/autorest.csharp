// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace CognitiveSearch.Models
{
    public partial class ResourceCounter
    {
        internal static ResourceCounter DeserializeResourceCounter(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            long usage = default;
            Optional<long?> quota = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("usage"u8))
                {
                    usage = property.Value.GetInt64();
                    continue;
                }
                if (property.NameEquals("quota"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        quota = null;
                        continue;
                    }
                    quota = property.Value.GetInt64();
                    continue;
                }
            }
            return new ResourceCounter(usage, Optional.ToNullable(quota));
        }
    }
}
