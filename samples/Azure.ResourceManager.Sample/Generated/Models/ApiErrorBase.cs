// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary>
    /// Api error base.
    /// Serialized Name: ApiErrorBase
    /// </summary>
    public partial class ApiErrorBase
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary>
        /// Initializes a new instance of global::Azure.ResourceManager.Sample.Models.ApiErrorBase
        ///
        /// </summary>
        internal ApiErrorBase()
        {
        }

        /// <summary>
        /// Initializes a new instance of global::Azure.ResourceManager.Sample.Models.ApiErrorBase
        ///
        /// </summary>
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
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal ApiErrorBase(string code, string target, string message, Dictionary<string, BinaryData> rawData)
        {
            Code = code;
            Target = target;
            Message = message;
            _rawData = rawData;
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
