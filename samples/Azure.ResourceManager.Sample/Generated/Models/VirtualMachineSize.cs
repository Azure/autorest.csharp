// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary>
    /// Describes the properties of a VM size.
    /// Serialized Name: VirtualMachineSize
    /// </summary>
    public partial class VirtualMachineSize
    {
        /// <summary> Initializes a new instance of VirtualMachineSize. </summary>
        internal VirtualMachineSize()
        {
        }

        /// <summary> Initializes a new instance of VirtualMachineSize. </summary>
        /// <param name="name">
        /// The name of the virtual machine size.
        /// Serialized Name: VirtualMachineSize.name
        /// </param>
        /// <param name="numberOfCores">
        /// The number of cores supported by the virtual machine size.
        /// Serialized Name: VirtualMachineSize.numberOfCores
        /// </param>
        /// <param name="osDiskSizeInMB">
        /// The OS disk size, in MB, allowed by the virtual machine size.
        /// Serialized Name: VirtualMachineSize.osDiskSizeInMB
        /// </param>
        /// <param name="resourceDiskSizeInMB">
        /// The resource disk size, in MB, allowed by the virtual machine size.
        /// Serialized Name: VirtualMachineSize.resourceDiskSizeInMB
        /// </param>
        /// <param name="memoryInMB">
        /// The amount of memory, in MB, supported by the virtual machine size.
        /// Serialized Name: VirtualMachineSize.memoryInMB
        /// </param>
        /// <param name="maxDataDiskCount">
        /// The maximum number of data disks that can be attached to the virtual machine size.
        /// Serialized Name: VirtualMachineSize.maxDataDiskCount
        /// </param>
        internal VirtualMachineSize(string name, int? numberOfCores, int? osDiskSizeInMB, int? resourceDiskSizeInMB, int? memoryInMB, int? maxDataDiskCount)
        {
            Name = name;
            NumberOfCores = numberOfCores;
            OsDiskSizeInMB = osDiskSizeInMB;
            ResourceDiskSizeInMB = resourceDiskSizeInMB;
            MemoryInMB = memoryInMB;
            MaxDataDiskCount = maxDataDiskCount;
        }

        /// <summary>
        /// The name of the virtual machine size.
        /// Serialized Name: VirtualMachineSize.name
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// The number of cores supported by the virtual machine size.
        /// Serialized Name: VirtualMachineSize.numberOfCores
        /// </summary>
        public int? NumberOfCores { get; }
        /// <summary>
        /// The OS disk size, in MB, allowed by the virtual machine size.
        /// Serialized Name: VirtualMachineSize.osDiskSizeInMB
        /// </summary>
        public int? OsDiskSizeInMB { get; }
        /// <summary>
        /// The resource disk size, in MB, allowed by the virtual machine size.
        /// Serialized Name: VirtualMachineSize.resourceDiskSizeInMB
        /// </summary>
        public int? ResourceDiskSizeInMB { get; }
        /// <summary>
        /// The amount of memory, in MB, supported by the virtual machine size.
        /// Serialized Name: VirtualMachineSize.memoryInMB
        /// </summary>
        public int? MemoryInMB { get; }
        /// <summary>
        /// The maximum number of data disks that can be attached to the virtual machine size.
        /// Serialized Name: VirtualMachineSize.maxDataDiskCount
        /// </summary>
        public int? MaxDataDiskCount { get; }
    }
}
