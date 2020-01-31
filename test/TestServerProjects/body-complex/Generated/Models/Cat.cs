// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace body_complex.Models
{
    /// <summary> The cat. </summary>
    public partial class Cat : Pet
    {
        public string Color { get; set; }
        public ICollection<Dog> Hates { get; set; }
    }
}
