// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace model_flattening.Models
{
    /// <summary> The Generic URL. </summary>
    internal partial class GenericUrl
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        protected internal Dictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="GenericUrl"/>. </summary>
        internal GenericUrl()
        {
        }

        /// <summary> Initializes a new instance of <see cref="GenericUrl"/>. </summary>
        /// <param name="genericValue"> Generic URL value. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal GenericUrl(string genericValue, Dictionary<string, BinaryData> serializedAdditionalRawData)
        {
            GenericValue = genericValue;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Generic URL value. </summary>
        public string GenericValue { get; }
    }
}
