// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure;
using Azure.Core;

namespace ModelsInCadl
{
    public partial class DerivedModelWithDiscriminatorB : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("requiredInt");
            writer.WriteNumberValue(RequiredInt);
            writer.WriteEndObject();
        }

        internal static DerivedModelWithDiscriminatorB DeserializeDerivedModelWithDiscriminatorB(JsonElement element)
        {
            int requiredInt = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("requiredInt"))
                {
                    requiredInt = property.Value.GetInt32();
                    continue;
                }
            }
            return new DerivedModelWithDiscriminatorB(requiredInt);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal new static DerivedModelWithDiscriminatorB FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeDerivedModelWithDiscriminatorB(document.RootElement);
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
