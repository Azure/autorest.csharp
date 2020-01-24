// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;
using System.Xml;
using System.Xml.Linq;
using Azure.Core;

namespace xml_service.Models
{
    public partial class Slideshow : IUtf8JsonSerializable, IXmlSerializable
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
            if (Slides != null)
            {
                writer.WritePropertyName("slides");
                writer.WriteStartArray();
                foreach (var item in Slides)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
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
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Slides = new List<Slide>();
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
            if (Title != null)
            {
                writer.WriteStartAttribute("title");
                writer.WriteValue(Title);
                writer.WriteEndAttribute();
            }
            if (Date != null)
            {
                writer.WriteStartAttribute("date");
                writer.WriteValue(Date);
                writer.WriteEndAttribute();
            }
            if (Author != null)
            {
                writer.WriteStartAttribute("author");
                writer.WriteValue(Author);
                writer.WriteEndAttribute();
            }
            if (Slides != null)
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
            Slideshow result = default;
            result = new Slideshow(); var title = element.Attribute("title");
            if (title != null)
            {
                result.Title = (string)title;
            }
            var date = element.Attribute("date");
            if (date != null)
            {
                result.Date = (string)date;
            }
            var author = element.Attribute("author");
            if (author != null)
            {
                result.Author = (string)author;
            }
            result.Slides = new List<Slide>();
            foreach (var e in element.Elements("slide"))
            {
                Slide value = default;
                value = Slide.DeserializeSlide(e);
                result.Slides.Add(value);
            }
            return result;
        }
    }
}
