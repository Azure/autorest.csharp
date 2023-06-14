// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace body_complex.Models
{
    /// <summary> The DatetimeWrapper. </summary>
    public partial class DatetimeWrapper
    {
        /// <summary> Initializes a new instance of DatetimeWrapper. </summary>
        public DatetimeWrapper()
        {
        }

        /// <summary> Initializes a new instance of DatetimeWrapper. </summary>
        /// <param name="field"></param>
        /// <param name="now"></param>
        internal DatetimeWrapper(DateTimeOffset? field, DateTimeOffset? now)
        {
            Field = field;
            Now = now;
        }

        /// <summary> Gets or sets the field. </summary>
        public DateTimeOffset? Field { get; set; }
        /// <summary> Gets or sets the now. </summary>
        public DateTimeOffset? Now { get; set; }
    }
}
