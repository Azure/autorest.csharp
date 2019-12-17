// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace body_complex.Models.V20160229
{
    public partial class DateWrapperSerializer
    {
        internal static void Serialize(DateWrapper model, Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (model.Field != null)
            {
                writer.WritePropertyName("field");
                writer.WriteStringValue(model.Field.Value, "D");
            }
            if (model.Leap != null)
            {
                writer.WritePropertyName("leap");
                writer.WriteStringValue(model.Leap.Value, "D");
            }

            writer.WriteEndObject();
        }
        internal static DateWrapper Deserialize(JsonElement element)
        {
            var result = new DateWrapper();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("field"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Field = property.Value.GetDateTimeOffset("D");
                    continue;
                }
                if (property.NameEquals("leap"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Leap = property.Value.GetDateTimeOffset("D");
                    continue;
                }

            }
            return result;
        }
    }
}
