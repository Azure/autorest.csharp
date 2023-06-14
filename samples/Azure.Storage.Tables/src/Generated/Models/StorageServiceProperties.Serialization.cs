// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using Azure.Core;

namespace Azure.Storage.Tables.Models
{
    public partial class StorageServiceProperties : IXmlSerializable
    {
        void IXmlSerializable.Write(XmlWriter writer, string nameHint)
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

        internal static StorageServiceProperties DeserializeStorageServiceProperties(XElement element)
        {
            Logging logging = default;
            Metrics hourMetrics = default;
            Metrics minuteMetrics = default;
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
            if (element.Element("Cors") is XElement corsElement)
            {
                var array = new List<CorsRule>();
                foreach (var e in corsElement.Elements("CorsRule"))
                {
                    array.Add(CorsRule.DeserializeCorsRule(e));
                }
                cors = array;
            }
            return new StorageServiceProperties(logging, hourMetrics, minuteMetrics, cors);
        }
    }
}
