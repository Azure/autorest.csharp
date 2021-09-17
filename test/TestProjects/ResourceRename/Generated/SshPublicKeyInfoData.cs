// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.ResourceManager;
using Azure.ResourceManager.Models;
using ResourceRename.Models;

namespace ResourceRename
{
    /// <summary> A class representing the SshPublicKeyInfo data model. </summary>
    public partial class SshPublicKeyInfoData : Resource
    {
        /// <summary> Initializes a new instance of SshPublicKeyInfoData. </summary>
        public SshPublicKeyInfoData()
        {
        }

        /// <summary> Initializes a new instance of SshPublicKeyInfoData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="type"> The type. </param>
        /// <param name="properties"></param>
        internal SshPublicKeyInfoData(ResourceIdentifier id, string name, ResourceType type, SshPublicKeyProperties properties) : base(id, name, type)
        {
            Properties = properties;
        }

        /// <summary> Gets or sets the properties. </summary>
        public SshPublicKeyProperties Properties { get; set; }
    }
}
