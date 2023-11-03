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
    public partial class StorageServiceStats : IXmlSerializable, IModel<StorageServiceStats>
    {
        void IXmlSerializable.Write(XmlWriter writer, string nameHint)
        {
            writer.WriteStartElement(nameHint ?? "StorageServiceStats");
            if (Optional.IsDefined(GeoReplication))
            {
                writer.WriteObjectValue(GeoReplication, "GeoReplication");
            }
            writer.WriteEndElement();
        }

        internal static StorageServiceStats DeserializeStorageServiceStats(XElement element, ModelReaderWriterOptions options = null)
        {
            GeoReplication geoReplication = default;
            if (element.Element("GeoReplication") is XElement geoReplicationElement)
            {
                geoReplication = GeoReplication.DeserializeGeoReplication(geoReplicationElement);
            }
            return new StorageServiceStats(geoReplication, default);
        }

        BinaryData IModel<StorageServiceStats>.Write(ModelReaderWriterOptions options)
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

        StorageServiceStats IModel<StorageServiceStats>.Read(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException(string.Format("The model {0} does not support '{1}' format.", GetType().Name, options.Format));
            }

            return DeserializeStorageServiceStats(XElement.Load(data.ToStream()), options);
        }

        ModelReaderWriterFormat IModel<StorageServiceStats>.GetWireFormat(ModelReaderWriterOptions options) => ModelReaderWriterFormat.Xml;
    }
}
