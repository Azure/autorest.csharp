// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace MgmtDiscriminator.Models
{
    /// <summary>
    /// An action for the delivery rule.
    /// Please note <see cref="DeliveryRuleAction"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
    /// The available derived classes include <see cref="DeliveryRuleCacheExpirationAction"/>, <see cref="DeliveryRuleCacheKeyQueryStringAction"/>, <see cref="DeliveryRuleRequestHeaderAction"/>, <see cref="DeliveryRuleResponseHeaderAction"/>, <see cref="OriginGroupOverrideAction"/>, <see cref="DeliveryRuleRouteConfigurationOverrideAction"/>, <see cref="UrlRedirectAction"/>, <see cref="UrlRewriteAction"/> and <see cref="UrlSigningAction"/>.
    /// </summary>
    public partial class DeliveryRuleAction
    {
        /// <summary> Initializes a new instance of <see cref="DeliveryRuleAction"/>. </summary>
        public DeliveryRuleAction()
        {
        }

        /// <summary> Initializes a new instance of <see cref="DeliveryRuleAction"/>. </summary>
        /// <param name="name"> The name of the action for the delivery rule. </param>
        /// <param name="foo"> for test. </param>
        internal DeliveryRuleAction(DeliveryRuleActionType name, string foo)
        {
            Name = name;
            Foo = foo;
        }

        /// <summary> The name of the action for the delivery rule. </summary>
        internal DeliveryRuleActionType Name { get; set; }
        /// <summary> for test. </summary>
        public string Foo { get; }
    }
}
