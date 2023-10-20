// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using MgmtListMethods;

namespace MgmtListMethods.Models
{
    /// <summary> The List operation response. </summary>
    internal partial class ResGrpParentWithAncestorWithNonResChWithLocListResult
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="ResGrpParentWithAncestorWithNonResChWithLocListResult"/>. </summary>
        /// <param name="value"> List. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        internal ResGrpParentWithAncestorWithNonResChWithLocListResult(IEnumerable<ResGrpParentWithAncestorWithNonResChWithLocData> value)
        {
            Argument.AssertNotNull(value, nameof(value));

            Value = value.ToList();
        }

        /// <summary> Initializes a new instance of <see cref="ResGrpParentWithAncestorWithNonResChWithLocListResult"/>. </summary>
        /// <param name="value"> List. </param>
        /// <param name="nextLink"> The URI to fetch the next page. Call ListNext() with this URI to fetch the next page. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal ResGrpParentWithAncestorWithNonResChWithLocListResult(IReadOnlyList<ResGrpParentWithAncestorWithNonResChWithLocData> value, string nextLink, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Value = value;
            NextLink = nextLink;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="ResGrpParentWithAncestorWithNonResChWithLocListResult"/> for deserialization. </summary>
        internal ResGrpParentWithAncestorWithNonResChWithLocListResult()
        {
        }

        /// <summary> List. </summary>
        public IReadOnlyList<ResGrpParentWithAncestorWithNonResChWithLocData> Value { get; }
        /// <summary> The URI to fetch the next page. Call ListNext() with this URI to fetch the next page. </summary>
        public string NextLink { get; }
    }
}
