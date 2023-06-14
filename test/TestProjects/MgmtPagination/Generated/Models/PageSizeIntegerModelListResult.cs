// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using MgmtPagination;

namespace MgmtPagination.Models
{
    /// <summary> The PageSizeIntegerModelListResult. </summary>
    internal partial class PageSizeIntegerModelListResult
    {
        /// <summary> Initializes a new instance of PageSizeIntegerModelListResult. </summary>
        internal PageSizeIntegerModelListResult()
        {
            Value = new ChangeTrackingList<PageSizeIntegerModelData>();
        }

        /// <summary> Initializes a new instance of PageSizeIntegerModelListResult. </summary>
        /// <param name="value"></param>
        /// <param name="nextLink"></param>
        internal PageSizeIntegerModelListResult(IReadOnlyList<PageSizeIntegerModelData> value, string nextLink)
        {
            Value = value;
            NextLink = nextLink;
        }

        /// <summary> Gets the value. </summary>
        public IReadOnlyList<PageSizeIntegerModelData> Value { get; }
        /// <summary> Gets the next link. </summary>
        public string NextLink { get; }
    }
}
