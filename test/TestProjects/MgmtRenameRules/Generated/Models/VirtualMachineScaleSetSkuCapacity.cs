// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtRenameRules.Models
{
    /// <summary>
    /// Describes scaling information of a sku.
    /// Serialized Name: VirtualMachineScaleSetSkuCapacity
    /// </summary>
    public partial class VirtualMachineScaleSetSkuCapacity
    {
        /// <summary> Initializes a new instance of VirtualMachineScaleSetSkuCapacity. </summary>
        internal VirtualMachineScaleSetSkuCapacity()
        {
        }

        /// <summary> Initializes a new instance of VirtualMachineScaleSetSkuCapacity. </summary>
        /// <param name="minimum">
        /// The minimum capacity.
        /// Serialized Name: VirtualMachineScaleSetSkuCapacity.minimum
        /// </param>
        /// <param name="maximum">
        /// The maximum capacity that can be set.
        /// Serialized Name: VirtualMachineScaleSetSkuCapacity.maximum
        /// </param>
        /// <param name="defaultCapacity">
        /// The default capacity.
        /// Serialized Name: VirtualMachineScaleSetSkuCapacity.defaultCapacity
        /// </param>
        /// <param name="scaleType">
        /// The scale type applicable to the sku.
        /// Serialized Name: VirtualMachineScaleSetSkuCapacity.scaleType
        /// </param>
        internal VirtualMachineScaleSetSkuCapacity(long? minimum, long? maximum, long? defaultCapacity, VirtualMachineScaleSetSkuScaleType? scaleType)
        {
            Minimum = minimum;
            Maximum = maximum;
            DefaultCapacity = defaultCapacity;
            ScaleType = scaleType;
        }

        /// <summary>
        /// The minimum capacity.
        /// Serialized Name: VirtualMachineScaleSetSkuCapacity.minimum
        /// </summary>
        public long? Minimum { get; }
        /// <summary>
        /// The maximum capacity that can be set.
        /// Serialized Name: VirtualMachineScaleSetSkuCapacity.maximum
        /// </summary>
        public long? Maximum { get; }
        /// <summary>
        /// The default capacity.
        /// Serialized Name: VirtualMachineScaleSetSkuCapacity.defaultCapacity
        /// </summary>
        public long? DefaultCapacity { get; }
        /// <summary>
        /// The scale type applicable to the sku.
        /// Serialized Name: VirtualMachineScaleSetSkuCapacity.scaleType
        /// </summary>
        public VirtualMachineScaleSetSkuScaleType? ScaleType { get; }
    }
}
