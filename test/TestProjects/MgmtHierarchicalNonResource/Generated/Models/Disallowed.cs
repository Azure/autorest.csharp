// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace MgmtHierarchicalNonResource.Models
{
    /// <summary> Describes the disallowed disk types. </summary>
    internal partial class Disallowed
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="Disallowed"/>. </summary>
        internal Disallowed()
        {
            DiskTypes = new ChangeTrackingList<string>();
        }

        /// <summary> Initializes a new instance of <see cref="Disallowed"/>. </summary>
        /// <param name="diskTypes"> A list of disk types. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal Disallowed(IReadOnlyList<string> diskTypes, Dictionary<string, BinaryData> rawData)
        {
            DiskTypes = diskTypes;
            _rawData = rawData;
        }

        /// <summary> A list of disk types. </summary>
        public IReadOnlyList<string> DiskTypes { get; }
    }
}
