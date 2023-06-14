// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace LroBasicTypeSpec.Models
{
    /// <summary> The Thing. </summary>
    public partial class Thing
    {
        /// <summary> Initializes a new instance of Thing. </summary>
        /// <param name="name"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public Thing(string name)
        {
            Argument.AssertNotNull(name, nameof(name));

            Name = name;
        }

        /// <summary> Gets or sets the name. </summary>
        public string Name { get; set; }
    }
}
