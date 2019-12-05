// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace body_string.Models.V100
{
    public partial class RefColorConstant
    {
        public void Serialize(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Field1 != null)
            {
                writer.WritePropertyName("field1");
                writer.WriteStringValue(Field1);
            }
            writer.WriteEndObject();
        }
        public static RefColorConstant Deserialize(JsonElement element)
        {
            var result = new RefColorConstant();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("field1"))
                {
                    result.Field1 = property.Value.GetString();
                    continue;
                }
            }
            return result;
        }
    }
}
