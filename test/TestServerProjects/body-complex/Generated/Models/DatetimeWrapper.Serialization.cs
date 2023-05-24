// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace body_complex.Models
{
    public partial class DatetimeWrapper : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IUtf8JsonSerializable)this).Write(writer, new SerializableOptions());

        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer, SerializableOptions options)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Field))
            {
                writer.WritePropertyName("field"u8);
                writer.WriteStringValue(Field.Value, "O");
            }
            if (Optional.IsDefined(Now))
            {
                writer.WritePropertyName("now"u8);
                writer.WriteStringValue(Now.Value, "O");
            }
            writer.WriteEndObject();
        }

        internal static DatetimeWrapper DeserializeDatetimeWrapper(JsonElement element, SerializableOptions options = default)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<DateTimeOffset> field = default;
            Optional<DateTimeOffset> now = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("field"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    field = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("now"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    now = property.Value.GetDateTimeOffset("O");
                    continue;
                }
            }
            return new DatetimeWrapper(Optional.ToNullable(field), Optional.ToNullable(now));
        }
    }
}
