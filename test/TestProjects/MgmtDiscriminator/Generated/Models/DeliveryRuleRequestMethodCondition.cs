// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

namespace MgmtDiscriminator.Models
{
    /// <summary> Defines the RequestMethod condition for the delivery rule. </summary>
    public partial class DeliveryRuleRequestMethodCondition : DeliveryRuleCondition
    {
        /// <summary> Initializes a new instance of DeliveryRuleRequestMethodCondition. </summary>
        /// <param name="parameters"> Defines the parameters for the condition. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="parameters"/> is null. </exception>
        public DeliveryRuleRequestMethodCondition(RequestMethodMatchConditionParameters parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            Parameters = parameters;
            Name = MatchVariable.RequestMethod;
        }

        /// <summary> Initializes a new instance of DeliveryRuleRequestMethodCondition. </summary>
        /// <param name="name"> The name of the condition for the delivery rule. </param>
        /// <param name="description"> The description of the condition for the delivery rule. </param>
        /// <param name="parameters"> Defines the parameters for the condition. </param>
        internal DeliveryRuleRequestMethodCondition(MatchVariable name, string description, RequestMethodMatchConditionParameters parameters) : base(name, description)
        {
            Parameters = parameters;
            Name = name;
        }

        /// <summary> Defines the parameters for the condition. </summary>
        public RequestMethodMatchConditionParameters Parameters { get; set; }
    }
}
