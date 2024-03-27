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
    public partial class Blobs : IXmlSerializable, IPersistableModel<Blobs>
    {
        private void WriteInternal(XmlWriter writer, string nameHint, ModelReaderWriterOptions options)
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

        void IXmlSerializable.Write(XmlWriter writer, string nameHint) => WriteInternal(writer, nameHint, new ModelReaderWriterOptions("W"));

        internal static Blobs DeserializeBlobs(XElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

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
            return new Blobs(blobPrefix, blob, serializedAdditionalRawData: null);
        }

        BinaryData IPersistableModel<Blobs>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<Blobs>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "X":
                    {
                        using MemoryStream stream = new MemoryStream();
                        using XmlWriter writer = XmlWriter.Create(stream);
                        WriteInternal(writer, null, options);
                        writer.Flush();
                        return new BinaryData(stream.GetBuffer().AsMemory(0, (int)stream.Position));
                    }
                default:
                    throw new FormatException($"The model {nameof(Blobs)} does not support writing '{options.Format}' format.");
            }
        }

        Blobs IPersistableModel<Blobs>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<Blobs>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "X":
                    return DeserializeBlobs(XElement.Load(data.ToStream()), options);
                default:
                    throw new FormatException($"The model {nameof(Blobs)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<Blobs>.GetFormatFromOptions(ModelReaderWriterOptions options) => "X";
    }
}
