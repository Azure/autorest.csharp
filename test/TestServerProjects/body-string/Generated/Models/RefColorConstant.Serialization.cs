// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace body_string.Models.V100
{
    public partial class RefColorConstantSerializer
    {
        internal static void Serialize(RefColorConstant model, Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("ColorConstant");
            writer.WriteStringValue(model.ColorConstant);
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
                if (property.NameEquals("ColorConstant"))
                {
                    result.ColorConstant = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("field1"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Field1 = property.Value.GetString();
                    continue;
                }

            }
            return result;
        }
    }
}
