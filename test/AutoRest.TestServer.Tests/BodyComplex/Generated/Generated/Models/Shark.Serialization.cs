// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace BodyComplex.Models.V20160229
{
    public partial class Shark
    {
        internal void Serialize(Utf8JsonWriter writer, bool includeName = true)
        {
            if (includeName)
            {
                writer.WriteStartObject("shark");
            }
            else
            {
                writer.WriteStartObject();
            }
            if (Age != null)
            {
                writer.WriteNumber("age", Age.Value);
            }
            writer.WriteString("birthday", Birthday.ToString());
            writer.WriteEndObject();
        }
        internal static Shark Deserialize(JsonElement element)
        {
            var result = new Shark();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("age"))
                {
                    result.Age = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("birthday"))
                {
                    result.Birthday = property.Value.GetDateTime();
                    continue;
                }
            }
            return result;
        }
    }
}
