// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;

namespace body_complex.Models
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
            DateTimeOffset? field = default;
            DateTimeOffset? now = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("field"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    field = property.Value.GetDateTimeOffset("S");
                    continue;
                }
                if (property.NameEquals("now"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    now = property.Value.GetDateTimeOffset("S");
                    continue;
                }
            }
            return new DatetimeWrapper(field, now);
        }
    }
}
