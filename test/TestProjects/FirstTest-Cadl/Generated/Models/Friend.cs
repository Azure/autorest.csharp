// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core;

namespace CadlFirstTest.Models
{
    /// <summary> The Friend. </summary>
    public partial class Friend
    {
        /// <summary> Initializes a new instance of Friend. </summary>
        /// <param name="actualName"> name of the NotFriend. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="actualName"/> is null. </exception>
        public Friend(string actualName)
        {
            Argument.AssertNotNull(actualName, nameof(actualName));

            ActualName = actualName;
        }

        /// <summary> name of the NotFriend. </summary>
        public string ActualName { get; set; }
    }
}
