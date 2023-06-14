// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace TypeSchemaMapping.Models
{
    public partial class DerivedFromAbstractModel
    {
        internal static DerivedFromAbstractModel DeserializeDerivedFromAbstractModel(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string discriminatorProperty = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("DiscriminatorProperty"u8))
                {
                    discriminatorProperty = property.Value.GetString();
                    continue;
                }
            }
            return new DerivedFromAbstractModel(discriminatorProperty);
        }
    }
}
