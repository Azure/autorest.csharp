// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> IP rule with specific IP or IP range in CIDR format. </summary>
    public partial class IPRule
    {
        /// <summary> Initializes a new instance of IPRule. </summary>
        /// <param name="ipAddressOrRange"> Specifies the IP or IP range in CIDR format. Only IPV4 address is allowed. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="ipAddressOrRange"/> is null. </exception>
        public IPRule(string ipAddressOrRange)
        {
            Argument.AssertNotNull(ipAddressOrRange, nameof(ipAddressOrRange));

            IPAddressOrRange = ipAddressOrRange;
        }

        /// <summary> Initializes a new instance of IPRule. </summary>
        /// <param name="ipAddressOrRange"> Specifies the IP or IP range in CIDR format. Only IPV4 address is allowed. </param>
        /// <param name="action"> The action of IP ACL rule. </param>
        internal IPRule(string ipAddressOrRange, Action? action)
        {
            IPAddressOrRange = ipAddressOrRange;
            Action = action;
        }

        /// <summary> Specifies the IP or IP range in CIDR format. Only IPV4 address is allowed. </summary>
        public string IPAddressOrRange { get; set; }
        /// <summary> The action of IP ACL rule. </summary>
        public Action? Action { get; set; }
    }
}
