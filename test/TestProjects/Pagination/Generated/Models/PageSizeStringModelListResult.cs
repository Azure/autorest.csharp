// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Pagination;

namespace Pagination.Models
{
    /// <summary> The PageSizeStringModelListResult. </summary>
    internal partial class PageSizeStringModelListResult
    {
        /// <summary> Initializes a new instance of PageSizeStringModelListResult. </summary>
        internal PageSizeStringModelListResult()
        {
            Value = new ChangeTrackingList<PageSizeStringModelResourceData>();
        }

        /// <summary> Initializes a new instance of PageSizeStringModelListResult. </summary>
        /// <param name="value"></param>
        /// <param name="nextLink"></param>
        internal PageSizeStringModelListResult(IReadOnlyList<PageSizeStringModelResourceData> value, string nextLink)
        {
            Value = value;
            NextLink = nextLink;
        }

        /// <summary> Gets the value. </summary>
        public IReadOnlyList<PageSizeStringModelResourceData> Value { get; }
        /// <summary> Gets the next link. </summary>
        public string NextLink { get; }
    }
}
