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

namespace Versioning.Removed.BetaVersion.Models
{
    public partial class ModelV2 : IUtf8JsonSerializable, IJsonModel<ModelV2>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<ModelV2>)this).Write(writer, ModelSerializationExtensions.WireOptions);

        void IJsonModel<ModelV2>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ModelV2>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ModelV2)} does not support writing '{format}' format.");
            }

            writer.WritePropertyName("prop"u8);
            writer.WriteStringValue(Prop);
            writer.WritePropertyName("removedProp"u8);
            writer.WriteStringValue(RemovedProp);
            writer.WritePropertyName("enumProp"u8);
            writer.WriteStringValue(EnumProp.ToSerialString());
            writer.WritePropertyName("unionProp"u8);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(UnionProp);
#else
            using (JsonDocument document = JsonDocument.Parse(UnionProp, ModelSerializationExtensions.JsonDocumentOptions))
            {
                JsonSerializer.Serialize(writer, document.RootElement);
            }
#endif
            if (options.Format != "W" && _serializedAdditionalRawData != null)
            {
                foreach (var item in _serializedAdditionalRawData)
                {
                    writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(item.Value);
#else
                    using (JsonDocument document = JsonDocument.Parse(item.Value, ModelSerializationExtensions.JsonDocumentOptions))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
            }
        }

        ModelV2 IJsonModel<ModelV2>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ModelV2>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ModelV2)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeModelV2(document.RootElement, options);
        }

        internal static ModelV2 DeserializeModelV2(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string prop = default;
            string removedProp = default;
            EnumV2 enumProp = default;
            BinaryData unionProp = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("prop"u8))
                {
                    prop = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("removedProp"u8))
                {
                    removedProp = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("enumProp"u8))
                {
                    enumProp = property.Value.GetString().ToEnumV2();
                    continue;
                }
                if (property.NameEquals("unionProp"u8))
                {
                    unionProp = BinaryData.FromString(property.Value.GetRawText());
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new ModelV2(prop, removedProp, enumProp, unionProp, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<ModelV2>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ModelV2>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, VersioningRemovedBetaVersionContext.Default);
                default:
                    throw new FormatException($"The model {nameof(ModelV2)} does not support writing '{options.Format}' format.");
            }
        }

        ModelV2 IPersistableModel<ModelV2>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ModelV2>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
                        return DeserializeModelV2(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(ModelV2)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<ModelV2>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static ModelV2 FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content, ModelSerializationExtensions.JsonDocumentOptions);
            return DeserializeModelV2(document.RootElement);
        }

        /// <summary> Convert into a <see cref="RequestContent"/>. </summary>
        internal virtual RequestContent ToRequestContent()
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(this, ModelSerializationExtensions.WireOptions);
            return content;
        }
    }
}
