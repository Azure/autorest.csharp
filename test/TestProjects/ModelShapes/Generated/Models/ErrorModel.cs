// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace ModelShapes.Models
{
    /// <summary> The ErrorModel. </summary>
    internal partial class ErrorModel
    {
        /// <summary> Initializes a new instance of ErrorModel. </summary>
        internal ErrorModel()
        {
        }

        /// <summary> Initializes a new instance of ErrorModel. </summary>
        /// <param name="code"> The Code. </param>
        /// <param name="status"> The Status. </param>
        internal ErrorModel(string code, string status)
        {
            Code = code;
            Status = status;
        }

        /// <summary> The Code. </summary>
        public string Code { get; }
        /// <summary> The Status. </summary>
        public string Status { get; }
    }
}
