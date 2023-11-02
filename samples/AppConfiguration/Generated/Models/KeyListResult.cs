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
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="KeyListResult"/>. </summary>
        internal KeyListResult()
        {
            Items = new ChangeTrackingList<Key>();
        }

        /// <summary> Initializes a new instance of <see cref="KeyListResult"/>. </summary>
        /// <param name="items"> The collection value. </param>
        /// <param name="nextLink"> The URI that can be used to request the next set of paged results. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal KeyListResult(IReadOnlyList<Key> items, string nextLink, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Items = items;
            NextLink = nextLink;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> The collection value. </summary>
        public IReadOnlyList<Key> Items { get; }
        /// <summary> The URI that can be used to request the next set of paged results. </summary>
        public string NextLink { get; }
    }
}
