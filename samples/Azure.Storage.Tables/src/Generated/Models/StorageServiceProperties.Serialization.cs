// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using Azure;
using Azure.Core;
using Azure.Core.Serialization;

namespace Azure.Storage.Tables.Models
{
    public partial class StorageServiceProperties : IXmlSerializable, IModelSerializable<StorageServiceProperties>
    {
        private void Serialize(XmlWriter writer, string nameHint, ModelSerializerOptions options)
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

        void IXmlSerializable.Write(XmlWriter writer, string nameHint) => Serialize(writer, nameHint, ModelSerializerOptions.DefaultWireOptions);

        internal static StorageServiceProperties DeserializeStorageServiceProperties(XElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;
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
            return new StorageServiceProperties(logging, hourMetrics, minuteMetrics, cors, default);
        }

        BinaryData IModelSerializable<StorageServiceProperties>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            options ??= ModelSerializerOptions.DefaultWireOptions;
            using MemoryStream stream = new MemoryStream();
            using XmlWriter writer = XmlWriter.Create(stream);
            Serialize(writer, null, options);
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

        StorageServiceProperties IModelSerializable<StorageServiceProperties>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return DeserializeStorageServiceProperties(XElement.Load(data.ToStream()), options);
        }

        /// <summary> Converts a <see cref="StorageServiceProperties"/> into a <see cref="RequestContent"/>. </summary>
        /// <param name="model"> The <see cref="StorageServiceProperties"/> to convert. </param>
        public static implicit operator RequestContent(StorageServiceProperties model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        /// <summary> Converts a <see cref="Response"/> into a <see cref="StorageServiceProperties"/>. </summary>
        /// <param name="response"> The <see cref="Response"/> to convert. </param>
        public static explicit operator StorageServiceProperties(Response response)
        {
            if (response is null)
            {
                return null;
            }

            return DeserializeStorageServiceProperties(XElement.Load(response.ContentStream), ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
