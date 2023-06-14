// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Authentication.OAuth2.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class AuthenticationOAuth2ModelFactory
    {
        /// <summary> Initializes a new instance of InvalidAuth. </summary>
        /// <param name="error"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="error"/> is null. </exception>
        /// <returns> A new <see cref="Models.InvalidAuth"/> instance for mocking. </returns>
        public static InvalidAuth InvalidAuth(string error = null)
        {
            if (error == null)
            {
                throw new ArgumentNullException(nameof(error));
            }

            return new InvalidAuth(error);
        }
    }
}
