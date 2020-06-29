// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace CognitiveServices.TextAnalytics.Models
{
    public partial class DocumentEntities
    {
        internal static DocumentEntities DeserializeDocumentEntities(JsonElement element)
        {
            string id = default;
            IReadOnlyList<Entity> entities = default;
            Optional<DocumentStatistics> statistics = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"))
                {
                    id = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("entities"))
                {
                    List<Entity> array = new List<Entity>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        if (item.ValueKind == JsonValueKind.Null)
                        {
                            array.Add(null);
                        }
                        else
                        {
                            array.Add(Entity.DeserializeEntity(item));
                        }
                    }
                    entities = array;
                    continue;
                }
                if (property.NameEquals("statistics"))
                {
                    statistics = DocumentStatistics.DeserializeDocumentStatistics(property.Value);
                    continue;
                }
            }
            return new DocumentEntities(id, entities, statistics.HasValue ? statistics.Value : null);
        }
    }
}
