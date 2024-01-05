// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using Azure.Core;

namespace xml_service.Models
{
    public partial class CorsRule : IXmlSerializable, IPersistableModel<CorsRule>
    {
        private void WriteInternal(XmlWriter writer, string nameHint, ModelReaderWriterOptions options)
        {
            writer.WriteStartElement(nameHint ?? "CorsRule");
            writer.WriteStartElement("AllowedOrigins");
            writer.WriteValue(AllowedOrigins);
            writer.WriteEndElement();
            writer.WriteStartElement("AllowedMethods");
            writer.WriteValue(AllowedMethods);
            writer.WriteEndElement();
            writer.WriteStartElement("AllowedHeaders");
            writer.WriteValue(AllowedHeaders);
            writer.WriteEndElement();
            writer.WriteStartElement("ExposedHeaders");
            writer.WriteValue(ExposedHeaders);
            writer.WriteEndElement();
            writer.WriteStartElement("MaxAgeInSeconds");
            writer.WriteValue(MaxAgeInSeconds);
            writer.WriteEndElement();
            writer.WriteEndElement();
        }

        void IXmlSerializable.Write(XmlWriter writer, string nameHint) => WriteInternal(writer, nameHint, new ModelReaderWriterOptions("W"));

        internal static CorsRule DeserializeCorsRule(XElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            string allowedOrigins = default;
            string allowedMethods = default;
            string allowedHeaders = default;
            string exposedHeaders = default;
            int maxAgeInSeconds = default;
            if (element.Element("AllowedOrigins") is XElement allowedOriginsElement)
            {
                allowedOrigins = (string)allowedOriginsElement;
            }
            if (element.Element("AllowedMethods") is XElement allowedMethodsElement)
            {
                allowedMethods = (string)allowedMethodsElement;
            }
            if (element.Element("AllowedHeaders") is XElement allowedHeadersElement)
            {
                allowedHeaders = (string)allowedHeadersElement;
            }
            if (element.Element("ExposedHeaders") is XElement exposedHeadersElement)
            {
                exposedHeaders = (string)exposedHeadersElement;
            }
            if (element.Element("MaxAgeInSeconds") is XElement maxAgeInSecondsElement)
            {
                maxAgeInSeconds = (int)maxAgeInSecondsElement;
            }
            return new CorsRule(allowedOrigins, allowedMethods, allowedHeaders, exposedHeaders, maxAgeInSeconds, serializedAdditionalRawData: null);
        }

        BinaryData IPersistableModel<CorsRule>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<CorsRule>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "X":
                    {
                        using MemoryStream stream = new MemoryStream();
                        using XmlWriter writer = XmlWriter.Create(stream);
                        WriteInternal(writer, null, options);
                        writer.Flush();
                        return new BinaryData(stream.GetBuffer().AsMemory(0, (int)stream.Position));
                    }
                default:
                    throw new FormatException($"The model {nameof(CorsRule)} does not support '{options.Format}' format.");
            }
        }

        CorsRule IPersistableModel<CorsRule>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<CorsRule>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "X":
                    return DeserializeCorsRule(XElement.Load(data.ToStream()), options);
                default:
                    throw new FormatException($"The model {nameof(CorsRule)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<CorsRule>.GetFormatFromOptions(ModelReaderWriterOptions options) => "X";
    }
}
