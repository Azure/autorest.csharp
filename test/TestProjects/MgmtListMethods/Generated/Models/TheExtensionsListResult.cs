// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;

namespace MgmtListMethods.Models
{
    /// <summary> The List Availability Set Child operation response. </summary>
    internal partial class TheExtensionsListResult
    {
        /// <summary> Initializes a new instance of TheExtensionsListResult. </summary>
        /// <param name="value"> The list of fakes child. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        internal TheExtensionsListResult(IEnumerable<TheExtensionData> value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            Value = value.ToList();
        }

        /// <summary> Initializes a new instance of TheExtensionsListResult. </summary>
        /// <param name="value"> The list of fakes child. </param>
        /// <param name="nextLink"> The URI to fetch the next page of FakeBar. Call ListNext() with this URI to fetch the next page of FakeBars. </param>
        internal TheExtensionsListResult(IReadOnlyList<TheExtensionData> value, string nextLink)
        {
            Value = value;
            NextLink = nextLink;
        }

        /// <summary> The list of fakes child. </summary>
        public IReadOnlyList<TheExtensionData> Value { get; }
        /// <summary> The URI to fetch the next page of FakeBar. Call ListNext() with this URI to fetch the next page of FakeBars. </summary>
        public string NextLink { get; }
    }
}
