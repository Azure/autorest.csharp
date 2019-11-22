// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace body_complex.Models.V20160229
{
    public partial class IntWrapper
    {
        internal void Serialize(Utf8JsonWriter writer, bool includeName = true)
        {
            if (includeName)
            {
                writer.WriteStartObject("int-wrapper");
            }
            else
            {
                writer.WriteStartObject();
            }
            if (Field1 != null)
            {
                writer.WriteNumber("field1", Field1.Value);
            }
            if (Field2 != null)
            {
                writer.WriteNumber("field2", Field2.Value);
            }
            writer.WriteEndObject();
        }
        internal static IntWrapper Deserialize(JsonElement element)
        {
            var result = new IntWrapper();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("field1"))
                {
                    result.Field1 = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("field2"))
                {
                    result.Field2 = property.Value.GetInt32();
                    continue;
                }
            }
            return result;
        }
    }
}
