// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Parameters.Spread.Models
{
    /// <summary> This is a simple model. </summary>
    public partial class BodyParameter
    {
        /// <summary> Initializes a new instance of BodyParameter. </summary>
        /// <param name="name"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public BodyParameter(string name)
        {
            Argument.AssertNotNull(name, nameof(name));

            Name = name;
        }

        /// <summary> Gets the name. </summary>
        public string Name { get; }
    }
}
