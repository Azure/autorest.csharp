// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Xml.Linq;
using Azure.Core;

namespace xml_service.Models
{
    public partial class ContainerProperties
    {
        internal static ContainerProperties DeserializeContainerProperties(XElement element)
        {
            DateTimeOffset lastModified = default;
            string etag = default;
            LeaseStatusType? leaseStatus = default;
            LeaseStateType? leaseState = default;
            LeaseDurationType? leaseDuration = default;
            PublicAccessType? publicAccess = default;
            if (element.Element("Last-Modified") is XElement lastModifiedElement)
            {
                lastModified = lastModifiedElement.GetDateTimeOffsetValue("R");
            }
            if (element.Element("Etag") is XElement etagElement)
            {
                etag = (string)etagElement;
            }
            if (element.Element("LeaseStatus") is XElement leaseStatusElement)
            {
                leaseStatus = leaseStatusElement.Value.ToLeaseStatusType();
            }
            if (element.Element("LeaseState") is XElement leaseStateElement)
            {
                leaseState = leaseStateElement.Value.ToLeaseStateType();
            }
            if (element.Element("LeaseDuration") is XElement leaseDurationElement)
            {
                leaseDuration = leaseDurationElement.Value.ToLeaseDurationType();
            }
            if (element.Element("PublicAccess") is XElement publicAccessElement)
            {
                publicAccess = new PublicAccessType(publicAccessElement.Value);
            }
            return new ContainerProperties(lastModified, etag, leaseStatus, leaseState, leaseDuration, publicAccess);
        }
    }
}
