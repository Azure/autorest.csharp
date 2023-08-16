// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.Sample;

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary>
    /// The List Image operation response.
    /// Serialized Name: ImageListResult
    /// </summary>
    internal partial class ImageListResult
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary>
        /// Initializes a new instance of global::Azure.ResourceManager.Sample.Models.ImageListResult
        ///
        /// </summary>
        /// <param name="images">
        /// The list of Images.
        /// Serialized Name: ImageListResult.value
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="images"/> is null. </exception>
        internal ImageListResult(IEnumerable<ImageData> images)
        {
            Argument.AssertNotNull(images, nameof(images));

            Images = images.ToList();
        }

        /// <summary>
        /// Initializes a new instance of global::Azure.ResourceManager.Sample.Models.ImageListResult
        ///
        /// </summary>
        /// <param name="images">
        /// The list of Images.
        /// Serialized Name: ImageListResult.value
        /// </param>
        /// <param name="nextLink">
        /// The uri to fetch the next page of Images. Call ListNext() with this to fetch the next page of Images.
        /// Serialized Name: ImageListResult.nextLink
        /// </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal ImageListResult(IReadOnlyList<ImageData> images, string nextLink, Dictionary<string, BinaryData> rawData)
        {
            Images = images;
            NextLink = nextLink;
            _rawData = rawData;
        }

        /// <summary>
        /// The list of Images.
        /// Serialized Name: ImageListResult.value
        /// </summary>
        public IReadOnlyList<ImageData> Images { get; }
        /// <summary>
        /// The uri to fetch the next page of Images. Call ListNext() with this to fetch the next page of Images.
        /// Serialized Name: ImageListResult.nextLink
        /// </summary>
        public string NextLink { get; }
    }
}
