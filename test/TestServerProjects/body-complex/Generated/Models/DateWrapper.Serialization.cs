// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;

namespace body_complex.Models.V20160229
{
    public partial class DateWrapperSerializer
    {
        internal static void Serialize(DateWrapper model, Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (model.Field != null)
            {
                writer.WritePropertyName("field");
                Azure.Core.Utf8JsonWriterExtensions.WriteStringValue(writer, model.Field.Value, "D");
            }
            if (model.Leap != null)
            {
                writer.WritePropertyName("leap");
                Azure.Core.Utf8JsonWriterExtensions.WriteStringValue(writer, model.Leap.Value, "D");
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
                    result.Field = Azure.Core.TypeFormatters.GetDateTimeOffset(property.Value, "D");
                    continue;
                }
                if (property.NameEquals("leap"))
                {
                    result.Leap = Azure.Core.TypeFormatters.GetDateTimeOffset(property.Value, "D");
                    continue;
                }
            }
            return result;
        }
    }
}
