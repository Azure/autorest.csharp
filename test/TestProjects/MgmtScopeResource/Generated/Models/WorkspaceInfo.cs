// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace MgmtScopeResource.Models
{
    /// <summary> Information about a Log Analytics Workspace. </summary>
    public partial class WorkspaceInfo
    {
        /// <summary> Initializes a new instance of WorkspaceInfo. </summary>
        /// <param name="id"> Azure Resource Manager identifier of the Log Analytics Workspace. </param>
        /// <param name="location"> Location of the Log Analytics workspace. </param>
        /// <param name="customerId"> Log Analytics workspace identifier. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/>, <paramref name="location"/> or <paramref name="customerId"/> is null. </exception>
        internal WorkspaceInfo(string id, string location, string customerId)
        {
            Argument.AssertNotNull(id, nameof(id));
            Argument.AssertNotNull(location, nameof(location));
            Argument.AssertNotNull(customerId, nameof(customerId));

            Id = id;
            Location = location;
            CustomerId = customerId;
        }

        /// <summary> Azure Resource Manager identifier of the Log Analytics Workspace. </summary>
        public string Id { get; }
        /// <summary> Location of the Log Analytics workspace. </summary>
        public string Location { get; }
        /// <summary> Log Analytics workspace identifier. </summary>
        public string CustomerId { get; }
    }
}
