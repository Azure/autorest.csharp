// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.ResourceManager.Core;
using SubscriptionExtensions.Models;

namespace SubscriptionExtensions
{
    /// <summary> A Class representing a Oven along with the instance operations that can be performed on it. </summary>
    public class Oven : OvenOperations
    {
        /// <summary> Initializes a new instance of the <see cref = "Oven"/> class for mocking. </summary>
        internal Oven() : base()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "Oven"/> class. </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="resource"> The resource that is the target of operations. </param>
        internal Oven(OperationsBase options, OvenData resource) : base(options, resource.Id)
        {
            Data = resource;
        }

        /// <summary> Gets or sets the OvenData. </summary>
        public OvenData Data { get; private set; }
    }
}
