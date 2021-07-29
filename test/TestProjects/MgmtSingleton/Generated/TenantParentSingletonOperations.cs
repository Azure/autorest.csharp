// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Threading.Tasks;
using Azure.ResourceManager;
using Azure.ResourceManager.Core;

namespace MgmtSingleton
{
    /// <summary> A class representing the operations that can be performed over a specific TenantParentSingleton. </summary>
    public partial class TenantParentSingletonOperations : SingletonOperations
    {
        /// <summary> Initializes a new instance of the <see cref="TenantParentSingletonOperations"/> class for mocking. </summary>
        protected TenantParentSingletonOperations()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="TenantParentSingletonOperations"/> class. </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        protected internal TenantParentSingletonOperations(ResourceOperations options) : base(options)
        {
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Billing/TenantParentSingleton/default";
        /// <summary> Gets the valid resource type for the operations. </summary>
        protected override ResourceType ValidResourceType => ResourceType;
    }
}
