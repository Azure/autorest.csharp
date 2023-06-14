// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Xml.Linq;
using Azure.Core;

namespace xml_service.Models
{
    public partial class ListContainersResponse
    {
        internal static ListContainersResponse DeserializeListContainersResponse(XElement element)
        {
            string serviceEndpoint = default;
            string prefix = default;
            string marker = default;
            int maxResults = default;
            string nextMarker = default;
            IReadOnlyList<Container> containers = default;
            if (element.Attribute("ServiceEndpoint") is XAttribute serviceEndpointAttribute)
            {
                serviceEndpoint = (string)serviceEndpointAttribute;
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
            if (element.Element("NextMarker") is XElement nextMarkerElement)
            {
                nextMarker = (string)nextMarkerElement;
            }
            if (element.Element("Containers") is XElement containersElement)
            {
                var array = new List<Container>();
                foreach (var e in containersElement.Elements("Container"))
                {
                    array.Add(Container.DeserializeContainer(e));
                }
                containers = array;
            }
            return new ListContainersResponse(serviceEndpoint, prefix, marker, maxResults, containers, nextMarker);
        }
    }
}
