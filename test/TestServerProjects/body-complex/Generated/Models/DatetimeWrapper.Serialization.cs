// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;

namespace body_complex.Models.V20160229
{
    public partial class DatetimeWrapperSerializer
    {
        internal static void Serialize(DatetimeWrapper model, Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (model.Field != null)
            {
                writer.WritePropertyName("field");
                Azure.Core.Utf8JsonWriterExtensions.WriteStringValue(writer, model.Field.Value, "S");
            }
            if (model.Now != null)
            {
                writer.WritePropertyName("now");
                Azure.Core.Utf8JsonWriterExtensions.WriteStringValue(writer, model.Now.Value, "S");
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
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Field = Azure.Core.TypeFormatters.GetDateTimeOffset(property.Value, "S");
                    continue;
                }
                if (property.NameEquals("now"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Now = Azure.Core.TypeFormatters.GetDateTimeOffset(property.Value, "S");
                    continue;
                }
            }
            return result;
        }
    }
}
