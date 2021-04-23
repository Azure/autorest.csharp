// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.ResourceManager.Core;

namespace Azure.Management.Storage.Models
{
    /// <summary> A class representing the BlobService data model. </summary>
    public partial class BlobServiceData : Resource<TenantResourceIdentifier>
    {
        /// <summary> Initializes a new instance of BlobServiceData. </summary>
        public BlobServiceData()
        {
        }

        /// <summary> Initializes a new instance of BlobServiceData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="type"> The type. </param>
        /// <param name="sku"> Sku name and tier. </param>
        /// <param name="cors"> Specifies CORS rules for the Blob service. You can include up to five CorsRule elements in the request. If no CorsRule elements are included in the request body, all CORS rules will be deleted, and CORS will be disabled for the Blob service. </param>
        /// <param name="defaultServiceVersion"> DefaultServiceVersion indicates the default version to use for requests to the Blob service if an incoming request’s version is not specified. Possible values include version 2008-10-27 and all more recent versions. </param>
        /// <param name="deleteRetentionPolicy"> The blob service properties for blob soft delete. </param>
        /// <param name="isVersioningEnabled"> Versioning is enabled if set to true. </param>
        /// <param name="automaticSnapshotPolicyEnabled"> Deprecated in favor of isVersioningEnabled property. </param>
        /// <param name="changeFeed"> The blob service properties for change feed events. </param>
        /// <param name="restorePolicy"> The blob service properties for blob restore policy. </param>
        /// <param name="containerDeleteRetentionPolicy"> The blob service properties for container soft delete. </param>
<<<<<<< HEAD
        internal BlobServiceData(Sku sku, CorsRules cors, string defaultServiceVersion, DeleteRetentionPolicy deleteRetentionPolicy, bool? isVersioningEnabled, bool? automaticSnapshotPolicyEnabled, ChangeFeed changeFeed, RestorePolicyProperties restorePolicy, DeleteRetentionPolicy containerDeleteRetentionPolicy)
=======
        internal BlobServiceData(TenantResourceIdentifier id, string name, ResourceType type, SkuData sku, CorsRules cors, string defaultServiceVersion, DeleteRetentionPolicy deleteRetentionPolicy, bool? isVersioningEnabled, bool? automaticSnapshotPolicyEnabled, ChangeFeed changeFeed, RestorePolicyProperties restorePolicy, DeleteRetentionPolicy containerDeleteRetentionPolicy) : base(id, name, type)
>>>>>>> 39d8276362dc7bda4732be7e79b62d35d4d17724
        {
            Sku = sku;
            Cors = cors;
            DefaultServiceVersion = defaultServiceVersion;
            DeleteRetentionPolicy = deleteRetentionPolicy;
            IsVersioningEnabled = isVersioningEnabled;
            AutomaticSnapshotPolicyEnabled = automaticSnapshotPolicyEnabled;
            ChangeFeed = changeFeed;
            RestorePolicy = restorePolicy;
            ContainerDeleteRetentionPolicy = containerDeleteRetentionPolicy;
        }

        /// <summary> Sku name and tier. </summary>
        public Sku Sku { get; }
        /// <summary> Specifies CORS rules for the Blob service. You can include up to five CorsRule elements in the request. If no CorsRule elements are included in the request body, all CORS rules will be deleted, and CORS will be disabled for the Blob service. </summary>
        public CorsRules Cors { get; set; }
        /// <summary> DefaultServiceVersion indicates the default version to use for requests to the Blob service if an incoming request’s version is not specified. Possible values include version 2008-10-27 and all more recent versions. </summary>
        public string DefaultServiceVersion { get; set; }
        /// <summary> The blob service properties for blob soft delete. </summary>
        public DeleteRetentionPolicy DeleteRetentionPolicy { get; set; }
        /// <summary> Versioning is enabled if set to true. </summary>
        public bool? IsVersioningEnabled { get; set; }
        /// <summary> Deprecated in favor of isVersioningEnabled property. </summary>
        public bool? AutomaticSnapshotPolicyEnabled { get; set; }
        /// <summary> The blob service properties for change feed events. </summary>
        public ChangeFeed ChangeFeed { get; set; }
        /// <summary> The blob service properties for blob restore policy. </summary>
        public RestorePolicyProperties RestorePolicy { get; set; }
        /// <summary> The blob service properties for container soft delete. </summary>
        public DeleteRetentionPolicy ContainerDeleteRetentionPolicy { get; set; }
    }
}
