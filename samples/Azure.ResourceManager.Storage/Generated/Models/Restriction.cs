// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> The restriction because of which SKU cannot be used. </summary>
    public partial class Restriction
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="Restriction"/>. </summary>
        internal Restriction()
        {
            Values = new ChangeTrackingList<string>();
        }

        /// <summary> Initializes a new instance of <see cref="Restriction"/>. </summary>
        /// <param name="restrictionType"> The type of restrictions. As of now only possible value for this is location. </param>
        /// <param name="values"> The value of restrictions. If the restriction type is set to location. This would be different locations where the SKU is restricted. </param>
        /// <param name="reasonCode"> The reason for the restriction. As of now this can be "QuotaId" or "NotAvailableForSubscription". Quota Id is set when the SKU has requiredQuotas parameter as the subscription does not belong to that quota. The "NotAvailableForSubscription" is related to capacity at DC. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal Restriction(string restrictionType, IReadOnlyList<string> values, ReasonCode? reasonCode, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            RestrictionType = restrictionType;
            Values = values;
            ReasonCode = reasonCode;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> The type of restrictions. As of now only possible value for this is location. </summary>
        public string RestrictionType { get; }
        /// <summary> The value of restrictions. If the restriction type is set to location. This would be different locations where the SKU is restricted. </summary>
        public IReadOnlyList<string> Values { get; }
        /// <summary> The reason for the restriction. As of now this can be "QuotaId" or "NotAvailableForSubscription". Quota Id is set when the SKU has requiredQuotas parameter as the subscription does not belong to that quota. The "NotAvailableForSubscription" is related to capacity at DC. </summary>
        public ReasonCode? ReasonCode { get; }
    }
}
