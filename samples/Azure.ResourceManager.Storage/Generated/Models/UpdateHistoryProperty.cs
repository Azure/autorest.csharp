// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> An update history of the ImmutabilityPolicy of a blob container. </summary>
    public partial class UpdateHistoryProperty
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="UpdateHistoryProperty"/>. </summary>
        internal UpdateHistoryProperty()
        {
        }

        /// <summary> Initializes a new instance of <see cref="UpdateHistoryProperty"/>. </summary>
        /// <param name="update"> The ImmutabilityPolicy update type of a blob container, possible values include: put, lock and extend. </param>
        /// <param name="immutabilityPeriodSinceCreationInDays"> The immutability period for the blobs in the container since the policy creation, in days. </param>
        /// <param name="timestamp"> Returns the date and time the ImmutabilityPolicy was updated. </param>
        /// <param name="objectIdentifier"> Returns the Object ID of the user who updated the ImmutabilityPolicy. </param>
        /// <param name="tenantId"> Returns the Tenant ID that issued the token for the user who updated the ImmutabilityPolicy. </param>
        /// <param name="upn"> Returns the User Principal Name of the user who updated the ImmutabilityPolicy. </param>
        /// <param name="allowProtectedAppendWrites"> This property can only be changed for unlocked time-based retention policies. When enabled, new blocks can be written to an append blob while maintaining immutability protection and compliance. Only new blocks can be added and any existing blocks cannot be modified or deleted. This property cannot be changed with ExtendImmutabilityPolicy API. </param>
        /// <param name="allowProtectedAppendWritesAll"> This property can only be changed for unlocked time-based retention policies. When enabled, new blocks can be written to both 'Append and Bock Blobs' while maintaining immutability protection and compliance. Only new blocks can be added and any existing blocks cannot be modified or deleted. This property cannot be changed with ExtendImmutabilityPolicy API. The 'allowProtectedAppendWrites' and 'allowProtectedAppendWritesAll' properties are mutually exclusive. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal UpdateHistoryProperty(ImmutabilityPolicyUpdateType? update, int? immutabilityPeriodSinceCreationInDays, DateTimeOffset? timestamp, string objectIdentifier, Guid? tenantId, string upn, bool? allowProtectedAppendWrites, bool? allowProtectedAppendWritesAll, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Update = update;
            ImmutabilityPeriodSinceCreationInDays = immutabilityPeriodSinceCreationInDays;
            Timestamp = timestamp;
            ObjectIdentifier = objectIdentifier;
            TenantId = tenantId;
            Upn = upn;
            AllowProtectedAppendWrites = allowProtectedAppendWrites;
            AllowProtectedAppendWritesAll = allowProtectedAppendWritesAll;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> The ImmutabilityPolicy update type of a blob container, possible values include: put, lock and extend. </summary>
        public ImmutabilityPolicyUpdateType? Update { get; }
        /// <summary> The immutability period for the blobs in the container since the policy creation, in days. </summary>
        public int? ImmutabilityPeriodSinceCreationInDays { get; }
        /// <summary> Returns the date and time the ImmutabilityPolicy was updated. </summary>
        public DateTimeOffset? Timestamp { get; }
        /// <summary> Returns the Object ID of the user who updated the ImmutabilityPolicy. </summary>
        public string ObjectIdentifier { get; }
        /// <summary> Returns the Tenant ID that issued the token for the user who updated the ImmutabilityPolicy. </summary>
        public Guid? TenantId { get; }
        /// <summary> Returns the User Principal Name of the user who updated the ImmutabilityPolicy. </summary>
        public string Upn { get; }
        /// <summary> This property can only be changed for unlocked time-based retention policies. When enabled, new blocks can be written to an append blob while maintaining immutability protection and compliance. Only new blocks can be added and any existing blocks cannot be modified or deleted. This property cannot be changed with ExtendImmutabilityPolicy API. </summary>
        public bool? AllowProtectedAppendWrites { get; }
        /// <summary> This property can only be changed for unlocked time-based retention policies. When enabled, new blocks can be written to both 'Append and Bock Blobs' while maintaining immutability protection and compliance. Only new blocks can be added and any existing blocks cannot be modified or deleted. This property cannot be changed with ExtendImmutabilityPolicy API. The 'allowProtectedAppendWrites' and 'allowProtectedAppendWritesAll' properties are mutually exclusive. </summary>
        public bool? AllowProtectedAppendWritesAll { get; }
    }
}
