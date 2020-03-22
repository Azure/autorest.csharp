// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Xml.Linq;
using Azure.Core;

namespace Azure.Storage.Tables.Models
{
    public partial class StorageServiceStats
    {
        internal static StorageServiceStats DeserializeStorageServiceStats(XElement element)
        {
            var obj = new StorageServiceStats();
            if (element.Element("GeoReplication") is XElement geoReplication)
            {
                obj.GeoReplication = GeoReplication.DeserializeGeoReplication(geoReplication);
            }
            return obj;
        }
    }
}
