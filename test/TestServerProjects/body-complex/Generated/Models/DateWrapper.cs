// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace body_complex.Models
{
    /// <summary> The DateWrapper. </summary>
    public partial class DateWrapper
    {
        /// <summary> Initializes a new instance of DateWrapper. </summary>
        public DateWrapper()
        {
        }

        /// <summary> Initializes a new instance of DateWrapper. </summary>
        /// <param name="field"></param>
        /// <param name="leap"></param>
        internal DateWrapper(DateTimeOffset? field, DateTimeOffset? leap)
        {
            Field = field;
            Leap = leap;
        }

        /// <summary> Gets or sets the field. </summary>
        public DateTimeOffset? Field { get; set; }
        /// <summary> Gets or sets the leap. </summary>
        public DateTimeOffset? Leap { get; set; }
    }
}
