// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.ResourceManager.Core;

namespace MgmtListMethods
{
    /// <summary> A Class representing a TenantParentWithLoc along with the instance operations that can be performed on it. </summary>
    public class TenantParentWithLoc : TenantParentWithLocOperations
    {
        /// <summary> Initializes a new instance of the <see cref = "TenantParentWithLoc"/> class for mocking. </summary>
        protected TenantParentWithLoc() : base()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "TenantParentWithLoc"/> class. </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="resource"> The resource that is the target of operations. </param>
        internal TenantParentWithLoc(ResourceOperations options, TenantParentWithLocData resource) : base(options, resource.Id)
        {
            Data = resource;
        }

        /// <summary> Gets or sets the TenantParentWithLocData. </summary>
        public virtual TenantParentWithLocData Data { get; private set; }
    }
}
