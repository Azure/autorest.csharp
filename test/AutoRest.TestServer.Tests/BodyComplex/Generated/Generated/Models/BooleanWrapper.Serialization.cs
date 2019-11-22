// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace BodyComplex.Models.V20160229
{
    public partial class BooleanWrapper
    {
        internal void Serialize(Utf8JsonWriter writer, bool includeName = true)
        {
            if (includeName)
            {
                writer.WriteStartObject("boolean-wrapper");
            }
            else
            {
                writer.WriteStartObject();
            }
            if (FieldTrue != null)
            {
                writer.WriteBoolean("field_true", FieldTrue.Value);
            }
            if (FieldFalse != null)
            {
                writer.WriteBoolean("field_false", FieldFalse.Value);
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
