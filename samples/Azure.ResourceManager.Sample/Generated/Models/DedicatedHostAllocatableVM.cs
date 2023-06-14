// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary>
    /// Represents the dedicated host unutilized capacity in terms of a specific VM size.
    /// Serialized Name: DedicatedHostAllocatableVM
    /// </summary>
    public partial class DedicatedHostAllocatableVM
    {
        /// <summary> Initializes a new instance of DedicatedHostAllocatableVM. </summary>
        internal DedicatedHostAllocatableVM()
        {
        }

        /// <summary> Initializes a new instance of DedicatedHostAllocatableVM. </summary>
        /// <param name="vmSize">
        /// VM size in terms of which the unutilized capacity is represented.
        /// Serialized Name: DedicatedHostAllocatableVM.vmSize
        /// </param>
        /// <param name="count">
        /// Maximum number of VMs of size vmSize that can fit in the dedicated host's remaining capacity.
        /// Serialized Name: DedicatedHostAllocatableVM.count
        /// </param>
        internal DedicatedHostAllocatableVM(string vmSize, double? count)
        {
            VmSize = vmSize;
            Count = count;
        }

        /// <summary>
        /// VM size in terms of which the unutilized capacity is represented.
        /// Serialized Name: DedicatedHostAllocatableVM.vmSize
        /// </summary>
        public string VmSize { get; }
        /// <summary>
        /// Maximum number of VMs of size vmSize that can fit in the dedicated host's remaining capacity.
        /// Serialized Name: DedicatedHostAllocatableVM.count
        /// </summary>
        public double? Count { get; }
    }
}
