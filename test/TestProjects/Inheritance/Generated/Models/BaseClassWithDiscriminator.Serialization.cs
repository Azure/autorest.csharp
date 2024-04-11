// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure;
using Azure.Core;

namespace Inheritance.Models
{
    public partial class BaseClassWithDiscriminator : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("DiscriminatorProperty"u8);
            writer.WriteStringValue(DiscriminatorProperty);
            if (Optional.IsDefined(BaseClassProperty))
            {
                writer.WritePropertyName("BaseClassProperty"u8);
                writer.WriteStringValue(BaseClassProperty);
            }
            if (Optional.IsDefined(DfeString))
            {
                writer.WritePropertyName("DfeString"u8);
                JsonSerializer.Serialize(writer, DfeString);
            }
            if (Optional.IsDefined(DfeDouble))
            {
                writer.WritePropertyName("DfeDouble"u8);
                JsonSerializer.Serialize(writer, DfeDouble);
            }
            if (Optional.IsDefined(DfeBool))
            {
                writer.WritePropertyName("DfeBool"u8);
                JsonSerializer.Serialize(writer, DfeBool);
            }
            if (Optional.IsDefined(DfeInt))
            {
                writer.WritePropertyName("DfeInt"u8);
                JsonSerializer.Serialize(writer, DfeInt);
            }
            if (Optional.IsDefined(DfeObject))
            {
                writer.WritePropertyName("DfeObject"u8);
                JsonSerializer.Serialize(writer, DfeObject);
            }
            if (Optional.IsDefined(DfeListOfT))
            {
                writer.WritePropertyName("DfeListOfT"u8);
                JsonSerializer.Serialize(writer, DfeListOfT);
            }
            if (Optional.IsDefined(DfeListOfString))
            {
                writer.WritePropertyName("DfeListOfString"u8);
                JsonSerializer.Serialize(writer, DfeListOfString);
            }
            if (Optional.IsDefined(DfeKeyValuePairs))
            {
                writer.WritePropertyName("DfeKeyValuePairs"u8);
                JsonSerializer.Serialize(writer, DfeKeyValuePairs);
            }
            if (Optional.IsDefined(DfeDateTime))
            {
                writer.WritePropertyName("DfeDateTime"u8);
                JsonSerializer.Serialize(writer, DfeDateTime);
            }
            if (Optional.IsDefined(DfeDuration))
            {
                writer.WritePropertyName("DfeDuration"u8);
                JsonSerializer.Serialize(writer, DfeDuration);
            }
            if (Optional.IsDefined(DfeUri))
            {
                writer.WritePropertyName("DfeUri"u8);
                JsonSerializer.Serialize(writer, DfeUri);
            }
            writer.WriteEndObject();
        }

        internal static BaseClassWithDiscriminator DeserializeBaseClassWithDiscriminator(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            if (element.TryGetProperty("DiscriminatorProperty", out JsonElement discriminator))
            {
                switch (discriminator.GetString())
                {
                    case "ClassThatInheritsFromBaseClassWithDiscriminator": return ClassThatInheritsFromBaseClassWithDiscriminator.DeserializeClassThatInheritsFromBaseClassWithDiscriminator(element);
                    case "ClassThatInheritsFromBaseClassWithDiscriminatorAndSomeProperties": return ClassThatInheritsFromBaseClassWithDiscriminatorAndSomeProperties.DeserializeClassThatInheritsFromBaseClassWithDiscriminatorAndSomeProperties(element);
                }
            }
            return UnknownBaseClassWithDiscriminator.DeserializeUnknownBaseClassWithDiscriminator(element);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static new BaseClassWithDiscriminator FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeBaseClassWithDiscriminator(document.RootElement);
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
