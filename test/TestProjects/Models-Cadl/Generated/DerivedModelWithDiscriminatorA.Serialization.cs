// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure;
using Azure.Core;

namespace ModelsInCadl
{
    public partial class DerivedModelWithDiscriminatorA : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("requiredString");
            writer.WriteStringValue(RequiredString);
            writer.WriteEndObject();
        }

        internal static DerivedModelWithDiscriminatorA DeserializeDerivedModelWithDiscriminatorA(JsonElement element)
        {
            string requiredString = default;
            string discriminatorProperty = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("requiredString"))
                {
                    requiredString = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("discriminatorProperty"))
                {
                    discriminatorProperty = property.Value.GetString();
                    continue;
                }
            }
            return new DerivedModelWithDiscriminatorA(requiredString);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal new static DerivedModelWithDiscriminatorA FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeDerivedModelWithDiscriminatorA(document.RootElement);
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
