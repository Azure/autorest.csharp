// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace BodyComplex.Models.V20160229
{
    public partial class Basic
    {
        internal void Serialize(Utf8JsonWriter writer, bool includeName = true)
        {
            if (includeName)
            {
                writer.WriteStartObject("basic");
            }
            else
            {
                writer.WriteStartObject();
            }
            if (Id != null)
            {
                writer.WriteNumber("id", Id.Value);
            }
            if (Name != null)
            {
                writer.WriteString("name", Name);
            }
            if (Color != null)
            {
                // SealedChoiceSchema Color: Not Implemented
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
                    // SealedChoiceSchema Color: Not Implemented
                    continue;
                }
            }
            return result;
        }
    }
}
