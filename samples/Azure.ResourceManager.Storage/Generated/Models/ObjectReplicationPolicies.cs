// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Storage;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> List storage account object replication policies. </summary>
    internal partial class ObjectReplicationPolicies
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="ObjectReplicationPolicies"/>. </summary>
        internal ObjectReplicationPolicies()
        {
            Value = new ChangeTrackingList<ObjectReplicationPolicyData>();
        }

        /// <summary> Initializes a new instance of <see cref="ObjectReplicationPolicies"/>. </summary>
        /// <param name="value"> The replication policy between two storage accounts. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal ObjectReplicationPolicies(IReadOnlyList<ObjectReplicationPolicyData> value, Dictionary<string, BinaryData> rawData)
        {
            Value = value;
            _rawData = rawData;
        }

        /// <summary> The replication policy between two storage accounts. </summary>
        public IReadOnlyList<ObjectReplicationPolicyData> Value { get; }
    }
}
