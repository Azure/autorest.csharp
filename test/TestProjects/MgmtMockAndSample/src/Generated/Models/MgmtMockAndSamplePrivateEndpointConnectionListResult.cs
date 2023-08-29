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
    /// <summary> List of private endpoint connections. </summary>
    internal partial class MgmtMockAndSamplePrivateEndpointConnectionListResult
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="MgmtMockAndSamplePrivateEndpointConnectionListResult"/>. </summary>
        internal MgmtMockAndSamplePrivateEndpointConnectionListResult()
        {
            Value = new ChangeTrackingList<MgmtMockAndSamplePrivateEndpointConnectionData>();
        }

        /// <summary> Initializes a new instance of <see cref="MgmtMockAndSamplePrivateEndpointConnectionListResult"/>. </summary>
        /// <param name="value"> The list of private endpoint connections. </param>
        /// <param name="nextLink"> The URL to get the next set of private endpoint connections. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal MgmtMockAndSamplePrivateEndpointConnectionListResult(IReadOnlyList<MgmtMockAndSamplePrivateEndpointConnectionData> value, string nextLink, Dictionary<string, BinaryData> rawData)
        {
            Value = value;
            NextLink = nextLink;
            _rawData = rawData;
        }

        /// <summary> The list of private endpoint connections. </summary>
        public IReadOnlyList<MgmtMockAndSamplePrivateEndpointConnectionData> Value { get; }
        /// <summary> The URL to get the next set of private endpoint connections. </summary>
        public string NextLink { get; }
    }
}
