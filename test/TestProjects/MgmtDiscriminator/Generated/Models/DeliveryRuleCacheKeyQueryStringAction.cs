// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace MgmtDiscriminator.Models
{
    /// <summary> Defines the cache-key query string action for the delivery rule. </summary>
    public partial class DeliveryRuleCacheKeyQueryStringAction : DeliveryRuleAction
    {
        /// <summary> Initializes a new instance of DeliveryRuleCacheKeyQueryStringAction. </summary>
        /// <param name="parameters"> Defines the parameters for the action. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="parameters"/> is null. </exception>
        public DeliveryRuleCacheKeyQueryStringAction(CacheKeyQueryStringActionParameters parameters)
        {
            Argument.AssertNotNull(parameters, nameof(parameters));

            Parameters = parameters;
            Name = DeliveryRuleActionType.CacheKeyQueryString;
        }

        /// <summary> Initializes a new instance of DeliveryRuleCacheKeyQueryStringAction. </summary>
        /// <param name="name"> The name of the action for the delivery rule. </param>
        /// <param name="foo"> for test. </param>
        /// <param name="parameters"> Defines the parameters for the action. </param>
        internal DeliveryRuleCacheKeyQueryStringAction(DeliveryRuleActionType name, string foo, CacheKeyQueryStringActionParameters parameters) : base(name, foo)
        {
            Parameters = parameters;
            Name = name;
        }

        /// <summary> Defines the parameters for the action. </summary>
        public CacheKeyQueryStringActionParameters Parameters { get; set; }
    }
}
