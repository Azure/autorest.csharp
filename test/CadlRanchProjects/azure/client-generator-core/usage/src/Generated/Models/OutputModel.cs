// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core;

namespace _Specs_.Azure.ClientGenerator.Core.Usage.Models
{
    /// <summary> Usage override to roundtrip. </summary>
    public partial class OutputModel
    {
        /// <summary> Initializes a new instance of <see cref="OutputModel"/>. </summary>
        /// <param name="name"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public OutputModel(string name)
        {
            Argument.AssertNotNull(name, nameof(name));

            Name = name;
        }

        /// <summary> Gets or sets the name. </summary>
        public string Name { get; set; }
    }
}
