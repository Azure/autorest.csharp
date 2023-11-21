// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using Azure.Core;

namespace xml_service.Models
{
    public partial class Slide : IXmlSerializable, IPersistableModel<Slide>
    {
        private void _Write(XmlWriter writer, string nameHint, ModelReaderWriterOptions options)
        {
            writer.WriteStartElement(nameHint ?? "slide");
            if (Optional.IsDefined(Type))
            {
                writer.WriteStartAttribute("type");
                writer.WriteValue(Type);
                writer.WriteEndAttribute();
            }
            if (Optional.IsDefined(Title))
            {
                writer.WriteStartElement("title");
                writer.WriteValue(Title);
                writer.WriteEndElement();
            }
            if (Optional.IsCollectionDefined(Items))
            {
                foreach (var item in Items)
                {
                    writer.WriteStartElement("item");
                    writer.WriteValue(item);
                    writer.WriteEndElement();
                }
            }
            writer.WriteEndElement();
        }

        void IXmlSerializable.Write(XmlWriter writer, string nameHint) => _Write(writer, nameHint, new ModelReaderWriterOptions("W"));

        internal static Slide DeserializeSlide(XElement element, ModelReaderWriterOptions options = null)
        {
            string type = default;
            string title = default;
            IList<string> items = default;
            if (element.Attribute("type") is XAttribute typeAttribute)
            {
                type = (string)typeAttribute;
            }
            if (element.Element("title") is XElement titleElement)
            {
                title = (string)titleElement;
            }
            var array = new List<string>();
            foreach (var e in element.Elements("item"))
            {
                array.Add((string)e);
            }
            items = array;
            return new Slide(type, title, items, serializedAdditionalRawData: null);
        }

        BinaryData IPersistableModel<Slide>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<Slide>)this).GetFormatFromOptions(options) : options.Format;

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
                    throw new InvalidOperationException($"The model {nameof(Slide)} does not support '{options.Format}' format.");
            }
        }

        Slide IPersistableModel<Slide>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<Slide>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "X":
                    return DeserializeSlide(XElement.Load(data.ToStream()), options);
                default:
                    throw new InvalidOperationException($"The model {nameof(Slide)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<Slide>.GetFormatFromOptions(ModelReaderWriterOptions options) => "X";
    }
}
