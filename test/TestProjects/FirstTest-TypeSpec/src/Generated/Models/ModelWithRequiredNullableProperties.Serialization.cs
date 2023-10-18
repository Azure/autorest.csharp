// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure;
using Azure.Core;

namespace FirstTestTypeSpec.Models
{
    public partial class ModelWithRequiredNullableProperties : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (RequiredNullablePrimitive != null)
            {
                writer.WritePropertyName("requiredNullablePrimitive"u8);
                writer.WriteNumberValue(RequiredNullablePrimitive.Value);
            }
            else
            {
                writer.WriteNull("requiredNullablePrimitive");
            }
            if (RequiredExtensibleEnum != null)
            {
                writer.WritePropertyName("requiredExtensibleEnum"u8);
                writer.WriteStringValue(RequiredExtensibleEnum.Value.ToString());
            }
            else
            {
                writer.WriteNull("requiredExtensibleEnum");
            }
            if (RequiredFixedEnum != null)
            {
                writer.WritePropertyName("requiredFixedEnum"u8);
                writer.WriteStringValue(RequiredFixedEnum.Value.ToSerialString());
            }
            else
            {
                writer.WriteNull("requiredFixedEnum");
            }
            writer.WriteEndObject();
        }

        internal static ModelWithRequiredNullableProperties DeserializeModelWithRequiredNullableProperties(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            int? requiredNullablePrimitive = default;
            StringExtensibleEnum? requiredExtensibleEnum = default;
            StringFixedEnum? requiredFixedEnum = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("requiredNullablePrimitive"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        requiredNullablePrimitive = null;
                        continue;
                    }
                    requiredNullablePrimitive = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("requiredExtensibleEnum"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        requiredExtensibleEnum = null;
                        continue;
                    }
                    requiredExtensibleEnum = new StringExtensibleEnum(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("requiredFixedEnum"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        requiredFixedEnum = null;
                        continue;
                    }
                    requiredFixedEnum = property.Value.GetString().ToStringFixedEnum();
                    continue;
                }
            }
            return new ModelWithRequiredNullableProperties(requiredNullablePrimitive, requiredExtensibleEnum, requiredFixedEnum);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static ModelWithRequiredNullableProperties FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeModelWithRequiredNullableProperties(document.RootElement);
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
