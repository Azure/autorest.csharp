// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace MgmtDiscriminator.Models
{
    /// <summary> Defines the cache expiration action for the delivery rule. </summary>
    public partial class DeliveryRuleCacheExpirationAction : DeliveryRuleAction
    {
        /// <summary> Initializes a new instance of <see cref="DeliveryRuleCacheExpirationAction"/>. </summary>
        /// <param name="parameters"> Defines the parameters for the action. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="parameters"/> is null. </exception>
        public DeliveryRuleCacheExpirationAction(CacheExpirationActionParameters parameters)
        {
            Argument.AssertNotNull(parameters, nameof(parameters));

            Parameters = parameters;
            Name = DeliveryRuleActionType.CacheExpiration;
        }

        /// <summary> Initializes a new instance of <see cref="DeliveryRuleCacheExpirationAction"/>. </summary>
        /// <param name="name"> The name of the action for the delivery rule. </param>
        /// <param name="foo"> for test. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        /// <param name="parameters"> Defines the parameters for the action. </param>
        internal DeliveryRuleCacheExpirationAction(DeliveryRuleActionType name, string foo, IDictionary<string, BinaryData> serializedAdditionalRawData, CacheExpirationActionParameters parameters) : base(name, foo, serializedAdditionalRawData)
        {
            Parameters = parameters;
            Name = name;
        }

        /// <summary> Initializes a new instance of <see cref="DeliveryRuleCacheExpirationAction"/> for deserialization. </summary>
        internal DeliveryRuleCacheExpirationAction()
        {
        }

        /// <summary> Defines the parameters for the action. </summary>
        [WirePath("parameters")]
        public CacheExpirationActionParameters Parameters { get; set; }
    }
}
