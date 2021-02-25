// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace Azure.ResourceManager.Sample
{
    /// <summary> Describes scaling information of a sku. </summary>
    public partial class VirtualMachineScaleSetSkuCapacity
    {
        /// <summary> Initializes a new instance of VirtualMachineScaleSetSkuCapacity. </summary>
        internal VirtualMachineScaleSetSkuCapacity()
        {
        }

        /// <summary> Initializes a new instance of VirtualMachineScaleSetSkuCapacity. </summary>
        /// <param name="minimum"> The minimum capacity. </param>
        /// <param name="maximum"> The maximum capacity that can be set. </param>
        /// <param name="defaultCapacity"> The default capacity. </param>
        /// <param name="scaleType"> The scale type applicable to the sku. </param>
        internal VirtualMachineScaleSetSkuCapacity(long? minimum, long? maximum, long? defaultCapacity, VirtualMachineScaleSetSkuScaleType? scaleType)
        {
            Minimum = minimum;
            Maximum = maximum;
            DefaultCapacity = defaultCapacity;
            ScaleType = scaleType;
        }

        /// <summary> The minimum capacity. </summary>
        public long? Minimum { get; }
        /// <summary> The maximum capacity that can be set. </summary>
        public long? Maximum { get; }
        /// <summary> The default capacity. </summary>
        public long? DefaultCapacity { get; }
        /// <summary> The scale type applicable to the sku. </summary>
        public VirtualMachineScaleSetSkuScaleType? ScaleType { get; }
    }
}
