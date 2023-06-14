// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using MgmtScopeResource;

namespace MgmtScopeResource.Models
{
    /// <summary> List of policy assignments. </summary>
    internal partial class FakePolicyAssignmentListResult
    {
        /// <summary> Initializes a new instance of FakePolicyAssignmentListResult. </summary>
        internal FakePolicyAssignmentListResult()
        {
            Value = new ChangeTrackingList<FakePolicyAssignmentData>();
        }

        /// <summary> Initializes a new instance of FakePolicyAssignmentListResult. </summary>
        /// <param name="value"> An array of policy assignments. </param>
        /// <param name="nextLink"> The URL to use for getting the next set of results. </param>
        internal FakePolicyAssignmentListResult(IReadOnlyList<FakePolicyAssignmentData> value, string nextLink)
        {
            Value = value;
            NextLink = nextLink;
        }

        /// <summary> An array of policy assignments. </summary>
        public IReadOnlyList<FakePolicyAssignmentData> Value { get; }
        /// <summary> The URL to use for getting the next set of results. </summary>
        public string NextLink { get; }
    }
}
