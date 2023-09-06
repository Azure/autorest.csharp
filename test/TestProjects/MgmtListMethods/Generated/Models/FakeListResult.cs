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
    /// <summary> The List Availability Set operation response. </summary>
    internal partial class FakeListResult
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="FakeListResult"/>. </summary>
        /// <param name="value"> The list of fakes. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        internal FakeListResult(IEnumerable<FakeData> value)
        {
            Argument.AssertNotNull(value, nameof(value));

            Value = value.ToList();
        }

        /// <summary> Initializes a new instance of <see cref="FakeListResult"/>. </summary>
        /// <param name="value"> The list of fakes. </param>
        /// <param name="nextLink"> The URI to fetch the next page of Fakes. Call ListNext() with this URI to fetch the next page of Fakes. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal FakeListResult(IReadOnlyList<FakeData> value, string nextLink, Dictionary<string, BinaryData> rawData)
        {
            Value = value;
            NextLink = nextLink;
            _rawData = rawData;
        }

        /// <summary> Initializes a new instance of <see cref="FakeListResult"/> for deserialization. </summary>
        internal FakeListResult()
        {
        }

        /// <summary> The list of fakes. </summary>
        public IReadOnlyList<FakeData> Value { get; }
        /// <summary> The URI to fetch the next page of Fakes. Call ListNext() with this URI to fetch the next page of Fakes. </summary>
        public string NextLink { get; }
    }
}
