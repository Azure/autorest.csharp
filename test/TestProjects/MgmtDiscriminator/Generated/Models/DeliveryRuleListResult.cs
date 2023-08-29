// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using MgmtDiscriminator;

namespace MgmtDiscriminator.Models
{
    /// <summary> The list result of the rules. </summary>
    internal partial class DeliveryRuleListResult
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="DeliveryRuleListResult"/>. </summary>
        internal DeliveryRuleListResult()
        {
            Value = new ChangeTrackingList<DeliveryRuleData>();
        }

        /// <summary> Initializes a new instance of <see cref="DeliveryRuleListResult"/>. </summary>
        /// <param name="value"> The values. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal DeliveryRuleListResult(IReadOnlyList<DeliveryRuleData> value, Dictionary<string, BinaryData> rawData)
        {
            Value = value;
            _rawData = rawData;
        }

        /// <summary> The values. </summary>
        public IReadOnlyList<DeliveryRuleData> Value { get; }
    }
}
