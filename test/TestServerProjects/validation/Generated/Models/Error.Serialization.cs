// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace validation.Models.V100
{
    public partial class ErrorSerializer
    {
        internal static void Serialize(Error model, Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (model.Code != null)
            {
                writer.WritePropertyName("code");
                writer.WriteNumberValue(model.Code.Value);
            }
            if (model.Message != null)
            {
                writer.WritePropertyName("message");
                writer.WriteStringValue(model.Message);
            }
            if (model.Fields != null)
            {
                writer.WritePropertyName("fields");
                writer.WriteStringValue(model.Fields);
            }
            writer.WriteEndObject();
        }
        internal static Error Deserialize(JsonElement element)
        {
            var result = new Error();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("code"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Code = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("message"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Message = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("fields"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Fields = property.Value.GetString();
                    continue;
                }
            }
            return result;
        }
    }
}
