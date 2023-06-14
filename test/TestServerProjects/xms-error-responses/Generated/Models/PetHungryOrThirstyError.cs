// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace xms_error_responses.Models
{
    /// <summary> The PetHungryOrThirstyError. </summary>
    public partial class PetHungryOrThirstyError : PetSadError
    {
        /// <summary> Initializes a new instance of PetHungryOrThirstyError. </summary>
        internal PetHungryOrThirstyError()
        {
            ErrorType = "PetHungryOrThirstyError";
        }

        /// <summary> Initializes a new instance of PetHungryOrThirstyError. </summary>
        /// <param name="actionResponse"> action feedback. </param>
        /// <param name="errorType"></param>
        /// <param name="errorMessage"> the error message. </param>
        /// <param name="reason"> why is the pet sad. </param>
        /// <param name="hungryOrThirsty"> is the pet hungry or thirsty or both. </param>
        internal PetHungryOrThirstyError(string actionResponse, string errorType, string errorMessage, string reason, string hungryOrThirsty) : base(actionResponse, errorType, errorMessage, reason)
        {
            HungryOrThirsty = hungryOrThirsty;
            ErrorType = errorType ?? "PetHungryOrThirstyError";
        }

        /// <summary> is the pet hungry or thirsty or both. </summary>
        public string HungryOrThirsty { get; }
    }
}
