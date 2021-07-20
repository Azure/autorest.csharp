// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.ResourceManager.Core;

namespace MgmtSingleton
{
    /// <summary> A Class representing a SubscriptionParentSingleton along with the instance operations that can be performed on it. </summary>
    public class SubscriptionParentSingleton : SubscriptionParentSingletonOperations
    {
        /// <summary> Initializes a new instance of the <see cref = "SubscriptionParentSingleton"/> class for mocking. </summary>
        internal SubscriptionParentSingleton() : base()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "SubscriptionParentSingleton"/> class. </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="resource"> The resource that is the target of operations. </param>
        internal SubscriptionParentSingleton(OperationsBase options, SubscriptionParentSingletonData resource) : base(options)
        {
            Data = resource;
        }

        /// <summary> Gets or sets the SubscriptionParentSingletonData. </summary>
        public SubscriptionParentSingletonData Data { get; private set; }
    }
}
