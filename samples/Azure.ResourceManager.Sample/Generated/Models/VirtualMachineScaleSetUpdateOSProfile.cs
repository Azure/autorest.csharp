// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary>
    /// Describes a virtual machine scale set OS profile.
    /// Serialized Name: VirtualMachineScaleSetUpdateOSProfile
    /// </summary>
    public partial class VirtualMachineScaleSetUpdateOSProfile
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary>
        /// Initializes a new instance of global::Azure.ResourceManager.Sample.Models.VirtualMachineScaleSetUpdateOSProfile
        ///
        /// </summary>
        public VirtualMachineScaleSetUpdateOSProfile()
        {
            Secrets = new ChangeTrackingList<VaultSecretGroup>();
        }

        /// <summary>
        /// Initializes a new instance of global::Azure.ResourceManager.Sample.Models.VirtualMachineScaleSetUpdateOSProfile
        ///
        /// </summary>
        /// <param name="customData">
        /// A base-64 encoded string of custom data.
        /// Serialized Name: VirtualMachineScaleSetUpdateOSProfile.customData
        /// </param>
        /// <param name="windowsConfiguration">
        /// The Windows Configuration of the OS profile.
        /// Serialized Name: VirtualMachineScaleSetUpdateOSProfile.windowsConfiguration
        /// </param>
        /// <param name="linuxConfiguration">
        /// The Linux Configuration of the OS profile.
        /// Serialized Name: VirtualMachineScaleSetUpdateOSProfile.linuxConfiguration
        /// </param>
        /// <param name="secrets">
        /// The List of certificates for addition to the VM.
        /// Serialized Name: VirtualMachineScaleSetUpdateOSProfile.secrets
        /// </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal VirtualMachineScaleSetUpdateOSProfile(string customData, WindowsConfiguration windowsConfiguration, LinuxConfiguration linuxConfiguration, IList<VaultSecretGroup> secrets, Dictionary<string, BinaryData> rawData)
        {
            CustomData = customData;
            WindowsConfiguration = windowsConfiguration;
            LinuxConfiguration = linuxConfiguration;
            Secrets = secrets;
            _rawData = rawData;
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
