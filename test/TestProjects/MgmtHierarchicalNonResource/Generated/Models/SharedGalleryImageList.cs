// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace MgmtHierarchicalNonResource.Models
{
    /// <summary> The List Shared Gallery Images operation response. </summary>
    internal partial class SharedGalleryImageList
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="SharedGalleryImageList"/>. </summary>
        /// <param name="value"> A list of shared gallery images. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        internal SharedGalleryImageList(IEnumerable<SharedGalleryImage> value)
        {
            Argument.AssertNotNull(value, nameof(value));

            Value = value.ToList();
        }

        /// <summary> Initializes a new instance of <see cref="SharedGalleryImageList"/>. </summary>
        /// <param name="value"> A list of shared gallery images. </param>
        /// <param name="nextLink"> The uri to fetch the next page of shared gallery images. Call ListNext() with this to fetch the next page of shared gallery images. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal SharedGalleryImageList(IReadOnlyList<SharedGalleryImage> value, string nextLink, Dictionary<string, BinaryData> rawData)
        {
            Value = value;
            NextLink = nextLink;
            _rawData = rawData;
        }

        /// <summary> Initializes a new instance of <see cref="SharedGalleryImageList"/> for deserialization. </summary>
        internal SharedGalleryImageList()
        {
        }

        /// <summary> A list of shared gallery images. </summary>
        public IReadOnlyList<SharedGalleryImage> Value { get; }
        /// <summary> The uri to fetch the next page of shared gallery images. Call ListNext() with this to fetch the next page of shared gallery images. </summary>
        public string NextLink { get; }
    }
}
