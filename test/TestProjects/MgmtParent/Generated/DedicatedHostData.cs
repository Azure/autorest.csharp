// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace MgmtParent
{
    /// <summary>
    /// A class representing the DedicatedHost data model.
    /// Specifies information about the Dedicated host.
    /// </summary>
    public partial class DedicatedHostData : TrackedResourceData
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="DedicatedHostData"/>. </summary>
        /// <param name="location"> The location. </param>
        public DedicatedHostData(AzureLocation location) : base(location)
        {
        }

        /// <summary> Initializes a new instance of <see cref="DedicatedHostData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="foo"> specifies the foo. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal DedicatedHostData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, string foo, Dictionary<string, BinaryData> rawData) : base(id, name, resourceType, systemData, tags, location)
        {
            Foo = foo;
            _rawData = rawData;
        }

        /// <summary> Initializes a new instance of <see cref="DedicatedHostData"/> for deserialization. </summary>
        internal DedicatedHostData()
        {
        }

        /// <summary> specifies the foo. </summary>
        public string Foo { get; set; }
    }
}
