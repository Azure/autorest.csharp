// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using Azure.Core;

namespace xml_service.Models
{
    public partial class Slideshow : IXmlSerializable
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

        internal static Slideshow DeserializeSlideshow(XElement element)
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
            return new Slideshow(title, date, author, slides);
        }
    }
}
