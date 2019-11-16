// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace BodyComplex.Models.V20160229
{
    public partial class Salmon
    {
        internal void Serialize(Utf8JsonWriter writer, bool includeName = true)
        {
            if (includeName)
            {
                writer.WriteStartObject("salmon");
            }
            else
            {
                writer.WriteStartObject();
            }
            if (Location != null)
            {
                writer.WriteString("location", Location);
            }
            if (Iswild != null)
            {
                writer.WriteBoolean("iswild", Iswild.Value);
            }
            writer.WriteEndObject();
        }
        internal static Salmon Deserialize(JsonElement element)
        {
            var result = new Salmon();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("location"))
                {
                    result.Location = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("iswild"))
                {
                    result.Iswild = property.Value.GetBoolean();
                    continue;
                }
            }
            return result;
        }
    }
}
