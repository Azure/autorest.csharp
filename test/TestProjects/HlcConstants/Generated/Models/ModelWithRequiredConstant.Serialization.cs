// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure;
using Azure.Core;

namespace HlcConstants.Models
{
    public partial class ModelWithRequiredConstant : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("requiredStringConstant"u8);
            writer.WriteStringValue(RequiredStringConstant.ToString());
            writer.WritePropertyName("requiredIntConstant"u8);
            writer.WriteNumberValue(RequiredIntConstant.ToSerialInt32());
            writer.WritePropertyName("requiredBooleanConstant"u8);
            writer.WriteBooleanValue(RequiredBooleanConstant);
            writer.WritePropertyName("requiredFloatConstant"u8);
            writer.WriteNumberValue(RequiredFloatConstant.ToSerialSingle());
            writer.WriteEndObject();
        }

        internal static ModelWithRequiredConstant DeserializeModelWithRequiredConstant(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            StringConstant requiredStringConstant = default;
            IntConstant requiredIntConstant = default;
            bool requiredBooleanConstant = default;
            FloatConstant requiredFloatConstant = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("requiredStringConstant"u8))
                {
                    requiredStringConstant = new StringConstant(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("requiredIntConstant"u8))
                {
                    requiredIntConstant = new IntConstant(property.Value.GetInt32());
                    continue;
                }
                if (property.NameEquals("requiredBooleanConstant"u8))
                {
                    requiredBooleanConstant = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("requiredFloatConstant"u8))
                {
                    requiredFloatConstant = new FloatConstant(property.Value.GetSingle());
                    continue;
                }
            }
            return new ModelWithRequiredConstant(requiredStringConstant, requiredIntConstant, requiredBooleanConstant, requiredFloatConstant);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static ModelWithRequiredConstant FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content, ModelSerializationExtensions.JsonDocumentOptions);
            return DeserializeModelWithRequiredConstant(document.RootElement);
        }

        /// <summary> Convert into a <see cref="RequestContent"/>. </summary>
        internal virtual RequestContent ToRequestContent()
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(this);
            return content;
        }
    }
}
