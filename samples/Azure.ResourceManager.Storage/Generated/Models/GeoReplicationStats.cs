// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> Statistics related to replication for storage account's Blob, Table, Queue and File services. It is only available when geo-redundant replication is enabled for the storage account. </summary>
    public partial class GeoReplicationStats
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="GeoReplicationStats"/>. </summary>
        internal GeoReplicationStats()
        {
        }

        /// <summary> Initializes a new instance of <see cref="GeoReplicationStats"/>. </summary>
        /// <param name="status"> The status of the secondary location. Possible values are: - Live: Indicates that the secondary location is active and operational. - Bootstrap: Indicates initial synchronization from the primary location to the secondary location is in progress.This typically occurs when replication is first enabled. - Unavailable: Indicates that the secondary location is temporarily unavailable. </param>
        /// <param name="lastSyncOn"> All primary writes preceding this UTC date/time value are guaranteed to be available for read operations. Primary writes following this point in time may or may not be available for reads. Element may be default value if value of LastSyncTime is not available, this can happen if secondary is offline or we are in bootstrap. </param>
        /// <param name="canFailover"> A boolean flag which indicates whether or not account failover is supported for the account. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal GeoReplicationStats(GeoReplicationStatus? status, DateTimeOffset? lastSyncOn, bool? canFailover, Dictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Status = status;
            LastSyncOn = lastSyncOn;
            CanFailover = canFailover;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> The status of the secondary location. Possible values are: - Live: Indicates that the secondary location is active and operational. - Bootstrap: Indicates initial synchronization from the primary location to the secondary location is in progress.This typically occurs when replication is first enabled. - Unavailable: Indicates that the secondary location is temporarily unavailable. </summary>
        public GeoReplicationStatus? Status { get; }
        /// <summary> All primary writes preceding this UTC date/time value are guaranteed to be available for read operations. Primary writes following this point in time may or may not be available for reads. Element may be default value if value of LastSyncTime is not available, this can happen if secondary is offline or we are in bootstrap. </summary>
        public DateTimeOffset? LastSyncOn { get; }
        /// <summary> A boolean flag which indicates whether or not account failover is supported for the account. </summary>
        public bool? CanFailover { get; }
    }
}
