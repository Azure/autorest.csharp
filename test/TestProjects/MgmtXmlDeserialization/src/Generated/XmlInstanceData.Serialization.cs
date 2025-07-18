// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Xml;
using System.Xml.Linq;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace MgmtXmlDeserialization
{
    public partial class XmlInstanceData : IUtf8JsonSerializable, IJsonModel<XmlInstanceData>, IXmlSerializable
    {
        private void WriteInternal(XmlWriter writer, string nameHint, ModelReaderWriterOptions options)
        {
            writer.WriteStartElement(nameHint ?? "XmlInstance");
            if (options.Format != "W")
            {
                writer.WriteStartElement("id");
                writer.WriteValue(Id);
                writer.WriteEndElement();
            }
            if (options.Format != "W")
            {
                writer.WriteStartElement("name");
                writer.WriteValue(Name);
                writer.WriteEndElement();
            }
            if (options.Format != "W")
            {
                writer.WriteStartElement("type");
                writer.WriteValue(ResourceType);
                writer.WriteEndElement();
            }
            if (options.Format != "W" && Optional.IsDefined(SystemData))
            {
                writer.WriteStartElement("systemData");
                writer.WriteValue(SystemData);
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }

        void IXmlSerializable.Write(XmlWriter writer, string nameHint) => WriteInternal(writer, nameHint, ModelSerializationExtensions.WireOptions);

        internal static XmlInstanceData DeserializeXmlInstanceData(XElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            ResourceIdentifier id = default;
            string name = default;
            ResourceType resourceType = default;
            SystemData systemData = default;
            if (element.Element("id") is XElement idElement)
            {
                id = new ResourceIdentifier((string)idElement);
            }
            if (element.Element("name") is XElement nameElement)
            {
                name = (string)nameElement;
            }
            if (element.Element("type") is XElement typeElement)
            {
                resourceType = (string)typeElement;
            }
            if (element.Element("systemData") is XElement systemDataElement)
            {
                systemData = null;
            }
            return new XmlInstanceData(id, name, resourceType, systemData, serializedAdditionalRawData: null);
        }

        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<XmlInstanceData>)this).Write(writer, ModelSerializationExtensions.WireOptions);

        void IJsonModel<XmlInstanceData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<XmlInstanceData>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(XmlInstanceData)} does not support writing '{format}' format.");
            }

            base.JsonModelWriteCore(writer, options);
        }

        XmlInstanceData IJsonModel<XmlInstanceData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<XmlInstanceData>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(XmlInstanceData)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeXmlInstanceData(document.RootElement, options);
        }

        internal static XmlInstanceData DeserializeXmlInstanceData(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            ResourceIdentifier id = default;
            string name = default;
            ResourceType type = default;
            SystemData systemData = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"u8))
                {
                    id = new ResourceIdentifier(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("type"u8))
                {
                    type = new ResourceType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("systemData"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    systemData = ModelReaderWriter.Read<SystemData>(new BinaryData(Encoding.UTF8.GetBytes(property.Value.GetRawText())), ModelSerializationExtensions.WireOptions, MgmtXmlDeserializationContext.Default);
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new XmlInstanceData(id, name, type, systemData, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<XmlInstanceData>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<XmlInstanceData>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, MgmtXmlDeserializationContext.Default);
                case "X":
                    {
                        using MemoryStream stream = new MemoryStream();
                        using XmlWriter writer = XmlWriter.Create(stream);
                        WriteInternal(writer, null, options);
                        writer.Flush();
                        return new BinaryData(stream.GetBuffer().AsMemory(0, (int)stream.Position));
                    }
                default:
                    throw new FormatException($"The model {nameof(XmlInstanceData)} does not support writing '{options.Format}' format.");
            }
        }

        XmlInstanceData IPersistableModel<XmlInstanceData>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<XmlInstanceData>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
                        return DeserializeXmlInstanceData(document.RootElement, options);
                    }
                case "X":
                    return DeserializeXmlInstanceData(XElement.Load(data.ToStream()), options);
                default:
                    throw new FormatException($"The model {nameof(XmlInstanceData)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<XmlInstanceData>.GetFormatFromOptions(ModelReaderWriterOptions options) => "X";
    }
}
