// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure;
using Azure.Core;

namespace ModelsTypeSpec.Models
{
    [PersistableModelProxy(typeof(UnknownBaseModelWithDiscriminator))]
    public partial class BaseModelWithDiscriminator : IUtf8JsonSerializable, IJsonModel<BaseModelWithDiscriminator>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<BaseModelWithDiscriminator>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<BaseModelWithDiscriminator>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if ((options.Format != "W" || ((IPersistableModel<BaseModelWithDiscriminator>)this).GetFormatFromOptions(options) != "J") && options.Format != "J")
            {
                throw new InvalidOperationException($"Must use 'J' format when calling the {nameof(IJsonModel<BaseModelWithDiscriminator>)} interface");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("discriminatorProperty"u8);
            writer.WriteStringValue(DiscriminatorProperty);
            if (Optional.IsDefined(OptionalPropertyOnBase))
            {
                writer.WritePropertyName("optionalPropertyOnBase"u8);
                writer.WriteStringValue(OptionalPropertyOnBase);
            }
            writer.WritePropertyName("requiredPropertyOnBase"u8);
            writer.WriteNumberValue(RequiredPropertyOnBase);
            if (_serializedAdditionalRawData != null && options.Format == "J")
            {
                foreach (var item in _serializedAdditionalRawData)
                {
                    writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(item.Value);
#else
                    using (JsonDocument document = JsonDocument.Parse(item.Value))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
            }
            writer.WriteEndObject();
        }

        BaseModelWithDiscriminator IJsonModel<BaseModelWithDiscriminator>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(BaseModelWithDiscriminator)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeBaseModelWithDiscriminator(document.RootElement, options);
        }

        internal static BaseModelWithDiscriminator DeserializeBaseModelWithDiscriminator(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            if (element.TryGetProperty("discriminatorProperty", out JsonElement discriminator))
            {
                switch (discriminator.GetString())
                {
                    case "A": return DerivedModelWithDiscriminatorA.DeserializeDerivedModelWithDiscriminatorA(element);
                    case "B": return DerivedModelWithDiscriminatorB.DeserializeDerivedModelWithDiscriminatorB(element);
                }
            }
            return UnknownBaseModelWithDiscriminator.DeserializeUnknownBaseModelWithDiscriminator(element);
        }

        BinaryData IPersistableModel<BaseModelWithDiscriminator>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(BaseModelWithDiscriminator)} does not support '{options.Format}' format.");
            }

            return ModelReaderWriter.Write(this, options);
        }

        BaseModelWithDiscriminator IPersistableModel<BaseModelWithDiscriminator>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(BaseModelWithDiscriminator)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeBaseModelWithDiscriminator(document.RootElement, options);
        }

        string IPersistableModel<BaseModelWithDiscriminator>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static BaseModelWithDiscriminator FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeBaseModelWithDiscriminator(document.RootElement, new ModelReaderWriterOptions("W"));
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
