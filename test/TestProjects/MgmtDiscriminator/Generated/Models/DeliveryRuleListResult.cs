// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using MgmtDiscriminator;

namespace MgmtDiscriminator.Models
{
    /// <summary> The list result of the rules. </summary>
    internal partial class DeliveryRuleListResult
    {
        /// <summary> Initializes a new instance of DeliveryRuleListResult. </summary>
        internal DeliveryRuleListResult()
        {
            Value = new ChangeTrackingList<DeliveryRuleData>();
        }

        /// <summary> Initializes a new instance of DeliveryRuleListResult. </summary>
        /// <param name="value"> The values. </param>
        internal DeliveryRuleListResult(IReadOnlyList<DeliveryRuleData> value)
        {
            Value = value;
        }

        /// <summary> The values. </summary>
        public IReadOnlyList<DeliveryRuleData> Value { get; }
    }
}
