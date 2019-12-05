// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace body_complex.Models.V20160229
{
    public partial class BooleanWrapper
    {
        public void Serialize(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (FieldTrue != null)
            {
                writer.WritePropertyName("field_true");
                writer.WriteBooleanValue(FieldTrue.Value);
            }
            if (FieldFalse != null)
            {
                writer.WritePropertyName("field_false");
                writer.WriteBooleanValue(FieldFalse.Value);
            }
            writer.WriteEndObject();
        }
        public static BooleanWrapper Deserialize(JsonElement element)
        {
            var result = new BooleanWrapper();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("field_true"))
                {
                    result.FieldTrue = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("field_false"))
                {
                    result.FieldFalse = property.Value.GetBoolean();
                    continue;
                }
            }
            return result;
        }
    }
}
