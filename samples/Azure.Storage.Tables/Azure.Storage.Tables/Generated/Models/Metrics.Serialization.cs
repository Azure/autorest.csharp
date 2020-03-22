// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Xml;
using System.Xml.Linq;
using Azure.Core;

namespace Azure.Storage.Tables.Models
{
    public partial class Metrics : IXmlSerializable
    {
        void IXmlSerializable.Write(XmlWriter writer, string nameHint)
        {
            writer.WriteStartElement(nameHint ?? "Metrics");
            if (Version != null)
            {
                writer.WriteStartElement("Version");
                writer.WriteValue(Version);
                writer.WriteEndElement();
            }
            writer.WriteStartElement("Enabled");
            writer.WriteValue(Enabled);
            writer.WriteEndElement();
            if (IncludeAPIs != null)
            {
                writer.WriteStartElement("IncludeAPIs");
                writer.WriteValue(IncludeAPIs.Value);
                writer.WriteEndElement();
            }
            if (RetentionPolicy != null)
            {
                writer.WriteObjectValue(RetentionPolicy, "RetentionPolicy");
            }
            writer.WriteEndElement();
        }

        internal static Metrics DeserializeMetrics(XElement element)
        {
            var obj = new Metrics();
            if (element.Element("Version") is XElement version)
            {
                obj.Version = (string)version;
            }
            if (element.Element("Enabled") is XElement enabled)
            {
                obj.Enabled = (bool)enabled;
            }
            if (element.Element("IncludeAPIs") is XElement includeAPIs)
            {
                obj.IncludeAPIs = (bool?)includeAPIs;
            }
            if (element.Element("RetentionPolicy") is XElement retentionPolicy)
            {
                obj.RetentionPolicy = RetentionPolicy.DeserializeRetentionPolicy(retentionPolicy);
            }
            return obj;
        }
    }
}
