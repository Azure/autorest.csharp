// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace MgmtParamOrdering
{
    /// <summary>
    /// A class representing the VirtualMachineExtensionImage data model.
    /// The VirtualMachineExtensionImage.
    /// </summary>
    public partial class VirtualMachineExtensionImageData : TrackedResourceData
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary>
        /// Initializes a new instance of global::MgmtParamOrdering.VirtualMachineExtensionImageData
        ///
        /// </summary>
        /// <param name="location"> The location. </param>
        public VirtualMachineExtensionImageData(AzureLocation location) : base(location)
        {
        }

        /// <summary>
        /// Initializes a new instance of global::MgmtParamOrdering.VirtualMachineExtensionImageData
        ///
        /// </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="bar"> specifies the bar. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal VirtualMachineExtensionImageData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, string bar, Dictionary<string, BinaryData> rawData) : base(id, name, resourceType, systemData, tags, location)
        {
            Bar = bar;
            _rawData = rawData;
        }

        /// <summary> specifies the bar. </summary>
        public string Bar { get; set; }
    }
}
