// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace custom_baseUrl.Models.V100
{
    public partial class Error
    {
        internal void Serialize(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Status != null)
            {
                writer.WritePropertyName("status");
                writer.WriteNumberValue(Status.Value);
            }
            if (Message != null)
            {
                writer.WritePropertyName("message");
                writer.WriteStringValue(Message);
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
