// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources.Models;

namespace MgmtContextualPath.Models
{
    /// <summary> Specifies information about the fake that the virtual machine should be assigned to. Virtual machines specified in the same fake are allocated to different nodes to maximize availability. For more information about fakes, see [Manage the availability of virtual machines](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-windows-manage-availability?toc=%2fazure%2fvirtual-machines%2fwindows%2ftoc.json). &lt;br&gt;&lt;br&gt; For more information on Azure planned maintenance, see [Planned maintenance for virtual machines in Azure](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-windows-planned-maintenance?toc=%2fazure%2fvirtual-machines%2fwindows%2ftoc.json) &lt;br&gt;&lt;br&gt; Currently, a VM can only be added to fake at creation time. An existing VM cannot be added to an fake. </summary>
    public partial class TenantTest : TrackedResource
    {
        /// <summary> Initializes a new instance of TenantTest. </summary>
        /// <param name="location"> The location. </param>
        public TenantTest(Location location) : base(location)
        {
        }

        /// <summary> Initializes a new instance of TenantTest. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="type"> The type. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="bar"> specifies the bar. </param>
        internal TenantTest(ResourceIdentifier id, string name, ResourceType type, IDictionary<string, string> tags, Location location, string bar) : base(id, name, type, tags, location)
        {
            Bar = bar;
        }

        /// <summary> specifies the bar. </summary>
        public string Bar { get; set; }
    }
}
