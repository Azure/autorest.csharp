// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.ResourceManager.Sample;

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary> The List Image operation response. </summary>
    internal partial class ImageListResult
    {
        /// <summary> Initializes a new instance of ImageListResult. </summary>
        /// <param name="value"> The list of Images. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        internal ImageListResult(IEnumerable<ImageData> value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            Value = value.ToList();
        }

        /// <summary> Initializes a new instance of ImageListResult. </summary>
        /// <param name="value"> The list of Images. </param>
        /// <param name="nextLink"> The uri to fetch the next page of Images. Call ListNext() with this to fetch the next page of Images. </param>
        internal ImageListResult(IReadOnlyList<ImageData> value, string nextLink)
        {
            Value = value;
            NextLink = nextLink;
        }

        /// <summary> The list of Images. </summary>
        public IReadOnlyList<ImageData> Value { get; }
        /// <summary> The uri to fetch the next page of Images. Call ListNext() with this to fetch the next page of Images. </summary>
        public string NextLink { get; }
    }
}
