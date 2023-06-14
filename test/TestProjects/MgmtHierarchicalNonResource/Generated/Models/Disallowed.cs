// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace MgmtHierarchicalNonResource.Models
{
    /// <summary> Describes the disallowed disk types. </summary>
    internal partial class Disallowed
    {
        /// <summary> Initializes a new instance of Disallowed. </summary>
        internal Disallowed()
        {
            DiskTypes = new ChangeTrackingList<string>();
        }

        /// <summary> Initializes a new instance of Disallowed. </summary>
        /// <param name="diskTypes"> A list of disk types. </param>
        internal Disallowed(IReadOnlyList<string> diskTypes)
        {
            DiskTypes = diskTypes;
        }

        /// <summary> A list of disk types. </summary>
        public IReadOnlyList<string> DiskTypes { get; }
    }
}
