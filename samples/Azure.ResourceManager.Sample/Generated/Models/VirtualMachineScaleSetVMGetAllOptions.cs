// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary> A class representing the optional parameters in this method. </summary>
    public partial class VirtualMachineScaleSetVMGetAllOptions
    {
        /// <summary> Initializes a new instance of VirtualMachineScaleSetVMGetAllOptions. </summary>
        public VirtualMachineScaleSetVMGetAllOptions()
        {
        }

        /// <summary> The filter to apply to the operation. Allowed values are &apos;startswith(instanceView/statuses/code, &apos;PowerState&apos;) eq true&apos;, &apos;properties/latestModelApplied eq true&apos;, &apos;properties/latestModelApplied eq false&apos;. </summary>
        public string Filter { get; set; }
        /// <summary> The list parameters. Allowed values are &apos;instanceView&apos;, &apos;instanceView/statuses&apos;. </summary>
        public string Select { get; set; }
        /// <summary> The expand expression to apply to the operation. Allowed values are &apos;instanceView&apos;. </summary>
        public string Expand { get; set; }
    }
}
