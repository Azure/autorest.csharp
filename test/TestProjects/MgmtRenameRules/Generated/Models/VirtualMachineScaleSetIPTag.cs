// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtRenameRules.Models
{
    /// <summary>
    /// Contains the IP tag associated with the public IP address.
    /// Serialized Name: VirtualMachineScaleSetIpTag
    /// </summary>
    public partial class VirtualMachineScaleSetIPTag
    {
        /// <summary> Initializes a new instance of VirtualMachineScaleSetIPTag. </summary>
        public VirtualMachineScaleSetIPTag()
        {
        }

        /// <summary> Initializes a new instance of VirtualMachineScaleSetIPTag. </summary>
        /// <param name="ipTagType">
        /// IP tag type. Example: FirstPartyUsage.
        /// Serialized Name: VirtualMachineScaleSetIpTag.ipTagType
        /// </param>
        /// <param name="tag">
        /// IP tag associated with the public IP. Example: SQL, Storage etc.
        /// Serialized Name: VirtualMachineScaleSetIpTag.tag
        /// </param>
        internal VirtualMachineScaleSetIPTag(string ipTagType, string tag)
        {
            IPTagType = ipTagType;
            Tag = tag;
        }

        /// <summary>
        /// IP tag type. Example: FirstPartyUsage.
        /// Serialized Name: VirtualMachineScaleSetIpTag.ipTagType
        /// </summary>
        public string IPTagType { get; set; }
        /// <summary>
        /// IP tag associated with the public IP. Example: SQL, Storage etc.
        /// Serialized Name: VirtualMachineScaleSetIpTag.tag
        /// </summary>
        public string Tag { get; set; }
    }
}
