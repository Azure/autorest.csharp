// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.ResourceManager.Core;

namespace MgmtParent
{
    /// <summary> A Class representing a DedicatedHost along with the instance operations that can be performed on it. </summary>
    public class DedicatedHost : DedicatedHostOperations
    {
        /// <summary> Initializes a new instance of the <see cref = "DedicatedHost"/> class for mocking. </summary>
        protected DedicatedHost() : base()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "DedicatedHost"/> class. </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="resource"> The resource that is the target of operations. </param>
        internal DedicatedHost(OperationsBase options, DedicatedHostData resource) : base(options, resource.Id)
        {
            Data = resource;
        }

        /// <summary> Gets or sets the DedicatedHostData. </summary>
        public virtual DedicatedHostData Data { get; private set; }
    }
}
