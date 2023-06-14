// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Authentication.ApiKey.Models
{
    /// <summary> The InvalidAuth. </summary>
    public partial class InvalidAuth
    {
        /// <summary> Initializes a new instance of InvalidAuth. </summary>
        /// <param name="error"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="error"/> is null. </exception>
        internal InvalidAuth(string error)
        {
            Argument.AssertNotNull(error, nameof(error));

            Error = error;
        }

        /// <summary> Gets the error. </summary>
        public string Error { get; }
    }
}
