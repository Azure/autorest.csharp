// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using MgmtAcronymMapping;

namespace MgmtAcronymMapping.Models
{
    /// <summary>
    /// The List Image operation response.
    /// Serialized Name: ImageListResult
    /// </summary>
    internal partial class ImageListResult
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="ImageListResult"/>. </summary>
        /// <param name="value">
        /// The list of Images.
        /// Serialized Name: ImageListResult.value
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        internal ImageListResult(IEnumerable<ImageData> value)
        {
            Argument.AssertNotNull(value, nameof(value));

            Value = value.ToList();
        }

        /// <summary> Initializes a new instance of <see cref="ImageListResult"/>. </summary>
        /// <param name="value">
        /// The list of Images.
        /// Serialized Name: ImageListResult.value
        /// </param>
        /// <param name="nextLink">
        /// The uri to fetch the next page of Images. Call ListNext() with this to fetch the next page of Images.
        /// Serialized Name: ImageListResult.nextLink
        /// </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal ImageListResult(IReadOnlyList<ImageData> value, string nextLink, Dictionary<string, BinaryData> rawData)
        {
            Value = value;
            NextLink = nextLink;
            _rawData = rawData;
        }

        /// <summary> Initializes a new instance of <see cref="ImageListResult"/> for deserialization. </summary>
        internal ImageListResult()
        {
        }

        /// <summary>
        /// The list of Images.
        /// Serialized Name: ImageListResult.value
        /// </summary>
        public IReadOnlyList<ImageData> Value { get; }
        /// <summary>
        /// The uri to fetch the next page of Images. Call ListNext() with this to fetch the next page of Images.
        /// Serialized Name: ImageListResult.nextLink
        /// </summary>
        public string NextLink { get; }
    }
}
