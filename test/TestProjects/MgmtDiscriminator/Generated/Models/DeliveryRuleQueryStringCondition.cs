// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace MgmtDiscriminator.Models
{
    /// <summary> Defines the QueryString condition for the delivery rule. </summary>
    public partial class DeliveryRuleQueryStringCondition : DeliveryRuleCondition
    {
        /// <summary> Initializes a new instance of <see cref="DeliveryRuleQueryStringCondition"/>. </summary>
        /// <param name="parameters"> Defines the parameters for the condition. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="parameters"/> is null. </exception>
        public DeliveryRuleQueryStringCondition(QueryStringMatchConditionParameters parameters)
        {
            Argument.AssertNotNull(parameters, nameof(parameters));

            Parameters = parameters;
            Name = MatchVariable.QueryString;
        }

        /// <summary> Initializes a new instance of <see cref="DeliveryRuleQueryStringCondition"/>. </summary>
        /// <param name="name"> The name of the condition for the delivery rule. </param>
        /// <param name="foo"> For test. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        /// <param name="parameters"> Defines the parameters for the condition. </param>
        internal DeliveryRuleQueryStringCondition(MatchVariable name, string foo, IDictionary<string, BinaryData> serializedAdditionalRawData, QueryStringMatchConditionParameters parameters) : base(name, foo, serializedAdditionalRawData)
        {
            Parameters = parameters;
            Name = name;
        }

        /// <summary> Initializes a new instance of <see cref="DeliveryRuleQueryStringCondition"/> for deserialization. </summary>
        internal DeliveryRuleQueryStringCondition()
        {
        }

        /// <summary> Defines the parameters for the condition. </summary>
        [WirePath("parameters")]
        public QueryStringMatchConditionParameters Parameters { get; set; }
    }
}
