// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.ResourceManager;
using Azure.ResourceManager.Resources.Models;

namespace MgmtSingleton
{
    /// <summary> A class representing the TenantParentSingleton data model. </summary>
    public partial class TenantParentSingletonData : Resource
    {
        /// <summary> Initializes a new instance of TenantParentSingletonData. </summary>
        public TenantParentSingletonData()
        {
        }

        /// <summary> Initializes a new instance of TenantParentSingletonData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="type"> The type. </param>
        /// <param name="new"></param>
        internal TenantParentSingletonData(ResourceIdentifier id, string name, ResourceType type, string @new) : base(id, name, type)
        {
            New = @new;
        }

        public string New { get; set; }
    }
}
