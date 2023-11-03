// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.IO;
using System.Net.ClientModel;
using System.Net.ClientModel.Core;
using System.Xml;
using System.Xml.Linq;
using Azure.Core;

namespace Azure.Storage.Tables.Models
{
    public partial class Logging : IXmlSerializable, IModel<Logging>
    {
        void IXmlSerializable.Write(XmlWriter writer, string nameHint)
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
            return new Logging(version, delete, read, write, retentionPolicy, default);
        }

        BinaryData IModel<Logging>.Write(ModelReaderWriterOptions options)
        {
            bool implementsJson = this is IJsonModel<Logging>;
            bool isValid = options.Format == ModelReaderWriterFormat.Json && implementsJson || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException(string.Format("The model {0} does not support '{1}' format.", GetType().Name, options.Format));
            }

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

        Logging IModel<Logging>.Read(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {GetType().Name} does not support '{options.Format}' format.");
            }

            return DeserializeLogging(XElement.Load(data.ToStream()), options);
        }

        ModelReaderWriterFormat IModel<Logging>.GetWireFormat(ModelReaderWriterOptions options) => ModelReaderWriterFormat.Xml;
    }
}
