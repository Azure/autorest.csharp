// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace TypeSchemaMapping.Models
{
    public partial class ModelWithAbstractModel
    {
        internal static ModelWithAbstractModel DeserializeModelWithAbstractModel(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<AbstractModel> abstractModelProperty = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("AbstractModelProperty"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    abstractModelProperty = AbstractModel.DeserializeAbstractModel(property.Value);
                    continue;
                }
            }
            return new ModelWithAbstractModel(abstractModelProperty.Value);
        }
    }
}
