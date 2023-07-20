// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Xml;
using System.Xml.Linq;
using Azure.Core;
using Azure.Core.Serialization;

namespace Azure.Storage.Tables.Models
{
    public partial class SignedIdentifier : IXmlSerializable, IXmlModelSerializable
    {
        void IXmlModelSerializable.Serialize(XmlWriter writer, ModelSerializerOptions options) => ((IXmlSerializable)this).Write(writer, null, options);

        void IXmlSerializable.Write(XmlWriter writer, string nameHint, ModelSerializerOptions options)
        {
            writer.WriteStartElement("SignedIdentifier");
            writer.WriteStartElement("Id");
            writer.WriteValue(Id);
            writer.WriteEndElement();
            writer.WriteObjectValue(AccessPolicy, "AccessPolicy", options);
            writer.WriteEndElement();
        }

        object IModelSerializable.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            return DeserializeSignedIdentifier(XElement.Load(data.ToStream()), options);
        }

        internal static SignedIdentifier DeserializeSignedIdentifier(XElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.AzureServiceDefault;
            string id = default;
            AccessPolicy accessPolicy = default;
            if (element.Element("Id") is XElement idElement)
            {
                id = (string)idElement;
            }
            if (element.Element("AccessPolicy") is XElement accessPolicyElement)
            {
                accessPolicy = AccessPolicy.DeserializeAccessPolicy(accessPolicyElement);
            }
            return new SignedIdentifier(id, accessPolicy);
        }
    }
}
