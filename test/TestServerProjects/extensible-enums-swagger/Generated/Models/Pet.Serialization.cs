// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace extensible_enums_swagger.Models.V20160707
{
    public partial class PetSerializer
    {
        internal static void Serialize(Pet model, Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (model.Name != null)
            {
                writer.WritePropertyName("name");
                writer.WriteStringValue(model.Name);
            }
            if (model.DaysOfWeek != null)
            {
                writer.WritePropertyName("DaysOfWeek");
                writer.WriteStringValue(model.DaysOfWeek.ToString());
            }
            writer.WritePropertyName("IntEnum");
            writer.WriteStringValue(model.IntEnum.ToString());
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
