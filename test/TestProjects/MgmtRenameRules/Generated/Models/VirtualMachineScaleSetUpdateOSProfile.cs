// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace MgmtRenameRules.Models
{
    /// <summary>
    /// Describes a virtual machine scale set OS profile.
    /// Serialized Name: VirtualMachineScaleSetUpdateOSProfile
    /// </summary>
    public partial class VirtualMachineScaleSetUpdateOSProfile
    {
        /// <summary> Initializes a new instance of VirtualMachineScaleSetUpdateOSProfile. </summary>
        public VirtualMachineScaleSetUpdateOSProfile()
        {
            Secrets = new ChangeTrackingList<VaultSecretGroup>();
        }

        /// <summary>
        /// A base-64 encoded string of custom data.
        /// Serialized Name: VirtualMachineScaleSetUpdateOSProfile.customData
        /// </summary>
        public string CustomData { get; set; }
        /// <summary>
        /// The Windows Configuration of the OS profile.
        /// Serialized Name: VirtualMachineScaleSetUpdateOSProfile.windowsConfiguration
        /// </summary>
        public WindowsConfiguration WindowsConfiguration { get; set; }
        /// <summary>
        /// The Linux Configuration of the OS profile.
        /// Serialized Name: VirtualMachineScaleSetUpdateOSProfile.linuxConfiguration
        /// </summary>
        public LinuxConfiguration LinuxConfiguration { get; set; }
        /// <summary>
        /// The List of certificates for addition to the VM.
        /// Serialized Name: VirtualMachineScaleSetUpdateOSProfile.secrets
        /// </summary>
        public IList<VaultSecretGroup> Secrets { get; }
    }
}
