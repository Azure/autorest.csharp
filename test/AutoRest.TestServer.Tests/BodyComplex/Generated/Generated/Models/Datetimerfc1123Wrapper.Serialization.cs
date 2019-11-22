// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace BodyComplex.Models.V20160229
{
    public partial class Datetimerfc1123Wrapper
    {
        internal void Serialize(Utf8JsonWriter writer, bool includeName = true)
        {
            if (includeName)
            {
                writer.WriteStartObject("datetimerfc1123-wrapper");
            }
            else
            {
                writer.WriteStartObject();
            }
            if (Field != null)
            {
                writer.WriteString("field", Field.ToString());
            }
            if (Now != null)
            {
                writer.WriteString("now", Now.ToString());
            }
            writer.WriteEndObject();
        }
        internal static Datetimerfc1123Wrapper Deserialize(JsonElement element)
        {
            var result = new Datetimerfc1123Wrapper();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("field"))
                {
                    result.Field = property.Value.GetDateTime();
                    continue;
                }
                if (property.NameEquals("now"))
                {
                    result.Now = property.Value.GetDateTime();
                    continue;
                }
            }
            return result;
        }
    }
}
