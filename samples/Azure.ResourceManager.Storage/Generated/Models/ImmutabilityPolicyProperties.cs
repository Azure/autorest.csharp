// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure;
using Azure.Core;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> The properties of an ImmutabilityPolicy of a blob container. </summary>
    public partial class ImmutabilityPolicyProperties
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="ImmutabilityPolicyProperties"/>. </summary>
        internal ImmutabilityPolicyProperties()
        {
            UpdateHistory = new ChangeTrackingList<UpdateHistoryProperty>();
        }

        /// <summary> Initializes a new instance of <see cref="ImmutabilityPolicyProperties"/>. </summary>
        /// <param name="etag"> ImmutabilityPolicy Etag. </param>
        /// <param name="updateHistory"> The ImmutabilityPolicy update history of the blob container. </param>
        /// <param name="immutabilityPeriodSinceCreationInDays"> The immutability period for the blobs in the container since the policy creation, in days. </param>
        /// <param name="state"> The ImmutabilityPolicy state of a blob container, possible values include: Locked and Unlocked. </param>
        /// <param name="allowProtectedAppendWrites"> This property can only be changed for unlocked time-based retention policies. When enabled, new blocks can be written to an append blob while maintaining immutability protection and compliance. Only new blocks can be added and any existing blocks cannot be modified or deleted. This property cannot be changed with ExtendImmutabilityPolicy API. </param>
        /// <param name="allowProtectedAppendWritesAll"> This property can only be changed for unlocked time-based retention policies. When enabled, new blocks can be written to both 'Append and Bock Blobs' while maintaining immutability protection and compliance. Only new blocks can be added and any existing blocks cannot be modified or deleted. This property cannot be changed with ExtendImmutabilityPolicy API. The 'allowProtectedAppendWrites' and 'allowProtectedAppendWritesAll' properties are mutually exclusive. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal ImmutabilityPolicyProperties(ETag? etag, IReadOnlyList<UpdateHistoryProperty> updateHistory, int? immutabilityPeriodSinceCreationInDays, ImmutabilityPolicyState? state, bool? allowProtectedAppendWrites, bool? allowProtectedAppendWritesAll, Dictionary<string, BinaryData> rawData)
        {
            Etag = etag;
            UpdateHistory = updateHistory;
            ImmutabilityPeriodSinceCreationInDays = immutabilityPeriodSinceCreationInDays;
            State = state;
            AllowProtectedAppendWrites = allowProtectedAppendWrites;
            AllowProtectedAppendWritesAll = allowProtectedAppendWritesAll;
            _rawData = rawData;
        }

        /// <summary> ImmutabilityPolicy Etag. </summary>
        public ETag? Etag { get; }
        /// <summary> The ImmutabilityPolicy update history of the blob container. </summary>
        public IReadOnlyList<UpdateHistoryProperty> UpdateHistory { get; }
        /// <summary> The immutability period for the blobs in the container since the policy creation, in days. </summary>
        public int? ImmutabilityPeriodSinceCreationInDays { get; }
        /// <summary> The ImmutabilityPolicy state of a blob container, possible values include: Locked and Unlocked. </summary>
        public ImmutabilityPolicyState? State { get; }
        /// <summary> This property can only be changed for unlocked time-based retention policies. When enabled, new blocks can be written to an append blob while maintaining immutability protection and compliance. Only new blocks can be added and any existing blocks cannot be modified or deleted. This property cannot be changed with ExtendImmutabilityPolicy API. </summary>
        public bool? AllowProtectedAppendWrites { get; }
        /// <summary> This property can only be changed for unlocked time-based retention policies. When enabled, new blocks can be written to both 'Append and Bock Blobs' while maintaining immutability protection and compliance. Only new blocks can be added and any existing blocks cannot be modified or deleted. This property cannot be changed with ExtendImmutabilityPolicy API. The 'allowProtectedAppendWrites' and 'allowProtectedAppendWritesAll' properties are mutually exclusive. </summary>
        public bool? AllowProtectedAppendWritesAll { get; }
    }
}
