// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace TypeSchemaMapping.Models
{
    public partial class ModelWithListOfInternalModel
    {
        internal static ModelWithListOfInternalModel DeserializeModelWithListOfInternalModel(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> stringProperty = default;
            Optional<IReadOnlyList<InternalModel>> internalListProperty = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("StringProperty"u8))
                {
                    stringProperty = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("InternalListProperty"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<InternalModel> array = new List<InternalModel>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(InternalModel.DeserializeInternalModel(item));
                    }
                    internalListProperty = array;
                    continue;
                }
            }
            return new ModelWithListOfInternalModel(stringProperty.Value, Optional.ToList(internalListProperty));
        }
    }
}
