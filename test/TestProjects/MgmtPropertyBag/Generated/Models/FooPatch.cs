// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtPropertyBag.Models
{
    /// <summary> Foo instance details. </summary>
    public partial class FooPatch
    {
        /// <summary> Initializes a new instance of FooPatch. </summary>
        public FooPatch()
        {
        }

        /// <summary> The details of the resource. </summary>
        public string Details { get; set; }
    }
}
