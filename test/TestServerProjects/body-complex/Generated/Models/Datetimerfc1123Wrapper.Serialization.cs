// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;

namespace body_complex.Models.V20160229
{
    public partial class Datetimerfc1123WrapperSerializer
    {
        internal static void Serialize(Datetimerfc1123Wrapper model, Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (model.Field != null)
            {
                writer.WritePropertyName("field");
                Azure.Core.Utf8JsonWriterExtensions.WriteStringValue(writer, model.Field.Value, "R");
            }
            if (model.Now != null)
            {
                writer.WritePropertyName("now");
                Azure.Core.Utf8JsonWriterExtensions.WriteStringValue(writer, model.Now.Value, "R");
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
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Field = Azure.Core.TypeFormatters.GetDateTimeOffset(property.Value, "R");
                    continue;
                }
                if (property.NameEquals("now"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Now = Azure.Core.TypeFormatters.GetDateTimeOffset(property.Value, "R");
                    continue;
                }
            }
            return result;
        }
    }
}
