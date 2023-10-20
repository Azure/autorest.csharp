// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace ModelShapes.Models
{
    /// <summary> The ErrorModel. </summary>
    internal partial class ErrorModel
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of ErrorModel. </summary>
        internal ErrorModel()
        {
        }

        /// <summary> Initializes a new instance of ErrorModel. </summary>
        /// <param name="code"></param>
        /// <param name="status"></param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal ErrorModel(string code, string status, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Code = code;
            Status = status;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Gets the code. </summary>
        public string Code { get; }
        /// <summary> Gets the status. </summary>
        public string Status { get; }
    }
}
