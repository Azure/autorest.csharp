// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Storage.Tables.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class StorageTablesModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="TableQueryResponse"/>. </summary>
        /// <param name="odataMetadata"> The metadata response of the table. </param>
        /// <param name="value"> List of tables. </param>
        /// <returns> A new <see cref="Models.TableQueryResponse"/> instance for mocking. </returns>
        public static TableQueryResponse TableQueryResponse(string odataMetadata = null, IEnumerable<TableResponseProperties> value = null)
        {
            value ??= new List<TableResponseProperties>();

            return new TableQueryResponse(odataMetadata, value?.ToList(), default);
        }

        /// <summary> Initializes a new instance of <see cref="TableResponseProperties"/>. </summary>
        /// <param name="tableName"> The name of the table. </param>
        /// <param name="odataType"> The odata type of the table. </param>
        /// <param name="odataId"> The id of the table. </param>
        /// <param name="odataEditLink"> The edit link of the table. </param>
        /// <returns> A new <see cref="Models.TableResponseProperties"/> instance for mocking. </returns>
        public static TableResponseProperties TableResponseProperties(string tableName = null, string odataType = null, string odataId = null, string odataEditLink = null)
        {
            return new TableResponseProperties(tableName, odataType, odataId, odataEditLink, default);
        }

        /// <summary> Initializes a new instance of <see cref="TableResponse"/>. </summary>
        /// <param name="tableName"> The name of the table. </param>
        /// <param name="odataType"> The odata type of the table. </param>
        /// <param name="odataId"> The id of the table. </param>
        /// <param name="odataEditLink"> The edit link of the table. </param>
        /// <param name="odataMetadata"> The metadata response of the table. </param>
        /// <returns> A new <see cref="Models.TableResponse"/> instance for mocking. </returns>
        public static TableResponse TableResponse(string tableName = null, string odataType = null, string odataId = null, string odataEditLink = null, string odataMetadata = null)
        {
            return new TableResponse(tableName, odataType, odataId, odataEditLink, odataMetadata, default);
        }

        /// <summary> Initializes a new instance of <see cref="TableEntityQueryResponse"/>. </summary>
        /// <param name="odataMetadata"> The metadata response of the table. </param>
        /// <param name="value"> List of table entities. </param>
        /// <returns> A new <see cref="Models.TableEntityQueryResponse"/> instance for mocking. </returns>
        public static TableEntityQueryResponse TableEntityQueryResponse(string odataMetadata = null, IEnumerable<IDictionary<string, object>> value = null)
        {
            value ??= new List<IDictionary<string, object>>();

            return new TableEntityQueryResponse(odataMetadata, value?.ToList(), default);
        }

        /// <summary> Initializes a new instance of <see cref="StorageServiceStats"/>. </summary>
        /// <param name="geoReplication"> Geo-Replication information for the Secondary Storage Service. </param>
        /// <returns> A new <see cref="Models.StorageServiceStats"/> instance for mocking. </returns>
        public static StorageServiceStats StorageServiceStats(GeoReplication geoReplication = null)
        {
            return new StorageServiceStats(geoReplication, default);
        }

        /// <summary> Initializes a new instance of <see cref="GeoReplication"/>. </summary>
        /// <param name="status"> The status of the secondary location. </param>
        /// <param name="lastSyncTime"> A GMT date/time value, to the second. All primary writes preceding this value are guaranteed to be available for read operations at the secondary. Primary writes after this point in time may or may not be available for reads. </param>
        /// <returns> A new <see cref="Models.GeoReplication"/> instance for mocking. </returns>
        public static GeoReplication GeoReplication(GeoReplicationStatusType status = default, DateTimeOffset lastSyncTime = default)
        {
            return new GeoReplication(status, lastSyncTime, default);
        }
    }
}
