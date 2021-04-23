// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.ResourceManager.Core;

namespace Azure.Management.Storage.Models
{
    /// <summary> A class representing the FileService data model. </summary>
    public partial class FileServiceData : Resource<TenantResourceIdentifier>
    {
        /// <summary> Initializes a new instance of FileServiceData. </summary>
        public FileServiceData()
        {
        }

        /// <summary> Initializes a new instance of FileServiceData. </summary>
        /// <param name="sku"> Sku name and tier. </param>
        /// <param name="cors"> Specifies CORS rules for the File service. You can include up to five CorsRule elements in the request. If no CorsRule elements are included in the request body, all CORS rules will be deleted, and CORS will be disabled for the File service. </param>
        /// <param name="shareDeleteRetentionPolicy"> The file service properties for share soft delete. </param>
        internal FileServiceData(SkuData sku, CorsRules cors, DeleteRetentionPolicy shareDeleteRetentionPolicy)
        {
            Sku = sku;
            Cors = cors;
            ShareDeleteRetentionPolicy = shareDeleteRetentionPolicy;
        }

        /// <summary> ARM resource type. </summary>
        public static ResourceType ResourceType => "todo: find out resource type";

        /// <summary> Sku name and tier. </summary>
        public SkuData Sku { get; }
        /// <summary> Specifies CORS rules for the File service. You can include up to five CorsRule elements in the request. If no CorsRule elements are included in the request body, all CORS rules will be deleted, and CORS will be disabled for the File service. </summary>
        public CorsRules Cors { get; set; }
        /// <summary> The file service properties for share soft delete. </summary>
        public DeleteRetentionPolicy ShareDeleteRetentionPolicy { get; set; }
    }
}
