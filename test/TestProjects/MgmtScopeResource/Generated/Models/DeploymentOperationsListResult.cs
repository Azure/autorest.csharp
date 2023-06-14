// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace MgmtScopeResource.Models
{
    /// <summary> List of deployment operations. </summary>
    internal partial class DeploymentOperationsListResult
    {
        /// <summary> Initializes a new instance of DeploymentOperationsListResult. </summary>
        internal DeploymentOperationsListResult()
        {
            Value = new ChangeTrackingList<DeploymentOperation>();
        }

        /// <summary> Initializes a new instance of DeploymentOperationsListResult. </summary>
        /// <param name="value"> An array of deployment operations. </param>
        /// <param name="nextLink"> The URL to use for getting the next set of results. </param>
        internal DeploymentOperationsListResult(IReadOnlyList<DeploymentOperation> value, string nextLink)
        {
            Value = value;
            NextLink = nextLink;
        }

        /// <summary> An array of deployment operations. </summary>
        public IReadOnlyList<DeploymentOperation> Value { get; }
        /// <summary> The URL to use for getting the next set of results. </summary>
        public string NextLink { get; }
    }
}
