// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Xml;
using System.Xml.Linq;
using Azure.Core;
using Azure.Core.Serialization;

namespace xml_service.Models
{
    public partial class RootWithRefAndMeta : IXmlSerializable, IXmlModelSerializable
    {
        void IXmlModelSerializable.Serialize(XmlWriter writer, ModelSerializerOptions options) => ((IXmlSerializable)this).Write(writer, null, options);

        void IXmlSerializable.Write(XmlWriter writer, string nameHint, ModelSerializerOptions options)
        {
            writer.WriteStartElement("RootWithRefAndMeta");
            if (Optional.IsDefined(RefToModel))
            {
                writer.WriteObjectValue(RefToModel, "XMLComplexTypeWithMeta", options);
            }
            if (Optional.IsDefined(Something))
            {
                writer.WriteStartElement("Something");
                writer.WriteValue(Something);
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }

        object IModelSerializable.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            return DeserializeRootWithRefAndMeta(XElement.Load(data.ToStream()), options);
        }

        internal static RootWithRefAndMeta DeserializeRootWithRefAndMeta(XElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.AzureServiceDefault;
            ComplexTypeWithMeta refToModel = default;
            string something = default;
            if (element.Element("XMLComplexTypeWithMeta") is XElement xmlComplexTypeWithMetaElement)
            {
                refToModel = ComplexTypeWithMeta.DeserializeComplexTypeWithMeta(xmlComplexTypeWithMetaElement);
            }
            if (element.Element("Something") is XElement somethingElement)
            {
                something = (string)somethingElement;
            }
            return new RootWithRefAndMeta(refToModel, something);
        }
    }
}
