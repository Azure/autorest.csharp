// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure;
using Azure.Core;

namespace _Type.Model.Usage.Models
{
    public partial class InputOutputRecord : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("requiredProp"u8);
            writer.WriteStringValue(RequiredProp);
            writer.WriteEndObject();
        }

        internal static InputOutputRecord DeserializeInputOutputRecord(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string requiredProp = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("requiredProp"u8))
                {
                    requiredProp = property.Value.GetString();
                    continue;
                }
            }
            return new InputOutputRecord(requiredProp);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static InputOutputRecord FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeInputOutputRecord(document.RootElement);
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
