// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;

namespace Body_Complex.Models
{
    public partial class DateWrapper : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Field))
            {
                writer.WritePropertyName("field");
                writer.WriteStringValue(Field.Value, "D");
            }
            if (Optional.IsDefined(Leap))
            {
                writer.WritePropertyName("leap");
                writer.WriteStringValue(Leap.Value, "D");
            }
            writer.WriteEndObject();
        }

        internal static DateWrapper DeserializeDateWrapper(JsonElement element)
        {
            Optional<DateTimeOffset> field = default;
            Optional<DateTimeOffset> leap = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("field"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    field = property.Value.GetDateTimeOffset("D");
                    continue;
                }
                if (property.NameEquals("leap"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
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
