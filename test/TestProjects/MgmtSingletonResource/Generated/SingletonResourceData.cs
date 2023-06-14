// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.ResourceManager.Models;

namespace MgmtSingletonResource
{
    /// <summary>
    /// A class representing the SingletonResource data model.
    /// A singleton resource.
    /// </summary>
    public partial class SingletonResourceData : ResourceData
    {
        /// <summary> Initializes a new instance of SingletonResourceData. </summary>
        public SingletonResourceData()
        {
        }

        /// <summary> Initializes a new instance of SingletonResourceData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="new"></param>
        internal SingletonResourceData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, string @new) : base(id, name, resourceType, systemData)
        {
            New = @new;
        }

        /// <summary> Gets or sets the new. </summary>
        public string New { get; set; }
    }
}
