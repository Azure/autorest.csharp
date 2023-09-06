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
    /// <summary> The PageSizeFloatModelListResult. </summary>
    internal partial class PageSizeFloatModelListResult
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="PageSizeFloatModelListResult"/>. </summary>
        internal PageSizeFloatModelListResult()
        {
            Value = new ChangeTrackingList<PageSizeFloatModelData>();
        }

        /// <summary> Initializes a new instance of <see cref="PageSizeFloatModelListResult"/>. </summary>
        /// <param name="value"></param>
        /// <param name="nextLink"></param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal PageSizeFloatModelListResult(IReadOnlyList<PageSizeFloatModelData> value, string nextLink, Dictionary<string, BinaryData> rawData)
        {
            Value = value;
            NextLink = nextLink;
            _rawData = rawData;
        }

        /// <summary> Gets the value. </summary>
        public IReadOnlyList<PageSizeFloatModelData> Value { get; }
        /// <summary> Gets the next link. </summary>
        public string NextLink { get; }
    }
}
