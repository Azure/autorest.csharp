// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace MgmtMockAndSample.Models
{
    /// <summary> A list of private link resources. </summary>
    internal partial class MgmtMockAndSamplePrivateLinkResourceListResult
    {
        /// <summary> Initializes a new instance of MgmtMockAndSamplePrivateLinkResourceListResult. </summary>
        internal MgmtMockAndSamplePrivateLinkResourceListResult()
        {
            Value = new ChangeTrackingList<MgmtMockAndSamplePrivateLinkResource>();
        }

        /// <summary> Initializes a new instance of MgmtMockAndSamplePrivateLinkResourceListResult. </summary>
        /// <param name="value"> Array of private link resources. </param>
        internal MgmtMockAndSamplePrivateLinkResourceListResult(IReadOnlyList<MgmtMockAndSamplePrivateLinkResource> value)
        {
            Value = value;
        }

        /// <summary> Array of private link resources. </summary>
        public IReadOnlyList<MgmtMockAndSamplePrivateLinkResource> Value { get; }
    }
}
