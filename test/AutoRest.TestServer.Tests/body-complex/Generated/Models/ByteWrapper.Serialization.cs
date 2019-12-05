// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;

namespace body_complex.Models.V20160229
{
    public partial class ByteWrapper
    {
        public void Serialize(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("field");
            writer.WriteBase64StringValue(Field);
            writer.WriteEndObject();
        }
        public static ByteWrapper Deserialize(JsonElement element)
        {
            var result = new ByteWrapper();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("field"))
                {
                    result.Field = property.Value.GetBytesFromBase64();
                    continue;
                }
            }
            return result;
        }
    }
}
