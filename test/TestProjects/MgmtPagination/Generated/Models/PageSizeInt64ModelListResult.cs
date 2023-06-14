// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using MgmtPagination;

namespace MgmtPagination.Models
{
    /// <summary> The PageSizeInt64ModelListResult. </summary>
    internal partial class PageSizeInt64ModelListResult
    {
        /// <summary> Initializes a new instance of PageSizeInt64ModelListResult. </summary>
        internal PageSizeInt64ModelListResult()
        {
            Value = new ChangeTrackingList<PageSizeInt64ModelData>();
        }

        /// <summary> Initializes a new instance of PageSizeInt64ModelListResult. </summary>
        /// <param name="value"></param>
        /// <param name="nextLink"></param>
        internal PageSizeInt64ModelListResult(IReadOnlyList<PageSizeInt64ModelData> value, string nextLink)
        {
            Value = value;
            NextLink = nextLink;
        }

        /// <summary> Gets the value. </summary>
        public IReadOnlyList<PageSizeInt64ModelData> Value { get; }
        /// <summary> Gets the next link. </summary>
        public string NextLink { get; }
    }
}
