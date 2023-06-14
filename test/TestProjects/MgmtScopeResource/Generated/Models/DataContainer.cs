// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace MgmtScopeResource.Models
{
    /// <summary> Information about a container with data for a given resource. </summary>
    public partial class DataContainer
    {
        /// <summary> Initializes a new instance of DataContainer. </summary>
        /// <param name="workspace"> Log Analytics workspace information. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="workspace"/> is null. </exception>
        internal DataContainer(WorkspaceInfo workspace)
        {
            Argument.AssertNotNull(workspace, nameof(workspace));

            Workspace = workspace;
        }

        /// <summary> Log Analytics workspace information. </summary>
        public WorkspaceInfo Workspace { get; }
    }
}
