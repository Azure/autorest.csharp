// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace MgmtNonStringPathVariable.Models
{
    /// <summary> Specifies information about the fake that the virtual machine should be assigned to. Only tags may be updated. </summary>
    public partial class BarPatch : UpdateResource
    {
        /// <summary> Initializes a new instance of BarPatch. </summary>
        public BarPatch()
        {
        }

        /// <summary> Update Domain count. </summary>
        public Guid? Buzz { get; set; }
    }
}
