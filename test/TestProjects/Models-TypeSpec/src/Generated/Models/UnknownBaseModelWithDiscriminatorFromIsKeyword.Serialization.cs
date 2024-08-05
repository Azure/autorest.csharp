// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure;
using Azure.Core;

namespace ModelsTypeSpec.Models
{
    internal partial class UnknownBaseModelWithDiscriminatorFromIsKeyword : IUtf8JsonSerializable, IJsonModel<BaseModelWithDiscriminatorFromIsKeyword>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<BaseModelWithDiscriminatorFromIsKeyword>)this).Write(writer, ModelSerializationExtensions.WireOptions);

        void IJsonModel<BaseModelWithDiscriminatorFromIsKeyword>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<BaseModelWithDiscriminatorFromIsKeyword>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(BaseModelWithDiscriminatorFromIsKeyword)} does not support writing '{format}' format.");
            }

            base.JsonModelWriteCore(writer, options);
            writer.WritePropertyName("kind"u8);
            writer.WriteStringValue(Kind);
            if (Optional.IsDefined(OptionalString))
            {
                writer.WritePropertyName("optionalString"u8);
                writer.WriteStringValue(OptionalString);
            }
        }

        BaseModelWithDiscriminatorFromIsKeyword IJsonModel<BaseModelWithDiscriminatorFromIsKeyword>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<BaseModelWithDiscriminatorFromIsKeyword>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(BaseModelWithDiscriminatorFromIsKeyword)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeBaseModelWithDiscriminatorFromIsKeyword(document.RootElement, options);
        }

        internal static UnknownBaseModelWithDiscriminatorFromIsKeyword DeserializeUnknownBaseModelWithDiscriminatorFromIsKeyword(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string kind = "Unknown";
            string optionalString = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("kind"u8))
                {
                    kind = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("optionalString"u8))
                {
                    optionalString = property.Value.GetString();
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new UnknownBaseModelWithDiscriminatorFromIsKeyword(kind, optionalString, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<BaseModelWithDiscriminatorFromIsKeyword>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<BaseModelWithDiscriminatorFromIsKeyword>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(BaseModelWithDiscriminatorFromIsKeyword)} does not support writing '{options.Format}' format.");
            }
        }

        BaseModelWithDiscriminatorFromIsKeyword IPersistableModel<BaseModelWithDiscriminatorFromIsKeyword>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<BaseModelWithDiscriminatorFromIsKeyword>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeBaseModelWithDiscriminatorFromIsKeyword(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(BaseModelWithDiscriminatorFromIsKeyword)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<BaseModelWithDiscriminatorFromIsKeyword>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static new UnknownBaseModelWithDiscriminatorFromIsKeyword FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeUnknownBaseModelWithDiscriminatorFromIsKeyword(document.RootElement);
        }

        /// <summary> Convert into a <see cref="RequestContent"/>. </summary>
        internal override RequestContent ToRequestContent()
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue<BaseModelWithDiscriminatorFromIsKeyword>(this, ModelSerializationExtensions.WireOptions);
            return content;
        }
    }
}
