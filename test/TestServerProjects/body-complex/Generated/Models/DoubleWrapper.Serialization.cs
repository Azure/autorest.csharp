// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace body_complex.Models.V20160229
{
    public partial class DoubleWrapper : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
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
        internal static DoubleWrapper DeserializeDoubleWrapper(JsonElement element)
        {
            DoubleWrapper result = new DoubleWrapper();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("field1"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Field1 = property.Value.GetDouble();
                    continue;
                }
                if (property.NameEquals("field_56_zeros_after_the_dot_and_negative_zero_before_dot_and_this_is_a_long_field_name_on_purpose"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Field56ZerosAfterTheDotAndNegativeZeroBeforeDotAndThisIsALongFieldNameOnPurpose = property.Value.GetDouble();
                    continue;
                }
            }
            return result;
        }
    }
}
