// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary>
    /// The VMScaleSetConvertToSinglePlacementGroupInput.
    /// Serialized Name: VMScaleSetConvertToSinglePlacementGroupInput
    /// </summary>
    public partial class VMScaleSetConvertToSinglePlacementGroupContent
    {
        /// <summary> Initializes a new instance of VMScaleSetConvertToSinglePlacementGroupContent. </summary>
        public VMScaleSetConvertToSinglePlacementGroupContent()
        {
        }

        /// <summary>
        /// Id of the placement group in which you want future virtual machine instances to be placed. To query placement group Id, please use Virtual Machine Scale Set VMs - Get API. If not provided, the platform will choose one with maximum number of virtual machine instances.
        /// Serialized Name: VMScaleSetConvertToSinglePlacementGroupInput.activePlacementGroupId
        /// </summary>
        public string ActivePlacementGroupId { get; set; }
    }
}
