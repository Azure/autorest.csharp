// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;

namespace Body_Complex.Models
{
    public partial class DurationWrapper : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Field))
            {
                writer.WritePropertyName("field");
                writer.WriteStringValue(Field.Value, "P");
            }
            writer.WriteEndObject();
        }

        internal static DurationWrapper DeserializeDurationWrapper(JsonElement element)
        {
            Optional<TimeSpan> field = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("field"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
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
