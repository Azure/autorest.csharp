// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace CognitiveSearch.Models
{
    public partial class GetIndexStatisticsResult
    {
        internal static GetIndexStatisticsResult DeserializeGetIndexStatisticsResult(JsonElement element)
        {
            GetIndexStatisticsResult result;
            long? documentCount = default;
            long? storageSize = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("documentCount"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    documentCount = property.Value.GetInt64();
                    continue;
                }
                if (property.NameEquals("storageSize"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    storageSize = property.Value.GetInt64();
                    continue;
                }
            }
            result = new GetIndexStatisticsResult(documentCount, storageSize);
            return result;
        }
    }
}
