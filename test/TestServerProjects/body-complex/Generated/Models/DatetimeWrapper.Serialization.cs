// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;

namespace body_complex.Models.V20160229
{
    public partial class DatetimeWrapper
    {
        internal void Serialize(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Field != null)
            {
                writer.WritePropertyName("field");
                writer.WriteStringValue(Field.Value.ToString("yyyy-MM-ddTHH:mm:ssZ"));
            }
            if (Now != null)
            {
                writer.WritePropertyName("now");
                writer.WriteStringValue(Now.Value.ToString("yyyy-MM-ddTHH:mm:ssZ"));
            }
            writer.WriteEndObject();
        }
        internal static DatetimeWrapper Deserialize(JsonElement element)
        {
            var result = new DatetimeWrapper();
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
