// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace MgmtListMethods.Models
{
    /// <summary> The result of list usages. </summary>
    internal partial class UsagesListResult
    {
        /// <summary> Initializes a new instance of UsagesListResult. </summary>
        internal UsagesListResult()
        {
            Value = new ChangeTrackingList<Usage>();
        }

        /// <summary> Initializes a new instance of UsagesListResult. </summary>
        /// <param name="value"> Usage. </param>
        /// <param name="nextLink"> The URL for getting next page result. </param>
        internal UsagesListResult(IReadOnlyList<Usage> value, string nextLink)
        {
            Value = value;
            NextLink = nextLink;
        }

        /// <summary> Usage. </summary>
        public IReadOnlyList<Usage> Value { get; }
        /// <summary> The URL for getting next page result. </summary>
        public string NextLink { get; }
    }
}
