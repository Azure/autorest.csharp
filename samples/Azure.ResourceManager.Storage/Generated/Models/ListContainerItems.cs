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
    /// <summary> Response schema. Contains list of blobs returned, and if paging is requested or required, a URL to next page of containers. </summary>
    internal partial class ListContainerItems
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary>
        /// Initializes a new instance of global::Azure.ResourceManager.Storage.Models.ListContainerItems
        ///
        /// </summary>
        internal ListContainerItems()
        {
            Value = new ChangeTrackingList<BlobContainerData>();
        }

        /// <summary>
        /// Initializes a new instance of global::Azure.ResourceManager.Storage.Models.ListContainerItems
        ///
        /// </summary>
        /// <param name="value"> List of blobs containers returned. </param>
        /// <param name="nextLink"> Request URL that can be used to query next page of containers. Returned when total number of requested containers exceed maximum page size. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal ListContainerItems(IReadOnlyList<BlobContainerData> value, string nextLink, Dictionary<string, BinaryData> rawData)
        {
            Value = value;
            NextLink = nextLink;
            _rawData = rawData;
        }

        /// <summary> List of blobs containers returned. </summary>
        public IReadOnlyList<BlobContainerData> Value { get; }
        /// <summary> Request URL that can be used to query next page of containers. Returned when total number of requested containers exceed maximum page size. </summary>
        public string NextLink { get; }
    }
}
