// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using MgmtMockAndSample;

namespace MgmtMockAndSample.Models
{
    /// <summary> List of managed HSM Pools. </summary>
    internal partial class ManagedHsmListResult
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="ManagedHsmListResult"/>. </summary>
        internal ManagedHsmListResult()
        {
            Value = new ChangeTrackingList<ManagedHsmData>();
        }

        /// <summary> Initializes a new instance of <see cref="ManagedHsmListResult"/>. </summary>
        /// <param name="value"> The list of managed HSM Pools. </param>
        /// <param name="nextLink"> The URL to get the next set of managed HSM Pools. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal ManagedHsmListResult(IReadOnlyList<ManagedHsmData> value, string nextLink, Dictionary<string, BinaryData> rawData)
        {
            Value = value;
            NextLink = nextLink;
            _rawData = rawData;
        }

        /// <summary> The list of managed HSM Pools. </summary>
        public IReadOnlyList<ManagedHsmData> Value { get; }
        /// <summary> The URL to get the next set of managed HSM Pools. </summary>
        public string NextLink { get; }
    }
}
