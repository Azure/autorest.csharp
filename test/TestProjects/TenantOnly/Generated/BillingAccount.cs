// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.ResourceManager.Core;

namespace TenantOnly
{
    /// <summary> A Class representing a BillingAccount along with the instance operations that can be performed on it. </summary>
    public class BillingAccount : BillingAccountOperations
    {
        /// <summary> Initializes a new instance of the <see cref = "BillingAccount"/> class for mocking. </summary>
        internal BillingAccount() : base()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "BillingAccount"/> class. </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="resource"> The resource that is the target of operations. </param>
        internal BillingAccount(OperationsBase options, BillingAccountData resource) : base(options, resource.Id)
        {
            Data = resource;
        }

        /// <summary> Gets or sets the BillingAccountData. </summary>
        public BillingAccountData Data { get; private set; }
    }
}
