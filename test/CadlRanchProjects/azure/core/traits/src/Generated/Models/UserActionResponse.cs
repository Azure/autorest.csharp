// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace _Specs_.Azure.Core.Traits.Models
{
    /// <summary> User action response. </summary>
    public partial class UserActionResponse
    {
        /// <summary> Initializes a new instance of UserActionResponse. </summary>
        /// <param name="userActionResult"> User action result. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="userActionResult"/> is null. </exception>
        internal UserActionResponse(string userActionResult)
        {
            Argument.AssertNotNull(userActionResult, nameof(userActionResult));

            UserActionResult = userActionResult;
        }

        /// <summary> User action result. </summary>
        public string UserActionResult { get; }
    }
}
