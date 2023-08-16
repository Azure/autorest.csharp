// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace lro.Models
{
    /// <summary> The OperationResult. </summary>
    internal partial class OperationResult
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary>
        /// Initializes a new instance of global::lro.Models.OperationResult
        ///
        /// </summary>
        internal OperationResult()
        {
        }

        /// <summary>
        /// Initializes a new instance of global::lro.Models.OperationResult
        ///
        /// </summary>
        /// <param name="status"> The status of the request. </param>
        /// <param name="error"></param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal OperationResult(OperationResultStatus? status, OperationResultError error, Dictionary<string, BinaryData> rawData)
        {
            Status = status;
            Error = error;
            _rawData = rawData;
        }

        /// <summary> The status of the request. </summary>
        public OperationResultStatus? Status { get; }
        /// <summary> Gets the error. </summary>
        public OperationResultError Error { get; }
    }
}
