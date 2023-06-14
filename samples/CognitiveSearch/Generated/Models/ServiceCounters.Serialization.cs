// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace CognitiveSearch.Models
{
    public partial class ServiceCounters
    {
        internal static ServiceCounters DeserializeServiceCounters(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            ResourceCounter documentCount = default;
            ResourceCounter indexesCount = default;
            ResourceCounter indexersCount = default;
            ResourceCounter dataSourcesCount = default;
            ResourceCounter storageSize = default;
            ResourceCounter synonymMaps = default;
            ResourceCounter skillsetCount = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("documentCount"u8))
                {
                    documentCount = ResourceCounter.DeserializeResourceCounter(property.Value);
                    continue;
                }
                if (property.NameEquals("indexesCount"u8))
                {
                    indexesCount = ResourceCounter.DeserializeResourceCounter(property.Value);
                    continue;
                }
                if (property.NameEquals("indexersCount"u8))
                {
                    indexersCount = ResourceCounter.DeserializeResourceCounter(property.Value);
                    continue;
                }
                if (property.NameEquals("dataSourcesCount"u8))
                {
                    dataSourcesCount = ResourceCounter.DeserializeResourceCounter(property.Value);
                    continue;
                }
                if (property.NameEquals("storageSize"u8))
                {
                    storageSize = ResourceCounter.DeserializeResourceCounter(property.Value);
                    continue;
                }
                if (property.NameEquals("synonymMaps"u8))
                {
                    synonymMaps = ResourceCounter.DeserializeResourceCounter(property.Value);
                    continue;
                }
                if (property.NameEquals("skillsetCount"u8))
                {
                    skillsetCount = ResourceCounter.DeserializeResourceCounter(property.Value);
                    continue;
                }
            }
            return new ServiceCounters(documentCount, indexesCount, indexersCount, dataSourcesCount, storageSize, synonymMaps, skillsetCount);
        }
    }
}
