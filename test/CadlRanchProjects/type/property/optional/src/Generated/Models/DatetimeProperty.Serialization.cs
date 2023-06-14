// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Text.Json;
using Azure;
using Azure.Core;

namespace _Type.Property.Optional.Models
{
    public partial class DatetimeProperty : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Azure.Core.Optional.IsDefined(Property))
            {
                writer.WritePropertyName("property"u8);
                writer.WriteStringValue(Property.Value, "O");
            }
            writer.WriteEndObject();
        }

        internal static DatetimeProperty DeserializeDatetimeProperty(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<DateTimeOffset> property = default;
            foreach (var property0 in element.EnumerateObject())
            {
                if (property0.NameEquals("property"u8))
                {
                    if (property0.Value.ValueKind == JsonValueKind.Null || property0.Value.ValueKind == JsonValueKind.String && property0.Value.GetString().Length == 0)
                    {
                        continue;
                    }
                    property = property0.Value.GetDateTimeOffset("O");
                    continue;
                }
            }
            return new DatetimeProperty(Azure.Core.Optional.ToNullable(property));
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static DatetimeProperty FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeDatetimeProperty(document.RootElement);
        }

        /// <summary> Convert into a Utf8JsonRequestContent. </summary>
        internal virtual RequestContent ToRequestContent()
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(this);
            return content;
        }
    }
}
