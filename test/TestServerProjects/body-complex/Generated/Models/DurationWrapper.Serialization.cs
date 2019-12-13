// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;

namespace body_complex.Models.V20160229
{
    public partial class DurationWrapper
    {
        internal void Serialize(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Field != null)
            {
                writer.WritePropertyName("field");
                Azure.Core.Utf8JsonWriterExtensions.WriteStringValue(writer, Field.Value, "P");
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
                    result.Field = Azure.Core.TypeFormatters.GetTimeSpan(property.Value, "P");
                    continue;
                }
            }
            return result;
        }
    }
}
