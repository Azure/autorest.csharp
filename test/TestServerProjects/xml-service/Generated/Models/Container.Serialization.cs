// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Xml.Linq;
using Azure.Core;

namespace xml_service.Models
{
    public partial class Container
    {
        internal static Container DeserializeContainer(XElement element)
        {
            string name = default;
            ContainerProperties properties = default;
            IReadOnlyDictionary<string, string> metadata = default;
            if (element.Element("Name") is XElement nameElement)
            {
                name = (string)nameElement;
            }
            if (element.Element("Properties") is XElement propertiesElement)
            {
                properties = ContainerProperties.DeserializeContainerProperties(propertiesElement);
            }
            if (element.Element("Metadata") is XElement metadataElement)
            {
                var dictionary = new Dictionary<string, string>();
                foreach (var e in metadataElement.Elements())
                {
                    dictionary.Add(e.Name.LocalName, (string)e);
                }
                metadata = dictionary;
            }
            return new Container(name, properties, metadata);
        }
    }
}
