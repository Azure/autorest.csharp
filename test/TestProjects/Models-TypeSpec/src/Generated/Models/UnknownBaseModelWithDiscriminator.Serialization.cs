// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure;
using Azure.Core;

namespace ModelsTypeSpec.Models
{
    internal partial class UnknownBaseModelWithDiscriminator : IUtf8JsonSerializable, IJsonModel<BaseModelWithDiscriminator>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<BaseModelWithDiscriminator>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<BaseModelWithDiscriminator>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<BaseModelWithDiscriminator>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new InvalidOperationException($"The model {nameof(BaseModelWithDiscriminator)} does not support '{format}' format.");
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
            if (_serializedAdditionalRawData != null && options.Format != "W")
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
            var format = options.Format == "W" ? ((IPersistableModel<BaseModelWithDiscriminator>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new InvalidOperationException($"The model {nameof(BaseModelWithDiscriminator)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeUnknownBaseModelWithDiscriminator(document.RootElement, options);
        }

        internal static UnknownBaseModelWithDiscriminator DeserializeUnknownBaseModelWithDiscriminator(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string discriminatorProperty = "Unknown";
            Optional<string> optionalPropertyOnBase = default;
            int requiredPropertyOnBase = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
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
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new UnknownBaseModelWithDiscriminator(discriminatorProperty, optionalPropertyOnBase.Value, requiredPropertyOnBase, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<BaseModelWithDiscriminator>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<BaseModelWithDiscriminator>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new InvalidOperationException($"The model {nameof(BaseModelWithDiscriminator)} does not support '{options.Format}' format.");
            }
        }

        BaseModelWithDiscriminator IPersistableModel<BaseModelWithDiscriminator>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<BaseModelWithDiscriminator>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeUnknownBaseModelWithDiscriminator(document.RootElement, options);
                    }
                default:
                    throw new InvalidOperationException($"The model {nameof(BaseModelWithDiscriminator)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<BaseModelWithDiscriminator>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static new UnknownBaseModelWithDiscriminator FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeUnknownBaseModelWithDiscriminator(document.RootElement, new ModelReaderWriterOptions("W"));
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
