// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace TypeSchemaMapping.Models
{
    public partial class ModelWithInternalModel
    {
        internal static ModelWithInternalModel DeserializeModelWithInternalModel(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<InternalModel> internalProperty = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("InternalProperty"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    internalProperty = InternalModel.DeserializeInternalModel(property.Value);
                    continue;
                }
            }
            return new ModelWithInternalModel(internalProperty.Value);
        }
    }
}
