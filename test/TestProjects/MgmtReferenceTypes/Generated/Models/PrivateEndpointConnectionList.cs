// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.ResourceManager.Fake.Models
{
    /// <summary> List of private endpoint connection associated with the specified storage account. </summary>
    [TypeReferenceType]
    public partial class PrivateEndpointConnectionList
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary>
        /// Initializes a new instance of global::Azure.ResourceManager.Fake.Models.PrivateEndpointConnectionList
        ///
        /// </summary>
        [InitializationConstructor]
        public PrivateEndpointConnectionList()
        {
            Value = new ChangeTrackingList<PrivateEndpointConnectionData>();
        }

        /// <summary>
        /// Initializes a new instance of global::Azure.ResourceManager.Fake.Models.PrivateEndpointConnectionList
        ///
        /// </summary>
        /// <param name="value"> Array of private endpoint connections. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        protected PrivateEndpointConnectionList(IReadOnlyList<PrivateEndpointConnectionData> value, Dictionary<string, BinaryData> rawData)
        {
            Value = value;
            _rawData = rawData;
        }

        /// <summary> Array of private endpoint connections. </summary>
        public IReadOnlyList<PrivateEndpointConnectionData> Value { get; }
    }
}
