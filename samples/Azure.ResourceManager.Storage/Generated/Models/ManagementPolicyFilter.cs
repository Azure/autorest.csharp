// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> Filters limit rule actions to a subset of blobs within the storage account. If multiple filters are defined, a logical AND is performed on all filters. </summary>
    public partial class ManagementPolicyFilter
    {
        /// <summary> Initializes a new instance of ManagementPolicyFilter. </summary>
        /// <param name="blobTypes"> An array of predefined enum values. Currently blockBlob supports all tiering and delete actions. Only delete actions are supported for appendBlob. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="blobTypes"/> is null. </exception>
        public ManagementPolicyFilter(IEnumerable<string> blobTypes)
        {
            Argument.AssertNotNull(blobTypes, nameof(blobTypes));

            PrefixMatch = new ChangeTrackingList<string>();
            BlobTypes = blobTypes.ToList();
            BlobIndexMatch = new ChangeTrackingList<TagFilter>();
        }

        /// <summary> Initializes a new instance of ManagementPolicyFilter. </summary>
        /// <param name="prefixMatch"> An array of strings for prefixes to be match. </param>
        /// <param name="blobTypes"> An array of predefined enum values. Currently blockBlob supports all tiering and delete actions. Only delete actions are supported for appendBlob. </param>
        /// <param name="blobIndexMatch"> An array of blob index tag based filters, there can be at most 10 tag filters. </param>
        internal ManagementPolicyFilter(IList<string> prefixMatch, IList<string> blobTypes, IList<TagFilter> blobIndexMatch)
        {
            PrefixMatch = prefixMatch;
            BlobTypes = blobTypes;
            BlobIndexMatch = blobIndexMatch;
        }

        /// <summary> An array of strings for prefixes to be match. </summary>
        public IList<string> PrefixMatch { get; }
        /// <summary> An array of predefined enum values. Currently blockBlob supports all tiering and delete actions. Only delete actions are supported for appendBlob. </summary>
        public IList<string> BlobTypes { get; }
        /// <summary> An array of blob index tag based filters, there can be at most 10 tag filters. </summary>
        public IList<TagFilter> BlobIndexMatch { get; }
    }
}
