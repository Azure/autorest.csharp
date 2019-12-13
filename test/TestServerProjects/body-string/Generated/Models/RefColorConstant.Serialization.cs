// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace body_string.Models.V100
{
    public partial class RefColorConstantSerializer
    {
        internal static void Serialize(RefColorConstant model, Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (model.Field1 != null)
            {
                writer.WritePropertyName("field1");
                writer.WriteStringValue(model.Field1);
            }
            writer.WriteEndObject();
        }
        internal static RefColorConstant Deserialize(JsonElement element)
        {
            var result = new RefColorConstant();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("field1"))
                {
                    result.Field1 = property.Value.GetString();
                    continue;
                }
            }
            return result;
        }
    }
}
