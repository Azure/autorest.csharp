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
    /// A class representing the ParentResource data model.
    /// A parent resource.
    /// </summary>
    public partial class ParentResourceData : TrackedResourceData
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="ParentResourceData"/>. </summary>
        /// <param name="location"> The location. </param>
        public ParentResourceData(AzureLocation location) : base(location)
        {
        }

        /// <summary> Initializes a new instance of <see cref="ParentResourceData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="new"></param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal ParentResourceData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, string @new, Dictionary<string, BinaryData> rawData) : base(id, name, resourceType, systemData, tags, location)
        {
            New = @new;
            _rawData = rawData;
        }

        /// <summary> Initializes a new instance of <see cref="ParentResourceData"/> for deserialization. </summary>
        internal ParentResourceData()
        {
        }

        /// <summary> Gets or sets the new. </summary>
        public string New { get; set; }
    }
}
