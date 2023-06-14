// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Xml.Linq;
using Azure.Core;

namespace xml_service.Models
{
    public partial class Blob
    {
        internal static Blob DeserializeBlob(XElement element)
        {
            string name = default;
            bool deleted = default;
            string snapshot = default;
            BlobProperties properties = default;
            IReadOnlyDictionary<string, string> metadata = default;
            if (element.Element("Name") is XElement nameElement)
            {
                name = (string)nameElement;
            }
            if (element.Element("Deleted") is XElement deletedElement)
            {
                deleted = (bool)deletedElement;
            }
            if (element.Element("Snapshot") is XElement snapshotElement)
            {
                snapshot = (string)snapshotElement;
            }
            if (element.Element("Properties") is XElement propertiesElement)
            {
                properties = BlobProperties.DeserializeBlobProperties(propertiesElement);
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
            return new Blob(name, deleted, snapshot, properties, metadata);
        }
    }
}
