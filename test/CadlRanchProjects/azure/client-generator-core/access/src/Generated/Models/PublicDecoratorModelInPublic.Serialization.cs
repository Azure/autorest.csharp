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

namespace _Specs_.Azure.ClientGenerator.Core.Access.Models
{
    public partial class PublicDecoratorModelInPublic : IUtf8JsonSerializable, IJsonModel<PublicDecoratorModelInPublic>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<PublicDecoratorModelInPublic>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<PublicDecoratorModelInPublic>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<PublicDecoratorModelInPublic>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new InvalidOperationException($"The model {nameof(PublicDecoratorModelInPublic)} does not support '{format}' format.");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("name"u8);
            writer.WriteStringValue(Name);
            if (options.Format != "W" && _serializedAdditionalRawData != null)
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

        PublicDecoratorModelInPublic IJsonModel<PublicDecoratorModelInPublic>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<PublicDecoratorModelInPublic>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new InvalidOperationException($"The model {nameof(PublicDecoratorModelInPublic)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializePublicDecoratorModelInPublic(document.RootElement, options);
        }

        internal static PublicDecoratorModelInPublic DeserializePublicDecoratorModelInPublic(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string name = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new PublicDecoratorModelInPublic(name, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<PublicDecoratorModelInPublic>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<PublicDecoratorModelInPublic>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new InvalidOperationException($"The model {nameof(PublicDecoratorModelInPublic)} does not support '{options.Format}' format.");
            }
        }

        PublicDecoratorModelInPublic IPersistableModel<PublicDecoratorModelInPublic>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<PublicDecoratorModelInPublic>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializePublicDecoratorModelInPublic(document.RootElement, options);
                    }
                default:
                    throw new InvalidOperationException($"The model {nameof(PublicDecoratorModelInPublic)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<PublicDecoratorModelInPublic>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static PublicDecoratorModelInPublic FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializePublicDecoratorModelInPublic(document.RootElement, new ModelReaderWriterOptions("W"));
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
