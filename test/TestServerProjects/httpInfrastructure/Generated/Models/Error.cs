// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace httpInfrastructure.Models
{
    /// <summary> The Error. </summary>
    internal partial class Error
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="Error"/>. </summary>
        internal Error()
        {
        }

        /// <summary> Initializes a new instance of <see cref="Error"/>. </summary>
        /// <param name="status"></param>
        /// <param name="message"></param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal Error(int? status, string message, Dictionary<string, BinaryData> rawData)
        {
            Status = status;
            Message = message;
            _rawData = rawData;
        }

        /// <summary> Gets the status. </summary>
        public int? Status { get; }
        /// <summary> Gets the message. </summary>
        public string Message { get; }
    }
}
