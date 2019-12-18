// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

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
                writer.WriteStringValue(model.Field.Value, "S");
            }
            if (model.Now != null)
            {
                writer.WritePropertyName("now");
                writer.WriteStringValue(model.Now.Value, "S");
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
                    result.Field = property.Value.GetDateTimeOffset("S");
                    continue;
                }
                if (property.NameEquals("now"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Now = property.Value.GetDateTimeOffset("S");
                    continue;
                }
            }
            return result;
        }
    }
}
