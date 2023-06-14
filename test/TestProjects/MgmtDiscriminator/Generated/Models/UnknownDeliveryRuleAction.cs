// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtDiscriminator.Models
{
    /// <summary> The UnknownDeliveryRuleAction. </summary>
    internal partial class UnknownDeliveryRuleAction : DeliveryRuleAction
    {
        /// <summary> Initializes a new instance of UnknownDeliveryRuleAction. </summary>
        /// <param name="name"> The name of the action for the delivery rule. </param>
        /// <param name="foo"> for test. </param>
        internal UnknownDeliveryRuleAction(DeliveryRuleActionType name, string foo) : base(name, foo)
        {
            Name = name;
        }
    }
}
