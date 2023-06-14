// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace MgmtRenameRules.Models
{
    /// <summary>
    /// Describes a virtual machines scale sets network configuration's DNS settings.
    /// Serialized Name: VirtualMachineScaleSetPublicIPAddressConfigurationDnsSettings
    /// </summary>
    internal partial class VirtualMachineScaleSetPublicIPAddressConfigurationDnsSettings
    {
        /// <summary> Initializes a new instance of VirtualMachineScaleSetPublicIPAddressConfigurationDnsSettings. </summary>
        /// <param name="domainNameLabel">
        /// The Domain name label.The concatenation of the domain name label and vm index will be the domain name labels of the PublicIPAddress resources that will be created
        /// Serialized Name: VirtualMachineScaleSetPublicIPAddressConfigurationDnsSettings.domainNameLabel
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="domainNameLabel"/> is null. </exception>
        public VirtualMachineScaleSetPublicIPAddressConfigurationDnsSettings(string domainNameLabel)
        {
            Argument.AssertNotNull(domainNameLabel, nameof(domainNameLabel));

            DomainNameLabel = domainNameLabel;
        }

        /// <summary>
        /// The Domain name label.The concatenation of the domain name label and vm index will be the domain name labels of the PublicIPAddress resources that will be created
        /// Serialized Name: VirtualMachineScaleSetPublicIPAddressConfigurationDnsSettings.domainNameLabel
        /// </summary>
        public string DomainNameLabel { get; set; }
    }
}
