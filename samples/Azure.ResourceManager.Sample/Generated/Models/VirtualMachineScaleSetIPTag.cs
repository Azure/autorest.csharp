// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary>
    /// Contains the IP tag associated with the public IP address.
    /// Serialized Name: VirtualMachineScaleSetIpTag
    /// </summary>
    public partial class VirtualMachineScaleSetIPTag
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="VirtualMachineScaleSetIPTag"/>. </summary>
        public VirtualMachineScaleSetIPTag()
        {
        }

        /// <summary> Initializes a new instance of <see cref="VirtualMachineScaleSetIPTag"/>. </summary>
        /// <param name="ipTagType">
        /// IP tag type. Example: FirstPartyUsage.
        /// Serialized Name: VirtualMachineScaleSetIpTag.ipTagType
        /// </param>
        /// <param name="tag">
        /// IP tag associated with the public IP. Example: SQL, Storage etc.
        /// Serialized Name: VirtualMachineScaleSetIpTag.tag
        /// </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal VirtualMachineScaleSetIPTag(string ipTagType, string tag, Dictionary<string, BinaryData> rawData)
        {
            IPTagType = ipTagType;
            Tag = tag;
            _rawData = rawData;
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
