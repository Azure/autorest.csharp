// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace MgmtMockAndSample.Models
{
    /// <summary> A rule governing the accessibility of a managed hsm pool from a specific ip address or ip range. </summary>
    public partial class MhsmipRule
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary>
        /// Initializes a new instance of global::MgmtMockAndSample.Models.MhsmipRule
        ///
        /// </summary>
        /// <param name="value"> An IPv4 address range in CIDR notation, such as '124.56.78.91' (simple IP address) or '124.56.78.0/24' (all addresses that start with 124.56.78). </param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public MhsmipRule(string value)
        {
            Argument.AssertNotNull(value, nameof(value));

            Value = value;
        }

        /// <summary>
        /// Initializes a new instance of global::MgmtMockAndSample.Models.MhsmipRule
        ///
        /// </summary>
        /// <param name="value"> An IPv4 address range in CIDR notation, such as '124.56.78.91' (simple IP address) or '124.56.78.0/24' (all addresses that start with 124.56.78). </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal MhsmipRule(string value, Dictionary<string, BinaryData> rawData)
        {
            Value = value;
            _rawData = rawData;
        }

        /// <summary> Initializes a new instance of <see cref="MhsmipRule"/> for deserialization. </summary>
        internal MhsmipRule()
        {
        }

        /// <summary> An IPv4 address range in CIDR notation, such as '124.56.78.91' (simple IP address) or '124.56.78.0/24' (all addresses that start with 124.56.78). </summary>
        public string Value { get; set; }
    }
}
