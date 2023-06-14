// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.Fake.Models
{
    /// <summary> The Private Endpoint resource. </summary>
    [TypeReferenceType]
    public partial class PrivateEndpoint
    {
        /// <summary> Initializes a new instance of PrivateEndpoint. </summary>
        [InitializationConstructor]
        public PrivateEndpoint()
        {
        }

        /// <summary> Initializes a new instance of PrivateEndpoint. </summary>
        /// <param name="id"> The ARM identifier for Private Endpoint. </param>
        [SerializationConstructor]
        protected PrivateEndpoint(ResourceIdentifier id)
        {
            Id = id;
        }

        /// <summary> The ARM identifier for Private Endpoint. </summary>
        public ResourceIdentifier Id { get; }
    }
}
