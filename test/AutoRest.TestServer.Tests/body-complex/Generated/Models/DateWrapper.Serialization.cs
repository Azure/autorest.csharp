// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;

namespace body_complex.Models.V20160229
{
    public partial class DateWrapper
    {
        internal void Serialize(Utf8JsonWriter writer, bool includeName = true)
        {
            if (includeName)
            {
                writer.WriteStartObject("date-wrapper");
            }
            else
            {
                writer.WriteStartObject();
            }
            if (Field != null)
            {
                writer.WriteString("field", Field.ToString());
            }
            if (Leap != null)
            {
                writer.WriteString("leap", Leap.ToString());
            }
            writer.WriteEndObject();
        }
        internal static DateWrapper Deserialize(JsonElement element)
        {
            var result = new DateWrapper();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("field"))
                {
                    result.Field = property.Value.GetDateTime();
                    continue;
                }
                if (property.NameEquals("leap"))
                {
                    result.Leap = property.Value.GetDateTime();
                    continue;
                }
            }
            return result;
        }
    }
}
