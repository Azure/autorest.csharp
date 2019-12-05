// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace body_complex.Models.V20160229
{
    public partial class DoubleWrapper
    {
        public void Serialize(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Field1 != null)
            {
                writer.WritePropertyName("field1");
                writer.WriteNumberValue(Field1.Value);
            }
            if (Field56ZerosAfterTheDotAndNegativeZeroBeforeDotAndThisIsALongFieldNameOnPurpose != null)
            {
                writer.WritePropertyName("field_56_zeros_after_the_dot_and_negative_zero_before_dot_and_this_is_a_long_field_name_on_purpose");
                writer.WriteNumberValue(Field56ZerosAfterTheDotAndNegativeZeroBeforeDotAndThisIsALongFieldNameOnPurpose.Value);
            }
            writer.WriteEndObject();
        }
        public static DoubleWrapper Deserialize(JsonElement element)
        {
            var result = new DoubleWrapper();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("field1"))
                {
                    result.Field1 = property.Value.GetDouble();
                    continue;
                }
                if (property.NameEquals("field_56_zeros_after_the_dot_and_negative_zero_before_dot_and_this_is_a_long_field_name_on_purpose"))
                {
                    result.Field56ZerosAfterTheDotAndNegativeZeroBeforeDotAndThisIsALongFieldNameOnPurpose = property.Value.GetDouble();
                    continue;
                }
            }
            return result;
        }
    }
}
