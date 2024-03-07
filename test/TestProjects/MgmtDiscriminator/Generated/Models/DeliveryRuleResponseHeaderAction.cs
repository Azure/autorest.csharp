// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using MgmtDiscriminator;

namespace MgmtDiscriminator.Models
{
    /// <summary> Defines the response header action for the delivery rule. </summary>
    public partial class DeliveryRuleResponseHeaderAction : DeliveryRuleAction
    {
        /// <summary> Initializes a new instance of <see cref="DeliveryRuleResponseHeaderAction"/>. </summary>
        /// <param name="parameters"> Defines the parameters for the action. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="parameters"/> is null. </exception>
        public DeliveryRuleResponseHeaderAction(HeaderActionParameters parameters)
        {
            Argument.AssertNotNull(parameters, nameof(parameters));

            Parameters = parameters;
            Name = DeliveryRuleActionType.ModifyResponseHeader;
        }

        /// <summary> Initializes a new instance of <see cref="DeliveryRuleResponseHeaderAction"/>. </summary>
        /// <param name="name"> The name of the action for the delivery rule. </param>
        /// <param name="foo"> for test. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        /// <param name="parameters"> Defines the parameters for the action. </param>
        internal DeliveryRuleResponseHeaderAction(DeliveryRuleActionType name, string foo, IDictionary<string, BinaryData> serializedAdditionalRawData, HeaderActionParameters parameters) : base(name, foo, serializedAdditionalRawData)
        {
            Parameters = parameters;
            Name = name;
        }

        /// <summary> Initializes a new instance of <see cref="DeliveryRuleResponseHeaderAction"/> for deserialization. </summary>
        internal DeliveryRuleResponseHeaderAction()
        {
        }

        /// <summary> Defines the parameters for the action. </summary>
        [WirePath("parameters")]
        public HeaderActionParameters Parameters { get; set; }
    }
}
