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
    [PersistableModelProxy(typeof(UnknownIsUnknownAdditionalPropertiesDiscriminated))]
    public partial class IsUnknownAdditionalPropertiesDiscriminated : IUtf8JsonSerializable, IJsonModel<IsUnknownAdditionalPropertiesDiscriminated>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<IsUnknownAdditionalPropertiesDiscriminated>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<IsUnknownAdditionalPropertiesDiscriminated>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<IsUnknownAdditionalPropertiesDiscriminated>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new InvalidOperationException($"The model {nameof(IsUnknownAdditionalPropertiesDiscriminated)} does not support '{format}' format.");
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

        IsUnknownAdditionalPropertiesDiscriminated IJsonModel<IsUnknownAdditionalPropertiesDiscriminated>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<IsUnknownAdditionalPropertiesDiscriminated>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new InvalidOperationException($"The model {nameof(IsUnknownAdditionalPropertiesDiscriminated)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeIsUnknownAdditionalPropertiesDiscriminated(document.RootElement, options);
        }

        internal static IsUnknownAdditionalPropertiesDiscriminated DeserializeIsUnknownAdditionalPropertiesDiscriminated(JsonElement element, ModelReaderWriterOptions options = null)
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
                    case "derived": return IsUnknownAdditionalPropertiesDiscriminatedDerived.DeserializeIsUnknownAdditionalPropertiesDiscriminatedDerived(element);
                }
            }
            return UnknownIsUnknownAdditionalPropertiesDiscriminated.DeserializeUnknownIsUnknownAdditionalPropertiesDiscriminated(element);
        }

        BinaryData IPersistableModel<IsUnknownAdditionalPropertiesDiscriminated>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<IsUnknownAdditionalPropertiesDiscriminated>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new InvalidOperationException($"The model {nameof(IsUnknownAdditionalPropertiesDiscriminated)} does not support '{options.Format}' format.");
            }
        }

        IsUnknownAdditionalPropertiesDiscriminated IPersistableModel<IsUnknownAdditionalPropertiesDiscriminated>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<IsUnknownAdditionalPropertiesDiscriminated>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeIsUnknownAdditionalPropertiesDiscriminated(document.RootElement, options);
                    }
                default:
                    throw new InvalidOperationException($"The model {nameof(IsUnknownAdditionalPropertiesDiscriminated)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<IsUnknownAdditionalPropertiesDiscriminated>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static IsUnknownAdditionalPropertiesDiscriminated FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeIsUnknownAdditionalPropertiesDiscriminated(document.RootElement);
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
