// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace body_dictionary.Models.V100
{
    public partial class Widget : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Integer != null)
            {
                writer.WritePropertyName("integer");
                writer.WriteNumberValue(Integer.Value);
            }
            if (String != null)
            {
                writer.WritePropertyName("string");
                writer.WriteStringValue(String);
            }
            writer.WriteEndObject();
        }
        internal static Widget DeserializeWidget(JsonElement element)
        {
            var result = new Widget();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("integer"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Integer = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("string"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.String = property.Value.GetString();
                    continue;
                }
            }
            return result;
        }
    }
}
