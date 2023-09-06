// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace lro.Models
{
    /// <summary> The CloudError. </summary>
    internal partial class CloudError
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="CloudError"/>. </summary>
        internal CloudError()
        {
        }

        /// <summary> Initializes a new instance of <see cref="CloudError"/>. </summary>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal CloudError(int? code, string message, Dictionary<string, BinaryData> rawData)
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
