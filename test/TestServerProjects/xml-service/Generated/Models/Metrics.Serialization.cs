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

namespace xml_service.Models
{
    public partial class Metrics : IXmlSerializable, IPersistableModel<Metrics>
    {
        private void _Write(XmlWriter writer, string nameHint, ModelReaderWriterOptions options)
        {
            writer.WriteStartElement(nameHint ?? "Metrics");
            if (Optional.IsDefined(Version))
            {
                writer.WriteStartElement("Version");
                writer.WriteValue(Version);
                writer.WriteEndElement();
            }
            writer.WriteStartElement("Enabled");
            writer.WriteValue(Enabled);
            writer.WriteEndElement();
            if (Optional.IsDefined(IncludeAPIs))
            {
                writer.WriteStartElement("IncludeAPIs");
                writer.WriteValue(IncludeAPIs.Value);
                writer.WriteEndElement();
            }
            if (Optional.IsDefined(RetentionPolicy))
            {
                writer.WriteObjectValue(RetentionPolicy, "RetentionPolicy");
            }
            writer.WriteEndElement();
        }

        void IXmlSerializable.Write(XmlWriter writer, string nameHint) => _Write(writer, nameHint, new ModelReaderWriterOptions("W"));

        internal static Metrics DeserializeMetrics(XElement element, ModelReaderWriterOptions options = null)
        {
            string version = default;
            bool enabled = default;
            bool? includeAPIs = default;
            RetentionPolicy retentionPolicy = default;
            if (element.Element("Version") is XElement versionElement)
            {
                version = (string)versionElement;
            }
            if (element.Element("Enabled") is XElement enabledElement)
            {
                enabled = (bool)enabledElement;
            }
            if (element.Element("IncludeAPIs") is XElement includeAPIsElement)
            {
                includeAPIs = (bool?)includeAPIsElement;
            }
            if (element.Element("RetentionPolicy") is XElement retentionPolicyElement)
            {
                retentionPolicy = RetentionPolicy.DeserializeRetentionPolicy(retentionPolicyElement);
            }
            return new Metrics(version, enabled, includeAPIs, retentionPolicy, serializedAdditionalRawData: null);
        }

        BinaryData IPersistableModel<Metrics>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<Metrics>)this).GetFormatFromOptions(options) : options.Format;

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
                    throw new InvalidOperationException($"The model {nameof(Metrics)} does not support '{options.Format}' format.");
            }
        }

        Metrics IPersistableModel<Metrics>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<Metrics>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "X":
                    return DeserializeMetrics(XElement.Load(data.ToStream()), options);
                default:
                    throw new InvalidOperationException($"The model {nameof(Metrics)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<Metrics>.GetFormatFromOptions(ModelReaderWriterOptions options) => "X";
    }
}
