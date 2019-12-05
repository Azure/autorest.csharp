// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace body_complex.Models.V20160229
{
    public partial class Siamese
    {
        public void Serialize(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Breed != null)
            {
                writer.WritePropertyName("breed");
                writer.WriteStringValue(Breed);
            }
            writer.WriteEndObject();
        }
        public static Siamese Deserialize(JsonElement element)
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
