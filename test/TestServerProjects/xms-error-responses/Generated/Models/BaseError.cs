// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace xms_error_responses.Models
{
    /// <summary> The BaseError. </summary>
    internal partial class BaseError
    {
        protected internal Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="BaseError"/>. </summary>
        internal BaseError()
        {
        }

        /// <summary> Initializes a new instance of <see cref="BaseError"/>. </summary>
        /// <param name="someBaseProp"></param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal BaseError(string someBaseProp, Dictionary<string, BinaryData> rawData)
        {
            SomeBaseProp = someBaseProp;
            _rawData = rawData;
        }

        /// <summary> Gets the some base prop. </summary>
        public string SomeBaseProp { get; }
    }
}
