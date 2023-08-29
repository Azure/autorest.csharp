// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace MgmtDiscriminator.Models
{
    /// <summary> The UnknownDeliveryRuleCondition. </summary>
    internal partial class UnknownDeliveryRuleCondition : DeliveryRuleCondition
    {
        /// <summary> Initializes a new instance of <see cref="UnknownDeliveryRuleCondition"/>. </summary>
        /// <param name="name"> The name of the condition for the delivery rule. </param>
        /// <param name="foo"> For test. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal UnknownDeliveryRuleCondition(MatchVariable name, string foo, Dictionary<string, BinaryData> rawData) : base(name, foo, rawData)
        {
            Name = name;
        }

        /// <summary> Initializes a new instance of <see cref="UnknownDeliveryRuleCondition"/> for deserialization. </summary>
        internal UnknownDeliveryRuleCondition()
        {
        }
    }
}
