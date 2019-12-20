// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace body_complex.Models.V20160229
{
    public partial class DatetimeWrapper : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Field != null)
            {
                writer.WritePropertyName("field");
                writer.WriteStringValue(Field.Value, "S");
            }
            if (Now != null)
            {
                writer.WritePropertyName("now");
                writer.WriteStringValue(Now.Value, "S");
            }
            writer.WriteEndObject();
        }
        internal static DatetimeWrapper DeserializeDatetimeWrapper(JsonElement element)
        {
            DatetimeWrapper result = new DatetimeWrapper();
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
