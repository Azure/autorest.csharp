// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;

namespace TypeSchemaMapping.Models
{
    public partial class AbstractModel
    {
        internal static AbstractModel DeserializeAbstractModel(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            if (element.TryGetProperty("DiscriminatorProperty", out JsonElement discriminator))
            {
                switch (discriminator.GetString())
                {
                    case "DerivedFromAbstractModel": return DerivedFromAbstractModel.DeserializeDerivedFromAbstractModel(element);
                }
            }
            return UnknownAbstractModel.DeserializeUnknownAbstractModel(element);
        }
    }
}
