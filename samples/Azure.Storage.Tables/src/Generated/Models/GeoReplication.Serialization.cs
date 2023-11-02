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
    public partial class GeoReplication : IXmlSerializable, IModel<GeoReplication>
    {
        void IXmlSerializable.Write(XmlWriter writer, string nameHint)
        {
            writer.WriteStartElement(nameHint ?? "GeoReplication");
            writer.WriteStartElement("Status");
            writer.WriteValue(Status.ToString());
            writer.WriteEndElement();
            writer.WriteStartElement("LastSyncTime");
            writer.WriteValue(LastSyncTime, "R");
            writer.WriteEndElement();
            writer.WriteEndElement();
        }

        internal static GeoReplication DeserializeGeoReplication(XElement element, ModelReaderWriterOptions options = null)
        {
            GeoReplicationStatusType status = default;
            DateTimeOffset lastSyncTime = default;
            if (element.Element("Status") is XElement statusElement)
            {
                status = new GeoReplicationStatusType(statusElement.Value);
            }
            if (element.Element("LastSyncTime") is XElement lastSyncTimeElement)
            {
                lastSyncTime = lastSyncTimeElement.GetDateTimeOffsetValue("R");
            }
            return new GeoReplication(status, lastSyncTime, default);
        }

        BinaryData IModel<GeoReplication>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
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

        GeoReplication IModel<GeoReplication>.Read(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException(string.Format("The model {0} does not support '{1}' format.", GetType().Name, options.Format));
            }

            return DeserializeGeoReplication(XElement.Load(data.ToStream()), options);
        }
    }
}
