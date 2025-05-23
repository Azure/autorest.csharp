// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Xml;
using System.Xml.Linq;
using Azure;
using Azure.Core;

namespace TypeSchemaMapping.Models
{
    public partial class ModelWithCustomUsage : IUtf8JsonSerializable, IJsonModel<ModelWithCustomUsage>, IXmlSerializable
    {
        private void WriteInternal(XmlWriter writer, string nameHint, ModelReaderWriterOptions options)
        {
            writer.WriteStartElement(nameHint ?? "ModelWithCustomUsage");
            if (Optional.IsDefined(ModelProperty))
            {
                writer.WriteStartElement("ModelProperty");
                writer.WriteValue(ModelProperty);
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }

        void IXmlSerializable.Write(XmlWriter writer, string nameHint) => WriteInternal(writer, nameHint, ModelSerializationExtensions.WireOptions);

        internal static ModelWithCustomUsage DeserializeModelWithCustomUsage(XElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            string modelProperty = default;
            if (element.Element("ModelProperty") is XElement modelPropertyElement)
            {
                modelProperty = (string)modelPropertyElement;
            }
            return new ModelWithCustomUsage(modelProperty, serializedAdditionalRawData: null);
        }

        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<ModelWithCustomUsage>)this).Write(writer, ModelSerializationExtensions.WireOptions);

        void IJsonModel<ModelWithCustomUsage>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ModelWithCustomUsage>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ModelWithCustomUsage)} does not support writing '{format}' format.");
            }

            if (Optional.IsDefined(ModelProperty))
            {
                writer.WritePropertyName("ModelProperty"u8);
                writer.WriteStringValue(ModelProperty);
            }
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

        ModelWithCustomUsage IJsonModel<ModelWithCustomUsage>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ModelWithCustomUsage>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ModelWithCustomUsage)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeModelWithCustomUsage(document.RootElement, options);
        }

        internal static ModelWithCustomUsage DeserializeModelWithCustomUsage(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string modelProperty = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("ModelProperty"u8))
                {
                    modelProperty = property.Value.GetString();
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new ModelWithCustomUsage(modelProperty, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<ModelWithCustomUsage>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ModelWithCustomUsage>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, TypeSchemaMappingContext.Default);
                case "X":
                    {
                        using MemoryStream stream = new MemoryStream();
                        using XmlWriter writer = XmlWriter.Create(stream);
                        WriteInternal(writer, null, options);
                        writer.Flush();
                        return new BinaryData(stream.GetBuffer().AsMemory(0, (int)stream.Position));
                    }
                default:
                    throw new FormatException($"The model {nameof(ModelWithCustomUsage)} does not support writing '{options.Format}' format.");
            }
        }

        ModelWithCustomUsage IPersistableModel<ModelWithCustomUsage>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ModelWithCustomUsage>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
                        return DeserializeModelWithCustomUsage(document.RootElement, options);
                    }
                case "X":
                    return DeserializeModelWithCustomUsage(XElement.Load(data.ToStream()), options);
                default:
                    throw new FormatException($"The model {nameof(ModelWithCustomUsage)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<ModelWithCustomUsage>.GetFormatFromOptions(ModelReaderWriterOptions options) => "X";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static ModelWithCustomUsage FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content, ModelSerializationExtensions.JsonDocumentOptions);
            return DeserializeModelWithCustomUsage(document.RootElement);
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
