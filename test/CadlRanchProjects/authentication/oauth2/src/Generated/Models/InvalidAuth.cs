// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Authentication.OAuth2.Models
{
    /// <summary> The InvalidAuth. </summary>
    public partial class InvalidAuth
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of InvalidAuth. </summary>
        /// <param name="error"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="error"/> is null. </exception>
        internal InvalidAuth(string error)
        {
            Argument.AssertNotNull(error, nameof(error));

            Error = error;
        }

        /// <summary> Initializes a new instance of InvalidAuth. </summary>
        /// <param name="error"></param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal InvalidAuth(string error, Dictionary<string, BinaryData> rawData)
        {
            Error = error;
            _rawData = rawData;
        }

        /// <summary> Initializes a new instance of <see cref="InvalidAuth"/> for deserialization. </summary>
        internal InvalidAuth()
        {
        }

        /// <summary> Gets the error. </summary>
        public string Error { get; }
    }
}
