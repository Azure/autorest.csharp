// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace MgmtDiscriminator.Models
{
    /// <summary> Defines the RemoteAddress condition for the delivery rule. </summary>
    public partial class DeliveryRuleRemoteAddressCondition : DeliveryRuleCondition
    {
        /// <summary> Initializes a new instance of DeliveryRuleRemoteAddressCondition. </summary>
        /// <param name="parameters"> Defines the parameters for the condition. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="parameters"/> is null. </exception>
        public DeliveryRuleRemoteAddressCondition(RemoteAddressMatchConditionParameters parameters)
        {
            Argument.AssertNotNull(parameters, nameof(parameters));

            Parameters = parameters;
            Name = MatchVariable.RemoteAddress;
        }

        /// <summary> Initializes a new instance of DeliveryRuleRemoteAddressCondition. </summary>
        /// <param name="name"> The name of the condition for the delivery rule. </param>
        /// <param name="foo"> For test. </param>
        /// <param name="parameters"> Defines the parameters for the condition. </param>
        internal DeliveryRuleRemoteAddressCondition(MatchVariable name, string foo, RemoteAddressMatchConditionParameters parameters) : base(name, foo)
        {
            Parameters = parameters;
            Name = name;
        }

        /// <summary> Defines the parameters for the condition. </summary>
        public RemoteAddressMatchConditionParameters Parameters { get; set; }
    }
}
