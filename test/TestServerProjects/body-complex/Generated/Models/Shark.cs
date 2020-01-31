// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace body_complex.Models
{
    /// <summary> The shark. </summary>
    public partial class Shark : Fish
    {
        /// <summary> Initializes a new instance of Shark. </summary>
        public Shark()
        {
            Fishtype = "shark";
        }
        public int? Age { get; set; }
        public DateTimeOffset Birthday { get; set; }
    }
}
