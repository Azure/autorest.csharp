// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core;

namespace _Specs_.Azure.ClientGenerator.Core.Internal.Models
{
    /// <summary> This is a non-internal model only used by internal operation. </summary>
    internal partial class ModelOnlyUsedByInternalOperation
    {
        /// <summary> Initializes a new instance of ModelOnlyUsedByInternalOperation. </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> or <paramref name="name"/> is null. </exception>
        public ModelOnlyUsedByInternalOperation(string id, string name)
        {
            Argument.AssertNotNull(id, nameof(id));
            Argument.AssertNotNull(name, nameof(name));

            Id = id;
            Name = name;
        }

        /// <summary> Gets or sets the id. </summary>
        public string Id { get; set; }
        /// <summary> Gets or sets the name. </summary>
        public string Name { get; set; }
    }
}
