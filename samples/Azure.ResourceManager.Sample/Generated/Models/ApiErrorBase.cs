// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary>
    /// Api error base.
    /// Serialized Name: ApiErrorBase
    /// </summary>
    public partial class ApiErrorBase
    {
        /// <summary> Initializes a new instance of ApiErrorBase. </summary>
        internal ApiErrorBase()
        {
        }

        /// <summary> Initializes a new instance of ApiErrorBase. </summary>
        /// <param name="code">
        /// The error code.
        /// Serialized Name: ApiErrorBase.code
        /// </param>
        /// <param name="target">
        /// The target of the particular error.
        /// Serialized Name: ApiErrorBase.target
        /// </param>
        /// <param name="message">
        /// The error message.
        /// Serialized Name: ApiErrorBase.message
        /// </param>
        internal ApiErrorBase(string code, string target, string message)
        {
            Code = code;
            Target = target;
            Message = message;
        }

        /// <summary>
        /// The error code.
        /// Serialized Name: ApiErrorBase.code
        /// </summary>
        public string Code { get; }
        /// <summary>
        /// The target of the particular error.
        /// Serialized Name: ApiErrorBase.target
        /// </summary>
        public string Target { get; }
        /// <summary>
        /// The error message.
        /// Serialized Name: ApiErrorBase.message
        /// </summary>
        public string Message { get; }
    }
}
