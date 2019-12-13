// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace body_complex.Models.V20160229
{
    public partial class BooleanWrapperSerializer
    {
        internal static void Serialize(BooleanWrapper model, Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (model.FieldTrue != null)
            {
                writer.WritePropertyName("field_true");
                writer.WriteBooleanValue(model.FieldTrue.Value);
            }
            if (model.FieldFalse != null)
            {
                writer.WritePropertyName("field_false");
                writer.WriteBooleanValue(model.FieldFalse.Value);
            }
            writer.WriteEndObject();
        }
        internal static BooleanWrapper Deserialize(JsonElement element)
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
