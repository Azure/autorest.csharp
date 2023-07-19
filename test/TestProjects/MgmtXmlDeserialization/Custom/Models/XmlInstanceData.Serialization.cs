// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using System.Xml;
using System.Xml.Linq;
using Azure.Core;
using Azure.Core.Serialization;
using Azure.ResourceManager.Models;

namespace MgmtXmlDeserialization
{
    public partial class XmlInstanceData : IUtf8JsonSerializable, IXmlSerializable
    {
        internal static XmlInstanceData DeserializeXmlInstanceData(XElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.AzureServiceDefault;
            ResourceIdentifier id = default;
            string name = default;
            ResourceType type = default;
            if (element.Element("id") is XElement idElement)
            {
                id = new ResourceIdentifier((string)idElement);
            }
            if (element.Element("name") is XElement nameElement)
            {
                name = (string)nameElement;
            }
            if (element.Element("type") is XElement typeElement)
            {
                type = (string)typeElement;
            }
            return new XmlInstanceData(id, name, type, null);
        }
    }
}
