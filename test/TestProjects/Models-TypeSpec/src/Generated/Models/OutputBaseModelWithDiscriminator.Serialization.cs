// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using Azure;
using Azure.Core;
using Azure.Core.Serialization;

namespace ModelsTypeSpec.Models
{
    public partial class OutputBaseModelWithDiscriminator : IUtf8JsonSerializable, IModelJsonSerializable<OutputBaseModelWithDiscriminator>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<OutputBaseModelWithDiscriminator>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<OutputBaseModelWithDiscriminator>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("kind"u8);
            writer.WriteStringValue(Kind);
            if (_serializedAdditionalRawData != null && options.Format == ModelSerializerFormat.Json)
            {
                foreach (var item in _serializedAdditionalRawData)
                {
                    writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(item.Value);
#else
                    JsonSerializer.Serialize(writer, JsonDocument.Parse(item.Value.ToString()).RootElement);
#endif
                }
            }
            writer.WriteEndObject();
        }

        OutputBaseModelWithDiscriminator IModelJsonSerializable<OutputBaseModelWithDiscriminator>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeOutputBaseModelWithDiscriminator(document.RootElement, options);
        }

        BinaryData IModelSerializable<OutputBaseModelWithDiscriminator>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);
            return ModelSerializer.SerializeCore(this, options);
        }

        OutputBaseModelWithDiscriminator IModelSerializable<OutputBaseModelWithDiscriminator>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeOutputBaseModelWithDiscriminator(document.RootElement, options);
        }

        internal static OutputBaseModelWithDiscriminator DeserializeOutputBaseModelWithDiscriminator(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            if (element.TryGetProperty("kind", out JsonElement discriminator))
            {
                switch (discriminator.GetString())
                {
                    case "first": return FirstDerivedOutputModel.DeserializeFirstDerivedOutputModel(element);
                    case "second": return SecondDerivedOutputModel.DeserializeSecondDerivedOutputModel(element);
                }
            }
            return UnknownOutputBaseModelWithDiscriminator.DeserializeUnknownOutputBaseModelWithDiscriminator(element);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static OutputBaseModelWithDiscriminator FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeOutputBaseModelWithDiscriminator(document.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }

        /// <summary> Convert into a Utf8JsonRequestContent. </summary>
        internal virtual RequestContent ToRequestContent()
        {
            return RequestContent.Create(this, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
