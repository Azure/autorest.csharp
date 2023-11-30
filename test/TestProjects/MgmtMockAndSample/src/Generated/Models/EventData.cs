// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

namespace MgmtMockAndSample.Models
{
    /// <summary> The Azure event log entries are of type EventData. </summary>
    public partial class EventData
    {
        /// <summary> Initializes a new instance of <see cref="EventData"/>. </summary>
        internal EventData()
        {
        }

        /// <summary> Initializes a new instance of <see cref="EventData"/>. </summary>
        /// <param name="authorization"> The sender authorization information. </param>
        /// <param name="tenantId"> the Azure tenant Id. </param>
        internal EventData(SenderAuthorization authorization, Guid? tenantId)
        {
            Authorization = authorization;
            TenantId = tenantId;
        }

        /// <summary> The sender authorization information. </summary>
        public SenderAuthorization Authorization { get; }
        /// <summary> the Azure tenant Id. </summary>
        public Guid? TenantId { get; }
    }
}
