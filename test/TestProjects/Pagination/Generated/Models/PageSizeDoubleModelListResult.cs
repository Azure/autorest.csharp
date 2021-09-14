// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Pagination;

namespace Pagination.Models
{
    /// <summary> The PageSizeDoubleModelListResult. </summary>
    internal partial class PageSizeDoubleModelListResult
    {
        /// <summary> Initializes a new instance of PageSizeDoubleModelListResult. </summary>
        internal PageSizeDoubleModelListResult()
        {
            Value = new ChangeTrackingList<PageSizeDoubleModelData>();
        }

        /// <summary> Initializes a new instance of PageSizeDoubleModelListResult. </summary>
        /// <param name="value"></param>
        /// <param name="nextLink"></param>
        internal PageSizeDoubleModelListResult(IReadOnlyList<PageSizeDoubleModelData> value, string nextLink)
        {
            Value = value;
            NextLink = nextLink;
        }

        /// <summary> Gets the value. </summary>
        public IReadOnlyList<PageSizeDoubleModelData> Value { get; }
        /// <summary> Gets the nextlink. </summary>
        public string NextLink { get; }
    }
}
