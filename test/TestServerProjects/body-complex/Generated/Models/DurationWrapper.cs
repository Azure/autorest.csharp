// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace body_complex.Models
{
    /// <summary> The DurationWrapper. </summary>
    public partial class DurationWrapper
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="DurationWrapper"/>. </summary>
        public DurationWrapper()
        {
        }

        /// <summary> Initializes a new instance of <see cref="DurationWrapper"/>. </summary>
        /// <param name="field"></param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal DurationWrapper(TimeSpan? field, Dictionary<string, BinaryData> rawData)
        {
            Field = field;
            _rawData = rawData;
        }

        /// <summary> Gets or sets the field. </summary>
        public TimeSpan? Field { get; set; }
    }
}
