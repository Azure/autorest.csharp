// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using Azure.Core;

namespace xml_service.Models
{
    public partial class StorageServiceProperties : IXmlSerializable, IPersistableModel<StorageServiceProperties>
    {
        private void WriteInternal(XmlWriter writer, string nameHint, ModelReaderWriterOptions options)
        {
            writer.WriteStartElement(nameHint ?? "StorageServiceProperties");
            if (Optional.IsDefined(Logging))
            {
                writer.WriteObjectValue(Logging, "Logging");
            }
            if (Optional.IsDefined(HourMetrics))
            {
                writer.WriteObjectValue(HourMetrics, "HourMetrics");
            }
            if (Optional.IsDefined(MinuteMetrics))
            {
                writer.WriteObjectValue(MinuteMetrics, "MinuteMetrics");
            }
            if (Optional.IsDefined(DefaultServiceVersion))
            {
                writer.WriteStartElement("DefaultServiceVersion");
                writer.WriteValue(DefaultServiceVersion);
                writer.WriteEndElement();
            }
            if (Optional.IsDefined(DeleteRetentionPolicy))
            {
                writer.WriteObjectValue(DeleteRetentionPolicy, "DeleteRetentionPolicy");
            }
            if (Optional.IsCollectionDefined(Cors))
            {
                writer.WriteStartElement("Cors");
                foreach (var item in Cors)
                {
                    writer.WriteObjectValue(item, "CorsRule");
                }
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }

        void IXmlSerializable.Write(XmlWriter writer, string nameHint) => WriteInternal(writer, nameHint, new ModelReaderWriterOptions("W"));

        internal static StorageServiceProperties DeserializeStorageServiceProperties(XElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            Logging logging = default;
            Metrics hourMetrics = default;
            Metrics minuteMetrics = default;
            string defaultServiceVersion = default;
            RetentionPolicy deleteRetentionPolicy = default;
            IList<CorsRule> cors = default;
            if (element.Element("Logging") is XElement loggingElement)
            {
                logging = Logging.DeserializeLogging(loggingElement);
            }
            if (element.Element("HourMetrics") is XElement hourMetricsElement)
            {
                hourMetrics = Metrics.DeserializeMetrics(hourMetricsElement);
            }
            if (element.Element("MinuteMetrics") is XElement minuteMetricsElement)
            {
                minuteMetrics = Metrics.DeserializeMetrics(minuteMetricsElement);
            }
            if (element.Element("DefaultServiceVersion") is XElement defaultServiceVersionElement)
            {
                defaultServiceVersion = (string)defaultServiceVersionElement;
            }
            if (element.Element("DeleteRetentionPolicy") is XElement deleteRetentionPolicyElement)
            {
                deleteRetentionPolicy = RetentionPolicy.DeserializeRetentionPolicy(deleteRetentionPolicyElement);
            }
            if (element.Element("Cors") is XElement corsElement)
            {
                var array = new List<CorsRule>();
                foreach (var e in corsElement.Elements("CorsRule"))
                {
                    array.Add(CorsRule.DeserializeCorsRule(e));
                }
                cors = array;
            }
            return new StorageServiceProperties(logging, hourMetrics, minuteMetrics, cors, defaultServiceVersion, deleteRetentionPolicy, serializedAdditionalRawData: null);
        }

        BinaryData IPersistableModel<StorageServiceProperties>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<StorageServiceProperties>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "X":
                    {
                        using MemoryStream stream = new MemoryStream();
                        using XmlWriter writer = XmlWriter.Create(stream);
                        WriteInternal(writer, null, options);
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
                    throw new InvalidOperationException($"The model {nameof(StorageServiceProperties)} does not support '{options.Format}' format.");
            }
        }

        StorageServiceProperties IPersistableModel<StorageServiceProperties>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<StorageServiceProperties>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "X":
                    return DeserializeStorageServiceProperties(XElement.Load(data.ToStream()), options);
                default:
                    throw new InvalidOperationException($"The model {nameof(StorageServiceProperties)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<StorageServiceProperties>.GetFormatFromOptions(ModelReaderWriterOptions options) => "X";
    }
}
