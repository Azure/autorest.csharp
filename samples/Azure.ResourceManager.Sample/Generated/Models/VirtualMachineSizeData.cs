// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace Azure.ResourceManager.Sample
{
    /// <summary> A class representing the VirtualMachineSize data model. </summary>
    public partial class VirtualMachineSizeData
    {
        /// <summary> The name of the virtual machine size. </summary>
        public string Name { get; }
        /// <summary> The number of cores supported by the virtual machine size. </summary>
        public int? NumberOfCores { get; }
        /// <summary> The OS disk size, in MB, allowed by the virtual machine size. </summary>
        public int? OsDiskSizeInMB { get; }
        /// <summary> The resource disk size, in MB, allowed by the virtual machine size. </summary>
        public int? ResourceDiskSizeInMB { get; }
        /// <summary> The amount of memory, in MB, supported by the virtual machine size. </summary>
        public int? MemoryInMB { get; }
        /// <summary> The maximum number of data disks that can be attached to the virtual machine size. </summary>
        public int? MaxDataDiskCount { get; }
    }
}
