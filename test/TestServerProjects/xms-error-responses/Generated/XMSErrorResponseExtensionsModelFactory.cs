// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace xms_error_responses.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class XMSErrorResponseExtensionsModelFactory
    {
        /// <summary> Initializes a new instance of Pet. </summary>
        /// <param name="aniType"></param>
        /// <param name="name"> Gets the Pet by id. </param>
        /// <returns> A new <see cref="Models.Pet"/> instance for mocking. </returns>
        public static Pet Pet(string aniType = null, string name = null)
        {
            return new Pet(aniType, name);
        }

        /// <summary> Initializes a new instance of Animal. </summary>
        /// <param name="aniType"></param>
        /// <returns> A new <see cref="Models.Animal"/> instance for mocking. </returns>
        public static Animal Animal(string aniType = null)
        {
            return new Animal(aniType);
        }

        /// <summary> Initializes a new instance of PetAction. </summary>
        /// <param name="actionResponse"> action feedback. </param>
        /// <returns> A new <see cref="Models.PetAction"/> instance for mocking. </returns>
        public static PetAction PetAction(string actionResponse = null)
        {
            return new PetAction(actionResponse);
        }

        /// <summary> Initializes a new instance of PetActionError. </summary>
        /// <param name="actionResponse"> action feedback. </param>
        /// <param name="errorType"></param>
        /// <param name="errorMessage"> the error message. </param>
        /// <returns> A new <see cref="Models.PetActionError"/> instance for mocking. </returns>
        public static PetActionError PetActionError(string actionResponse = null, string errorType = null, string errorMessage = null)
        {
            return new PetActionError(actionResponse, errorType, errorMessage);
        }

        /// <summary> Initializes a new instance of PetSadError. </summary>
        /// <param name="actionResponse"> action feedback. </param>
        /// <param name="errorMessage"> the error message. </param>
        /// <param name="reason"> why is the pet sad. </param>
        /// <returns> A new <see cref="Models.PetSadError"/> instance for mocking. </returns>
        public static PetSadError PetSadError(string actionResponse = null, string errorMessage = null, string reason = null)
        {
            return new PetSadError(actionResponse, "PetSadError", errorMessage, reason);
        }

        /// <summary> Initializes a new instance of PetHungryOrThirstyError. </summary>
        /// <param name="actionResponse"> action feedback. </param>
        /// <param name="errorMessage"> the error message. </param>
        /// <param name="reason"> why is the pet sad. </param>
        /// <param name="hungryOrThirsty"> is the pet hungry or thirsty or both. </param>
        /// <returns> A new <see cref="Models.PetHungryOrThirstyError"/> instance for mocking. </returns>
        public static PetHungryOrThirstyError PetHungryOrThirstyError(string actionResponse = null, string errorMessage = null, string reason = null, string hungryOrThirsty = null)
        {
            return new PetHungryOrThirstyError(actionResponse, "PetHungryOrThirstyError", errorMessage, reason, hungryOrThirsty);
        }
    }
}
