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
            writer.WritePropertyName("discriminatorProperty");
            writer.WriteStringValue(DiscriminatorProperty);
            writer.WritePropertyName("requiredString");
            writer.WriteStringValue(RequiredString);
            writer.WriteEndObject();
        }

        internal static DerivedModelWithDiscriminatorA DeserializeDerivedModelWithDiscriminatorA(JsonElement element)
        {
            string discriminatorProperty = default;
            string requiredString = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("discriminatorProperty"))
                {
                    discriminatorProperty = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("requiredString"))
                {
                    requiredString = property.Value.GetString();
                    continue;
                }
            }
            return new DerivedModelWithDiscriminatorA(discriminatorProperty, requiredString);
        }

        internal RequestContent ToRequestContent()
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(this);
            return content;
        }

        internal static DerivedModelWithDiscriminatorA FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeDerivedModelWithDiscriminatorA(document.RootElement);
        }
    }
}
