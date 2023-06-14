// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtDiscriminator.Models
{
    /// <summary>
    /// A condition for the delivery rule.
    /// Please note <see cref="DeliveryRuleCondition"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
    /// The available derived classes include <see cref="DeliveryRuleQueryStringCondition"/>, <see cref="DeliveryRuleRemoteAddressCondition"/> and <see cref="DeliveryRuleRequestMethodCondition"/>.
    /// </summary>
    public abstract partial class DeliveryRuleCondition
    {
        /// <summary> Initializes a new instance of DeliveryRuleCondition. </summary>
        protected DeliveryRuleCondition()
        {
        }

        /// <summary> Initializes a new instance of DeliveryRuleCondition. </summary>
        /// <param name="name"> The name of the condition for the delivery rule. </param>
        /// <param name="foo"> For test. </param>
        internal DeliveryRuleCondition(MatchVariable name, string foo)
        {
            Name = name;
            Foo = foo;
        }

        /// <summary> The name of the condition for the delivery rule. </summary>
        internal MatchVariable Name { get; set; }
        /// <summary> For test. </summary>
        public string Foo { get; }
    }
}
