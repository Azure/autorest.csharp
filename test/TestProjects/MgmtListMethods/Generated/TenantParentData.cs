// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace MgmtListMethods
{
    /// <summary>
    /// A class representing the TenantParent data model.
    /// Specifies information about the fake that the virtual machine should be assigned to. Virtual machines specified in the same fake are allocated to different nodes to maximize availability. For more information about fakes, see [Manage the availability of virtual machines](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-windows-manage-availability?toc=%2fazure%2fvirtual-machines%2fwindows%2ftoc.json). &lt;br&gt;&lt;br&gt; For more information on Azure planned maintenance, see [Planned maintenance for virtual machines in Azure](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-windows-planned-maintenance?toc=%2fazure%2fvirtual-machines%2fwindows%2ftoc.json) &lt;br&gt;&lt;br&gt; Currently, a VM can only be added to fake at creation time. An existing VM cannot be added to an fake.
    /// </summary>
    public partial class TenantParentData : TrackedResourceData
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="TenantParentData"/>. </summary>
        /// <param name="location"> The location. </param>
        public TenantParentData(AzureLocation location) : base(location)
        {
        }

        /// <summary> Initializes a new instance of <see cref="TenantParentData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="bar"> specifies the bar. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal TenantParentData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, string bar, IDictionary<string, BinaryData> serializedAdditionalRawData) : base(id, name, resourceType, systemData, tags, location)
        {
            Bar = bar;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="TenantParentData"/> for deserialization. </summary>
        internal TenantParentData()
        {
        }

        /// <summary> specifies the bar. </summary>
        public string Bar { get; set; }
    }
}
