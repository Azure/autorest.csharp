// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace extensible_enums_swagger.Models
{
    public partial class Pet : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Name != null)
            {
                writer.WritePropertyName("name");
                writer.WriteStringValue(Name);
            }
            if (DaysOfWeek != null)
            {
                writer.WritePropertyName("DaysOfWeek");
                writer.WriteStringValue(DaysOfWeek.Value.ToString());
            }
            writer.WritePropertyName("IntEnum");
            writer.WriteStringValue(IntEnum.ToString());
            writer.WriteEndObject();
        }
        internal static Pet DeserializePet(JsonElement element)
        {
            Pet result = new Pet();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("DaysOfWeek"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.DaysOfWeek = new DaysOfWeekExtensibleEnum(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("IntEnum"))
                {
                    result.IntEnum = new IntEnum(property.Value.GetString());
                    continue;
                }
            }
            return result;
        }
    }
}
