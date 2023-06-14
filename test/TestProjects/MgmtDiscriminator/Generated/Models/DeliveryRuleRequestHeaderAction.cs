// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace MgmtDiscriminator.Models
{
    /// <summary> Defines the request header action for the delivery rule. </summary>
    public partial class DeliveryRuleRequestHeaderAction : DeliveryRuleAction
    {
        /// <summary> Initializes a new instance of DeliveryRuleRequestHeaderAction. </summary>
        /// <param name="parameters"> Defines the parameters for the action. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="parameters"/> is null. </exception>
        public DeliveryRuleRequestHeaderAction(HeaderActionParameters parameters)
        {
            Argument.AssertNotNull(parameters, nameof(parameters));

            Parameters = parameters;
            Name = DeliveryRuleActionType.ModifyRequestHeader;
        }

        /// <summary> Initializes a new instance of DeliveryRuleRequestHeaderAction. </summary>
        /// <param name="name"> The name of the action for the delivery rule. </param>
        /// <param name="foo"> for test. </param>
        /// <param name="parameters"> Defines the parameters for the action. </param>
        internal DeliveryRuleRequestHeaderAction(DeliveryRuleActionType name, string foo, HeaderActionParameters parameters) : base(name, foo)
        {
            Parameters = parameters;
            Name = name;
        }

        /// <summary> Defines the parameters for the action. </summary>
        public HeaderActionParameters Parameters { get; set; }
    }
}
