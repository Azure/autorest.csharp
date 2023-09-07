// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace custom_baseUrl.Models
{
    /// <summary> The Error. </summary>
    internal partial class Error
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="Error"/>. </summary>
        internal Error()
        {
        }

        /// <summary> Initializes a new instance of <see cref="Error"/>. </summary>
        /// <param name="status"></param>
        /// <param name="message"></param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal Error(int? status, string message, Dictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Status = status;
            Message = message;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Gets the status. </summary>
        public int? Status { get; }
        /// <summary> Gets the message. </summary>
        public string Message { get; }
    }
}
