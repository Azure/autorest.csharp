// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure;
using Azure.Core;
using Azure.Core.Serialization;

namespace ModelsTypeSpec.Models
{
    public partial class DerivedModelWithDiscriminatorB : IUtf8JsonSerializable, IModelSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelSerializable)this).Serialize(writer, new SerializableOptions());

        void IModelSerializable.Serialize(Utf8JsonWriter writer, SerializableOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("requiredInt"u8);
            writer.WriteNumberValue(RequiredInt);
            writer.WritePropertyName("discriminatorProperty"u8);
            writer.WriteStringValue(DiscriminatorProperty);
            if (Optional.IsDefined(OptionalPropertyOnBase))
            {
                writer.WritePropertyName("optionalPropertyOnBase"u8);
                writer.WriteStringValue(OptionalPropertyOnBase);
            }
            writer.WritePropertyName("requiredPropertyOnBase"u8);
            writer.WriteNumberValue(RequiredPropertyOnBase);
            writer.WriteEndObject();
        }

        internal static DerivedModelWithDiscriminatorB DeserializeDerivedModelWithDiscriminatorB(JsonElement element, SerializableOptions options = default)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            int requiredInt = default;
            string discriminatorProperty = default;
            Optional<string> optionalPropertyOnBase = default;
            int requiredPropertyOnBase = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("requiredInt"u8))
                {
                    requiredInt = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("discriminatorProperty"u8))
                {
                    discriminatorProperty = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("optionalPropertyOnBase"u8))
                {
                    optionalPropertyOnBase = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("requiredPropertyOnBase"u8))
                {
                    requiredPropertyOnBase = property.Value.GetInt32();
                    continue;
                }
            }
            return new DerivedModelWithDiscriminatorB(discriminatorProperty, optionalPropertyOnBase.Value, requiredPropertyOnBase, requiredInt);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static new DerivedModelWithDiscriminatorB FromResponse(Response response)
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
