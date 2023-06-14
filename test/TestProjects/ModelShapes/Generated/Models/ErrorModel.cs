// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
        /// <param name="code"></param>
        /// <param name="status"></param>
        internal ErrorModel(string code, string status)
        {
            Code = code;
            Status = status;
        }

        /// <summary> Gets the code. </summary>
        public string Code { get; }
        /// <summary> Gets the status. </summary>
        public string Status { get; }
    }
}
