// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;

namespace body_complex.Models.V20160229
{
    public partial class DateWrapper
    {
        public void Serialize(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Field != null)
            {
                writer.WritePropertyName("field");
                writer.WriteStringValue(Field.ToString());
            }
            if (Leap != null)
            {
                writer.WritePropertyName("leap");
                writer.WriteStringValue(Leap.ToString());
            }
            writer.WriteEndObject();
        }
        public static DateWrapper Deserialize(JsonElement element)
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
