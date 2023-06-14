// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace xms_error_responses.Models
{
    /// <summary>
    /// The PetSadError.
    /// Please note <see cref="PetSadError"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
    /// The available derived classes include <see cref="PetHungryOrThirstyError"/>.
    /// </summary>
    public partial class PetSadError : PetActionError
    {
        /// <summary> Initializes a new instance of PetSadError. </summary>
        internal PetSadError()
        {
            ErrorType = "PetSadError";
        }

        /// <summary> Initializes a new instance of PetSadError. </summary>
        /// <param name="actionResponse"> action feedback. </param>
        /// <param name="errorType"></param>
        /// <param name="errorMessage"> the error message. </param>
        /// <param name="reason"> why is the pet sad. </param>
        internal PetSadError(string actionResponse, string errorType, string errorMessage, string reason) : base(actionResponse, errorType, errorMessage)
        {
            Reason = reason;
            ErrorType = errorType ?? "PetSadError";
        }

        /// <summary> why is the pet sad. </summary>
        public string Reason { get; }
    }
}
