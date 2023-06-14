// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace MgmtDiscriminator.Models
{
    /// <summary> Defines the url signing action for the delivery rule. </summary>
    public partial class UrlSigningAction : DeliveryRuleAction
    {
        /// <summary> Initializes a new instance of UrlSigningAction. </summary>
        /// <param name="parameters"> Defines the parameters for the action. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="parameters"/> is null. </exception>
        public UrlSigningAction(UrlSigningActionParameters parameters)
        {
            Argument.AssertNotNull(parameters, nameof(parameters));

            Parameters = parameters;
            Name = DeliveryRuleActionType.UrlSigning;
        }

        /// <summary> Initializes a new instance of UrlSigningAction. </summary>
        /// <param name="name"> The name of the action for the delivery rule. </param>
        /// <param name="foo"> for test. </param>
        /// <param name="parameters"> Defines the parameters for the action. </param>
        internal UrlSigningAction(DeliveryRuleActionType name, string foo, UrlSigningActionParameters parameters) : base(name, foo)
        {
            Parameters = parameters;
            Name = name;
        }

        /// <summary> Defines the parameters for the action. </summary>
        public UrlSigningActionParameters Parameters { get; set; }
    }
}
