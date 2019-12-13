// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace body_complex.Models.V20160229
{
    public partial class StringWrapperSerializer
    {
        internal static void Serialize(StringWrapper model, Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (model.Field != null)
            {
                writer.WritePropertyName("field");
                writer.WriteStringValue(model.Field);
            }
            if (model.Empty != null)
            {
                writer.WritePropertyName("empty");
                writer.WriteStringValue(model.Empty);
            }
            if (model.NullProperty != null)
            {
                writer.WritePropertyName("null");
                writer.WriteStringValue(model.NullProperty);
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
