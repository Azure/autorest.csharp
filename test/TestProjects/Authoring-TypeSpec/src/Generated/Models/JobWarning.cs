// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace AuthoringTypeSpec.Models
{
    /// <summary> Represents a warning that was encountered while executing the request. </summary>
    public partial class JobWarning
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of JobWarning. </summary>
        /// <param name="code"> The warning code. </param>
        /// <param name="message"> The warning message. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="code"/> or <paramref name="message"/> is null. </exception>
        internal JobWarning(string code, string message)
        {
            Argument.AssertNotNull(code, nameof(code));
            Argument.AssertNotNull(message, nameof(message));

            Code = code;
            Message = message;
        }

        /// <summary> Initializes a new instance of JobWarning. </summary>
        /// <param name="code"> The warning code. </param>
        /// <param name="message"> The warning message. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal JobWarning(string code, string message, Dictionary<string, BinaryData> rawData)
        {
            Code = code;
            Message = message;
            _rawData = rawData;
        }

        /// <summary> Initializes a new instance of <see cref="JobWarning"/> for deserialization. </summary>
        internal JobWarning()
        {
        }

        /// <summary> The warning code. </summary>
        public string Code { get; }
        /// <summary> The warning message. </summary>
        public string Message { get; }
    }
}
