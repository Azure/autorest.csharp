// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Xml;
using System.Xml.Linq;
using Azure.Core;

namespace Azure.Storage.Tables.Models
{
    public partial class AccessPolicy : IXmlSerializable
    {
        void IXmlSerializable.Write(XmlWriter writer, string nameHint)
        {
            writer.WriteStartElement(nameHint ?? "AccessPolicy");
            writer.WriteStartElement("Start");
            writer.WriteValue(Start, "S");
            writer.WriteEndElement();
            writer.WriteStartElement("Expiry");
            writer.WriteValue(Expiry, "S");
            writer.WriteEndElement();
            writer.WriteStartElement("Permission");
            writer.WriteValue(Permission);
            writer.WriteEndElement();
            writer.WriteEndElement();
        }

        internal static AccessPolicy DeserializeAccessPolicy(XElement element)
        {
            AccessPolicy result = default;
            result = new AccessPolicy(); DateTimeOffset value = default;
            var start = element.Element("Start");
            if (start != null)
            {
                value = start.GetDateTimeOffsetValue("S");
            }
            result.Start = value;
            DateTimeOffset value0 = default;
            var expiry = element.Element("Expiry");
            if (expiry != null)
            {
                value0 = expiry.GetDateTimeOffsetValue("S");
            }
            result.Expiry = value0;
            string value1 = default;
            var permission = element.Element("Permission");
            if (permission != null)
            {
                value1 = (string)permission;
            }
            result.Permission = value1;
            return result;
        }
    }
}
