// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace BodyComplex.Models.V20160229
{
    public partial class Goblinshark
    {
        internal void Serialize(Utf8JsonWriter writer, bool includeName = true)
        {
            if (includeName)
            {
                writer.WriteStartObject("goblinshark");
            }
            else
            {
                writer.WriteStartObject();
            }
            if (Jawsize != null)
            {
                writer.WriteNumber("jawsize", Jawsize.Value);
            }
            if (Color != null)
            {
                // SealedChoiceSchema Color: Not Implemented
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
                    // SealedChoiceSchema Color: Not Implemented
                    continue;
                }
            }
            return result;
        }
    }
}
