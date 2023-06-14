// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Xml;
using System.Xml.Linq;
using Azure.Core;

namespace TypeSchemaMapping.Models
{
    public partial class ModelWithGuidProperty : IXmlSerializable
    {
        void IXmlSerializable.Write(XmlWriter writer, string nameHint)
        {
            writer.WriteStartElement(nameHint ?? "ModelWithGuidProperty");
            if (Optional.IsDefined(ModelProperty))
            {
                writer.WriteStartElement("ModelProperty");
                writer.WriteValue(ModelProperty.Value);
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }

        internal static ModelWithGuidProperty DeserializeModelWithGuidProperty(XElement element)
        {
            Guid? modelProperty = default;
            if (element.Element("ModelProperty") is XElement modelPropertyElement)
            {
                modelProperty = new Guid(modelPropertyElement.Value);
            }
            return new ModelWithGuidProperty(modelProperty);
        }
    }
}
