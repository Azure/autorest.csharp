// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace CognitiveSearch.Models
{
    public partial class ServiceLimits
    {
        internal static ServiceLimits DeserializeServiceLimits(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<int?> maxFieldsPerIndex = default;
            Optional<int?> maxFieldNestingDepthPerIndex = default;
            Optional<int?> maxComplexCollectionFieldsPerIndex = default;
            Optional<int?> maxComplexObjectsInCollectionsPerDocument = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("maxFieldsPerIndex"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        maxFieldsPerIndex = null;
                        continue;
                    }
                    maxFieldsPerIndex = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("maxFieldNestingDepthPerIndex"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        maxFieldNestingDepthPerIndex = null;
                        continue;
                    }
                    maxFieldNestingDepthPerIndex = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("maxComplexCollectionFieldsPerIndex"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        maxComplexCollectionFieldsPerIndex = null;
                        continue;
                    }
                    maxComplexCollectionFieldsPerIndex = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("maxComplexObjectsInCollectionsPerDocument"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        maxComplexObjectsInCollectionsPerDocument = null;
                        continue;
                    }
                    maxComplexObjectsInCollectionsPerDocument = property.Value.GetInt32();
                    continue;
                }
            }
            return new ServiceLimits(Optional.ToNullable(maxFieldsPerIndex), Optional.ToNullable(maxFieldNestingDepthPerIndex), Optional.ToNullable(maxComplexCollectionFieldsPerIndex), Optional.ToNullable(maxComplexObjectsInCollectionsPerDocument));
        }
    }
}
