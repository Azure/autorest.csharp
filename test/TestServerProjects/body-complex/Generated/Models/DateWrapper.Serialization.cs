// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;

namespace body_complex.Models
{
    public partial class DateWrapper : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Field))
            {
                writer.WritePropertyName("field"u8);
                writer.WriteStringValue(Field.Value, "D");
            }
            if (Optional.IsDefined(Leap))
            {
                writer.WritePropertyName("leap"u8);
                writer.WriteStringValue(Leap.Value, "D");
            }
            writer.WriteEndObject();
        }

        internal static DateWrapper DeserializeDateWrapper(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<DateTimeOffset> field = default;
            Optional<DateTimeOffset> leap = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("field"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    field = property.Value.GetDateTimeOffset("D");
                    continue;
                }
                if (property.NameEquals("leap"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    leap = property.Value.GetDateTimeOffset("D");
                    continue;
                }
            }
            return new DateWrapper(Optional.ToNullable(field), Optional.ToNullable(leap));
        }
    }
}
