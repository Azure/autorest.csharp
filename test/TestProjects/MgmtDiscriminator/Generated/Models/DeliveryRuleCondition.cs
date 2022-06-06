// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace MgmtDiscriminator.Models
{
    /// <summary>
    /// A condition for the delivery rule.
    /// Please note <see cref="DeliveryRuleCondition"/> is the base class. In order to more specifically assign or retrieve the value of this property, the derived class is needed.
    /// The available derived classes include <see cref="DeliveryRuleQueryStringCondition"/>, <see cref="DeliveryRuleRemoteAddressCondition"/>, <see cref="DeliveryRuleRequestMethodCondition"/>.
    /// </summary>
    public partial class DeliveryRuleCondition
    {
        /// <summary> Initializes a new instance of DeliveryRuleCondition. </summary>
        public DeliveryRuleCondition()
        {
        }

        /// <summary> Initializes a new instance of DeliveryRuleCondition. </summary>
        /// <param name="name"> The name of the condition for the delivery rule. </param>
        internal DeliveryRuleCondition(MatchVariable name)
        {
            Name = name;
        }

        /// <summary> The name of the condition for the delivery rule. </summary>
        internal MatchVariable Name { get; set; }
    }
}
