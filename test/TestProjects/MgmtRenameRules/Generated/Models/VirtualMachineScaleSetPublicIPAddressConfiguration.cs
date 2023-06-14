// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;

namespace MgmtRenameRules.Models
{
    /// <summary>
    /// Describes a virtual machines scale set IP Configuration's PublicIPAddress configuration
    /// Serialized Name: VirtualMachineScaleSetPublicIPAddressConfiguration
    /// </summary>
    public partial class VirtualMachineScaleSetPublicIPAddressConfiguration
    {
        /// <summary> Initializes a new instance of VirtualMachineScaleSetPublicIPAddressConfiguration. </summary>
        /// <param name="name">
        /// The publicIP address configuration name.
        /// Serialized Name: VirtualMachineScaleSetPublicIPAddressConfiguration.name
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public VirtualMachineScaleSetPublicIPAddressConfiguration(string name)
        {
            Argument.AssertNotNull(name, nameof(name));

            Name = name;
            IPTags = new ChangeTrackingList<VirtualMachineScaleSetIPTag>();
        }

        /// <summary> Initializes a new instance of VirtualMachineScaleSetPublicIPAddressConfiguration. </summary>
        /// <param name="name">
        /// The publicIP address configuration name.
        /// Serialized Name: VirtualMachineScaleSetPublicIPAddressConfiguration.name
        /// </param>
        /// <param name="idleTimeoutInMinutes">
        /// The idle timeout of the public IP address.
        /// Serialized Name: VirtualMachineScaleSetPublicIPAddressConfiguration.properties.idleTimeoutInMinutes
        /// </param>
        /// <param name="dnsSettings">
        /// The dns settings to be applied on the publicIP addresses .
        /// Serialized Name: VirtualMachineScaleSetPublicIPAddressConfiguration.properties.dnsSettings
        /// </param>
        /// <param name="ipTags">
        /// The list of IP tags associated with the public IP address.
        /// Serialized Name: VirtualMachineScaleSetPublicIPAddressConfiguration.properties.ipTags
        /// </param>
        /// <param name="publicIPPrefix">
        /// The PublicIPPrefix from which to allocate publicIP addresses.
        /// Serialized Name: VirtualMachineScaleSetPublicIPAddressConfiguration.properties.publicIPPrefix
        /// </param>
        /// <param name="publicIPAddressVersion">
        /// Available from Api-Version 2019-07-01 onwards, it represents whether the specific ipconfiguration is IPv4 or IPv6. Default is taken as IPv4. Possible values are: 'IPv4' and 'IPv6'.
        /// Serialized Name: VirtualMachineScaleSetPublicIPAddressConfiguration.properties.publicIPAddressVersion
        /// </param>
        internal VirtualMachineScaleSetPublicIPAddressConfiguration(string name, int? idleTimeoutInMinutes, VirtualMachineScaleSetPublicIPAddressConfigurationDnsSettings dnsSettings, IList<VirtualMachineScaleSetIPTag> ipTags, WritableSubResource publicIPPrefix, IPVersion? publicIPAddressVersion)
        {
            Name = name;
            IdleTimeoutInMinutes = idleTimeoutInMinutes;
            DnsSettings = dnsSettings;
            IPTags = ipTags;
            PublicIPPrefix = publicIPPrefix;
            PublicIPAddressVersion = publicIPAddressVersion;
        }

        /// <summary>
        /// The publicIP address configuration name.
        /// Serialized Name: VirtualMachineScaleSetPublicIPAddressConfiguration.name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The idle timeout of the public IP address.
        /// Serialized Name: VirtualMachineScaleSetPublicIPAddressConfiguration.properties.idleTimeoutInMinutes
        /// </summary>
        public int? IdleTimeoutInMinutes { get; set; }
        /// <summary>
        /// The dns settings to be applied on the publicIP addresses .
        /// Serialized Name: VirtualMachineScaleSetPublicIPAddressConfiguration.properties.dnsSettings
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

        /// <summary>
        /// The list of IP tags associated with the public IP address.
        /// Serialized Name: VirtualMachineScaleSetPublicIPAddressConfiguration.properties.ipTags
        /// </summary>
        public IList<VirtualMachineScaleSetIPTag> IPTags { get; }
        /// <summary>
        /// The PublicIPPrefix from which to allocate publicIP addresses.
        /// Serialized Name: VirtualMachineScaleSetPublicIPAddressConfiguration.properties.publicIPPrefix
        /// </summary>
        internal WritableSubResource PublicIPPrefix { get; set; }
        /// <summary> Gets or sets Id. </summary>
        public ResourceIdentifier PublicIPPrefixId
        {
            get => PublicIPPrefix is null ? default : PublicIPPrefix.Id;
            set
            {
                if (PublicIPPrefix is null)
                    PublicIPPrefix = new WritableSubResource();
                PublicIPPrefix.Id = value;
            }
        }

        /// <summary>
        /// Available from Api-Version 2019-07-01 onwards, it represents whether the specific ipconfiguration is IPv4 or IPv6. Default is taken as IPv4. Possible values are: 'IPv4' and 'IPv6'.
        /// Serialized Name: VirtualMachineScaleSetPublicIPAddressConfiguration.properties.publicIPAddressVersion
        /// </summary>
        public IPVersion? PublicIPAddressVersion { get; set; }
    }
}
