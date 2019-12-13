// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace body_complex.Models.V20160229
{
    public partial class FloatWrapperSerializer
    {
        internal static void Serialize(FloatWrapper model, Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (model.Field1 != null)
            {
                writer.WritePropertyName("field1");
                writer.WriteNumberValue(model.Field1.Value);
            }
            if (model.Field2 != null)
            {
                writer.WritePropertyName("field2");
                writer.WriteNumberValue(model.Field2.Value);
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
                    result.Field1 = property.Value.GetSingle();
                    continue;
                }
                if (property.NameEquals("field2"))
                {
                    result.Field2 = property.Value.GetSingle();
                    continue;
                }
            }
            return result;
        }
    }
}
