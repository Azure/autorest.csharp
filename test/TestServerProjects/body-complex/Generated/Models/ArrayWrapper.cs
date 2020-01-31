// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace body_complex.Models
{
    /// <summary> The array-wrapper. </summary>
    public partial class ArrayWrapper
    {
        public ICollection<string> Array { get; set; }
    }
}
