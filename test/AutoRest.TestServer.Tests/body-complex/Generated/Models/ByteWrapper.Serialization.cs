// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;

namespace body_complex.Models.V20160229
{
    public partial class ByteWrapper
    {
        internal void Serialize(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Field != null)
            {
                writer.WritePropertyName("field");
                writer.WriteNullValue();
            }
            writer.WriteEndObject();
        }
        internal static ByteWrapper Deserialize(JsonElement element)
        {
            var result = new ByteWrapper();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("field"))
                {
                    result.Field = null;
                    continue;
                }
            }
            return result;
        }
    }
}
