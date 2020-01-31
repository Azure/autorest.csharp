// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace body_complex.Models
{
    /// <summary> The sawshark. </summary>
    public partial class Sawshark : Shark
    {
        /// <summary> Initializes a new instance of Sawshark. </summary>
        public Sawshark()
        {
            Fishtype = "sawshark";
        }
        public byte[] Picture { get; set; }
    }
}
