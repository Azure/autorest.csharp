// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace MgmtScopeResource.Models
{
    /// <summary> Information about a container with data for a given resource. </summary>
    public partial class DataContainer
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="DataContainer"/>. </summary>
        /// <param name="workspace"> Log Analytics workspace information. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="workspace"/> is null. </exception>
        internal DataContainer(WorkspaceInfo workspace)
        {
            Argument.AssertNotNull(workspace, nameof(workspace));

            Workspace = workspace;
        }

        /// <summary> Initializes a new instance of <see cref="DataContainer"/>. </summary>
        /// <param name="workspace"> Log Analytics workspace information. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal DataContainer(WorkspaceInfo workspace, Dictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Workspace = workspace;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="DataContainer"/> for deserialization. </summary>
        internal DataContainer()
        {
        }

        /// <summary> Log Analytics workspace information. </summary>
        public WorkspaceInfo Workspace { get; }
    }
}
