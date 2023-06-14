// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace TypeSchemaMapping.Models
{
    public partial class PublicModelWithInternalProperty
    {
        internal static PublicModelWithInternalProperty DeserializePublicModelWithInternalProperty(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<JsonElement> internalProperty = default;
            Optional<string> publicProperty = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("InternalProperty"u8))
                {
                    internalProperty = property.Value.Clone();
                    continue;
                }
                if (property.NameEquals("PublicProperty"u8))
                {
                    publicProperty = property.Value.GetString();
                    continue;
                }
            }
            return new PublicModelWithInternalProperty(internalProperty, publicProperty.Value);
        }
    }
}
