// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace body_complex.Models.V20160229
{
    public partial class Cat : Pet
    {
        public string? Color { get; set; }
        public ICollection<Dog>? Hates { get; set; }
    }
}
