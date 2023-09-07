// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace xms_error_responses.Models
{
    /// <summary>
    /// The PetSadError.
    /// Please note <see cref="PetSadError"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
    /// The available derived classes include <see cref="PetHungryOrThirstyError"/>.
    /// </summary>
    public partial class PetSadError : PetActionError
    {
        /// <summary> Initializes a new instance of <see cref="PetSadError"/>. </summary>
        internal PetSadError()
        {
            ErrorType = "PetSadError";
        }

        /// <summary> Initializes a new instance of <see cref="PetSadError"/>. </summary>
        /// <param name="actionResponse"> action feedback. </param>
        /// <param name="errorType"></param>
        /// <param name="errorMessage"> the error message. </param>
        /// <param name="reason"> why is the pet sad. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal PetSadError(string actionResponse, string errorType, string errorMessage, string reason, Dictionary<string, BinaryData> serializedAdditionalRawData) : base(actionResponse, errorType, errorMessage, serializedAdditionalRawData)
        {
            Reason = reason;
            ErrorType = errorType ?? "PetSadError";
        }

        /// <summary> why is the pet sad. </summary>
        public string Reason { get; }
    }
}
