// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.Language.Authoring.Models
{
    /// <summary> Represents a warning that was encountered while executing the request. </summary>
    public partial class JobWarning
    {
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

        /// <summary> The warning code. </summary>
        public string Code { get; }
        /// <summary> The warning message. </summary>
        public string Message { get; }
    }
}
