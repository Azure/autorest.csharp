// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace body_string.Models.V100
{
    public partial class RefColorConstant
    {
        internal void Serialize(Utf8JsonWriter writer, bool includeName = true)
        {
            if (includeName)
            {
                writer.WriteStartObject("RefColorConstant");
            }
            else
            {
                writer.WriteStartObject();
            }
            writer.WriteString("ColorConstant", ColorConstant);
            if (Field1 != null)
            {
                writer.WriteString("field1", Field1);
            }
            writer.WriteEndObject();
        }
        internal static RefColorConstant Deserialize(JsonElement element)
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
