// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace TypeSchemaMapping.Models
{
    public partial class Model : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (ModelProperty != null)
            {
                writer.WritePropertyName("ModelProperty");
                writer.WriteObjectValue(ModelProperty);
            }
            writer.WriteEndObject();
        }
        internal static Model DeserializeModel(JsonElement element)
        {
            Model result = new Model();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("ModelProperty"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.ModelProperty = property.Value.GetObject();
                    continue;
                }
            }
            return result;
        }
    }
}
