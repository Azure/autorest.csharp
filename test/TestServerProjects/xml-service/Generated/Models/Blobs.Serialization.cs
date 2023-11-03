// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.IO;
using System.Net.ClientModel;
using System.Net.ClientModel.Core;
using System.Xml;
using System.Xml.Linq;
using Azure.Core;

namespace xml_service.Models
{
    public partial class Blobs : IXmlSerializable, IModel<Blobs>
    {
        void IXmlSerializable.Write(XmlWriter writer, string nameHint)
        {
            writer.WriteStartElement(nameHint ?? "Blobs");
            if (Optional.IsCollectionDefined(BlobPrefix))
            {
                foreach (var item in BlobPrefix)
                {
                    writer.WriteObjectValue(item, "BlobPrefix");
                }
            }
            if (Optional.IsCollectionDefined(Blob))
            {
                foreach (var item in Blob)
                {
                    writer.WriteObjectValue(item, "Blob");
                }
            }
            writer.WriteEndElement();
        }

        internal static Blobs DeserializeBlobs(XElement element, ModelReaderWriterOptions options = null)
        {
            IReadOnlyList<BlobPrefix> blobPrefix = default;
            IReadOnlyList<Blob> blob = default;
            var array = new List<BlobPrefix>();
            foreach (var e in element.Elements("BlobPrefix"))
            {
                array.Add(Models.BlobPrefix.DeserializeBlobPrefix(e));
            }
            blobPrefix = array;
            var array0 = new List<Blob>();
            foreach (var e in element.Elements("Blob"))
            {
                array0.Add(Models.Blob.DeserializeBlob(e));
            }
            blob = array0;
            return new Blobs(blobPrefix, blob, default);
        }

        BinaryData IModel<Blobs>.Write(ModelReaderWriterOptions options)
        {
            bool implementsJson = this is IJsonModel<Blobs>;
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

        Blobs IModel<Blobs>.Read(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {GetType().Name} does not support '{options.Format}' format.");
            }

            return DeserializeBlobs(XElement.Load(data.ToStream()), options);
        }

        ModelReaderWriterFormat IModel<Blobs>.GetWireFormat(ModelReaderWriterOptions options) => ModelReaderWriterFormat.Xml;
    }
}
