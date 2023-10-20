// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace MgmtMockAndSample.Models
{
    /// <summary> The Azure event log entries are of type EventData. </summary>
    public partial class EventData
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="EventData"/>. </summary>
        internal EventData()
        {
        }

        /// <summary> Initializes a new instance of <see cref="EventData"/>. </summary>
        /// <param name="authorization"> The sender authorization information. </param>
        /// <param name="tenantId"> the Azure tenant Id. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal EventData(SenderAuthorization authorization, Guid? tenantId, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Authorization = authorization;
            TenantId = tenantId;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> The sender authorization information. </summary>
        public SenderAuthorization Authorization { get; }
        /// <summary> the Azure tenant Id. </summary>
        public Guid? TenantId { get; }
    }
}
