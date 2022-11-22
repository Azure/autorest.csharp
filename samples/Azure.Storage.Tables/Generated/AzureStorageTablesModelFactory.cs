// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Storage.Tables.Models
{
    /// <summary> Model factory for read-only models. </summary>
    public static partial class AzureStorageTablesModelFactory
    {

        /// <summary> Initializes a new instance of TableResponseProperties. </summary>
        /// <param name="tableName"> The name of the table. </param>
        /// <param name="odataType"> The odata type of the table. </param>
        /// <param name="odataId"> The id of the table. </param>
        /// <param name="odataEditLink"> The edit link of the table. </param>
        /// <returns> A new <see cref="Models.TableResponseProperties"/> instance for mocking. </returns>
        public static TableResponseProperties TableResponseProperties(string tableName = null, string odataType = null, string odataId = null, string odataEditLink = null)
        {
            return new TableResponseProperties(tableName, odataType, odataId, odataEditLink);
        }

        /// <summary> Initializes a new instance of StorageServiceStats. </summary>
        /// <param name="geoReplication"> Geo-Replication information for the Secondary Storage Service. </param>
        /// <returns> A new <see cref="Models.StorageServiceStats"/> instance for mocking. </returns>
        public static StorageServiceStats StorageServiceStats(GeoReplication geoReplication = null)
        {
            return new StorageServiceStats(geoReplication);
        }

        /// <summary> Initializes a new instance of GeoReplication. </summary>
        /// <param name="status"> The status of the secondary location. </param>
        /// <param name="lastSyncTime"> A GMT date/time value, to the second. All primary writes preceding this value are guaranteed to be available for read operations at the secondary. Primary writes after this point in time may or may not be available for reads. </param>
        /// <returns> A new <see cref="Models.GeoReplication"/> instance for mocking. </returns>
        public static GeoReplication GeoReplication(GeoReplicationStatusType status = default, DateTimeOffset lastSyncTime = default)
        {
            return new GeoReplication(status, lastSyncTime);
        }
    }
}
