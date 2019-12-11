// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace body_complex.Models.V20160229
{
    public partial class Goblinshark
    {
        internal void Serialize(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Jawsize != null)
            {
                writer.WritePropertyName("jawsize");
                writer.WriteNumberValue(Jawsize.Value);
            }
            if (Color != null)
            {
                writer.WritePropertyName("color");
                writer.WriteStringValue(Color.ToString());
            }
            writer.WriteEndObject();
        }
        internal static Goblinshark Deserialize(JsonElement element)
        {
            var result = new Goblinshark();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("jawsize"))
                {
                    result.Jawsize = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("color"))
                {
                    result.Color = new GoblinSharkColor(property.Value.GetString());
                    continue;
                }
            }
            return result;
        }
    }
}
