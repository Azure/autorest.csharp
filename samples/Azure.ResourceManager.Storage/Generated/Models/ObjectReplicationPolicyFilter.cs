// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> Filters limit replication to a subset of blobs within the storage account. A logical OR is performed on values in the filter. If multiple filters are defined, a logical AND is performed on all filters. </summary>
    public partial class ObjectReplicationPolicyFilter
    {
        /// <summary> Initializes a new instance of ObjectReplicationPolicyFilter. </summary>
        public ObjectReplicationPolicyFilter()
        {
            PrefixMatch = new ChangeTrackingList<string>();
        }

        /// <summary> Initializes a new instance of ObjectReplicationPolicyFilter. </summary>
        /// <param name="prefixMatch"> Optional. Filters the results to replicate only blobs whose names begin with the specified prefix. </param>
        /// <param name="minCreationTime"> Blobs created after the time will be replicated to the destination. It must be in datetime format 'yyyy-MM-ddTHH:mm:ssZ'. Example: 2020-02-19T16:05:00Z. </param>
        internal ObjectReplicationPolicyFilter(IList<string> prefixMatch, string minCreationTime)
        {
            PrefixMatch = prefixMatch;
            MinCreationTime = minCreationTime;
        }

        /// <summary> Optional. Filters the results to replicate only blobs whose names begin with the specified prefix. </summary>
        public IList<string> PrefixMatch { get; }
        /// <summary> Blobs created after the time will be replicated to the destination. It must be in datetime format 'yyyy-MM-ddTHH:mm:ssZ'. Example: 2020-02-19T16:05:00Z. </summary>
        public string MinCreationTime { get; set; }
    }
}
