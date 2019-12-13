// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace body_complex.Models.V20160229
{
    public partial class BasicSerializer
    {
        internal static void Serialize(Basic model, Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
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
            if (model.Color != null)
            {
                writer.WritePropertyName("color");
                writer.WriteStringValue(model.Color.ToString());
            }
            writer.WriteEndObject();
        }
        internal static Basic Deserialize(JsonElement element)
        {
            var result = new Basic();
            foreach (var property in element.EnumerateObject())
            {
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
                if (property.NameEquals("color"))
                {
                    result.Color = new CMYKColors(property.Value.GetString());
                    continue;
                }
            }
            return result;
        }
    }
}
