// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace CognitiveSearch.Models
{
    /// <summary> Removes words that are too long or too short. This token filter is implemented using Apache Lucene. </summary>
    public partial class LengthTokenFilter : TokenFilter
    {
        /// <summary> Initializes a new instance of LengthTokenFilter. </summary>
        /// <param name="name"> The name of the token filter. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public LengthTokenFilter(string name) : base(name)
        {
            Argument.AssertNotNull(name, nameof(name));

            OdataType = "#Microsoft.Azure.Search.LengthTokenFilter";
        }

        /// <summary> Initializes a new instance of LengthTokenFilter. </summary>
        /// <param name="odataType"> Identifies the concrete type of the token filter. </param>
        /// <param name="name"> The name of the token filter. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </param>
        /// <param name="min"> The minimum length in characters. Default is 0. Maximum is 300. Must be less than the value of max. </param>
        /// <param name="max"> The maximum length in characters. Default and maximum is 300. </param>
        internal LengthTokenFilter(string odataType, string name, int? min, int? max) : base(odataType, name)
        {
            Min = min;
            Max = max;
            OdataType = odataType ?? "#Microsoft.Azure.Search.LengthTokenFilter";
        }

        /// <summary> The minimum length in characters. Default is 0. Maximum is 300. Must be less than the value of max. </summary>
        public int? Min { get; set; }
        /// <summary> The maximum length in characters. Default and maximum is 300. </summary>
        public int? Max { get; set; }
    }
}
