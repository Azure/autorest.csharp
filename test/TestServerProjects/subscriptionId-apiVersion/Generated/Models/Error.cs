// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace subscriptionId_apiVersion.Models
{
    /// <summary> The Error. </summary>
    internal partial class Error
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary>
        /// Initializes a new instance of global::subscriptionId_apiVersion.Models.Error
        ///
        /// </summary>
        internal Error()
        {
        }

        /// <summary>
        /// Initializes a new instance of global::subscriptionId_apiVersion.Models.Error
        ///
        /// </summary>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal Error(int? code, string message, Dictionary<string, BinaryData> rawData)
        {
            Code = code;
            Message = message;
            _rawData = rawData;
        }

        /// <summary> Gets the code. </summary>
        public int? Code { get; }
        /// <summary> Gets the message. </summary>
        public string Message { get; }
    }
}
