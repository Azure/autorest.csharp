// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;

namespace body_complex.Models.V20160229
{
    public partial class DateWrapper
    {
        internal void Serialize(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Field != null)
            {
                writer.WritePropertyName("field");
                Azure.Core.Utf8JsonWriterExtensions.WriteDateTimeOffsetValue(writer, Field.Value, "D");
            }
            if (Leap != null)
            {
                writer.WritePropertyName("leap");
                Azure.Core.Utf8JsonWriterExtensions.WriteDateTimeOffsetValue(writer, Leap.Value, "D");
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
                    result.Field = property.Value.GetDateTimeOffset();
                    continue;
                }
                if (property.NameEquals("leap"))
                {
                    result.Leap = property.Value.GetDateTimeOffset();
                    continue;
                }
            }
            return result;
        }
    }
}
