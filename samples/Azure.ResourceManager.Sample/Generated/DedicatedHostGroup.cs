// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.ResourceManager.Core;

namespace Azure.ResourceManager.Sample
{
    /// <summary> A Class representing a DedicatedHostGroup along with the instance operations that can be performed on it. </summary>
    public class DedicatedHostGroup : DedicatedHostGroupOperations
    {
        /// <summary> Initializes a new instance of the <see cref = "DedicatedHostGroup"/> class for mocking. </summary>
        internal DedicatedHostGroup() : base()
        {
        }
        /// <summary> Initializes a new instance of the <see cref = "DedicatedHostGroup"/> class. </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="resource"> The resource that is the target of operations. </param>
        internal DedicatedHostGroup(OperationsBase options, DedicatedHostGroupData resource) : base(options, resource.Id)
        {
            Data = resource;
        }

        /// <summary> Gets or sets the DedicatedHostGroupData. </summary>
        public DedicatedHostGroupData Data { get; private set; }
    }
}
