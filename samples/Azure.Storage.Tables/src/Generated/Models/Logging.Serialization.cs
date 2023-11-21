// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using Azure.Core;

namespace Azure.Storage.Tables.Models
{
    public partial class Logging : IXmlSerializable, IPersistableModel<Logging>
    {
        private void _Write(XmlWriter writer, string nameHint, ModelReaderWriterOptions options)
        {
            writer.WriteStartElement(nameHint ?? "Logging");
            writer.WriteStartElement("Version");
            writer.WriteValue(Version);
            writer.WriteEndElement();
            writer.WriteStartElement("Delete");
            writer.WriteValue(Delete);
            writer.WriteEndElement();
            writer.WriteStartElement("Read");
            writer.WriteValue(Read);
            writer.WriteEndElement();
            writer.WriteStartElement("Write");
            writer.WriteValue(Write);
            writer.WriteEndElement();
            writer.WriteObjectValue(RetentionPolicy, "RetentionPolicy");
            writer.WriteEndElement();
        }

        void IXmlSerializable.Write(XmlWriter writer, string nameHint) => _Write(writer, nameHint, new ModelReaderWriterOptions("W"));

        internal static Logging DeserializeLogging(XElement element, ModelReaderWriterOptions options = null)
        {
            string version = default;
            bool delete = default;
            bool read = default;
            bool write = default;
            RetentionPolicy retentionPolicy = default;
            if (element.Element("Version") is XElement versionElement)
            {
                version = (string)versionElement;
            }
            if (element.Element("Delete") is XElement deleteElement)
            {
                delete = (bool)deleteElement;
            }
            if (element.Element("Read") is XElement readElement)
            {
                read = (bool)readElement;
            }
            if (element.Element("Write") is XElement writeElement)
            {
                write = (bool)writeElement;
            }
            if (element.Element("RetentionPolicy") is XElement retentionPolicyElement)
            {
                retentionPolicy = RetentionPolicy.DeserializeRetentionPolicy(retentionPolicyElement);
            }
            return new Logging(version, delete, read, write, retentionPolicy, serializedAdditionalRawData: null);
        }

        BinaryData IPersistableModel<Logging>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<Logging>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "X":
                    {
                        using MemoryStream stream = new MemoryStream();
                        using XmlWriter writer = XmlWriter.Create(stream);
                        _Write(writer, null, options);
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
                default:
                    throw new InvalidOperationException($"The model {nameof(Logging)} does not support '{options.Format}' format.");
            }
        }

        Logging IPersistableModel<Logging>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<Logging>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "X":
                    return DeserializeLogging(XElement.Load(data.ToStream()), options);
                default:
                    throw new InvalidOperationException($"The model {nameof(Logging)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<Logging>.GetFormatFromOptions(ModelReaderWriterOptions options) => "X";
    }
}
