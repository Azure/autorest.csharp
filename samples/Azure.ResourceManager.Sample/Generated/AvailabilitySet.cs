// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.ResourceManager.Core;

namespace Azure.ResourceManager.Sample
{
    /// <summary> A Class representing a AvailabilitySet along with the instance operations that can be performed on it. </summary>
    public class AvailabilitySet : AvailabilitySetOperations
    {
        /// <summary> Initializes a new instance of the <see cref = "AvailabilitySet"/> class. </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="resource"> The resource that is the target of operations. </param>
        internal AvailabilitySet(OperationsBase options, AvailabilitySetData resource) : base(options, resource.Id)
        {
            Data = resource;
        }

        /// <summary> Gets or sets the AvailabilitySetData. </summary>
        public AvailabilitySetData Data { get; private set; }
    }
}
