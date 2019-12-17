// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace body_complex.Models.V20160229
{
    public partial class DurationWrapperSerializer
    {
        internal static void Serialize(DurationWrapper model, Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (model.Field != null)
            {
                writer.WritePropertyName("field");
                writer.WriteStringValue(model.Field.Value, "P");
            }

            writer.WriteEndObject();
        }
        internal static DurationWrapper Deserialize(JsonElement element)
        {
            var result = new DurationWrapper();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("field"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Field = property.Value.GetTimeSpan("P");
                    continue;
                }

            }
            return result;
        }
    }
}
