// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace _Specs_.Azure.Core.Traits.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class SpecsAzureCoreTraitsModelFactory
    {
        /// <summary> Initializes a new instance of User. </summary>
        /// <param name="id"> The user's id. </param>
        /// <param name="name"> The user's name. </param>
        /// <returns> A new <see cref="Models.User"/> instance for mocking. </returns>
        public static User User(int id = default, string name = null)
        {
            return new User(id, name);
        }

        /// <summary> Initializes a new instance of UserActionResponse. </summary>
        /// <param name="userActionResult"> User action result. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="userActionResult"/> is null. </exception>
        /// <returns> A new <see cref="Models.UserActionResponse"/> instance for mocking. </returns>
        public static UserActionResponse UserActionResponse(string userActionResult = null)
        {
            if (userActionResult == null)
            {
                throw new ArgumentNullException(nameof(userActionResult));
            }

            return new UserActionResponse(userActionResult);
        }
    }
}
