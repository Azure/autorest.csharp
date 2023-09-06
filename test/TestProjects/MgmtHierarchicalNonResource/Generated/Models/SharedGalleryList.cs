// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using MgmtHierarchicalNonResource;

namespace MgmtHierarchicalNonResource.Models
{
    /// <summary> The List Shared Galleries operation response. </summary>
    internal partial class SharedGalleryList
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="SharedGalleryList"/>. </summary>
        /// <param name="value"> A list of shared galleries. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        internal SharedGalleryList(IEnumerable<SharedGalleryData> value)
        {
            Argument.AssertNotNull(value, nameof(value));

            Value = value.ToList();
        }

        /// <summary> Initializes a new instance of <see cref="SharedGalleryList"/>. </summary>
        /// <param name="value"> A list of shared galleries. </param>
        /// <param name="nextLink"> The uri to fetch the next page of shared galleries. Call ListNext() with this to fetch the next page of shared galleries. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal SharedGalleryList(IReadOnlyList<SharedGalleryData> value, string nextLink, Dictionary<string, BinaryData> rawData)
        {
            Value = value;
            NextLink = nextLink;
            _rawData = rawData;
        }

        /// <summary> Initializes a new instance of <see cref="SharedGalleryList"/> for deserialization. </summary>
        internal SharedGalleryList()
        {
        }

        /// <summary> A list of shared galleries. </summary>
        public IReadOnlyList<SharedGalleryData> Value { get; }
        /// <summary> The uri to fetch the next page of shared galleries. Call ListNext() with this to fetch the next page of shared galleries. </summary>
        public string NextLink { get; }
    }
}
