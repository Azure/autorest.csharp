// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Xml;
using System.Xml.Linq;
using Azure.Core;

namespace xml_service.Models
{
    public partial class ContainerProperties : IXmlSerializable
    {
        void IXmlSerializable.Write(XmlWriter writer, string nameHint)
        {
            writer.WriteStartElement(nameHint ?? "ContainerProperties");
            writer.WriteStartElement("Last-Modified");
            writer.WriteValue(LastModified, "R");
            writer.WriteEndElement();
            writer.WriteStartElement("Etag");
            writer.WriteValue(Etag);
            writer.WriteEndElement();
            if (LeaseStatus != null)
            {
                writer.WriteStartElement("LeaseStatus");
                writer.WriteValue(LeaseStatus.Value.ToSerialString());
                writer.WriteEndElement();
            }
            if (LeaseState != null)
            {
                writer.WriteStartElement("LeaseState");
                writer.WriteValue(LeaseState.Value.ToSerialString());
                writer.WriteEndElement();
            }
            if (LeaseDuration != null)
            {
                writer.WriteStartElement("LeaseDuration");
                writer.WriteValue(LeaseDuration.Value.ToSerialString());
                writer.WriteEndElement();
            }
            if (PublicAccess != null)
            {
                writer.WriteStartElement("PublicAccess");
                writer.WriteValue(PublicAccess.Value.ToString());
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }
        internal static ContainerProperties DeserializeContainerProperties(XElement element)
        {
            ContainerProperties result = default;
            result = new ContainerProperties(); DateTimeOffset value = default;
            var lastModified = element.Element("Last-Modified");
            if (lastModified != null)
            {
                value = lastModified.GetDateTimeOffsetValue("R");
            }
            result.LastModified = value;
            string value0 = default;
            var etag = element.Element("Etag");
            if (etag != null)
            {
                value0 = (string)etag;
            }
            result.Etag = value0;
            LeaseStatusType? value1 = default;
            var leaseStatus = element.Element("LeaseStatus");
            if (leaseStatus != null)
            {
                value1 = leaseStatus.Value.ToLeaseStatusType();
            }
            result.LeaseStatus = value1;
            LeaseStateType? value2 = default;
            var leaseState = element.Element("LeaseState");
            if (leaseState != null)
            {
                value2 = leaseState.Value.ToLeaseStateType();
            }
            result.LeaseState = value2;
            LeaseDurationType? value3 = default;
            var leaseDuration = element.Element("LeaseDuration");
            if (leaseDuration != null)
            {
                value3 = leaseDuration.Value.ToLeaseDurationType();
            }
            result.LeaseDuration = value3;
            PublicAccessType? value4 = default;
            var publicAccess = element.Element("PublicAccess");
            if (publicAccess != null)
            {
                value4 = new PublicAccessType(publicAccess.Value);
            }
            result.PublicAccess = value4;
            return result;
        }
    }
}
