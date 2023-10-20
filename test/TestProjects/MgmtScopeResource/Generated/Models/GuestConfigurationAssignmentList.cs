// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using MgmtScopeResource;

namespace MgmtScopeResource.Models
{
    /// <summary> The response of the list guest configuration assignment operation. </summary>
    internal partial class GuestConfigurationAssignmentList
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="GuestConfigurationAssignmentList"/>. </summary>
        internal GuestConfigurationAssignmentList()
        {
            Value = new ChangeTrackingList<GuestConfigurationAssignmentData>();
        }

        /// <summary> Initializes a new instance of <see cref="GuestConfigurationAssignmentList"/>. </summary>
        /// <param name="value"> Result of the list guest configuration assignment operation. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal GuestConfigurationAssignmentList(IReadOnlyList<GuestConfigurationAssignmentData> value, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Value = value;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Result of the list guest configuration assignment operation. </summary>
        public IReadOnlyList<GuestConfigurationAssignmentData> Value { get; }
    }
}
