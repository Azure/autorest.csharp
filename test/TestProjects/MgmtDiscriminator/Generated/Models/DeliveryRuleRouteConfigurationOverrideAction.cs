// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace MgmtDiscriminator.Models
{
    /// <summary> Defines the route configuration override action for the delivery rule. Only applicable to Frontdoor Standard/Premium Profiles. </summary>
    public partial class DeliveryRuleRouteConfigurationOverrideAction : DeliveryRuleAction
    {
        /// <summary> Initializes a new instance of DeliveryRuleRouteConfigurationOverrideAction. </summary>
        /// <param name="parameters"> Defines the parameters for the action. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="parameters"/> is null. </exception>
        public DeliveryRuleRouteConfigurationOverrideAction(RouteConfigurationOverrideActionParameters parameters)
        {
            Argument.AssertNotNull(parameters, nameof(parameters));

            Parameters = parameters;
            Name = DeliveryRuleActionType.RouteConfigurationOverride;
        }

        /// <summary> Initializes a new instance of DeliveryRuleRouteConfigurationOverrideAction. </summary>
        /// <param name="name"> The name of the action for the delivery rule. </param>
        /// <param name="foo"> for test. </param>
        /// <param name="parameters"> Defines the parameters for the action. </param>
        internal DeliveryRuleRouteConfigurationOverrideAction(DeliveryRuleActionType name, string foo, RouteConfigurationOverrideActionParameters parameters) : base(name, foo)
        {
            Parameters = parameters;
            Name = name;
        }

        /// <summary> Defines the parameters for the action. </summary>
        public RouteConfigurationOverrideActionParameters Parameters { get; set; }
    }
}
