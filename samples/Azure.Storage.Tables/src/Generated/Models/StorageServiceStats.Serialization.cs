// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Xml.Linq;
using Azure.Core;

namespace Azure.Storage.Tables.Models
{
    public partial class StorageServiceStats
    {
        internal static StorageServiceStats DeserializeStorageServiceStats(XElement element)
        {
            GeoReplication geoReplication = default;
            if (element.Element("GeoReplication") is XElement geoReplicationElement)
            {
                geoReplication = GeoReplication.DeserializeGeoReplication(geoReplicationElement);
            }
            return new StorageServiceStats(geoReplication);
        }
    }
}
