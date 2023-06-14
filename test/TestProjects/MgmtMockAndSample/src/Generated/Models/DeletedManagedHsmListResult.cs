// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using MgmtMockAndSample;

namespace MgmtMockAndSample.Models
{
    /// <summary> List of deleted managed HSM Pools. </summary>
    internal partial class DeletedManagedHsmListResult
    {
        /// <summary> Initializes a new instance of DeletedManagedHsmListResult. </summary>
        internal DeletedManagedHsmListResult()
        {
            Value = new ChangeTrackingList<DeletedManagedHsmData>();
        }

        /// <summary> Initializes a new instance of DeletedManagedHsmListResult. </summary>
        /// <param name="value"> The list of deleted managed HSM Pools. </param>
        /// <param name="nextLink"> The URL to get the next set of deleted managed HSM Pools. </param>
        internal DeletedManagedHsmListResult(IReadOnlyList<DeletedManagedHsmData> value, string nextLink)
        {
            Value = value;
            NextLink = nextLink;
        }

        /// <summary> The list of deleted managed HSM Pools. </summary>
        public IReadOnlyList<DeletedManagedHsmData> Value { get; }
        /// <summary> The URL to get the next set of deleted managed HSM Pools. </summary>
        public string NextLink { get; }
    }
}
