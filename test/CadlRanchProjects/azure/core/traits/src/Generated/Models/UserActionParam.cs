// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace _Specs_.Azure.Core.Traits.Models
{
    /// <summary> User action param. </summary>
    public partial class UserActionParam
    {
        /// <summary> Initializes a new instance of UserActionParam. </summary>
        /// <param name="userActionValue"> User action value. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="userActionValue"/> is null. </exception>
        public UserActionParam(string userActionValue)
        {
            Argument.AssertNotNull(userActionValue, nameof(userActionValue));

            UserActionValue = userActionValue;
        }

        /// <summary> User action value. </summary>
        public string UserActionValue { get; }
    }
}
