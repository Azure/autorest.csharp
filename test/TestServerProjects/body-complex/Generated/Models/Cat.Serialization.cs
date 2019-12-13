// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace body_complex.Models.V20160229
{
    public partial class CatSerializer
    {
        internal static void Serialize(Cat model, Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (model.Color != null)
            {
                writer.WritePropertyName("color");
                writer.WriteStringValue(model.Color);
            }
            if (model.Hates != null)
            {
                writer.WriteStartArray("hates");
                foreach (var item in model.Hates)
                {
                    DogSerializer.Serialize(item, writer);
                }
                writer.WriteEndArray();
            }

            if (model.Id != null)
            {
                writer.WritePropertyName("id");
                writer.WriteNumberValue(model.Id.Value);
            }
            if (model.Name != null)
            {
                writer.WritePropertyName("name");
                writer.WriteStringValue(model.Name);
            }
            writer.WriteEndObject();
        }
        internal static Cat Deserialize(JsonElement element)
        {
            var result = new Cat();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("color"))
                {
                    result.Color = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("hates"))
                {
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        result.Hates.Add(DogSerializer.Deserialize(item));
                    }
                    continue;
                }

                if (property.NameEquals("id"))
                {
                    result.Id = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("name"))
                {
                    result.Name = property.Value.GetString();
                    continue;
                }
            }
            return result;
        }
    }
}
