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
    public partial class GeoReplication : IXmlSerializable, IPersistableModel<GeoReplication>
    {
        private void _Write(XmlWriter writer, string nameHint, ModelReaderWriterOptions options)
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

        void IXmlSerializable.Write(XmlWriter writer, string nameHint) => _Write(writer, nameHint, new ModelReaderWriterOptions("W"));

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
            return new GeoReplication(status, lastSyncTime, serializedAdditionalRawData: null);
        }

        BinaryData IPersistableModel<GeoReplication>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<GeoReplication>)this).GetFormatFromOptions(options) : options.Format;

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
                    throw new InvalidOperationException($"The model {nameof(GeoReplication)} does not support '{options.Format}' format.");
            }
        }

        GeoReplication IPersistableModel<GeoReplication>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<GeoReplication>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "X":
                    return DeserializeGeoReplication(XElement.Load(data.ToStream()), options);
                default:
                    throw new InvalidOperationException($"The model {nameof(GeoReplication)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<GeoReplication>.GetFormatFromOptions(ModelReaderWriterOptions options) => "X";
    }
}
