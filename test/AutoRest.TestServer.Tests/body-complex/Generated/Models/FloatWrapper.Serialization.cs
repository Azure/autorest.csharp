// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace body_complex.Models.V20160229
{
    public partial class FloatWrapper
    {
        internal void Serialize(Utf8JsonWriter writer, bool includeName = true)
        {
            if (includeName)
            {
                writer.WriteStartObject("float-wrapper");
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
        internal static FloatWrapper Deserialize(JsonElement element)
        {
            var result = new FloatWrapper();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("field1"))
                {
                    result.Field1 = property.Value.GetDouble();
                    continue;
                }
                if (property.NameEquals("field2"))
                {
                    result.Field2 = property.Value.GetDouble();
                    continue;
                }
            }
            return result;
        }
    }
}
