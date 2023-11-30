// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using MgmtPagination;

namespace MgmtPagination.Models
{
    /// <summary> The PageSizeNumericModelListResult. </summary>
    internal partial class PageSizeNumericModelListResult
    {
        /// <summary> Initializes a new instance of <see cref="PageSizeNumericModelListResult"/>. </summary>
        internal PageSizeNumericModelListResult()
        {
            Value = new ChangeTrackingList<PageSizeNumericModelData>();
        }

        /// <summary> Initializes a new instance of <see cref="PageSizeNumericModelListResult"/>. </summary>
        /// <param name="value"></param>
        /// <param name="nextLink"></param>
        internal PageSizeNumericModelListResult(IReadOnlyList<PageSizeNumericModelData> value, string nextLink)
        {
            Value = value;
            NextLink = nextLink;
        }

        /// <summary> Gets the value. </summary>
        public IReadOnlyList<PageSizeNumericModelData> Value { get; }
        /// <summary> Gets the next link. </summary>
        public string NextLink { get; }
    }
}
