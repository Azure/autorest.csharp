// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace body_complex.Models.V20160229
{
    public partial class Basic
    {
        internal void Serialize(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Id != null)
            {
                writer.WritePropertyName("id");
                writer.WriteNumberValue(Id.Value);
            }
            if (Name != null)
            {
                writer.WritePropertyName("name");
                writer.WriteStringValue(Name);
            }
            if (Color != null)
            {
                writer.WritePropertyName("color");
                writer.WriteStringValue(Color.Value.ToSerialString());
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
                    result.Color = property.Value.GetString().ToCMYKColors();
                    continue;
                }
            }
            return result;
        }
    }
}
