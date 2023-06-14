// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using MgmtPagination;

namespace MgmtPagination.Models
{
    /// <summary> The PageSizeStringModelListResult. </summary>
    internal partial class PageSizeStringModelListResult
    {
        /// <summary> Initializes a new instance of PageSizeStringModelListResult. </summary>
        internal PageSizeStringModelListResult()
        {
            Value = new ChangeTrackingList<PageSizeStringModelData>();
        }

        /// <summary> Initializes a new instance of PageSizeStringModelListResult. </summary>
        /// <param name="value"></param>
        /// <param name="nextLink"></param>
        internal PageSizeStringModelListResult(IReadOnlyList<PageSizeStringModelData> value, string nextLink)
        {
            Value = value;
            NextLink = nextLink;
        }

        /// <summary> Gets the value. </summary>
        public IReadOnlyList<PageSizeStringModelData> Value { get; }
        /// <summary> Gets the next link. </summary>
        public string NextLink { get; }
    }
}
