// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace body_complex.Models
{
    /// <summary> The Datetimerfc1123Wrapper. </summary>
    public partial class Datetimerfc1123Wrapper
    {
        /// <summary> Initializes a new instance of Datetimerfc1123Wrapper. </summary>
        public Datetimerfc1123Wrapper()
        {
        }

        /// <summary> Initializes a new instance of Datetimerfc1123Wrapper. </summary>
        /// <param name="field"></param>
        /// <param name="now"></param>
        internal Datetimerfc1123Wrapper(DateTimeOffset? field, DateTimeOffset? now)
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
