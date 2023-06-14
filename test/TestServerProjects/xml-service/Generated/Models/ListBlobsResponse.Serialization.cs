// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Xml.Linq;
using Azure.Core;

namespace xml_service.Models
{
    public partial class ListBlobsResponse
    {
        internal static ListBlobsResponse DeserializeListBlobsResponse(XElement element)
        {
            string serviceEndpoint = default;
            string containerName = default;
            string prefix = default;
            string marker = default;
            int maxResults = default;
            string delimiter = default;
            Blobs blobs = default;
            string nextMarker = default;
            if (element.Attribute("ServiceEndpoint") is XAttribute serviceEndpointAttribute)
            {
                serviceEndpoint = (string)serviceEndpointAttribute;
            }
            if (element.Attribute("ContainerName") is XAttribute containerNameAttribute)
            {
                containerName = (string)containerNameAttribute;
            }
            if (element.Element("Prefix") is XElement prefixElement)
            {
                prefix = (string)prefixElement;
            }
            if (element.Element("Marker") is XElement markerElement)
            {
                marker = (string)markerElement;
            }
            if (element.Element("MaxResults") is XElement maxResultsElement)
            {
                maxResults = (int)maxResultsElement;
            }
            if (element.Element("Delimiter") is XElement delimiterElement)
            {
                delimiter = (string)delimiterElement;
            }
            if (element.Element("Blobs") is XElement blobsElement)
            {
                blobs = Blobs.DeserializeBlobs(blobsElement);
            }
            if (element.Element("NextMarker") is XElement nextMarkerElement)
            {
                nextMarker = (string)nextMarkerElement;
            }
            return new ListBlobsResponse(serviceEndpoint, containerName, prefix, marker, maxResults, delimiter, blobs, nextMarker);
        }
    }
}
