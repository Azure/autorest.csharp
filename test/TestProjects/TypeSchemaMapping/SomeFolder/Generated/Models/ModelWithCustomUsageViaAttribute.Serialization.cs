// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Xml;
using System.Xml.Linq;
using Azure.Core;

namespace TypeSchemaMapping.Models
{
    public partial class ModelWithCustomUsageViaAttribute : IUtf8JsonSerializable, IJsonModel<ModelWithCustomUsageViaAttribute>, IXmlSerializable, IPersistableModel<ModelWithCustomUsageViaAttribute>
    {
        void IXmlSerializable.Write(XmlWriter writer, string nameHint)
        {
            writer.WriteStartElement(nameHint ?? "ModelWithCustomUsageViaAttribute");
            if (Optional.IsDefined(ModelProperty))
            {
                writer.WriteStartElement("ModelProperty");
                writer.WriteValue(ModelProperty);
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }

        internal static ModelWithCustomUsageViaAttribute DeserializeModelWithCustomUsageViaAttribute(XElement element, ModelReaderWriterOptions options = null)
        {
            string modelProperty = default;
            if (element.Element("ModelProperty") is XElement modelPropertyElement)
            {
                modelProperty = (string)modelPropertyElement;
            }
            return new ModelWithCustomUsageViaAttribute(modelProperty, default);
        }

        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<ModelWithCustomUsageViaAttribute>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<ModelWithCustomUsageViaAttribute>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if ((options.Format != "W" || ((IPersistableModel<ModelWithCustomUsageViaAttribute>)this).GetFormatFromOptions(options) != "J") && options.Format != "J")
            {
                throw new InvalidOperationException($"Must use 'J' format when calling the {nameof(IJsonModel<ModelWithCustomUsageViaAttribute>)} interface");
            }

            writer.WriteStartObject();
            if (Optional.IsDefined(ModelProperty))
            {
                writer.WritePropertyName("ModelProperty"u8);
                writer.WriteStringValue(ModelProperty);
            }
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

        ModelWithCustomUsageViaAttribute IJsonModel<ModelWithCustomUsageViaAttribute>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(ModelWithCustomUsageViaAttribute)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeModelWithCustomUsageViaAttribute(document.RootElement, options);
        }

        internal static ModelWithCustomUsageViaAttribute DeserializeModelWithCustomUsageViaAttribute(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> modelProperty = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("ModelProperty"u8))
                {
                    modelProperty = property.Value.GetString();
                    continue;
                }
                if (options.Format == "J")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new ModelWithCustomUsageViaAttribute(modelProperty.Value, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<ModelWithCustomUsageViaAttribute>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(ModelWithCustomUsageViaAttribute)} does not support '{options.Format}' format.");
            }

            if (options.Format == "J")
            {
                return ModelReaderWriter.Write(this, options);
            }
            else
            {
                using MemoryStream stream = new MemoryStream();
                using XmlWriter writer = XmlWriter.Create(stream);
                ((IXmlSerializable)this).Write(writer, null);
                writer.Flush();
                if (stream.Position > int.MaxValue)
                {
                    return BinaryData.FromStream(stream);
                }
                else
                {
                    return new BinaryData(stream.GetBuffer().AsMemory(0, (int)stream.Position));
                }
            }
        }

        ModelWithCustomUsageViaAttribute IPersistableModel<ModelWithCustomUsageViaAttribute>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(ModelWithCustomUsageViaAttribute)} does not support '{options.Format}' format.");
            }

            if (options.Format == "J")
            {
                using JsonDocument document = JsonDocument.Parse(data);
                return DeserializeModelWithCustomUsageViaAttribute(document.RootElement, options);
            }
            else
            {
                return DeserializeModelWithCustomUsageViaAttribute(XElement.Load(data.ToStream()), options);
            }
        }

        string IPersistableModel<ModelWithCustomUsageViaAttribute>.GetFormatFromOptions(ModelReaderWriterOptions options) => "X";
    }
}
