// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary> The ErrorInformation. </summary>
    public partial class ErrorInformation
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary>
        /// Initializes a new instance of global::Azure.AI.FormRecognizer.Models.ErrorInformation
        ///
        /// </summary>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="code"/> or <paramref name="message"/> is null. </exception>
        internal ErrorInformation(string code, string message)
        {
            Argument.AssertNotNull(code, nameof(code));
            Argument.AssertNotNull(message, nameof(message));

            Code = code;
            Message = message;
        }

        /// <summary>
        /// Initializes a new instance of global::Azure.AI.FormRecognizer.Models.ErrorInformation
        ///
        /// </summary>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal ErrorInformation(string code, string message, Dictionary<string, BinaryData> rawData)
        {
            Code = code;
            Message = message;
            _rawData = rawData;
        }

        /// <summary> Gets the code. </summary>
        public string Code { get; }
        /// <summary> Gets the message. </summary>
        public string Message { get; }
    }
}
