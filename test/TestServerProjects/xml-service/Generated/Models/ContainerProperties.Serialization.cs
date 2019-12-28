// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using System.Xml;
using System.Xml.Linq;
using Azure.Core;

namespace xml_service.Models.V100
{
    public partial class ContainerProperties : IUtf8JsonSerializable, IXmlSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("Last-Modified");
            writer.WriteStringValue(LastModified, "R");
            writer.WritePropertyName("Etag");
            writer.WriteStringValue(Etag);
            if (LeaseStatus != null)
            {
                writer.WritePropertyName("LeaseStatus");
                writer.WriteStringValue(LeaseStatus.Value.ToSerialString());
            }
            if (LeaseState != null)
            {
                writer.WritePropertyName("LeaseState");
                writer.WriteStringValue(LeaseState.Value.ToSerialString());
            }
            if (LeaseDuration != null)
            {
                writer.WritePropertyName("LeaseDuration");
                writer.WriteStringValue(LeaseDuration.Value.ToSerialString());
            }
            if (PublicAccess != null)
            {
                writer.WritePropertyName("PublicAccess");
                writer.WriteStringValue(PublicAccess.Value.ToString());
            }
            writer.WriteEndObject();
        }
        internal static ContainerProperties DeserializeContainerProperties(JsonElement element)
        {
            ContainerProperties result = new ContainerProperties();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("Last-Modified"))
                {
                    result.LastModified = property.Value.GetDateTimeOffset("R");
                    continue;
                }
                if (property.NameEquals("Etag"))
                {
                    result.Etag = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("LeaseStatus"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.LeaseStatus = property.Value.GetString().ToLeaseStatusType();
                    continue;
                }
                if (property.NameEquals("LeaseState"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.LeaseState = property.Value.GetString().ToLeaseStateType();
                    continue;
                }
                if (property.NameEquals("LeaseDuration"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.LeaseDuration = property.Value.GetString().ToLeaseDurationType();
                    continue;
                }
                if (property.NameEquals("PublicAccess"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.PublicAccess = new PublicAccessType(property.Value.GetString());
                    continue;
                }
            }
            return result;
        }
        void IXmlSerializable.Write(XmlWriter writer, string nameHint)
        {
            writer.WriteStartElement(nameHint ?? "AutoContainerProperties");
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
        }
        internal static ContainerProperties DeserializeContainerProperties(XElement element)
        {
            ContainerProperties result = new ContainerProperties();
            var lastModified = element.Element("Last-Modified");
            if (lastModified != null)
            {
                result.LastModified = lastModified.GetDateTimeOffsetValue("R");
            }
            var etag = element.Element("Etag");
            if (etag != null)
            {
                result.Etag = (string)etag;
            }
            var leaseStatus = element.Element("LeaseStatus");
            if (leaseStatus != null)
            {
                result.LeaseStatus = leaseStatus.Value.ToLeaseStatusType();
            }
            var leaseState = element.Element("LeaseState");
            if (leaseState != null)
            {
                result.LeaseState = leaseState.Value.ToLeaseStateType();
            }
            var leaseDuration = element.Element("LeaseDuration");
            if (leaseDuration != null)
            {
                result.LeaseDuration = leaseDuration.Value.ToLeaseDurationType();
            }
            var publicAccess = element.Element("PublicAccess");
            if (publicAccess != null)
            {
                result.PublicAccess = new PublicAccessType(publicAccess.Value);
            }
            return result;
        }
    }
}
