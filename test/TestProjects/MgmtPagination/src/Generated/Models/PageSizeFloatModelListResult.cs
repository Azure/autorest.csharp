// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;

namespace MgmtPagination.Models
{
    /// <summary> The PageSizeFloatModelListResult. </summary>
    internal partial class PageSizeFloatModelListResult
    {
        /// <summary> Initializes a new instance of <see cref="PageSizeFloatModelListResult"/>. </summary>
        internal PageSizeFloatModelListResult()
        {
            Value = new ChangeTrackingList<PageSizeFloatModelData>();
        }

        /// <summary> Initializes a new instance of <see cref="PageSizeFloatModelListResult"/>. </summary>
        /// <param name="value"></param>
        /// <param name="nextLink"></param>
        internal PageSizeFloatModelListResult(IReadOnlyList<PageSizeFloatModelData> value, string nextLink)
        {
            Value = value;
            NextLink = nextLink;
        }

        /// <summary> Gets the value. </summary>
        public IReadOnlyList<PageSizeFloatModelData> Value { get; }
        /// <summary> Gets the next link. </summary>
        public string NextLink { get; }
    }
}
