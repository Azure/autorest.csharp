// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace _Type.Model.Inheritance.Recursive.Models
{
    /// <summary> element. </summary>
    public partial class Element
    {
        /// <summary> Initializes a new instance of <see cref="Element"/>. </summary>
        internal Element()
        {
            Extension = new ChangeTrackingList<Extension>();
        }

        /// <summary> Initializes a new instance of <see cref="Element"/>. </summary>
        /// <param name="extension"></param>
        internal Element(IReadOnlyList<Extension> extension)
        {
            Extension = extension;
        }

        /// <summary> Gets the extension. </summary>
        public IReadOnlyList<Extension> Extension { get; }
    }
}
