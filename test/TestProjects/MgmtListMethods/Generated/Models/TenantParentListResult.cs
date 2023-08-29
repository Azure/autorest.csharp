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
    internal partial class TenantParentListResult
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary>
        /// Initializes a new instance of global::MgmtListMethods.Models.TenantParentListResult
        ///
        /// </summary>
        /// <param name="value"> The list of fakes. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        internal TenantParentListResult(IEnumerable<TenantParentData> value)
        {
            Argument.AssertNotNull(value, nameof(value));

            Value = value.ToList();
        }

        /// <summary>
        /// Initializes a new instance of global::MgmtListMethods.Models.TenantParentListResult
        ///
        /// </summary>
        /// <param name="value"> The list of fakes. </param>
        /// <param name="nextLink"> The URI to fetch the next page of Fakes. Call ListNext() with this URI to fetch the next page of Fakes. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal TenantParentListResult(IReadOnlyList<TenantParentData> value, string nextLink, Dictionary<string, BinaryData> rawData)
        {
            Value = value;
            NextLink = nextLink;
            _rawData = rawData;
        }

        /// <summary> Initializes a new instance of <see cref="TenantParentListResult"/> for deserialization. </summary>
        internal TenantParentListResult()
        {
        }

        /// <summary> The list of fakes. </summary>
        public IReadOnlyList<TenantParentData> Value { get; }
        /// <summary> The URI to fetch the next page of Fakes. Call ListNext() with this URI to fetch the next page of Fakes. </summary>
        public string NextLink { get; }
    }
}
