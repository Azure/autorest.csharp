// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core.Serialization;

namespace MgmtDiscriminator.Models
{
    /// <summary>
    /// A condition for the delivery rule.
    /// Please note <see cref="DeliveryRuleCondition"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
    /// The available derived classes include <see cref="DeliveryRuleQueryStringCondition"/>, <see cref="DeliveryRuleRemoteAddressCondition"/> and <see cref="DeliveryRuleRequestMethodCondition"/>.
    /// </summary>
    [DeserializationProxy(typeof(UnknownDeliveryRuleCondition))]
    public abstract partial class DeliveryRuleCondition
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        protected internal Dictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="DeliveryRuleCondition"/>. </summary>
        protected DeliveryRuleCondition()
        {
        }

        /// <summary> Initializes a new instance of <see cref="DeliveryRuleCondition"/>. </summary>
        /// <param name="name"> The name of the condition for the delivery rule. </param>
        /// <param name="foo"> For test. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal DeliveryRuleCondition(MatchVariable name, string foo, Dictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Name = name;
            Foo = foo;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> The name of the condition for the delivery rule. </summary>
        internal MatchVariable Name { get; set; }
        /// <summary> For test. </summary>
        public string Foo { get; }
    }
}
