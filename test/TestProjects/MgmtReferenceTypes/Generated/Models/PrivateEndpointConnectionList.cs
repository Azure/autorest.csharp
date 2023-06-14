// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace Azure.ResourceManager.Fake.Models
{
    /// <summary> List of private endpoint connection associated with the specified storage account. </summary>
    [TypeReferenceType]
    public partial class PrivateEndpointConnectionList
    {
        /// <summary> Initializes a new instance of PrivateEndpointConnectionList. </summary>
        [InitializationConstructor]
        public PrivateEndpointConnectionList()
        {
            Value = new ChangeTrackingList<PrivateEndpointConnectionData>();
        }

        /// <summary> Initializes a new instance of PrivateEndpointConnectionList. </summary>
        /// <param name="value"> Array of private endpoint connections. </param>
        [SerializationConstructor]
        protected PrivateEndpointConnectionList(IReadOnlyList<PrivateEndpointConnectionData> value)
        {
            Value = value;
        }

        /// <summary> Array of private endpoint connections. </summary>
        public IReadOnlyList<PrivateEndpointConnectionData> Value { get; }
    }
}
