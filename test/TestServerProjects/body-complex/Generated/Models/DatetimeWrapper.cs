// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace body_complex.Models
{
    /// <summary> The DatetimeWrapper. </summary>
    public partial class DatetimeWrapper
    {
        public DateTimeOffset? Field { get; set; }
        public DateTimeOffset? Now { get; set; }
    }
}
