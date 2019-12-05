// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;

namespace body_complex.Models.V20160229
{
    public partial class DurationWrapper
    {
        public void Serialize(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Field != null)
            {
                writer.WritePropertyName("field");
                writer.WriteStringValue(Field.ToString());
            }
            writer.WriteEndObject();
        }
        public static DurationWrapper Deserialize(JsonElement element)
        {
            var result = new DurationWrapper();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("field"))
                {
                    result.Field = TimeSpan.Parse(property.Value.GetString());
                    continue;
                }
            }
            return result;
        }
    }
}
