// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.Storage.Tables.Models
{
    /// <summary> Stats for the storage service. </summary>
    public partial class StorageServiceStats
    {
        /// <summary> Initializes a new instance of StorageServiceStats. </summary>
        internal StorageServiceStats()
        {
        }

        /// <summary> Initializes a new instance of StorageServiceStats. </summary>
        /// <param name="geoReplication"> Geo-Replication information for the Secondary Storage Service. </param>
        internal StorageServiceStats(GeoReplication geoReplication)
        {
            GeoReplication = geoReplication;
        }

        /// <summary> Geo-Replication information for the Secondary Storage Service. </summary>
        public GeoReplication GeoReplication { get; }
    }
}
