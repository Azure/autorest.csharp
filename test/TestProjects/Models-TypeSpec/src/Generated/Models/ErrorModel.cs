// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace ModelsTypeSpec.Models
{
    /// <summary> Output model that has property of its own type. </summary>
    public partial class ErrorModel
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of ErrorModel. </summary>
        internal ErrorModel()
        {
        }

        /// <summary> Initializes a new instance of ErrorModel. </summary>
        /// <param name="message"> Error message. </param>
        /// <param name="innerError"> Required Record. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal ErrorModel(string message, ErrorModel innerError, Dictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Message = message;
            InnerError = innerError;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Error message. </summary>
        public string Message { get; }
        /// <summary> Required Record. </summary>
        public ErrorModel InnerError { get; }
    }
}
