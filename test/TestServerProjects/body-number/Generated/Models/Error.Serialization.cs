// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace body_number.Models.V100
{
    public partial class ErrorSerializer
    {
        internal static void Serialize(Error model, Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (model.Status != null)
            {
                writer.WritePropertyName("status");
                writer.WriteNumberValue(model.Status.Value);
            }
            if (model.Message != null)
            {
                writer.WritePropertyName("message");
                writer.WriteStringValue(model.Message);
            }
            writer.WriteEndObject();
        }
        internal static Error Deserialize(JsonElement element)
        {
            var result = new Error();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("status"))
                {
                    result.Status = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("message"))
                {
                    result.Message = property.Value.GetString();
                    continue;
                }
            }
            return result;
        }
    }
}
