// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace MgmtExpandResourceTypes.Models
{
    /// <summary> Represents the properties of the Dns Resource Reference Result. </summary>
    public partial class DnsResourceReferenceResult
    {
        /// <summary> Initializes a new instance of <see cref="DnsResourceReferenceResult"/>. </summary>
        internal DnsResourceReferenceResult()
        {
            DnsResourceReferences = new ChangeTrackingList<DnsResourceReference>();
        }

        /// <summary> Initializes a new instance of <see cref="DnsResourceReferenceResult"/>. </summary>
        /// <param name="dnsResourceReferences"> The result of dns resource reference request. A list of dns resource references for each of the azure resource in the request. </param>
        internal DnsResourceReferenceResult(IReadOnlyList<DnsResourceReference> dnsResourceReferences)
        {
            DnsResourceReferences = dnsResourceReferences;
        }

        /// <summary> The result of dns resource reference request. A list of dns resource references for each of the azure resource in the request. </summary>
        public IReadOnlyList<DnsResourceReference> DnsResourceReferences { get; }
    }
}
