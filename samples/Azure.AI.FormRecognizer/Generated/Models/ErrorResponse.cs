// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary> The ErrorResponse. </summary>
    internal partial class ErrorResponse
    {
        /// <summary> Initializes a new instance of ErrorResponse. </summary>
        /// <param name="error"> The Error. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="error"/> is null. </exception>
        internal ErrorResponse(ErrorInformation error)
        {
            if (error == null)
            {
                throw new ArgumentNullException(nameof(error));
            }

            Error = error;
        }

        /// <summary> The Error. </summary>
        public ErrorInformation Error { get; }
    }
}
