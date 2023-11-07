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
    public partial class Slideshow : IXmlSerializable, IModel<Slideshow>
    {
        void IXmlSerializable.Write(XmlWriter writer, string nameHint)
        {
            writer.WriteStartElement(nameHint ?? "slideshow");
            if (Optional.IsDefined(Title))
            {
                writer.WriteStartAttribute("title");
                writer.WriteValue(Title);
                writer.WriteEndAttribute();
            }
            if (Optional.IsDefined(Date))
            {
                writer.WriteStartAttribute("date");
                writer.WriteValue(Date);
                writer.WriteEndAttribute();
            }
            if (Optional.IsDefined(Author))
            {
                writer.WriteStartAttribute("author");
                writer.WriteValue(Author);
                writer.WriteEndAttribute();
            }
            if (Optional.IsCollectionDefined(Slides))
            {
                foreach (var item in Slides)
                {
                    writer.WriteObjectValue(item, "slide");
                }
            }
            writer.WriteEndElement();
        }

        internal static Slideshow DeserializeSlideshow(XElement element, ModelReaderWriterOptions options = null)
        {
            string title = default;
            string date = default;
            string author = default;
            IList<Slide> slides = default;
            if (element.Attribute("title") is XAttribute titleAttribute)
            {
                title = (string)titleAttribute;
            }
            if (element.Attribute("date") is XAttribute dateAttribute)
            {
                date = (string)dateAttribute;
            }
            if (element.Attribute("author") is XAttribute authorAttribute)
            {
                author = (string)authorAttribute;
            }
            var array = new List<Slide>();
            foreach (var e in element.Elements("slide"))
            {
                array.Add(Slide.DeserializeSlide(e));
            }
            slides = array;
            return new Slideshow(title, date, author, slides, default);
        }

        BinaryData IModel<Slideshow>.Write(ModelReaderWriterOptions options)
        {
            bool implementsJson = this is IJsonModel<Slideshow>;
            bool isValid = options.Format == ModelReaderWriterFormat.Json && implementsJson || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {GetType().Name} does not support '{options.Format}' format.");
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

        Slideshow IModel<Slideshow>.Read(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(Slideshow)} does not support '{options.Format}' format.");
            }

            return DeserializeSlideshow(XElement.Load(data.ToStream()), options);
        }

        ModelReaderWriterFormat IModel<Slideshow>.GetWireFormat(ModelReaderWriterOptions options) => ModelReaderWriterFormat.Xml;
    }
}
