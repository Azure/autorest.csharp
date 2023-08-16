// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
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
        private Dictionary<string, BinaryData> _rawData;

        /// <summary>
        /// Initializes a new instance of global::MgmtSingletonResource.SingletonResourceData
        ///
        /// </summary>
        public SingletonResourceData()
        {
        }

        /// <summary>
        /// Initializes a new instance of global::MgmtSingletonResource.SingletonResourceData
        ///
        /// </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="new"></param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal SingletonResourceData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, string @new, Dictionary<string, BinaryData> rawData) : base(id, name, resourceType, systemData)
        {
            New = @new;
            _rawData = rawData;
        }

        /// <summary> Gets or sets the new. </summary>
        public string New { get; set; }
    }
}
