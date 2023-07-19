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
    public partial class RetentionPolicy : IXmlSerializable, IXmlModelSerializable
    {
        void IXmlSerializable.Write(XmlWriter writer, string nameHint) => ((IXmlModelSerializable)this).Serialize(writer, ModelSerializerOptions.AzureServiceDefault);

        void IXmlModelSerializable.Serialize(XmlWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartElement("RetentionPolicy");
            writer.WriteStartElement("Enabled");
            writer.WriteValue(Enabled);
            writer.WriteEndElement();
            if (Optional.IsDefined(Days))
            {
                writer.WriteStartElement("Days");
                writer.WriteValue(Days.Value);
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }

        object IModelSerializable.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            return DeserializeRetentionPolicy(XElement.Load(data.ToStream()), options);
        }

        internal static RetentionPolicy DeserializeRetentionPolicy(XElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.AzureServiceDefault;
            bool enabled = default;
            int? days = default;
            if (element.Element("Enabled") is XElement enabledElement)
            {
                enabled = (bool)enabledElement;
            }
            if (element.Element("Days") is XElement daysElement)
            {
                days = (int?)daysElement;
            }
            return new RetentionPolicy(enabled, days);
        }
    }
}
