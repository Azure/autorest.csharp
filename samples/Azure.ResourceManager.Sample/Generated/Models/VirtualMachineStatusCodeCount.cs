// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary>
    /// The status code and count of the virtual machine scale set instance view status summary.
    /// Serialized Name: VirtualMachineStatusCodeCount
    /// </summary>
    public partial class VirtualMachineStatusCodeCount
    {
        /// <summary> Initializes a new instance of VirtualMachineStatusCodeCount. </summary>
        internal VirtualMachineStatusCodeCount()
        {
        }

        /// <summary> Initializes a new instance of VirtualMachineStatusCodeCount. </summary>
        /// <param name="code">
        /// The instance view status code.
        /// Serialized Name: VirtualMachineStatusCodeCount.code
        /// </param>
        /// <param name="count">
        /// The number of instances having a particular status code.
        /// Serialized Name: VirtualMachineStatusCodeCount.count
        /// </param>
        internal VirtualMachineStatusCodeCount(string code, int? count)
        {
            Code = code;
            Count = count;
        }

        /// <summary>
        /// The instance view status code.
        /// Serialized Name: VirtualMachineStatusCodeCount.code
        /// </summary>
        public string Code { get; }
        /// <summary>
        /// The number of instances having a particular status code.
        /// Serialized Name: VirtualMachineStatusCodeCount.count
        /// </summary>
        public int? Count { get; }
    }
}
