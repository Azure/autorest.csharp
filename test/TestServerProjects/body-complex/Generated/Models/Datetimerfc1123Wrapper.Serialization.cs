// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;

namespace body_complex.Models.V20160229
{
    public partial class Datetimerfc1123Wrapper
    {
        internal void Serialize(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Field != null)
            {
                writer.WritePropertyName("field");
                Azure.Core.Utf8JsonWriterExtensions.WriteStringValue(writer, Field.Value, "R");
            }
            if (Now != null)
            {
                writer.WritePropertyName("now");
                Azure.Core.Utf8JsonWriterExtensions.WriteStringValue(writer, Now.Value, "R");
            }
            writer.WriteEndObject();
        }
        internal static Datetimerfc1123Wrapper Deserialize(JsonElement element)
        {
            var result = new Datetimerfc1123Wrapper();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("field"))
                {
                    result.Field = property.Value.GetDateTimeOffset();
                    continue;
                }
                if (property.NameEquals("now"))
                {
                    result.Now = property.Value.GetDateTimeOffset();
                    continue;
                }
            }
            return result;
        }
    }
}
