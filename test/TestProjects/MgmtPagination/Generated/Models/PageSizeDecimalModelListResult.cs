// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using MgmtPagination;

namespace MgmtPagination.Models
{
    /// <summary> The PageSizeDecimalModelListResult. </summary>
    internal partial class PageSizeDecimalModelListResult
    {
        /// <summary> Initializes a new instance of PageSizeDecimalModelListResult. </summary>
        internal PageSizeDecimalModelListResult()
        {
            Value = new ChangeTrackingList<PageSizeDecimalModelData>();
        }

        /// <summary> Initializes a new instance of PageSizeDecimalModelListResult. </summary>
        /// <param name="value"></param>
        /// <param name="nextLink"></param>
        internal PageSizeDecimalModelListResult(IReadOnlyList<PageSizeDecimalModelData> value, string nextLink)
        {
            Value = value;
            NextLink = nextLink;
        }

        /// <summary> Gets the value. </summary>
        public IReadOnlyList<PageSizeDecimalModelData> Value { get; }
        /// <summary> Gets the next link. </summary>
        public string NextLink { get; }
    }
}
