// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;

namespace body_complex.Models
{
    public partial class DurationWrapper : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Field))
            {
                writer.WritePropertyName("field"u8);
                writer.WriteStringValue(Field.Value, "P");
            }
            writer.WriteEndObject();
        }

        internal static DurationWrapper DeserializeDurationWrapper(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<TimeSpan> field = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("field"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    field = property.Value.GetTimeSpan("P");
                    continue;
                }
            }
            return new DurationWrapper(Optional.ToNullable(field));
        }
    }
}
