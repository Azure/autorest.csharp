// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace MgmtParamOrdering.Models
{
    /// <summary> The parameters for updating a machine learning workspace. </summary>
    public partial class WorkspacePatch
    {
        /// <summary> Initializes a new instance of WorkspacePatch. </summary>
        public WorkspacePatch()
        {
            Tags = new ChangeTrackingDictionary<string, string>();
        }

        /// <summary> The resource tags for the machine learning workspace. </summary>
        public IDictionary<string, string> Tags { get; }
    }
}
