// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Storage;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> Response schema. Contains list of blobs returned, and if paging is requested or required, a URL to next page of containers. </summary>
    internal partial class ListContainerItems
    {
        /// <summary> Initializes a new instance of ListContainerItems. </summary>
        internal ListContainerItems()
        {
            Value = new ChangeTrackingList<BlobContainerData>();
        }

        /// <summary> Initializes a new instance of ListContainerItems. </summary>
        /// <param name="value"> List of blobs containers returned. </param>
        /// <param name="nextLink"> Request URL that can be used to query next page of containers. Returned when total number of requested containers exceed maximum page size. </param>
        internal ListContainerItems(IReadOnlyList<BlobContainerData> value, string nextLink)
        {
            Value = value;
            NextLink = nextLink;
        }

        /// <summary> List of blobs containers returned. </summary>
        public IReadOnlyList<BlobContainerData> Value { get; }
        /// <summary> Request URL that can be used to query next page of containers. Returned when total number of requested containers exceed maximum page size. </summary>
        public string NextLink { get; }
    }
}
