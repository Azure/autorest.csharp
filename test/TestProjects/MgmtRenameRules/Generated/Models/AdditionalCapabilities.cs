// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace MgmtRenameRules.Models
{
    /// <summary>
    /// Enables or disables a capability on the virtual machine or virtual machine scale set.
    /// Serialized Name: AdditionalCapabilities
    /// </summary>
    internal partial class AdditionalCapabilities
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="AdditionalCapabilities"/>. </summary>
        public AdditionalCapabilities()
        {
        }

        /// <summary> Initializes a new instance of <see cref="AdditionalCapabilities"/>. </summary>
        /// <param name="ultraSSDEnabled">
        /// The flag that enables or disables a capability to have one or more managed data disks with UltraSSD_LRS storage account type on the VM or VMSS. Managed disks with storage account type UltraSSD_LRS can be added to a virtual machine or virtual machine scale set only if this property is enabled.
        /// Serialized Name: AdditionalCapabilities.ultraSSDEnabled
        /// </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal AdditionalCapabilities(bool? ultraSSDEnabled, Dictionary<string, BinaryData> rawData)
        {
            UltraSSDEnabled = ultraSSDEnabled;
            _rawData = rawData;
        }

        /// <summary>
        /// The flag that enables or disables a capability to have one or more managed data disks with UltraSSD_LRS storage account type on the VM or VMSS. Managed disks with storage account type UltraSSD_LRS can be added to a virtual machine or virtual machine scale set only if this property is enabled.
        /// Serialized Name: AdditionalCapabilities.ultraSSDEnabled
        /// </summary>
        public bool? UltraSSDEnabled { get; set; }
    }
}
