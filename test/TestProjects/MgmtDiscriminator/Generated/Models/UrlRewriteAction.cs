// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace MgmtDiscriminator.Models
{
    /// <summary> Defines the url rewrite action for the delivery rule. </summary>
    public partial class UrlRewriteAction : DeliveryRuleAction
    {
        /// <summary> Initializes a new instance of UrlRewriteAction. </summary>
        /// <param name="parameters"> Defines the parameters for the action. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="parameters"/> is null. </exception>
        public UrlRewriteAction(UrlRewriteActionParameters parameters)
        {
            Argument.AssertNotNull(parameters, nameof(parameters));

            Parameters = parameters;
            Name = DeliveryRuleActionType.UrlRewrite;
        }

        /// <summary> Initializes a new instance of UrlRewriteAction. </summary>
        /// <param name="name"> The name of the action for the delivery rule. </param>
        /// <param name="foo"> for test. </param>
        /// <param name="parameters"> Defines the parameters for the action. </param>
        internal UrlRewriteAction(DeliveryRuleActionType name, string foo, UrlRewriteActionParameters parameters) : base(name, foo)
        {
            Parameters = parameters;
            Name = name;
        }

        /// <summary> Defines the parameters for the action. </summary>
        public UrlRewriteActionParameters Parameters { get; set; }
    }
}
