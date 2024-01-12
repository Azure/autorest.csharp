// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace xms_error_responses.Models
{
    /// <summary> The UnknownNotFoundErrorBase. </summary>
    internal partial class UnknownNotFoundErrorBase : NotFoundErrorBase
    {
        /// <summary> Initializes a new instance of <see cref="UnknownNotFoundErrorBase"/>. </summary>
        /// <param name="someBaseProp"></param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        /// <param name="reason"></param>
        /// <param name="whatNotFound"></param>
        internal UnknownNotFoundErrorBase(string someBaseProp, IDictionary<string, BinaryData> serializedAdditionalRawData, string reason, string whatNotFound) : base(someBaseProp, serializedAdditionalRawData, reason, whatNotFound)
        {
            WhatNotFound = whatNotFound ?? "Unknown";
        }

        /// <summary> Initializes a new instance of <see cref="UnknownNotFoundErrorBase"/> for deserialization. </summary>
        internal UnknownNotFoundErrorBase()
        {
        }
    }
}
