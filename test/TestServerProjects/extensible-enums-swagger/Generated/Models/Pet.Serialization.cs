// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace extensible_enums_swagger.Models.V20160707
{
    public partial class Pet
    {
        internal void Serialize(Utf8JsonWriter writer)
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
                writer.WriteStringValue(DaysOfWeek.ToString());
            }
            writer.WritePropertyName("IntEnum");
            writer.WriteStringValue(IntEnum.ToString());
            writer.WriteEndObject();
        }
        internal static Pet Deserialize(JsonElement element)
        {
            var result = new Pet();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name"))
                {
                    result.Name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("DaysOfWeek"))
                {
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
