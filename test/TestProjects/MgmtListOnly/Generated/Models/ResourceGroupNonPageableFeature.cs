// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace MgmtListOnly.Models
{
    /// <summary> Specifies information about the fake that the virtual machine should be assigned to. Virtual machines specified in the same fake are allocated to different nodes to maximize availability. For more information about fakes, see [Manage the availability of virtual machines](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-windows-manage-availability?toc=%2fazure%2fvirtual-machines%2fwindows%2ftoc.json). &lt;br&gt;&lt;br&gt; For more information on Azure planned maintenance, see [Planned maintenance for virtual machines in Azure](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-windows-planned-maintenance?toc=%2fazure%2fvirtual-machines%2fwindows%2ftoc.json) &lt;br&gt;&lt;br&gt; Currently, a VM can only be added to fake at creation time. An existing VM cannot be added to an fake. </summary>
    public partial class ResourceGroupNonPageableFeature
    {
        /// <summary> Initializes a new instance of ResourceGroupNonPageableFeature. </summary>
        internal ResourceGroupNonPageableFeature()
        {
        }

        /// <summary> Initializes a new instance of ResourceGroupNonPageableFeature. </summary>
        /// <param name="foo"> specifies the bar. </param>
        internal ResourceGroupNonPageableFeature(string foo)
        {
            Foo = foo;
        }

        /// <summary> specifies the bar. </summary>
        public string Foo { get; }
    }
}
