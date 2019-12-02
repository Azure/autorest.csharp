// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;

namespace body_complex.Models.V20160229
{
    public partial class Sawshark
    {
        internal void Serialize(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Picture != null)
            {
                writer.WritePropertyName("picture");
                writer.WriteNullValue();
            }
            writer.WriteEndObject();
        }
        internal static Sawshark Deserialize(JsonElement element)
        {
            var result = new Sawshark();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("picture"))
                {
                    result.Picture = null;
                    continue;
                }
            }
            return result;
        }
    }
}
