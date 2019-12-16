// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace body_complex.Models.V20160229
{
    public partial class Shark : Fish
    {
        public Shark()
        {
            Fishtype = "shark";
        }
        public int? Age { get; set; }
        public DateTimeOffset Birthday { get; set; }
    }
}
