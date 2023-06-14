// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace TypeSchemaMapping.Models
{
    internal partial class InternalModel
    {
        internal static InternalModel DeserializeInternalModel(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> stringProperty = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("StringProperty"u8))
                {
                    stringProperty = property.Value.GetString();
                    continue;
                }
            }
            return new InternalModel(stringProperty.Value);
        }
    }
}
