// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure;
using Azure.Core;

namespace SpecialWords.Models
{
    public partial class BaseModel : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("model.kind"u8);
            writer.WriteStringValue(ModelKind);
            writer.WriteEndObject();
        }

        internal static BaseModel DeserializeBaseModel(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            if (element.TryGetProperty("model.kind", out JsonElement discriminator))
            {
                switch (discriminator.GetString())
                {
                    case "derived": return DerivedModel.DeserializeDerivedModel(element);
                }
            }
            return UnknownBaseModel.DeserializeUnknownBaseModel(element);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static BaseModel FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeBaseModel(document.RootElement);
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
