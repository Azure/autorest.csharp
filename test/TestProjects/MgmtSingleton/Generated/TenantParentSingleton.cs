// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.ResourceManager.Core;

namespace MgmtSingleton
{
    /// <summary> A Class representing a TenantParentSingleton along with the instance operations that can be performed on it. </summary>
    public class TenantParentSingleton : TenantParentSingletonOperations
    {
        /// <summary> Initializes a new instance of the <see cref = "TenantParentSingleton"/> class for mocking. </summary>
        internal TenantParentSingleton() : base()
        {
        }
        /// <summary> Initializes a new instance of the <see cref = "TenantParentSingleton"/> class. </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="resource"> The resource that is the target of operations. </param>
        internal TenantParentSingleton(OperationsBase options, TenantParentSingletonData resource) : base(options)
        {
            Data = resource;
        }

        /// <summary> Gets or sets the TenantParentSingletonData. </summary>
        public TenantParentSingletonData Data { get; private set; }
    }
}
