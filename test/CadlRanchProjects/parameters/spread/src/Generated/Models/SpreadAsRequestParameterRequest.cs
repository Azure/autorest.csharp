// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Parameters.Spread.Models
{
    /// <summary> The SpreadAsRequestParameterRequest. </summary>
    internal partial class SpreadAsRequestParameterRequest
    {
        /// <summary> Initializes a new instance of SpreadAsRequestParameterRequest. </summary>
        /// <param name="name"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public SpreadAsRequestParameterRequest(string name)
        {
            Argument.AssertNotNull(name, nameof(name));

            Name = name;
        }

        /// <summary> Gets the name. </summary>
        public string Name { get; }
    }
}
