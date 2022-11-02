// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core;

namespace MgmtDiscriminator.Models
{
    /// <summary> Defines the QueryString condition for the delivery rule. </summary>
    public partial class DeliveryRuleQueryStringCondition : DeliveryRuleCondition
    {
        /// <summary> Initializes a new instance of DeliveryRuleQueryStringCondition. </summary>
        /// <param name="parameters"> Defines the parameters for the condition. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="parameters"/> is null. </exception>
        public DeliveryRuleQueryStringCondition(QueryStringMatchConditionParameters parameters)
        {
            Argument.AssertNotNull(parameters, nameof(parameters));

            Parameters = parameters;
            Name = MatchVariable.QueryString;
        }

        /// <summary> Initializes a new instance of DeliveryRuleQueryStringCondition. </summary>
        /// <param name="name"> The name of the condition for the delivery rule. </param>
        /// <param name="parameters"> Defines the parameters for the condition. </param>
        internal DeliveryRuleQueryStringCondition(MatchVariable name, QueryStringMatchConditionParameters parameters) : base(name)
        {
            Parameters = parameters;
            Name = name;
        }

        /// <summary> Defines the parameters for the condition. </summary>
        public QueryStringMatchConditionParameters Parameters { get; set; }
    }
}
