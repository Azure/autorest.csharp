// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> An object that defines the blob inventory rule filter conditions. For 'Blob' definition.objectType all filter properties are applicable, 'blobTypes' is required and others are optional. For 'Container' definition.objectType only prefixMatch is applicable and is optional. </summary>
    public partial class BlobInventoryPolicyFilter
    {
        /// <summary> Initializes a new instance of BlobInventoryPolicyFilter. </summary>
        public BlobInventoryPolicyFilter()
        {
            PrefixMatch = new ChangeTrackingList<string>();
            BlobTypes = new ChangeTrackingList<string>();
        }

        /// <summary> Initializes a new instance of BlobInventoryPolicyFilter. </summary>
        /// <param name="prefixMatch"> An array of strings for blob prefixes to be matched. </param>
        /// <param name="blobTypes"> An array of predefined enum values. Valid values include blockBlob, appendBlob, pageBlob. Hns accounts does not support pageBlobs. This field is required when definition.objectType property is set to 'Blob'. </param>
        /// <param name="includeBlobVersions"> Includes blob versions in blob inventory when value is set to true. The definition.schemaFields values 'VersionId and IsCurrentVersion' are required if this property is set to true, else they must be excluded. </param>
        /// <param name="includeSnapshots"> Includes blob snapshots in blob inventory when value is set to true. The definition.schemaFields value 'Snapshot' is required if this property is set to true, else it must be excluded. </param>
        internal BlobInventoryPolicyFilter(IList<string> prefixMatch, IList<string> blobTypes, bool? includeBlobVersions, bool? includeSnapshots)
        {
            PrefixMatch = prefixMatch;
            BlobTypes = blobTypes;
            IncludeBlobVersions = includeBlobVersions;
            IncludeSnapshots = includeSnapshots;
        }

        /// <summary> An array of strings for blob prefixes to be matched. </summary>
        public IList<string> PrefixMatch { get; }
        /// <summary> An array of predefined enum values. Valid values include blockBlob, appendBlob, pageBlob. Hns accounts does not support pageBlobs. This field is required when definition.objectType property is set to 'Blob'. </summary>
        public IList<string> BlobTypes { get; }
        /// <summary> Includes blob versions in blob inventory when value is set to true. The definition.schemaFields values 'VersionId and IsCurrentVersion' are required if this property is set to true, else they must be excluded. </summary>
        public bool? IncludeBlobVersions { get; set; }
        /// <summary> Includes blob snapshots in blob inventory when value is set to true. The definition.schemaFields value 'Snapshot' is required if this property is set to true, else it must be excluded. </summary>
        public bool? IncludeSnapshots { get; set; }
    }
}
