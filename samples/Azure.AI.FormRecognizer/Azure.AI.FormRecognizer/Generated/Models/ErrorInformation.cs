// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary> The ErrorInformation. </summary>
    public partial class ErrorInformation
    {
        /// <summary> Initializes a new instance of ErrorInformation. </summary>
        internal ErrorInformation()
        {
        }

        /// <summary> Initializes a new instance of ErrorInformation. </summary>
        /// <param name="code"> . </param>
        /// <param name="message"> . </param>
        internal ErrorInformation(string code, string message)
        {
            Code = code;
            Message = message;
        }

        public string Code { get; internal set; }
        public string Message { get; internal set; }
    }
}
