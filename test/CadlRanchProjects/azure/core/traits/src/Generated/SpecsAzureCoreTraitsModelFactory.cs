// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure;

namespace _Specs_.Azure.Core.Traits.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class SpecsAzureCoreTraitsModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Models.User"/>. </summary>
        /// <param name="id"> The user's id. </param>
        /// <param name="name"> The user's name. </param>
        /// <returns> A new <see cref="Models.User"/> instance for mocking. </returns>
        public static User User(int id = default, string name = null)
        {
            return new User(id, name, serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.UserActionResponse"/>. </summary>
        /// <param name="userActionResult"> User action result. </param>
        /// <returns> A new <see cref="Models.UserActionResponse"/> instance for mocking. </returns>
        public static UserActionResponse UserActionResponse(string userActionResult = null)
        {
            return new UserActionResponse(userActionResult, serializedAdditionalRawData: null);
        }
    }
}
