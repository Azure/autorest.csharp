// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtDiscriminator.Models
{
    /// <summary> The UnknownDeliveryRuleCondition. </summary>
    internal partial class UnknownDeliveryRuleCondition : DeliveryRuleCondition
    {
        /// <summary> Initializes a new instance of UnknownDeliveryRuleCondition. </summary>
        /// <param name="name"> The name of the condition for the delivery rule. </param>
        /// <param name="foo"> For test. </param>
        internal UnknownDeliveryRuleCondition(MatchVariable name, string foo) : base(name, foo)
        {
            Name = name;
        }
    }
}
