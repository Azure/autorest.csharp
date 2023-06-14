// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
        /// <summary> Initializes a new instance of SharedGalleryImageList. </summary>
        /// <param name="value"> A list of shared gallery images. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        internal SharedGalleryImageList(IEnumerable<SharedGalleryImage> value)
        {
            Argument.AssertNotNull(value, nameof(value));

            Value = value.ToList();
        }

        /// <summary> Initializes a new instance of SharedGalleryImageList. </summary>
        /// <param name="value"> A list of shared gallery images. </param>
        /// <param name="nextLink"> The uri to fetch the next page of shared gallery images. Call ListNext() with this to fetch the next page of shared gallery images. </param>
        internal SharedGalleryImageList(IReadOnlyList<SharedGalleryImage> value, string nextLink)
        {
            Value = value;
            NextLink = nextLink;
        }

        /// <summary> A list of shared gallery images. </summary>
        public IReadOnlyList<SharedGalleryImage> Value { get; }
        /// <summary> The uri to fetch the next page of shared gallery images. Call ListNext() with this to fetch the next page of shared gallery images. </summary>
        public string NextLink { get; }
    }
}
