// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

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
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            Parameters = parameters;
            Name = MatchVariable.RemoteAddress;
        }

        /// <summary> Initializes a new instance of DeliveryRuleRemoteAddressCondition. </summary>
        /// <param name="name"> The name of the condition for the delivery rule. </param>
        /// <param name="parameters"> Defines the parameters for the condition. </param>
        internal DeliveryRuleRemoteAddressCondition(MatchVariable name, RemoteAddressMatchConditionParameters parameters) : base(name)
        {
            Parameters = parameters;
            Name = name;
        }

        /// <summary> Defines the parameters for the condition. </summary>
        public RemoteAddressMatchConditionParameters Parameters { get; set; }
    }
}
