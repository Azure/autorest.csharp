// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure;
using Azure.Core;

namespace SpecialWords.Models
{
    public partial class DerivedModel : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("derived.name"u8);
            writer.WriteStringValue(DerivedName);
            writer.WritePropertyName("for"u8);
            writer.WriteStringValue(For);
            writer.WritePropertyName("model.kind"u8);
            writer.WriteStringValue(ModelKind);
            writer.WriteEndObject();
        }

        internal static DerivedModel DeserializeDerivedModel(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string derivedName = default;
            string @for = default;
            string modelKind = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("derived.name"u8))
                {
                    derivedName = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("for"u8))
                {
                    @for = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("model.kind"u8))
                {
                    modelKind = property.Value.GetString();
                    continue;
                }
            }
            return new DerivedModel(modelKind, derivedName, @for);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static new DerivedModel FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeDerivedModel(document.RootElement);
        }

        /// <summary> Convert into a Utf8JsonRequestContent. </summary>
        internal override RequestContent ToRequestContent()
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(this);
            return content;
        }
    }
}
