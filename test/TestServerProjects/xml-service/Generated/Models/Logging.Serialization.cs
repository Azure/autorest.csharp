// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Xml;
using System.Xml.Linq;
using Azure.Core;

namespace xml_service.Models
{
    public partial class Logging : IXmlSerializable
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

        internal static Logging DeserializeLogging(XElement element)
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
            return new Logging(version, delete, read, write, retentionPolicy);
        }
    }
}
