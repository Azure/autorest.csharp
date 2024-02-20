// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure;
using Azure.Core;

namespace _Type.Property.AdditionalProperties.Models
{
    [PersistableModelProxy(typeof(UnknownExtendsUnknownAdditionalPropertiesDiscriminated))]
    public partial class ExtendsUnknownAdditionalPropertiesDiscriminated : IUtf8JsonSerializable, IJsonModel<ExtendsUnknownAdditionalPropertiesDiscriminated>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<ExtendsUnknownAdditionalPropertiesDiscriminated>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<ExtendsUnknownAdditionalPropertiesDiscriminated>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ExtendsUnknownAdditionalPropertiesDiscriminated>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ExtendsUnknownAdditionalPropertiesDiscriminated)} does not support '{format}' format.");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("name"u8);
            writer.WriteStringValue(Name);
            writer.WritePropertyName("kind"u8);
            writer.WriteStringValue(Kind);
            foreach (var item in AdditionalProperties)
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
            writer.WriteEndObject();
        }

        ExtendsUnknownAdditionalPropertiesDiscriminated IJsonModel<ExtendsUnknownAdditionalPropertiesDiscriminated>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ExtendsUnknownAdditionalPropertiesDiscriminated>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ExtendsUnknownAdditionalPropertiesDiscriminated)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeExtendsUnknownAdditionalPropertiesDiscriminated(document.RootElement, options);
        }

        internal static ExtendsUnknownAdditionalPropertiesDiscriminated DeserializeExtendsUnknownAdditionalPropertiesDiscriminated(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            if (element.TryGetProperty("kind", out JsonElement discriminator))
            {
                switch (discriminator.GetString())
                {
                    case "derived": return ExtendsUnknownAdditionalPropertiesDiscriminatedDerived.DeserializeExtendsUnknownAdditionalPropertiesDiscriminatedDerived(element, options);
                }
            }
            return UnknownExtendsUnknownAdditionalPropertiesDiscriminated.DeserializeUnknownExtendsUnknownAdditionalPropertiesDiscriminated(element, options);
        }

        BinaryData IPersistableModel<ExtendsUnknownAdditionalPropertiesDiscriminated>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ExtendsUnknownAdditionalPropertiesDiscriminated>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(ExtendsUnknownAdditionalPropertiesDiscriminated)} does not support '{options.Format}' format.");
            }
        }

        ExtendsUnknownAdditionalPropertiesDiscriminated IPersistableModel<ExtendsUnknownAdditionalPropertiesDiscriminated>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ExtendsUnknownAdditionalPropertiesDiscriminated>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeExtendsUnknownAdditionalPropertiesDiscriminated(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(ExtendsUnknownAdditionalPropertiesDiscriminated)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<ExtendsUnknownAdditionalPropertiesDiscriminated>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static ExtendsUnknownAdditionalPropertiesDiscriminated FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeExtendsUnknownAdditionalPropertiesDiscriminated(document.RootElement);
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
