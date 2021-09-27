// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

namespace Azure.Core
{
    internal static class ResponseWithError
    {
        /// <summary>
        /// Creates a new instance of <see cref="ErrorResponse{T}"/> with the provided HTTP response and <see cref="RequestFailedException"/> exception.
        /// </summary>
        /// <param name="response">The HTTP response.</param>
        /// <param name="exception"><see cref="RequestFailedException"/> exception.</param>
        public static ErrorResponse<T> FromError<T>(Response response, RequestFailedException exception)
        {
            return new ErrorResponse<T>(response, exception);
        }
    }
}
