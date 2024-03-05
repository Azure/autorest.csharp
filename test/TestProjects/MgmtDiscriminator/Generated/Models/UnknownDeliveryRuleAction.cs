// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace MgmtDiscriminator.Models
{
    /// <summary> The UnknownDeliveryRuleAction. </summary>
    internal partial class UnknownDeliveryRuleAction : DeliveryRuleAction
    {
        /// <summary> Initializes a new instance of <see cref="UnknownDeliveryRuleAction"/>. </summary>
        /// <param name="name"> The name of the action for the delivery rule. </param>
        /// <param name="foo"> for test. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal UnknownDeliveryRuleAction(DeliveryRuleActionType name, string foo, IDictionary<string, BinaryData> serializedAdditionalRawData) : base(name, foo, serializedAdditionalRawData)
        {
            Name = name;
        }

        /// <summary> Initializes a new instance of <see cref="UnknownDeliveryRuleAction"/> for deserialization. </summary>
        internal UnknownDeliveryRuleAction()
        {
        }
    }
}
