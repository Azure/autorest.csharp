// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace extensible_enums_swagger.Models
{
    public partial class Pet : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Name))
            {
                writer.WritePropertyName("name"u8);
                writer.WriteStringValue(Name);
            }
            if (Optional.IsDefined(DaysOfWeek))
            {
                writer.WritePropertyName("DaysOfWeek"u8);
                writer.WriteStringValue(DaysOfWeek.Value.ToString());
            }
            writer.WritePropertyName("IntEnum"u8);
            writer.WriteStringValue(IntEnum.ToString());
            writer.WriteEndObject();
        }

        internal static Pet DeserializePet(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> name = default;
            Optional<DaysOfWeekExtensibleEnum> daysOfWeek = default;
            IntEnum intEnum = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("DaysOfWeek"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    daysOfWeek = new DaysOfWeekExtensibleEnum(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("IntEnum"u8))
                {
                    intEnum = new IntEnum(property.Value.GetString());
                    continue;
                }
            }
            return new Pet(name.Value, Optional.ToNullable(daysOfWeek), intEnum);
        }
    }
}
