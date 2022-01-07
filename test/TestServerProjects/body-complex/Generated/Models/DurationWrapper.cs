// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

namespace Body_Complex.Models
{
    /// <summary> The DurationWrapper. </summary>
    public partial class DurationWrapper
    {
        /// <summary> Initializes a new instance of DurationWrapper. </summary>
        public DurationWrapper()
        {
        }

        /// <summary> Initializes a new instance of DurationWrapper. </summary>
        /// <param name="field"></param>
        internal DurationWrapper(TimeSpan? field)
        {
            Field = field;
        }

        /// <summary> Gets or sets the field. </summary>
        public TimeSpan? Field { get; set; }
    }
}
