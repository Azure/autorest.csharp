// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace AppConfiguration.Models
{
    /// <summary> The result of a list request. </summary>
    internal partial class KeyListResult
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary>
        /// Initializes a new instance of global::AppConfiguration.Models.KeyListResult
        ///
        /// </summary>
        internal KeyListResult()
        {
            Items = new ChangeTrackingList<Key>();
        }

        /// <summary>
        /// Initializes a new instance of global::AppConfiguration.Models.KeyListResult
        ///
        /// </summary>
        /// <param name="items"> The collection value. </param>
        /// <param name="nextLink"> The URI that can be used to request the next set of paged results. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal KeyListResult(IReadOnlyList<Key> items, string nextLink, Dictionary<string, BinaryData> rawData)
        {
            Items = items;
            NextLink = nextLink;
            _rawData = rawData;
        }

        /// <summary> The collection value. </summary>
        public IReadOnlyList<Key> Items { get; }
        /// <summary> The URI that can be used to request the next set of paged results. </summary>
        public string NextLink { get; }
    }
}
