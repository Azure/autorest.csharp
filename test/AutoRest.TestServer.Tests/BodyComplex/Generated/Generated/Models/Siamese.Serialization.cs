// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace BodyComplex.Models.V20160229
{
    public partial class Siamese
    {
        internal void Serialize(Utf8JsonWriter writer, bool includeName = true)
        {
            if (includeName)
            {
                writer.WriteStartObject("siamese");
            }
            else
            {
                writer.WriteStartObject();
            }
            if (Breed != null)
            {
                writer.WriteString("breed", Breed);
            }
            writer.WriteEndObject();
        }
        internal static Siamese Deserialize(JsonElement element)
        {
            var result = new Siamese();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("breed"))
                {
                    result.Breed = property.Value.GetString();
                    continue;
                }
            }
            return result;
        }
    }
}
