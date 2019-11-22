// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace body_complex.Models.V20160229
{
    public partial class DurationWrapper
    {
        internal void Serialize(Utf8JsonWriter writer, bool includeName = true)
        {
            if (includeName)
            {
                writer.WriteStartObject("duration-wrapper");
            }
            else
            {
                writer.WriteStartObject();
            }
            if (Field != null)
            {
                writer.WriteString("field", Field.ToString());
            }
            writer.WriteEndObject();
        }
        internal static DurationWrapper Deserialize(JsonElement element)
        {
            var result = new DurationWrapper();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("field"))
                {
                    // DurationSchema Field: Not Implemented
                    continue;
                }
            }
            return result;
        }
    }
}
