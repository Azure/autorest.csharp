// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace MgmtRenameRules.Models
{
    /// <summary>
    /// Api error.
    /// Serialized Name: ApiError
    /// </summary>
    public partial class ApiError
    {
        /// <summary> Initializes a new instance of ApiError. </summary>
        internal ApiError()
        {
            Details = new ChangeTrackingList<ApiErrorBase>();
        }

        /// <summary> Initializes a new instance of ApiError. </summary>
        /// <param name="details">
        /// The Api error details
        /// Serialized Name: ApiError.details
        /// </param>
        /// <param name="innererror">
        /// The Api inner error
        /// Serialized Name: ApiError.innererror
        /// </param>
        /// <param name="code">
        /// The error code.
        /// Serialized Name: ApiError.code
        /// </param>
        /// <param name="target">
        /// The target of the particular error.
        /// Serialized Name: ApiError.target
        /// </param>
        /// <param name="message">
        /// The error message.
        /// Serialized Name: ApiError.message
        /// </param>
        internal ApiError(IReadOnlyList<ApiErrorBase> details, InnerError innererror, string code, string target, string message)
        {
            Details = details;
            Innererror = innererror;
            Code = code;
            Target = target;
            Message = message;
        }

        /// <summary>
        /// The Api error details
        /// Serialized Name: ApiError.details
        /// </summary>
        public IReadOnlyList<ApiErrorBase> Details { get; }
        /// <summary>
        /// The Api inner error
        /// Serialized Name: ApiError.innererror
        /// </summary>
        public InnerError Innererror { get; }
        /// <summary>
        /// The error code.
        /// Serialized Name: ApiError.code
        /// </summary>
        public string Code { get; }
        /// <summary>
        /// The target of the particular error.
        /// Serialized Name: ApiError.target
        /// </summary>
        public string Target { get; }
        /// <summary>
        /// The error message.
        /// Serialized Name: ApiError.message
        /// </summary>
        public string Message { get; }
    }
}
