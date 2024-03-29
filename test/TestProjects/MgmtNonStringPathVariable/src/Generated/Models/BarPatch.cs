// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace MgmtNonStringPathVariable.Models
{
    /// <summary> Specifies information about the fake that the virtual machine should be assigned to. Only tags may be updated. </summary>
    public partial class BarPatch : UpdateResource
    {
        /// <summary> Initializes a new instance of <see cref="BarPatch"/>. </summary>
        public BarPatch()
        {
        }

        /// <summary> Initializes a new instance of <see cref="BarPatch"/>. </summary>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="buzz"> Update Domain count. </param>
        internal BarPatch(IDictionary<string, string> tags, Guid? buzz) : base(tags)
        {
            Buzz = buzz;
        }

        /// <summary> Update Domain count. </summary>
        public Guid? Buzz { get; set; }
    }
}
