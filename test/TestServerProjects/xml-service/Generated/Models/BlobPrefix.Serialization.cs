// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Xml.Linq;
using Azure.Core;

namespace xml_service.Models
{
    public partial class BlobPrefix
    {
        internal static BlobPrefix DeserializeBlobPrefix(XElement element)
        {
            string name = default;
            if (element.Element("Name") is XElement nameElement)
            {
                name = (string)nameElement;
            }
            return new BlobPrefix(name);
        }
    }
}
