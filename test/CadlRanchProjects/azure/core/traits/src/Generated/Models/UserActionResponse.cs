// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace _Specs_.Azure.Core.Traits.Models
{
    /// <summary> User action response. </summary>
    public partial class UserActionResponse
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of UserActionResponse. </summary>
        /// <param name="userActionResult"> User action result. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="userActionResult"/> is null. </exception>
        internal UserActionResponse(string userActionResult)
        {
            Argument.AssertNotNull(userActionResult, nameof(userActionResult));

            UserActionResult = userActionResult;
        }

        /// <summary> Initializes a new instance of UserActionResponse. </summary>
        /// <param name="userActionResult"> User action result. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal UserActionResponse(string userActionResult, Dictionary<string, BinaryData> rawData)
        {
            UserActionResult = userActionResult;
            _rawData = rawData;
        }

        /// <summary> Initializes a new instance of <see cref="UserActionResponse"/> for deserialization. </summary>
        internal UserActionResponse()
        {
        }

        /// <summary> User action result. </summary>
        public string UserActionResult { get; }
    }
}
