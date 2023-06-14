// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary> The ErrorResponse. </summary>
    internal partial class ErrorResponse
    {
        /// <summary> Initializes a new instance of ErrorResponse. </summary>
        /// <param name="error"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="error"/> is null. </exception>
        internal ErrorResponse(ErrorInformation error)
        {
            Argument.AssertNotNull(error, nameof(error));

            Error = error;
        }

        /// <summary> Gets the error. </summary>
        public ErrorInformation Error { get; }
    }
}
