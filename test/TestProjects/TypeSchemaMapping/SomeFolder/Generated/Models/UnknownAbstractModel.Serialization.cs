// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace TypeSchemaMapping.Models
{
    internal partial class UnknownAbstractModel
    {
        internal static UnknownAbstractModel DeserializeUnknownAbstractModel(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string discriminatorProperty = "Unknown";
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("DiscriminatorProperty"u8))
                {
                    discriminatorProperty = property.Value.GetString();
                    continue;
                }
            }
            return new UnknownAbstractModel(discriminatorProperty);
        }
    }
}
