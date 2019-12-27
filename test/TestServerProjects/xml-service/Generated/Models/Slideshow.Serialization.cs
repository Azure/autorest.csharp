// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;
using System.Xml;
using System.Xml.Linq;
using Azure.Core;

namespace xml_service.Models.V100
{
    public partial class Slideshow : IXmlSerializable, IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Title != null)
            {
                writer.WritePropertyName("title");
                writer.WriteStringValue(Title);
            }
            if (Date != null)
            {
                writer.WritePropertyName("date");
                writer.WriteStringValue(Date);
            }
            if (Author != null)
            {
                writer.WritePropertyName("author");
                writer.WriteStringValue(Author);
            }
            writer.WritePropertyName("slides");
            writer.WriteStartArray();
            foreach (var item in Slides)
            {
                writer.WriteObjectValue(item);
            }
            writer.WriteEndArray();
            writer.WriteEndObject();
        }
        internal static Slideshow DeserializeSlideshow(JsonElement element)
        {
            Slideshow result = new Slideshow();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("title"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Title = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("date"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Date = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("author"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Author = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("slides"))
                {
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        result.Slides.Add(Slide.DeserializeSlide(item));
                    }
                    continue;
                }
            }
            return result;
        }
        void IXmlSerializable.Write(XmlWriter writer, string nameHint)
        {
            writer.WriteStartElement(nameHint ?? "slideshow");
            writer.WriteStartElement("slides");
            writer.WriteEndElement();
        }
        internal static Slideshow DeserializeSlideshow(XElement element)
        {
            Slideshow result = new Slideshow();
            var title = element.Attribute("title");
            if (title != null)
            {
                result.Title = (string?)title;
            }
            var date = element.Attribute("date");
            if (date != null)
            {
                result.Date = (string?)date;
            }
            var author = element.Attribute("author");
            if (author != null)
            {
                result.Author = (string?)author;
            }
            var slides = element.Element("slides");
            if (slides != null)
            {
                ICollection<Slide> value = new List<Slide>();
                result.Slides = value;
            }
            return result;
        }
    }
}
