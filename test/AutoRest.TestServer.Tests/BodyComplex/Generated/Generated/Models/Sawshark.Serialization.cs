// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace BodyComplex.Models.V20160229
{
    public partial class Sawshark
    {
        internal void Serialize(Utf8JsonWriter writer, bool includeName = true)
        {
            if (includeName)
            {
                writer.WriteStartObject("sawshark");
            }
            else
            {
                writer.WriteStartObject();
            }
            if (Picture != null)
            {
                // ByteArraySchema Picture: Not Implemented
            }
            writer.WriteEndObject();
        }
        internal static Sawshark Deserialize(JsonElement element)
        {
            var result = new Sawshark();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("picture"))
                {
                    // ByteArraySchema Picture: Not Implemented
                    continue;
                }
            }
            return result;
        }
    }
}
