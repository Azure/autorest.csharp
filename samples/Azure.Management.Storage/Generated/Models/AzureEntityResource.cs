// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.Management.Storage.Models
{
    /// <summary> The resource model definition for an Azure Resource Manager resource with an etag. </summary>
    public partial class AzureEntityResource : ResourceData
    {
        /// <summary> Initializes a new instance of AzureEntityResource. </summary>
        public AzureEntityResource()
        {
        }

        /// <summary> Initializes a new instance of AzureEntityResource. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="etag"> Resource Etag. </param>
        internal AzureEntityResource(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, string etag) : base(id, name, resourceType, systemData)
        {
            Etag = etag;
        }

        /// <summary> Resource Etag. </summary>
        public string Etag { get; }
    }
}
