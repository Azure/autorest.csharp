// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace xms_error_responses.Models
{
    /// <summary> The UnknownPetActionError. </summary>
    internal partial class UnknownPetActionError : PetActionError
    {
        /// <summary> Initializes a new instance of <see cref="UnknownPetActionError"/>. </summary>
        /// <param name="actionResponse"> action feedback. </param>
        /// <param name="errorType"></param>
        /// <param name="errorMessage"> the error message. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal UnknownPetActionError(string actionResponse, string errorType, string errorMessage, Dictionary<string, BinaryData> serializedAdditionalRawData) : base(actionResponse, errorType, errorMessage, serializedAdditionalRawData)
        {
            ErrorType = errorType ?? "Unknown";
        }

        /// <summary> Initializes a new instance of <see cref="UnknownPetActionError"/> for deserialization. </summary>
        internal UnknownPetActionError()
        {
        }
    }
}
