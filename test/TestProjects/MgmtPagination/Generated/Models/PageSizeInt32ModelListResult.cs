// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using MgmtPagination;

namespace MgmtPagination.Models
{
    /// <summary> The PageSizeInt32ModelListResult. </summary>
    internal partial class PageSizeInt32ModelListResult
    {
        /// <summary> Initializes a new instance of PageSizeInt32ModelListResult. </summary>
        internal PageSizeInt32ModelListResult()
        {
            Value = new ChangeTrackingList<PageSizeInt32ModelData>();
        }

        /// <summary> Initializes a new instance of PageSizeInt32ModelListResult. </summary>
        /// <param name="value"></param>
        /// <param name="nextLink"></param>
        internal PageSizeInt32ModelListResult(IReadOnlyList<PageSizeInt32ModelData> value, string nextLink)
        {
            Value = value;
            NextLink = nextLink;
        }

        /// <summary> Gets the value. </summary>
        public IReadOnlyList<PageSizeInt32ModelData> Value { get; }
        /// <summary> Gets the next link. </summary>
        public string NextLink { get; }
    }
}
