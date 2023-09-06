// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using MgmtPagination;

namespace MgmtPagination.Models
{
    /// <summary> The PageSizeStringModelListResult. </summary>
    internal partial class PageSizeStringModelListResult
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="PageSizeStringModelListResult"/>. </summary>
        internal PageSizeStringModelListResult()
        {
            Value = new ChangeTrackingList<PageSizeStringModelData>();
        }

        /// <summary> Initializes a new instance of <see cref="PageSizeStringModelListResult"/>. </summary>
        /// <param name="value"></param>
        /// <param name="nextLink"></param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal PageSizeStringModelListResult(IReadOnlyList<PageSizeStringModelData> value, string nextLink, Dictionary<string, BinaryData> rawData)
        {
            Value = value;
            NextLink = nextLink;
            _rawData = rawData;
        }

        /// <summary> Gets the value. </summary>
        public IReadOnlyList<PageSizeStringModelData> Value { get; }
        /// <summary> Gets the next link. </summary>
        public string NextLink { get; }
    }
}
