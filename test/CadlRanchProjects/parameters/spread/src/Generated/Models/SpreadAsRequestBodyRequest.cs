// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core;

namespace Parameters.Spread.Models
{
    /// <summary> The SpreadAsRequestBodyRequest. </summary>
    internal partial class SpreadAsRequestBodyRequest
    {
        /// <summary> Initializes a new instance of <see cref="SpreadAsRequestBodyRequest"/>. </summary>
        /// <param name="name"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public SpreadAsRequestBodyRequest(string name)
        {
            Argument.AssertNotNull(name, nameof(name));

            Name = name;
        }

        /// <summary> Gets the name. </summary>
        public string Name { get; }
    }
}
