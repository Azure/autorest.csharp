// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Linq;
using System.Threading.Tasks;
using Azure.ResourceManager.Core;

namespace MgmtSingleton
{
    /// <summary> A class representing the operations that can be performed over a specific SubscriptionParentSingleton. </summary>
    public partial class SubscriptionParentSingletonOperations : SingletonOperationsBase<SubscriptionResourceIdentifier, SubscriptionParentSingleton>
    {
        /// <summary> Initializes a new instance of the <see cref="SubscriptionParentSingletonOperations"/> class for mocking. </summary>
        protected SubscriptionParentSingletonOperations()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="SubscriptionParentSingletonOperations"/> class. </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        protected internal SubscriptionParentSingletonOperations(OperationsBase options) : base(options)
        {
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Billing/SubscriptionParentSingleton/default";
        /// <summary> Gets the valid resource type for the operations. </summary>
        protected override ResourceType ValidResourceType => ResourceType;
    }
}
