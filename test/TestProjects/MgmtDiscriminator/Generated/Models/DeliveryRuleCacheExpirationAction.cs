// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace MgmtDiscriminator.Models
{
    /// <summary> Defines the cache expiration action for the delivery rule. </summary>
    public partial class DeliveryRuleCacheExpirationAction : DeliveryRuleAction
    {
        /// <summary> Initializes a new instance of DeliveryRuleCacheExpirationAction. </summary>
        /// <param name="parameters"> Defines the parameters for the action. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="parameters"/> is null. </exception>
        public DeliveryRuleCacheExpirationAction(CacheExpirationActionParameters parameters)
        {
            Argument.AssertNotNull(parameters, nameof(parameters));

            Parameters = parameters;
            Name = DeliveryRuleActionType.CacheExpiration;
        }

        /// <summary> Initializes a new instance of DeliveryRuleCacheExpirationAction. </summary>
        /// <param name="name"> The name of the action for the delivery rule. </param>
        /// <param name="foo"> for test. </param>
        /// <param name="parameters"> Defines the parameters for the action. </param>
        internal DeliveryRuleCacheExpirationAction(DeliveryRuleActionType name, string foo, CacheExpirationActionParameters parameters) : base(name, foo)
        {
            Parameters = parameters;
            Name = name;
        }

        /// <summary> Defines the parameters for the action. </summary>
        public CacheExpirationActionParameters Parameters { get; set; }
    }
}
