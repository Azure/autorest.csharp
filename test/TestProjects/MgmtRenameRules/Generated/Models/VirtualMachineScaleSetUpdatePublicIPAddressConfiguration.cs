// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace MgmtRenameRules.Models
{
    /// <summary>
    /// Describes a virtual machines scale set IP Configuration's PublicIPAddress configuration
    /// Serialized Name: VirtualMachineScaleSetUpdatePublicIPAddressConfiguration
    /// </summary>
    public partial class VirtualMachineScaleSetUpdatePublicIPAddressConfiguration
    {
        /// <summary> Initializes a new instance of VirtualMachineScaleSetUpdatePublicIPAddressConfiguration. </summary>
        public VirtualMachineScaleSetUpdatePublicIPAddressConfiguration()
        {
        }

        /// <summary> Initializes a new instance of VirtualMachineScaleSetUpdatePublicIPAddressConfiguration. </summary>
        /// <param name="name">
        /// The publicIP address configuration name.
        /// Serialized Name: VirtualMachineScaleSetUpdatePublicIPAddressConfiguration.name
        /// </param>
        /// <param name="idleTimeoutInMinutes">
        /// The idle timeout of the public IP address.
        /// Serialized Name: VirtualMachineScaleSetUpdatePublicIPAddressConfiguration.properties.idleTimeoutInMinutes
        /// </param>
        /// <param name="dnsSettings">
        /// The dns settings to be applied on the publicIP addresses .
        /// Serialized Name: VirtualMachineScaleSetUpdatePublicIPAddressConfiguration.properties.dnsSettings
        /// </param>
        internal VirtualMachineScaleSetUpdatePublicIPAddressConfiguration(string name, int? idleTimeoutInMinutes, VirtualMachineScaleSetPublicIPAddressConfigurationDnsSettings dnsSettings)
        {
            Name = name;
            IdleTimeoutInMinutes = idleTimeoutInMinutes;
            DnsSettings = dnsSettings;
        }

        /// <summary>
        /// The publicIP address configuration name.
        /// Serialized Name: VirtualMachineScaleSetUpdatePublicIPAddressConfiguration.name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The idle timeout of the public IP address.
        /// Serialized Name: VirtualMachineScaleSetUpdatePublicIPAddressConfiguration.properties.idleTimeoutInMinutes
        /// </summary>
        public int? IdleTimeoutInMinutes { get; set; }
        /// <summary>
        /// The dns settings to be applied on the publicIP addresses .
        /// Serialized Name: VirtualMachineScaleSetUpdatePublicIPAddressConfiguration.properties.dnsSettings
        /// </summary>
        internal VirtualMachineScaleSetPublicIPAddressConfigurationDnsSettings DnsSettings { get; set; }
        /// <summary>
        /// The Domain name label.The concatenation of the domain name label and vm index will be the domain name labels of the PublicIPAddress resources that will be created
        /// Serialized Name: VirtualMachineScaleSetPublicIPAddressConfigurationDnsSettings.domainNameLabel
        /// </summary>
        public string DnsDomainNameLabel
        {
            get => DnsSettings is null ? default : DnsSettings.DomainNameLabel;
            set => DnsSettings = new VirtualMachineScaleSetPublicIPAddressConfigurationDnsSettings(value);
        }
    }
}
