// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace model_flattening.Models
{
    /// <summary> The Generic URL. </summary>
    public partial class GenericUrl
    {
        /// <summary> Initializes a new instance of GenericUrl. </summary>
        internal GenericUrl()
        {
        }

        /// <summary> Initializes a new instance of GenericUrl. </summary>
        /// <param name="genericValue"> Generic URL value. </param>
        internal GenericUrl(string genericValue)
        {
            GenericValue = genericValue;
        }

        /// <summary> Generic URL value. </summary>
        public string GenericValue { get; set; }
    }
}
