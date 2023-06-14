// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace MgmtMockAndSample.Models
{
    /// <summary> A rule governing the accessibility of a vault from a specific ip address or ip range. </summary>
    public partial class IPRule
    {
        /// <summary> Initializes a new instance of IPRule. </summary>
        /// <param name="value"> An IPv4 address range in CIDR notation, such as '124.56.78.91' (simple IP address) or '124.56.78.0/24' (all addresses that start with 124.56.78). </param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public IPRule(string value)
        {
            Argument.AssertNotNull(value, nameof(value));

            Value = value;
        }

        /// <summary> An IPv4 address range in CIDR notation, such as '124.56.78.91' (simple IP address) or '124.56.78.0/24' (all addresses that start with 124.56.78). </summary>
        public string Value { get; set; }
    }
}
