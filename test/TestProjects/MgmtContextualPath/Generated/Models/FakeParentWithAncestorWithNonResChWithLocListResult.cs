// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;

namespace MgmtContextualPath.Models
{
    /// <summary> The List operation response. </summary>
    internal partial class FakeParentWithAncestorWithNonResChWithLocListResult
    {
        /// <summary> Initializes a new instance of FakeParentWithAncestorWithNonResChWithLocListResult. </summary>
        /// <param name="value"> List. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        internal FakeParentWithAncestorWithNonResChWithLocListResult(IEnumerable<FakeParentWithAncestorWithNonResChWithLoc> value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            Value = value.ToList();
        }

        /// <summary> List. </summary>
        public IReadOnlyList<FakeParentWithAncestorWithNonResChWithLoc> Value { get; }
        /// <summary> The URI to fetch the next page. Call ListNext() with this URI to fetch the next page. </summary>
        public string NextLink { get; }
    }
}
