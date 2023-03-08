// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace TypeSchemaMapping.Models
{
    internal partial class ModelWithNullableObjectProperty : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(ModelProperty))
            {
                writer.WritePropertyName("ModelProperty"u8);
                ModelProperty.WriteTo(writer);
            }
            writer.WriteEndObject();
        }

        internal static ModelWithNullableObjectProperty DeserializeModelWithNullableObjectProperty(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<JsonElement> modelProperty = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("ModelProperty"u8))
                {
                    modelProperty = property.Value.Clone();
                    continue;
                }
            }
            return new ModelWithNullableObjectProperty(modelProperty);
        }
    }
}
