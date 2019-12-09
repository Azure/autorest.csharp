// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace body_complex.Models.V20160229
{
    public partial class LongWrapper
    {
        internal void Serialize(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Field1 != null)
            {
                writer.WritePropertyName("field1");
                writer.WriteNumberValue(Field1.Value);
            }
            if (Field2 != null)
            {
                writer.WritePropertyName("field2");
                writer.WriteNumberValue(Field2.Value);
            }
            writer.WriteEndObject();
        }
        internal static LongWrapper Deserialize(JsonElement element)
        {
            var result = new LongWrapper();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("field1"))
                {
                    result.Field1 = property.Value.GetInt64();
                    continue;
                }
                if (property.NameEquals("field2"))
                {
                    result.Field2 = property.Value.GetInt64();
                    continue;
                }
            }
            return result;
        }
    }
}
