// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace CognitiveSearch.Models
{
    public partial class GetIndexStatisticsResult
    {
        internal static GetIndexStatisticsResult DeserializeGetIndexStatisticsResult(JsonElement element, SerializableOptions options = default)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            long documentCount = default;
            long storageSize = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("documentCount"u8))
                {
                    documentCount = property.Value.GetInt64();
                    continue;
                }
                if (property.NameEquals("storageSize"u8))
                {
                    storageSize = property.Value.GetInt64();
                    continue;
                }
            }
            return new GetIndexStatisticsResult(documentCount, storageSize);
        }
    }
}
