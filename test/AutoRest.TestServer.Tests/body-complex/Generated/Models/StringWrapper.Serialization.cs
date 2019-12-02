// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace body_complex.Models.V20160229
{
    public partial class StringWrapper
    {
        internal void Serialize(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Field != null)
            {
                writer.WritePropertyName("field");
                writer.WriteStringValue(Field);
            }
            if (Empty != null)
            {
                writer.WritePropertyName("empty");
                writer.WriteStringValue(Empty);
            }
            if (NullProperty != null)
            {
                writer.WritePropertyName("null");
                writer.WriteStringValue(NullProperty);
            }
            writer.WriteEndObject();
        }
        internal static StringWrapper Deserialize(JsonElement element)
        {
            var result = new StringWrapper();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("field"))
                {
                    result.Field = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("empty"))
                {
                    result.Empty = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("null"))
                {
                    result.NullProperty = property.Value.GetString();
                    continue;
                }
            }
            return result;
        }
    }
}
