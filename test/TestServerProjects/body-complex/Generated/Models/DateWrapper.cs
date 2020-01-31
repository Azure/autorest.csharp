// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace body_complex.Models
{
    /// <summary> The date-wrapper. </summary>
    public partial class DateWrapper
    {
        public DateTimeOffset? Field { get; set; }
        public DateTimeOffset? Leap { get; set; }
    }
}
